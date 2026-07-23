using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.Assertions;
using EnsureFramework.Results;

namespace EnsureFramework
{
    /// <summary>
    /// Provides extension methods for validating dictionary instances.
    /// </summary>
    public static partial class DictionaryValidationExtensions
    {
        /// <summary>
        /// Adds a validation assertion that checks whether the dictionary contains the specified key.
        /// </summary>
        /// <remarks>This method enables fluent validation of dictionaries by asserting the presence of a
        /// specific key. The assertion result is added to the collection of validation results, allowing for further
        /// chained validations.</remarks>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="this">The validation result for the dictionary to which the assertion is applied.</param>
        /// <param name="key">The key to check for existence in the dictionary. Cannot be null if the dictionary does not allow null keys.</param>
        /// <returns>The original validation result with the additional assertion result included.</returns>
        public static IValidationResult<IDictionary<TKey, TValue>> HasKey<TKey, TValue>(this IValidationResult<IDictionary<TKey, TValue>> @this, TKey key)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(DictionaryAssertions.HasKey(@this.Value, key));
            return @this;
        }
    }
}
