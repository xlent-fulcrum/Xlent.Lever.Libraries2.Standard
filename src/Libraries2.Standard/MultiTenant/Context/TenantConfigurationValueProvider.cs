﻿using Xlent.Lever.Libraries2.Standard.Context;
using Xlent.Lever.Libraries2.Standard.MultiTenant.Model;
using Xlent.Lever.Libraries2.Standard.Platform.Configurations;

namespace Xlent.Lever.Libraries2.Standard.MultiTenant.Context
{
    /// <summary>
    /// Stores values in the execution context which is unaffected by asynchronous code that switches threads or context. 
    /// </summary>
    /// <remarks>Updating values in a thread will not affect the value in parent/sibling threads</remarks>
    public class TenantConfigurationValueProvider : CorrelationIdValueProvider, ITenantConfigurationValueProvider
    {
        private const string TenantIdKey = "TenantId";
        private const string LeverConfigurationIdKey = "LeverConfigurationId";

        /// <summary>
        /// An instances based on <see cref="AsyncLocalValueProvider"/>.
        /// </summary>
        public new static ITenantConfigurationValueProvider AsyncLocalInstance { get; } = new TenantConfigurationValueProvider(new AsyncLocalValueProvider());

        /// <summary>
        /// An instances based on <see cref="SingleThreadValueProvider"/>.
        /// </summary>
        public new static ITenantConfigurationValueProvider MemoryCacheInstance { get; } = new TenantConfigurationValueProvider(new SingleThreadValueProvider());

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="valueProvider">The value provider to use for getting and setting.</param>
        public TenantConfigurationValueProvider(IValueProvider valueProvider)
            : base(valueProvider)
        {
        }

        /// <inheritdoc />
        public ITenant Tenant
        {
            get => ValueProvider.GetValue<Tenant>(TenantIdKey);
            set => ValueProvider.SetValue(TenantIdKey, value);
        }

        /// <inheritdoc />
        public ILeverConfiguration LeverConfiguration
        {
            get => ValueProvider.GetValue<ILeverConfiguration>(LeverConfigurationIdKey);
            set => ValueProvider.SetValue(LeverConfigurationIdKey, value);
        }
    }
}
