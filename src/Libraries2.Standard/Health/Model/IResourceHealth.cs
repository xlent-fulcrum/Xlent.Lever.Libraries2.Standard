using System.Threading.Tasks;
using Xlent.Lever.Libraries2.Standard.MultiTenant.Model;

namespace Xlent.Lever.Libraries2.Standard.Health.Model
{
    /// <summary>
    /// Interface to be implemented by every controller for a service that should report their health.
    /// </summary>
    public interface IResourceHealth
    {
        /// <summary>
        /// Get the health status for a specific <paramref name="tenant"/>.
        /// </summary>
        Task<HealthResponse> GetResourceHealthAsync(ITenant tenant);
    }
}
