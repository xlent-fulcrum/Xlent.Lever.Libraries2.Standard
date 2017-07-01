﻿using System;

namespace Xlent.Lever.Libraries2.Standard.Storage.Model
{
    /// <summary>
    /// A convenience class that implements the recommended interfaces for a storable item, using a Guid as <see cref="IStorableItem{TId}.Id"/>.
    /// </summary>
    public abstract class StorableItem : StorableItem<Guid>
    {
    }

    /// <summary>
    /// A convenience class that implements the recommended interfaces for a storable item.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class StorableItem<TId> : IStorableItemRecommended<TId>
    {
        /// <inheritdoc />
        public TId Id { get; set; }

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public string ETag { get; set; }

        /// <inheritdoc />
        public abstract void Validate(string errorLocation, string propertyPath = "");
    }
}
