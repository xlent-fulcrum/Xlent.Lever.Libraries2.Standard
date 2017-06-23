using System;
using System.Linq.Expressions;
using Xlent.Lever.Libraries2.Standard.Error;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Assert
{
    /// <summary>
    /// A class for asserting things that the programmer thinks is true. Works both as documentation and as verification that the programmers assumptions holds.
    /// </summary>
    public static class FulcrumAssert
    {
        /// <summary>
        /// Will always fail. Used in parts of the code where we should never end up. E.g. a default case in a switch statement where all cases should be covered, so we should never end up in the default case.
        /// </summary>
        /// <param name="message">A message that documents/explains this failure. This message should normally start with "Expected ...".</param>
        public static void Fail(string message)
        {
            InternalContract.RequireNotNullOrWhitespace(message, nameof(message));
            GenericAssert<FulcrumAssertionFailedException>.Fail(message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is true.
        /// </summary>
        public static void IsTrue(bool value, string customMessage = null)
        {
            GenericAssert<FulcrumAssertionFailedException>.IsTrue(value, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is null.
        /// </summary>
        public static void IsNull(object value, string customMessage = null)
        {
            GenericAssert<FulcrumAssertionFailedException>.IsNull(value, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null.
        /// </summary>
        public static void IsNotNull(object value, string customMessage = null)
        {
            GenericAssert<FulcrumAssertionFailedException>.IsNotNull(value, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not the default value for that type.
        /// </summary>
        public static void IsNotDefaultValue<T>(T value, string customMessage = null)
        {
            GenericAssert<FulcrumAssertionFailedException>.IsNotDefaultValue(value, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null, not empty and contains other characters than white space.
        /// </summary>
        public static void IsNotNullOrWhiteSpace(string value, string customMessage = null)
        {
            GenericAssert<FulcrumAssertionFailedException>.IsNotNullOrWhiteSpace(value, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="actualValue"/> is equal to <paramref name="expectedValue"/>.
        /// </summary>
        public static void AreEqual(object expectedValue, object actualValue, string customMessage = null)
        {
            GenericAssert<FulcrumAssertionFailedException>.AreEqual(expectedValue, actualValue, customMessage);
        }
    }
}
