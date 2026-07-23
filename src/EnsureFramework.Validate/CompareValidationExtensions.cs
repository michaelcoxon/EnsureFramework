using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.Assertions;
using EnsureFramework.Results;

namespace EnsureFramework
{
    /// <summary>
    /// Provides extension methods for adding comparison-based assertions to validation results. These methods enable
    /// fluent validation of values against comparison criteria such as greater than, less than, equality, and range
    /// checks.
    /// </summary>
    /// <remarks>These extension methods are intended to be used with types implementing the
    /// <see cref="IValidationResult{T}"/> interface. Each method adds a corresponding comparison assertion to the validation result,
    /// allowing for composable and expressive validation logic. All methods require that the validated value implements
    /// <see cref="IComparable{T}"/> to support the necessary comparisons.</remarks>
    public static partial class CompareValidationExtensions
    {
        /// <summary>
        /// Adds a validation assertion that the current value is greater than or equal to the specified value.
        /// </summary>
        /// <remarks>This method enables fluent validation by chaining multiple assertions. The comparison
        /// uses the default comparer for the type <typeparamref name="T"/>.</remarks>
        /// <typeparam name="T">The type of the value being validated. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="this">The validation result to which the assertion is added.</param>
        /// <param name="value">The value to compare against. The current value must be greater than or equal to this value.</param>
        /// <returns>The original validation result with the new assertion added.</returns>
        public static IValidationResult<T> IsGreaterThanOrEqualTo<T>(this IValidationResult<T> @this, T value)
            where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(CompareAssertions.IsGreaterThanOrEqualTo(@this.Value, value));
            return @this;
        }

        /// <summary>
        /// Adds a validation assertion that the current value is less than or equal to the specified value.
        /// </summary>
        /// <typeparam name="T">The type of the value being validated. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="this">The validation result to which the assertion is added.</param>
        /// <param name="value">The value to compare against. The assertion passes if the current value is less than or equal to this value.</param>
        /// <returns>The same <see cref="IValidationResult{T}"/> instance with the new assertion result added.</returns>
        public static IValidationResult<T> IsLessThanOrEqualTo<T>(this IValidationResult<T> @this, T value)
            where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(CompareAssertions.IsLessThanOrEqualTo(@this.Value, value));
            return @this;
        }

        /// <summary>
        /// Adds a validation assertion that the current value is less than the specified value.
        /// </summary>
        /// <remarks>This method enables fluent chaining of multiple validation assertions. The comparison
        /// uses the default comparer for type <typeparamref name="T"/>.</remarks>
        /// <typeparam name="T">The type of the value being validated. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="this">The validation result to which the assertion is added.</param>
        /// <param name="value">The value to compare against. The assertion passes if the current value is less than this value.</param>
        /// <returns>The same <see cref="IValidationResult{T}"/> instance with the new assertion result added.</returns>
        public static IValidationResult<T> IsLessThan<T>(this IValidationResult<T> @this, T value)
            where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(CompareAssertions.IsLessThan(@this.Value, value));
            return @this;
        }

        /// <summary>
        /// Adds a validation assertion that the current value is greater than the specified value.
        /// </summary>
        /// <typeparam name="T">The type of the value being validated. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="this">The validation result to which the assertion is added.</param>
        /// <param name="value">The value to compare against. The current value must be greater than this value for the assertion to pass.</param>
        /// <returns>The same <see cref="IValidationResult{T}"/> instance with the new assertion result added.</returns>
        public static IValidationResult<T> IsGreaterThan<T>(this IValidationResult<T> @this, T value)
            where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(CompareAssertions.IsGreaterThan(@this.Value, value));
            return @this;
        }

        /// <summary>
        /// Adds an equality assertion that verifies whether the validated value is equal to the specified value.   
        /// </summary>
        /// <typeparam name="T">The type of the value being validated. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="this">The validation result to which the equality assertion is added.</param>
        /// <param name="value">The value to compare against the validated value. The assertion passes if the values are equal.</param>
        /// <returns>The same <see cref="IValidationResult{T}"/> instance with the equality assertion result added.</returns>
        public static IValidationResult<T> IsEqualTo<T>(this IValidationResult<T> @this, T value)
            where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(CompareAssertions.IsEqualTo(@this.Value, value));
            return @this;
        }

        /// <summary>
        /// Adds a validation assertion that checks whether the value is within the specified inclusive range.
        /// </summary>
        /// <remarks>This method does not modify the original value, but appends a new assertion result to
        /// the validation result. The range check uses the default comparer for type <typeparamref
        /// name="T"/>.</remarks>
        /// <typeparam name="T">The type of the value to validate. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="this">The validation result to which the range assertion is added.</param>
        /// <param name="lowerBound">The inclusive lower bound of the valid range.</param>
        /// <param name="upperBound">The inclusive upper bound of the valid range.</param>
        /// <returns>The original validation result with the range assertion added.</returns>
        public static IValidationResult<T> IsWithinRange<T>(this IValidationResult<T> @this, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(CompareAssertions.IsWithinRange(@this.Value, lowerBound, upperBound));
            return @this;
        }

        /// <summary>
        /// Adds a validation result indicating whether the value is within the specified inclusive range.
        /// </summary>
        /// <remarks>Use this method to assert that a value falls within a specified range, including the
        /// boundary values. The assertion result is appended to the existing validation results, allowing for fluent
        /// validation chaining.</remarks>
        /// <typeparam name="T">The type of the value to validate. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="this">The validation result to which the range assertion will be added.</param>
        /// <param name="lowerBound">The inclusive lower bound of the valid range.</param>
        /// <param name="upperBound">The inclusive upper bound of the valid range.</param>
        /// <returns>The original validation result with the range assertion added.</returns>
        public static IValidationResult<T> IsWithinAndIncludingRange<T>(this IValidationResult<T> @this, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(CompareAssertions.IsWithinAndIncludingRange(@this.Value, lowerBound, upperBound));
            return @this;
        }
    }
}
