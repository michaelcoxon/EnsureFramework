using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Provides assertion methods for verifying dictionary collections.
    /// </summary>
    /// <remarks>This static class contains utility methods to assist in validating dictionary contents,
    /// typically for use in testing or guard clauses. All members are static and thread safe.</remarks>
    public static class DictionaryAssertions
    {
        /// <summary>
        /// Determines whether the specified dictionary contains the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The dictionary to search for the specified key. Cannot be null.</param>
        /// <param name="key">The key to locate in the dictionary.</param>
        /// <returns>true if the dictionary contains an element with the specified key; otherwise, false.</returns>
        public static IAssertionResult HasKey<TKey, TValue>( IDictionary<TKey, TValue> source, TKey key)
        {
            ArgumentNullException.ThrowIfNull(source);
            if (!source.ContainsKey(key))
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_key_keyName_is_not_in_the_dictionary_Format, key));
            }
            return AssertionResult.Ok;
        }
    }
}
