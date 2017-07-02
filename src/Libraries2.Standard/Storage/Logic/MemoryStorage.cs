﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xlent.Lever.Libraries2.Standard.Assert;
using Xlent.Lever.Libraries2.Standard.Error.Logic;
using Xlent.Lever.Libraries2.Standard.Misc.Models;
using Xlent.Lever.Libraries2.Standard.Storage.Model;

namespace Xlent.Lever.Libraries2.Standard.Storage.Logic
{
    /// <summary>
    /// General class for storing any <see cref="IStorableItem{Guid}"/> in memory.
    /// </summary>
    /// <typeparam name="TStorableItem"></typeparam>
    public class MemoryStorage<TStorableItem> : ICrudAll<IStorableItem<Guid>, Guid>
        where TStorableItem : class, IStorableItem<Guid>, IOptimisticConcurrencyControlByETag, IDeepCopy<TStorableItem>
    {
        private static readonly string Namespace = typeof(MemoryStorage<TStorableItem>).Namespace;
        private readonly Dictionary<Guid, IStorableItem<Guid>> _memoryItems = new Dictionary<Guid, IStorableItem<Guid>>();

        /// <inheritdoc />
        public Task<IStorableItem<Guid>> CreateAsync(IStorableItem<Guid> item)
        {
            InternalContract.RequireNotNull(item, nameof(item));
            InternalContract.RequireValidated(item, nameof(item));

            return CreateAsync(Guid.NewGuid(), item);
        }

        /// <inheritdoc />
        public Task<IStorableItem<Guid>> CreateAsync(Guid id, IStorableItem<Guid> item)
        {
            InternalContract.RequireNotDefaultValue(id, nameof(id));
            InternalContract.RequireNotNull(item, nameof(item));
            InternalContract.RequireValidated(item, nameof(item));

            var itemCopy = CopyItem(item);
            itemCopy.ETag = Guid.NewGuid().ToString();
            itemCopy.Id = id;
            lock (_memoryItems)
            {
                ValidateNotExists(itemCopy.Id);
                _memoryItems.Add(itemCopy.Id, itemCopy);
                return Task.FromResult(GetMemoryItem(itemCopy.Id));
            }
        }

        /// <inheritdoc />
        public Task<IStorableItem<Guid>> ReadAsync(Guid id)
        {
            InternalContract.RequireNotDefaultValue(id, nameof(id));

            lock (_memoryItems)
            {
                var itemCopy = GetMemoryItem(id);
                return Task.FromResult(itemCopy);
            }
        }

        /// <inheritdoc />
        public Task<IStorableItem<Guid>> UpdateAsync(IStorableItem<Guid> item)
        {
            InternalContract.RequireNotNull(item, nameof(item));
            InternalContract.RequireValidated(item, nameof(item));
            InternalContract.RequireNotDefaultValue(item.Id, nameof(item.Id));

            var itemCopy = CopyItem(item);
            lock (_memoryItems)
            {
                ValidateExists(itemCopy.Id);
                var current = GetMemoryItem(itemCopy.Id);
                ValidateEtag(current, itemCopy);
                itemCopy.ETag = Guid.NewGuid().ToString();
                SetMemoryItem(itemCopy);
                return Task.FromResult(GetMemoryItem(itemCopy.Id));
            }
        }

        /// <inheritdoc />
        /// <remarks>
        /// Idempotent, i.e. will not throw an exception if the item does not exist.
        /// </remarks>
        public Task DeleteAsync(Guid id)
        {
            InternalContract.RequireNotDefaultValue(id, nameof(id));
            lock (_memoryItems)
            {
                if (!_memoryItems.ContainsKey(id)) return Task.FromResult(0);
                _memoryItems.Remove(id);
            }
            return Task.FromResult(0);
        }

        /// <inheritdoc />
        public Task<IPageEnvelope<IStorableItem<Guid>, Guid>> ReadAllAsync(int offset = 0, int limit = 100)
        {
            InternalContract.RequireGreaterThanOrEqualTo(0, offset, nameof(offset));
            InternalContract.RequireGreaterThan(0, limit, nameof(limit));
            lock (_memoryItems)
            {
                var keys = _memoryItems.Keys.Skip(offset).Take(limit);
                var list = keys.Select(GetMemoryItem).ToList();
                IPageEnvelope<IStorableItem<Guid>, Guid> page = new PageEnvelope<IStorableItem<Guid>, Guid>
                {
                    PageInfo = new PageInfo
                    {
                        Offset = offset,
                        Limit = limit,
                        Returned = list.Count,
                        Total = _memoryItems.Count
                    },
                    Data = list
                };
                return Task.FromResult(page);
            }
        }

        /// <inheritdoc />
        public Task DeleteAllAsync()
        {
            lock (_memoryItems)
            {
                _memoryItems.Clear();
            }
            return Task.FromResult(0);
        }

        #region private

        private void ValidateNotExists(Guid id)
        {
            if (!_memoryItems.ContainsKey(id)) return;
            throw new FulcrumConflictException(
                $"An item of type {typeof(TStorableItem).Name} with id {id} already exists.");
        }

        private void ValidateExists(Guid id)
        {
            if (_memoryItems.ContainsKey(id)) return;
            throw new FulcrumNotFoundException(
                $"Could not find an item of type {typeof(TStorableItem).Name} with id {id}.");
        }

        private void ValidateEtag(IStorableItem<Guid> current, IStorableItem<Guid> item)
        {
            var currentWithEtag = current as IOptimisticConcurrencyControlByETag;
            var itemWithEtag = item as IOptimisticConcurrencyControlByETag;
            if (currentWithEtag == null || itemWithEtag == null) return;

            if (string.Equals(currentWithEtag.ETag, itemWithEtag.ETag, StringComparison.OrdinalIgnoreCase)) return;
            throw new FulcrumConflictException(
                $"The item of type {typeof(TStorableItem).Name} with id {item.Id} has been updated by someone else. Please get a fresh copy and try again.");
        }

        private static TStorableItem CopyItem(IStorableItem<Guid> item)
        {
            var storableItem = item as TStorableItem;
            FulcrumAssert.IsNotNull(storableItem, $"{Namespace}: 8EA4FC22-63CF-40AA-A53F-40444A23E14D");
            var itemCopy = storableItem?.DeepCopy();
            if (itemCopy == null)
                throw new FulcrumAssertionFailedException("Could not copy an item.",
                    $"{Namespace}: F517B23A-CB23-4B69-A3AE-7F52CD804352");
            return itemCopy;
        }

        private void SetMemoryItem(TStorableItem item)
        {
            _memoryItems[item.Id] = CopyItem(item);
        }

        private IStorableItem<Guid> GetMemoryItem(Guid id)
        {
            ValidateExists(id);
            InternalContract.RequireNotDefaultValue(id, nameof(id));
            var item = _memoryItems[id];
            FulcrumAssert.IsNotNull(item, $"{Namespace}: B431A6BB-4A76-4672-9607-65E1C6EBFBC9");
            return CopyItem(item);
        }
        #endregion
    }
}
