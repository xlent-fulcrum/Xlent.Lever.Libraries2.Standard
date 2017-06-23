﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Xlent.Lever.Libraries2.Standard.Assert
{
    /// <summary>
    /// A generic class for verifying method contracts. Generic in the meaning that a parameter says what exception that should be thrown when a requirement doesn't hold.
    /// </summary>
    internal static class GenericContract<TException>
        where TException : Exception
    {
        /// <summary>
        /// Verify that <paramref name="expression"/> return true, when applied to <paramref name="parameterValue"/>.
        /// </summary>
        public static void Require<TParameter>(TParameter parameterValue,
            Expression<Func<TParameter, bool>> expression, string parameterName)
        {
            var message = GetErrorMessageIfFalse(parameterValue, expression, parameterName);
            MaybeThrowException(message);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null.
        /// </summary>
        public static void RequireNotNull<TParameter>(TParameter parameterValue, string parameterName, string customMessage = null)
        {
            var message = GetErrorMessageIfNull(parameterValue, parameterName, customMessage);
            MaybeThrowException(message);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not the default value for this type.
        /// </summary>
        public static void RequireNotDefaultValue<TParameter>(TParameter parameterValue, string parameterName, string customMessage = null)
        {
            var message = GetErrorMessageIfDefaultValue(parameterValue, parameterName, customMessage);
            MaybeThrowException(message);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null, not empty and contains other characters than white space.
        /// </summary>
        public static void RequireNotNullOrWhitespace(string parameterValue, string parameterName, string customMessage = null)
        {
            var message = GetErrorMessageIfNullOrWhitespace(parameterValue, parameterName, customMessage);
            MaybeThrowException(message);
        }

        /// <summary>
        /// Verify that <paramref name="expression"/> returns a true value.
        /// </summary>
        public static void Require(Expression<Func<bool>> expression, string customMessage = null)
        {
            var message = GetErrorMessageIfFalse(expression, customMessage);
            MaybeThrowException(message);
        }

        /// <summary>
        /// Verify that <paramref name="mustBeTrue"/> really is true.
        /// </summary>
        public static void Require(bool mustBeTrue, string message)
        {
            InternalContract.RequireNotNullOrWhitespace(message, nameof(message));
            var m = GetErrorMessageIfFalse(mustBeTrue, message);
            MaybeThrowException(m);
        }

        /// <summary>
        /// Always fail, with the given <paramref name="message"/>.
        /// </summary>
        public static void Fail(string message)
        {
            InternalContract.RequireNotNullOrWhitespace(message, nameof(message));
            ThrowException(message);
        }

        private static string GetErrorMessageIfFalse<T>(T parameterValue, Expression<Func<T, bool>> requirementExpression, string parameterName)
        {
            if (requirementExpression.Compile()(parameterValue)) return null;

            var condition = requirementExpression.Body.ToString();
            condition = condition.Replace(requirementExpression.Parameters.First().Name, parameterName);
            return $"Contract violation: {parameterName} ({parameterValue}) is required to fulfil {condition}.";
        }

        private static string GetErrorMessageIfNull<T>(T parameterValue, string parameterName, string customMessage)
        {
            return parameterValue != null ? null : customMessage ?? $"Contract violation: {parameterName} must not be null.";
        }

        private static string GetErrorMessageIfDefaultValue<T>(T parameterValue, string parameterName, string customMessage)
        {
            if (!Equals(parameterValue, default(T))) return null;
            return customMessage ?? $"Contract violation: {parameterName} must not be null.";
        }

        private static string GetErrorMessageIfNullOrWhitespace(string parameterValue, string parameterName, string customMessage)
        {
            if (!string.IsNullOrWhiteSpace(parameterValue)) return null;
            var value = parameterValue == null ? "null" : $"\"{parameterValue}\"";
            return customMessage ?? $"Contract violation: {parameterName} ({value}) must not be null, empty or whitespace.";
        }

        private static string GetErrorMessageIfFalse(Expression<Func<bool>> requirementExpression, string customMessage)
        {
            if (requirementExpression.Compile()()) return null;

            var condition = requirementExpression.Body.ToString();
            return customMessage ?? $"Contract violation: The call must fulfil {condition}.";
        }

        private static string GetErrorMessageIfFalse(bool mustBeTrue, string message)
        {
            InternalContract.RequireNotNullOrWhitespace(message, nameof(message));
            return mustBeTrue ? null : message;
        }

        private static void MaybeThrowException(string message)
        {
            if (message == null) return;
            ThrowException(message);
        }

        private static void ThrowException(string message)
        {
            var exception = (TException)Activator.CreateInstance(typeof(TException), message);
            throw exception;
        }
    }
}
