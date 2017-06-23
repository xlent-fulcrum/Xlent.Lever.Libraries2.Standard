using Xlent.Lever.Libraries2.Standard.Assert;

namespace Xlent.Lever.Libraries2.Standard.MultiTenant.Model
{
    /// <summary>
    /// Information about a tenant in the Fulcrum multi tenant runtime.
    /// </summary>
    public class Tenant : ITenant
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Tenant(string organization, string environment)
        {
            InternalContract.RequireNotNullOrWhitespace(organization, nameof(organization));
            InternalContract.RequireNotNullOrWhitespace(environment, nameof(environment));
            Organization = organization?.ToLower();
            Environment = environment?.ToLower();
            Validate();
        }

        /// <summary>
        /// A unique lowercase abbreviation or acronym for the organization, e.g. "sef" for Svensk Elitfotboll
        /// </summary>
        public string Organization { get; }
        /// <summary>
        /// A lowercase name of the organization environment, e.g. "local", "dev", "tst", "ver", "int", "prd", "production", etc.
        /// </summary>
        public string Environment { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Organization} ({Environment})";
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var tenant = obj as Tenant;
            return tenant != null && ToString().Equals(tenant.ToString());
        }

        /// <inheritdoc />
        public void Validate()
        {
            FulcrumValidate.IsNotNullOrWhiteSpace(Organization, nameof(Organization));
            FulcrumValidate.IsNotNullOrWhiteSpace(Environment, nameof(Environment));
        }
    }
}
