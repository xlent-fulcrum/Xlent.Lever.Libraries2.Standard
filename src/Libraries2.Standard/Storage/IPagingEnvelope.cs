using System;
using System.Collections.Generic;

namespace Xlent.Lever.Libraries2.Standard.Storage
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPagingEnvelope<TData, TId>
        where TData : IStorable<TId>
    {
        /// <summary>
        /// The data in this segment, this "page"
        /// </summary>
        IEnumerable<TData> Data { get; set; }

        /// <summary>
        /// Information about this segment of the data
        /// </summary>
        PageInfo PageInfo { get; set; }
    }
}
