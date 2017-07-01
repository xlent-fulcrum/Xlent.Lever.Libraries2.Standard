using System;

namespace Xlent.Lever.Libraries2.Standard.Storage.Model
{

    /// <summary>
    /// The recommended interfaces for a storable item. Uses a <see cref="Guid"/> as the <see cref="IStorableItem{TId}.Id"/>.
    /// </summary>
    public interface IStorableItemRecommended : IStorableItemRecommended<Guid>
    {
    }

    /// <summary>
    /// The recommended interfaces for a storable item.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IStorableItemRecommended<TId> : IStorableItem<TId>, INameProperty, IOptimisticConcurrencyControlByETag
    {
    }
}
