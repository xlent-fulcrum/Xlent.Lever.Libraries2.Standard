using Xlent.Lever.Libraries2.Standard.Storage.Model;

namespace Xlent.Lever.Libraries2.Standard.Storage.Test
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IStorableItemForTesting<TId> : IStorableItem<TId>
    {
        /// <summary>
        /// Fills all mandatory fields  with valid data.
        /// </summary>
        /// <param name="typeOfTestData">Decides what kind of data to fill with, <see cref="TypeOfTestDataEnum"/>.</param>
        /// <returns>The item itself ("this").</returns>
        IStorableItem<TId> InitializeWithDataForTesting(TypeOfTestDataEnum typeOfTestData);

        /// <summary>
        /// Changes the information in a way that would make the item not equal to the state before the changes. 
        /// </summary>
        /// <returns>The item itself ("this").</returns>
        IStorableItem<TId> ChangeDataToNotEqualForTesting();
    }
}
