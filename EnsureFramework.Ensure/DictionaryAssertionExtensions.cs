using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Assertions;

namespace EnsureFramework
{
    /// <summary>
    /// <see cref="IArgumentAssertionBuilder"/> assertions for <see cref="IDictionary{TKey, TValue}"/>
    /// </summary>
    public static partial class DictionaryAssertionExtensions
    {
        /// <summary>
        /// Determines whether the specified key exists in the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="this">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IDictionary<TKey, TValue>> HasKey<TKey, TValue>([NotNull] this IArgumentAssertionBuilder<IDictionary<TKey, TValue>> @this, TKey key)
        {
            var result = @this.PushResult(DictionaryAssertions.HasKey(@this.Argument, key));
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }
    }
}
