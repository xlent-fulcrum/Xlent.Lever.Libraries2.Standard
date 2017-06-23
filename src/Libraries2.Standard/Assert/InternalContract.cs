using System;
using System.Linq.Expressions;
using Xlent.Lever.Libraries2.Standard.Error;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Assert
{
    /// <summary>
    /// A class for verifying method contracts. Will throw <see cref="FulcrumContractException"/> if the contract is broken.
    /// </summary>
    public static class InternalContract
    {
        private static readonly string Namespace = typeof(InternalContract).Namespace;
        /// <summary>
        /// Verify that <paramref name="expression"/> return true, when applied to <paramref name="parameterValue"/>.
        /// </summary>
        public static void Require<TParameter>(TParameter parameterValue,
            Expression<Func<TParameter, bool>> expression, string parameterName)
        {
            GenericContract<FulcrumContractException>.Require(parameterValue, expression, parameterName);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null.
        /// </summary>
        public static void RequireNotNull<TParameter>(TParameter parameterValue, string parameterName, string customMessage = null)
        {
            GenericContract<FulcrumContractException>.RequireNotNull(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not the default value for this type.
        /// </summary>
        public static void RequireNotDefaultValue<TParameter>(TParameter parameterValue, string parameterName, string customMessage = null)
        {
            GenericContract<FulcrumContractException>.RequireNotDefaultValue(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null, not empty and contains other characters than white space.
        /// </summary>
        public static void RequireNotNullOrWhitespace(string parameterValue, string parameterName, string customMessage = null)
        {
            GenericContract<FulcrumContractException>.RequireNotNullOrWhitespace(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// If <paramref name="parameterValue"/> is not null, then call the FulcrumValidate() method of that type.
        /// </summary>
        public static void RequireValidatedOrNull(IValidatable parameterValue, string parameterName, string customMessage = null)
        {
            if (parameterValue == null) return;
            try
            {
                parameterValue.Validate($"{Namespace}: FA88DA6F-8EA4-414F-86EE-34F4B7A14E40");
            }
            catch (FulcrumAssertionFailedException e)
            {
                throw new FulcrumContractException($"Validation failed for {parameterName}: {e.Message}", e);
            }
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null and also call the FulcrumValidate() method of that type.
        /// </summary>
        public static void RequireValidatedAndNotNull(IValidatable parameterValue, string parameterName, string customMessage = null)
        {
            RequireNotNull(parameterValue, parameterName);
            RequireValidatedOrNull(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="expression"/> returns a true value.
        /// </summary>
        public static void Require(Expression<Func<bool>> expression, string customMessage = null)
        {
            GenericContract<FulcrumContractException>.Require(expression, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="mustBeTrue"/> really is true.
        /// </summary>
        public static void Require(bool mustBeTrue, string customMessage = null)
        {
            GenericContract<FulcrumContractException>.Require(mustBeTrue, customMessage);
        }

        /// <summary>
        /// Always fail, with the given <paramref name="message"/>.
        /// </summary>
        public static void Fail(string message)
        {
            RequireNotNull(message, nameof(message));
            GenericContract<FulcrumContractException>.Fail(message);
        }
    }
}
