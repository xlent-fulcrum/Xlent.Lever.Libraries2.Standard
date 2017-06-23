using Xlent.Lever.Libraries2.Standard.Error;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Assert
{
    /// <summary>
    /// Interface for classes that are validatable, i.e has a method for validating the properties of the class.
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// FulcrumValidate that the properties are OK. The validation should be made with methods from the <see cref="Validate"/> class.
        /// </summary>
        /// <exception cref="FulcrumAssertionFailedException">A validation failed.</exception>
        void Validate();
    }
}
