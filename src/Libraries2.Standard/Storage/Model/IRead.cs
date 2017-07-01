using System.Threading.Tasks;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Storage.Model
{
    /// <summary>
    /// ReadAsync an item of type <see cref="IStorableItem{TId}"/>.
    /// </summary>
    /// <typeparam name="TStorable">The type of objects to read from persistant storage.</typeparam>
    /// <typeparam name="TId">The type for the <see cref="IStorableItem{TId}.Id"/> property.</typeparam>
    public interface IRead<TStorable, TId>
        where TStorable : IStorableItem<TId>
    {
        /// <summary>
        /// Returns the item uniquely identified by <paramref name="id"/> from storage.
        /// </summary>
        /// <returns>The found item.</returns>
        /// <exception cref="FulcrumNotFoundException">Thrown if the <paramref name="id"/> could not be found.</exception>
        Task<TStorable> ReadAsync(TId id);

        /// <summary>
        /// Reads all the items from storage.
        /// </summary>
        /// <returns>A list of the found objects. Can be empty, but never null.</returns>
        /// <remarks>
        /// The implementor of this method can decide that it is not a valid method to expose.
        /// In that case, the method should throw a <see cref="FulcrumNotImplementedException"/>.
        /// </remarks>
        Task<IPageEnvelope<TStorable, TId>> ReadAllAsync(int offset = 0, int limit = PageInfo.DefaultLimit);
    }
}
