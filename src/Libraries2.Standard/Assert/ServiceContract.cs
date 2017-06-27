﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Assert
{
    /// <summary>
    /// A class for verifying service contracts. Will throw <see cref="FulcrumServiceContractException"/> if the contract is broken.
    /// </summary>
    public static class ServiceContract
    {
        private static readonly string Namespace = typeof(ServiceContract).Namespace;
        /// <summary>
        /// Verify that <paramref name="expression"/> return true, when applied to <paramref name="parameterValue"/>.
        /// </summary>
        public static void Require<TParameter>(TParameter parameterValue,
            Expression<Func<TParameter, bool>> expression, string parameterName)
        {
            GenericContract<FulcrumServiceContractException>.Require(parameterValue, expression, parameterName);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null.
        /// </summary>
        public static void RequireNotNull(object parameterValue, string parameterName, string customMessage = null)
        {
            GenericContract<FulcrumServiceContractException>.RequireNotNull(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not the default value for this type.
        /// </summary>
        public static void RequireNotDefaultValue<TParameter>(TParameter parameterValue, string parameterName, string customMessage = null)
        {
            GenericContract<FulcrumServiceContractException>.RequireNotDefaultValue(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null, not empty and contains other characters than white space.
        /// </summary>
        public static void RequireNotNullOrWhitespace(string parameterValue, string parameterName, string customMessage = null)
        {
            GenericContract<FulcrumServiceContractException>.RequireNotNullOrWhitespace(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// If <paramref name="parameterValue"/> is not null, then call the FulcrumValidate() method of that type.
        /// </summary>
        [Obsolete("Use the RequireValidated() method.")]
        public static void RequireValidatedOrNull(IValidatable parameterValue, string parameterName, string customMessage = null)
        {
            if (parameterValue == null) return;
            try
            {
                parameterValue.Validate($"{Namespace}: E1774ECE-78BC-40B4-B9FD-2293BBF4D944");
            }
            catch (FulcrumServiceContractException e)
            {
                throw new FulcrumServiceContractException($"Validation failed for {parameterName}: {e.Message}", e);
            }
        }

        /// <summary>
        /// If <paramref name="parameterValues"/> is not null, then call the FulcrumValidate() method of that type.
        /// </summary>
        [Obsolete("Use the RequireValidated() method.")]
        public static void RequireValidatedOrNull(IEnumerable<IValidatable> parameterValues, string parameterName, string customMessage = null)
        {
            if (parameterValues == null) return;
            foreach (var parameterValue in parameterValues)
            {
                RequireValidatedOrNull(parameterValue, parameterName, customMessage);
            }
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is not null and also call the FulcrumValidate() method of that type.
        /// </summary>
        [Obsolete("Use the RequireValidated() method.")]
        public static void RequireValidatedAndNotNull(IValidatable parameterValue, string parameterName, string customMessage = null)
        {
            RequireNotNull(parameterValue, parameterName);
            RequireValidatedOrNull(parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValues"/> is not null and also call the FulcrumValidate() method of that type.
        /// </summary>
        [Obsolete("Use the RequireValidated() method.")]
        public static void RequireValidatedAndNotNull(IEnumerable<IValidatable> parameterValues, string parameterName, string customMessage = null)
        {
            RequireNotNull(parameterValues, parameterName);
            foreach (var parameterValue in parameterValues)
            {
                RequireValidatedOrNull(parameterValue, parameterName, customMessage);
            }
        }

        /// <summary>
        /// If <paramref name="parameterValue"/> is not null, then call the Validate() method of that type.
        /// </summary>
        public static void RequireValidated(IValidatable parameterValue, string parameterName, string customMessage = null)
        {
            if (parameterValue == null) return;
            try
            {
                parameterValue.Validate($"{Namespace}: E1774ECE-78BC-40B4-B9FD-2293BBF4D944");
            }
            catch (FulcrumServiceContractException e)
            {
                throw new FulcrumServiceContractException($"Validation failed for {parameterName}: {e.Message}", e);
            }
        }

        /// <summary>
        /// If <paramref name="parameterValues"/> is not null, then call the Validate() method of that type.
        /// </summary>
        public static void RequireValidated(IEnumerable<IValidatable> parameterValues, string parameterName, string customMessage = null)
        {
            if (parameterValues == null) return;
            foreach (var parameterValue in parameterValues)
            {
                RequireValidatedOrNull(parameterValue, parameterName, customMessage);
            }
        }

        /// <summary>
        /// Verify that <paramref name="expression"/> returns a true value.
        /// </summary>
        public static void Require(Expression<Func<bool>> expression, string customMessage = null)
        {
            GenericContract<FulcrumServiceContractException>.Require(expression, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="mustBeTrue"/> really is true.
        /// </summary>
        public static void Require(bool mustBeTrue, string customMessage = null)
        {
            GenericContract<FulcrumServiceContractException>.Require(mustBeTrue, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is less than to <paramref name="greaterValue"/>.
        /// </summary>
        public static void RequireLessThan<T>(T greaterValue, T parameterValue, string parameterName, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(greaterValue, nameof(greaterValue));
            InternalContract.RequireNotNull(parameterValue, nameof(parameterValue));
            InternalContract.RequireNotNull(parameterName, nameof(parameterName));
            GenericContract<FulcrumServiceContractException>.RequireLessThan(greaterValue, parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is less than or equal to <paramref name="greaterOrEqualValue"/>.
        /// </summary>
        public static void RequireLessThanOrEqualTo<T>(T greaterOrEqualValue, T parameterValue, string parameterName, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(greaterOrEqualValue, nameof(greaterOrEqualValue));
            InternalContract.RequireNotNull(parameterValue, nameof(parameterValue));
            InternalContract.RequireNotNull(parameterName, nameof(parameterName));
            GenericContract<FulcrumServiceContractException>.RequireLessThanOrEqualTo(greaterOrEqualValue, parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is greater than <paramref name="lesserValue"/>.
        /// </summary>
        public static void RequireGreaterThan<T>(T lesserValue, T parameterValue, string parameterName, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(lesserValue, nameof(lesserValue));
            InternalContract.RequireNotNull(parameterValue, nameof(parameterValue));
            InternalContract.RequireNotNull(parameterName, nameof(parameterName));
            GenericContract<FulcrumServiceContractException>.RequireGreaterThan(lesserValue, parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Verify that <paramref name="parameterValue"/> is greater than or equal to <paramref name="lesserOrEqualValue"/>.
        /// </summary>
        public static void RequireGreaterThanOrEqualTo<T>(T lesserOrEqualValue, T parameterValue, string parameterName, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(lesserOrEqualValue, nameof(lesserOrEqualValue));
            InternalContract.RequireNotNull(parameterValue, nameof(parameterValue));
            InternalContract.RequireNotNull(parameterName, nameof(parameterName));
            GenericContract<FulcrumServiceContractException>.RequireLessThanOrEqualTo(lesserOrEqualValue, parameterValue, parameterName, customMessage);
        }

        /// <summary>
        /// Always fail, with the given <paramref name="message"/>.
        /// </summary>
        public static void Fail(string message)
        {
            RequireNotNull(message, nameof(message));
            GenericContract<FulcrumServiceContractException>.Fail(message);
        }
    }
}
