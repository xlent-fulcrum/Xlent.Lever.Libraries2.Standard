using Xlent.Lever.Libraries2.Standard.Error;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Assert
{
    /// <summary>
    /// A class for asserting things that the programmer thinks is true. Works both as documentation and as verification that the programmers assumptions holds.
    /// </summary>
    public static class FulcrumValidate
    {
        /// <summary>
        /// Will always fail. Used in parts of the code where we should never end up. E.g. a default case in a switch statement where all cases should be covered, so we should never end up in the default case.
        /// </summary>
        /// <param name="message">A message that documents/explains this failure. This message should normally start with "Expected ...".</param>
        public static void Fail(string message)
        {
            GenericAssert<FulcrumAssertionFailedException>.Fail(message);
        }

        /// <summary>
        /// Verify that <paramref name="mustBeTrue"/> is true.
        /// </summary>
        /// <param name="mustBeTrue">The value that must be true.</param>
        /// <param name="message">A message that documents/explains this failure. This message should normally start with "Expected ...".</param>
        public static void IsTrue(bool mustBeTrue, string message)
        {
            InternalContract.RequireNotNullOrWhitespace(message, nameof(message));
            GenericAssert<FulcrumAssertionFailedException>.IsTrue(mustBeTrue, message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null.
        /// </summary>
        public static void IsNotNull(object value, string propertyName, string customMessage = null)
        {
            var message = customMessage ?? $"Property {propertyName} ({value}) must not be null.";
            GenericAssert<FulcrumAssertionFailedException>.IsNotNull(value, message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not the default mustBeTrue for that type.
        /// </summary>
        public static void IsNotDefaultValue<T>(T value, string propertyName, string customMessage = null)
        {
            var message = customMessage ?? $"Property {propertyName} ({value}) must not have the default value ({default(T)}.";
            GenericAssert<FulcrumAssertionFailedException>.IsNotDefaultValue(value, message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null, not empty and contains other characters than white space.
        /// </summary>
        public static void IsNotNullOrWhiteSpace(string value, string propertyName, string customMessage = null)
        {
            var message = customMessage ?? $"Property {propertyName} ({value}) must not be null or empty and it must contain other characters than white space.";
            GenericAssert<FulcrumAssertionFailedException>.IsNotNullOrWhiteSpace(value, message);
        }

        /// <summary>
        /// Verify that <paramref name="propertyValue"/> is equal to <paramref name="expectedValue"/>.
        /// </summary>
        public static void AreEqual(object expectedValue, object propertyValue, string propertyName, string customMessage = null)
        {
            var message = customMessage ?? $"Expected property {propertyName} ({propertyValue}) to be equal to ({expectedValue}).";
            GenericAssert<FulcrumAssertionFailedException>.AreEqual(expectedValue, propertyValue, message);
        }
    }
}
