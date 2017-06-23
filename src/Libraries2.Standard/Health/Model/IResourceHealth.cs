using System.Threading.Tasks;

namespace Xlent.Lever.Libraries2.Standard.Health.Model
{
    /// <summary>
    /// Interface to be implemented by every controller for a service that should report their health.
    /// </summary>
    public interface IResourceHealth
    {
        /// <summary>
        /// Get the health status.
        /// </summary>
        Task<HealthResponse> GetResourceHealthAsync();
    }
}
