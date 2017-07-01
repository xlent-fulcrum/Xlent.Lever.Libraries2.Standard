using Xlent.Lever.Libraries2.Standard.Assert;

namespace Xlent.Lever.Libraries2.Standard.Storage.Model
{
    /// <summary>
    /// Properties required to be a storable class
    /// </summary>
    /// <typeparam name="TId">The type for the property <see cref="Id"/>.</typeparam>
    public interface IStorableItem<TId> : IValidatable
    {
        /// <summary>
        /// A unique identifier for the item.
        /// </summary>
        TId Id { get; set; }
    }
}
