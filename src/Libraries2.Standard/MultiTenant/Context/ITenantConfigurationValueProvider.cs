using Xlent.Lever.Libraries2.Standard.Context;
using Xlent.Lever.Libraries2.Standard.MultiTenant.Model;
using Xlent.Lever.Libraries2.Standard.Platform.Configurations;

namespace Xlent.Lever.Libraries2.Standard.MultiTenant.Context
{
    /// <summary>
    /// Adds Tenant and LeverConfiguration to what <see cref="ICorrelationIdValueProvider"/> provides.
    /// </summary>
    public interface ITenantConfigurationValueProvider : ICorrelationIdValueProvider
    {
        /// <summary>
        /// The current Tenant.
        /// </summary>
        ITenant Tenant { get; set; }

        /// <summary>
        /// The current configuration.
        /// </summary>
        ILeverConfiguration LeverConfiguration { get; set; }
    }
}