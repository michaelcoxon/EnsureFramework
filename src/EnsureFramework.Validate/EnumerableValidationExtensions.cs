using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using EnsureFramework;
using EnsureFramework.Assertions;
using EnsureFramework.Results;

namespace EnsureFramework
{
    /// <summary>
    /// Provides extension methods for validating enumerable collections using IValidationResult.
    /// </summary>
    public static class EnumerableValidationExtensions
    {
        /// <summary>
        /// Validates that the enumerable is not null and not empty.
        /// </summary>
        /// <param name="this">The validation result containing the enumerable to validate.</param>
        /// <returns>A validation result containing the enumerable and the not-null and not-empty assertion results.</returns>
        public static IValidationResult<IEnumerable> IsNotNullOrEmpty([NotNull] this IValidationResult<IEnumerable> @this)
        {
            var newThis = @this.IsNotNull();
            newThis.AssertionResults.Add(EnumerableAssertions.IsNotEmpty(newThis.Value));
            return newThis;
        }

        /// <summary>
        /// Validates that the enumerable is not empty.
        /// </summary>
        /// <param name="this">The validation result.</param>
        /// <returns>The validation result for method chaining.</returns>
        public static IValidationResult<IEnumerable> IsNotEmpty([NotNull] this IValidationResult<IEnumerable> @this)
        {
            @this.AssertionResults.Add(EnumerableAssertions.IsNotEmpty(@this.Value));
            return @this;
        }

        /// <summary>
        /// Validates that the enumerable is not empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="this">The validation result containing the enumerable to validate.</param>
        /// <returns>The validation result for chaining.</returns>
        public static IValidationResult<IEnumerable<T>> IsNotEmpty<T>([NotNull] this IValidationResult<IEnumerable<T>> @this)
        {
            @this.AssertionResults.Add(EnumerableAssertions.IsNotEmpty(@this.Value));
            return @this;
        }

        /// <summary>
        /// Validates that the enumerable contains the specified item.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="this">The validation result to extend.</param>
        /// <param name="item">The item to search for in the enumerable.</param>
        /// <returns>The validation result for method chaining.</returns>
        public static IValidationResult<IEnumerable<T>> Contains<T>([NotNull] this IValidationResult<IEnumerable<T>> @this, T item)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Contains(@this.Value, item));
            return @this;
        }

        /// <summary>
        /// Validates that the enumerable contains the specified item.
        /// </summary>
        /// <param name="this">The validation result containing the enumerable to validate.</param>
        /// <param name="item">The item to search for in the enumerable.</param>
        /// <returns>The validation result for chaining further validations.</returns>
        public static IValidationResult<IEnumerable> Contains([NotNull] this IValidationResult<IEnumerable> @this, object item)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Contains(@this.Value, item));
            return @this;
        }

        /// <summary>
        /// Validates that at least one element in the enumerable satisfies the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="this">The validation result containing the enumerable to validate.</param>
        /// <param name="predicate">The condition to test each element against.</param>
        /// <returns>The current validation result to enable method chaining.</returns>
        public static IValidationResult<IEnumerable<T>> Any<T>([NotNull] this IValidationResult<IEnumerable<T>> @this, Func<T, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Any(@this.Value, predicate));
            return @this;
        }

        /// <summary>
        /// Validates that at least one element in the enumerable satisfies the specified predicate.
        /// </summary>
        /// <param name="this">The validation result containing the enumerable to validate.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The validation result for fluent chaining.</returns>
        public static IValidationResult<IEnumerable> Any([NotNull] this IValidationResult<IEnumerable> @this, Func<object, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Any(@this.Value, predicate));
            return @this;
        }

        /// <summary>
        /// Validates that all elements in the collection satisfy the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="this">The validation result containing the collection to validate.</param>
        /// <param name="predicate">The function to test each element for a condition.</param>
        /// <returns>The validation result for method chaining.</returns>
        public static IValidationResult<IEnumerable<T>> All<T>([NotNull] this IValidationResult<IEnumerable<T>> @this, Func<T, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.All(@this.Value, predicate));
            return @this;
        }

        /// <summary>
        /// Validates that all elements in the enumerable satisfy the specified condition.
        /// </summary>
        /// <param name="this">The validation result containing the enumerable to validate.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The validation result for chaining further validations.</returns>
        public static IValidationResult<IEnumerable> All([NotNull] this IValidationResult<IEnumerable> @this, Func<object, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.All(@this.Value, predicate));
            return @this;
        }
    }
}
