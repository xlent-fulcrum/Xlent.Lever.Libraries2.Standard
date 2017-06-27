﻿using System;
using System.Collections.Generic;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Xlent.Lever.Libraries2.Standard.Assert
{
    /// <summary>
    /// A class for asserting things that the programmer thinks is true. Works both as documentation and as verification that the programmers assumptions holds.
    /// </summary>
    public static class FulcrumValidate
    {
        /// <summary>
        /// Will always fail. Used in parts of the errorLocation where we should never end up. E.g. a default case in a switch statement where all cases should be covered, so we should never end up in the default case.
        /// </summary>
        /// <param name="errorLocation">A unique errorLocation for the part of errorLocation where the validation didn't hold.</param>
        /// <param name="message">A message that documents/explains this failure. This message should normally start with "Expected ...".</param>
        public static void Fail(string errorLocation, string message)
        {
            InternalContract.RequireNotNull(message, nameof(message));
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            GenericAssert<FulcrumAssertionFailedException>.Fail(errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="mustBeTrue"/> is true.
        /// </summary>
        /// <param name="mustBeTrue">The value that must be true.</param>
        /// <param name="message">A message that documents/explains this failure. This message should normally start with "Expected ...".</param>
        /// <param name="errorLocation">A unique errorLocation for the part of errorLocation where the validation didn't hold.</param>
        public static void IsTrue(bool mustBeTrue, string errorLocation, string message)
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNullOrWhitespace(message, nameof(message));
            GenericAssert<FulcrumAssertionFailedException>.IsTrue(mustBeTrue, errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null.
        /// </summary>
        public static void IsNotNull(object value, string propertyName, string errorLocation, string customMessage = null)
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Property {propertyName} ({value}) must not be null.";
            GenericAssert<FulcrumAssertionFailedException>.IsNotNull(value, errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not the default mustBeTrue for that type.
        /// </summary>
        public static void IsNotDefaultValue<T>(T value, string propertyName, string errorLocation, string customMessage = null)
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Property {propertyName} ({value}) must not have the default value ({default(T)}.";
            GenericAssert<FulcrumAssertionFailedException>.IsNotDefaultValue(value, errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="value"/> is not null, not empty and contains other characters than white space.
        /// </summary>
        public static void IsNotNullOrWhiteSpace(string value, string propertyName, string errorLocation, string customMessage = null)
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Property {propertyName} ({value}) must not be null or empty and it must contain other characters than white space.";
            GenericAssert<FulcrumAssertionFailedException>.IsNotNullOrWhiteSpace(value, errorLocation, message);
        }

        /// <summary>
        /// Call the Validate() method for <paramref name="value"/>
        /// </summary>
        public static void IsValidated(IValidatable value, string propertyPath, string propertyName, string errorLocation, string customMessage = null)
        {
            value?.Validate(errorLocation, $"{propertyPath}.{propertyName}");
        }

        /// <summary>
        /// Call the Validate() method for each item in <paramref name="values"/>
        /// </summary>
        public static void IsValidated(IEnumerable<IValidatable> values, string propertyPath, string propertyName, string errorLocation, string customMessage = null)
        {
            if (values == null) return;
            foreach (var value in values)
            {
                IsValidated(value, propertyPath, propertyName, errorLocation, customMessage);
            }
        }

        /// <summary>
        /// Verify that <paramref name="propertyValue"/> is equal to <paramref name="expectedValue"/>.
        /// </summary>
        public static void AreEqual(object expectedValue, object propertyValue, string propertyName, string errorLocation, string customMessage = null)
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Expected property {propertyName} ({propertyValue}) to be equal to ({expectedValue}).";
            GenericAssert<FulcrumAssertionFailedException>.AreEqual(expectedValue, propertyValue, errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="propertyValue"/> is less than <paramref name="greaterValue"/>.
        /// </summary>
        public static void IsLessThan<T>(T greaterValue, T propertyValue, string propertyName, string errorLocation, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Expected property {propertyName} ({propertyValue}) to be less than ({greaterValue}).";
            GenericAssert<FulcrumAssertionFailedException>.IsLessThan(greaterValue, propertyValue, errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="propertyValue"/> is less than or equal to <paramref name="greaterOrEqualValue"/>.
        /// </summary>
        public static void IsLessThanOrEqualTo<T>(T greaterOrEqualValue, T propertyValue, string propertyName, string errorLocation, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Expected property {propertyName} ({propertyValue}) to be less than ({greaterOrEqualValue}).";
            GenericAssert<FulcrumAssertionFailedException>.IsLessThanOrEqualTo(greaterOrEqualValue, propertyValue, errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="propertyValue"/> is greater than <paramref name="lesserValue"/>.
        /// </summary>
        public static void IsGreaterThan<T>(T lesserValue, T propertyValue, string propertyName, string errorLocation, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Expected property {propertyName} ({propertyValue}) to be less than ({lesserValue}).";
            GenericAssert<FulcrumAssertionFailedException>.IsGreaterThan(lesserValue, propertyValue, errorLocation, message);
        }

        /// <summary>
        /// Verify that <paramref name="propertyValue"/> is greater than or equal to <paramref name="lesserOrEqualValue"/>.
        /// </summary>
        public static void IsGreaterThanOrEqualTo<T>(T lesserOrEqualValue, T propertyValue, string propertyName, string errorLocation, string customMessage = null)
            where T : IComparable<T>
        {
            InternalContract.RequireNotNull(errorLocation, nameof(errorLocation));
            InternalContract.RequireNotNull(propertyName, nameof(propertyName));
            var message = customMessage ?? $"Expected property {propertyName} ({propertyValue}) to be less than ({lesserOrEqualValue}).";
            GenericAssert<FulcrumAssertionFailedException>.IsGreaterThanOrEqualTo(lesserOrEqualValue, propertyValue, errorLocation, message);
        }
    }
}

