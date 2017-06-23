﻿using System.Collections.Generic;
using System.Threading;
using Xlent.Lever.Libraries2.Standard.Assert;

namespace Xlent.Lever.Libraries2.Standard.Context
{
    /// <summary>
    /// Stores values in the execution context which is unaffected by asynchronous code that switches threads or context. 
    /// </summary>
    /// <remarks>Updating values in a thread will not affect the value in parent/sibling threads</remarks>
    public class AsyncLocalValueProvider : IValueProvider
    {
        private static readonly AsyncLocal<Dictionary<string, object>> Holder;

        /// <summary>
        /// Constructor
        /// </summary>
        static AsyncLocalValueProvider()
        {
            Holder = new AsyncLocal<Dictionary<string, object>>();
        }

        /// <inheritdoc />
        public T GetValue<T>(string key)
        {
            InternalContract.RequireNotNullOrWhitespace(key, nameof(key));
            if (Holder?.Value?.ContainsKey(key) != true) return default(T);
            return (T) Holder.Value[key];
        }

        /// <inheritdoc />
        public void SetValue<T>(string name, T data)
        {
            InternalContract.RequireNotNullOrWhitespace(name, nameof(name));
            InternalContract.RequireNotNull(data, nameof(data));
            FulcrumAssert.IsNotNull(Holder);
            if (Holder.Value == null)
            {
                Holder.Value = new Dictionary<string, object>();
            }
            Holder.Value[name] = data;
        }
    }
}
