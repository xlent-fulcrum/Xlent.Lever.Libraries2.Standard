﻿using System.Threading.Tasks;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Storage.Model
{
    /// <summary>
    /// Delete items of type <see cref="IStorableItem{TId}"/>.
    /// </summary>
    /// <typeparam name="TId">The type for the <see cref="IStorableItem{TId}.Id"/> property.</typeparam>
    public interface IDeleteAll<in TId>
    {
        /// <summary>
        /// Delete all the items from storage.
        /// </summary>
        /// <remarks>
        /// The implementor of this method can decide that it is not a valid method to expose.
        /// In that case, the method should throw a <see cref="FulcrumNotImplementedException"/>.
        /// </remarks>
        Task DeleteAllAsync();
    }
}
