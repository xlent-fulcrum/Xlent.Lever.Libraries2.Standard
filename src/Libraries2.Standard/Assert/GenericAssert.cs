using System;
using System.Linq.Expressions;

namespace Xlent.Lever.Libraries2.Standard.Assert
{ 
    /// <summary>
    /// A generic class for asserting things that the programmer thinks is true. Generic in the meaning that a parameter says what exception that should be thrown when an assumption is false.
    /// </summary>
    internal static class GenericAssert<TException>
        where TException : Exception
    {
        /// <summary>
        /// Will always fail. Used in parts of the code where we should never end up. E.g. a default case in a switch statement where all cases should be covered, so we should never end up in the default case.
        /// </summary>
        /// <param name="message">A message that documents/explains this failure. This message should normally start with "Expected ...".</param>
        public static void Fail(string message)
        {
            InternalContract.RequireNotNullOrWhitespace(message, nameof(message));
            ThrowException(message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is true.
        /// </summary>
        public static void IsTrue(bool value, string customMessage = null)
        {
            if (value) return;
            ThrowException(customMessage ?? "Expected value to be true.");
        }

        /// <summary>
        /// Verify that the result of <paramref name="expression"/> is true.
        /// </summary>
        public static void IsTrue(Expression<Func<bool>> expression, string customMessage = null)
        {
            var value = expression.Compile()();
            if (value) return;
            ThrowException(customMessage ?? $"Expected '{expression.Body} to be true.");
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is null.
        /// </summary>
        public static void IsNull(object value, string customMessage = null)
        {
            if (value == null) return;
            ThrowException(customMessage ?? $"Expected value ({value}) to be null.");
        }

        /// <summary>
        /// Verify that the result of <paramref name="expression"/> is null.
        /// </summary>
        public static void IsNull(Expression<Func<object>> expression, string customMessage = null)
        {
            var value = expression.Compile()();
            if (value == null) return;
            ThrowException(customMessage ?? $"Expected '{expression.Body}' ({value}) to be null.");
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null.
        /// </summary>
        public static void IsNotNull(object value, string customMessage = null)
        {
            if (value != null) return;
            ThrowException(customMessage ?? "Did not expect value to be null.");
        }

        /// <summary>
        /// Verify that the result of <paramref name="expression"/> is null.
        /// </summary>
        public static void IsNotNull(Expression<Func<object>> expression, string customMessage = null)
        {
            IsNotNull((object) expression, customMessage);
            var value = expression.Compile()();
            if (value != null) return;
            ThrowException(customMessage ?? $"Did not expect '{expression.Body}' to be null.");
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not the default value for that type.
        /// </summary>
        public static void IsNotDefaultValue<T>(T value, string customMessage = null)
        {
            if (!value.Equals(default(T))) return;
            ThrowException(customMessage ?? $"Did not expect value to be default value ({default(T)}).");
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null, not empty and has other characters than white space.
        /// </summary>
        public static void IsNotNullOrWhiteSpace(string value, string customMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(value)) return;
            ThrowException(customMessage ?? $"Did not expect value ({value}) to be null, empty or only contain whitespace.");
        }

        /// <summary>
        /// Verify that the result of <paramref name="expression"/> is not null, not empty and contains other characters than white space.
        /// </summary>
        public static void IsNotNullOrWhiteSpace(Expression<Func<string>> expression, string customMessage = null)
        {
            var value = expression.Compile()();
            if (!string.IsNullOrWhiteSpace(value)) return;
            ThrowException(customMessage ?? $"Did not expect '{expression.Body}' ({value}) to be null, empty or only contain whitespace.");
        }

        /// <summary>
        /// Verify that <paramref name="actualValue"/> is equal to <paramref name="expectedValue"/>.
        /// </summary>
        public static void AreEqual(object expectedValue, object actualValue, string customMessage = null)
        {
            if (Equals(expectedValue, actualValue)) return;
            ThrowException(customMessage ?? $"Expected ({actualValue}) to be equal to ({expectedValue}).");
        }

        /// <summary>
        /// Verify that the result of <paramref name="expression"/> is equal to <paramref name="expectedValue"/>.
        /// </summary>
        public static void AreEqual(object expectedValue, Expression<Func<string>> expression, string customMessage = null)
        {
            var actualValue = expression.Compile()();
            if (Equals(expectedValue, actualValue)) return;
            ThrowException(customMessage ?? $"Expected '{expression.Body}' ({actualValue}) to be equal to ({expectedValue}).");
        }

        private static void ThrowException(string message)
        {
            var exception = (TException)Activator.CreateInstance(typeof(TException), message);
            throw exception;
        }
    }
}
