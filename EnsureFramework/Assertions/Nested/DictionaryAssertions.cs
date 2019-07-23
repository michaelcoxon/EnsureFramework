using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework
{
    public static partial class DictionaryAssertions
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, IDictionary<TKey, TValue>> HasKey<TParentArgumentAssertionBuilder, TKey, TValue>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, IDictionary<TKey, TValue>> @this, TKey key)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (!@this.Argument.ContainsKey(key))
            {
                throw new ArgumentException($"{@this.ArgumentName}[\"{key}\"] is not in the dictionary", @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Makes assertions against the value defined by the key. This does not check if the key exists. Use <see cref="HasKey{TKey, TValue}(IArgumentAssertionBuilder{IDictionary{TKey, TValue}}, TKey)"/> for that.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="this">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, IDictionary<TKey, TValue>>, TValue> WithKey<TParentArgumentAssertionBuilder, TKey, TValue>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, IDictionary<TKey, TValue>> @this, TKey key)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            return Ensure.Nested(@this, @this.Argument[key], $"{@this.ArgumentName}[\"{key}\"]");
        }

        /// <summary>
        /// Makes assertions against the value defined by the key. This does not check if the key exists. Use <see cref="HasKey{TKey, TValue}(IArgumentAssertionBuilder{IDictionary{TKey, TValue}}, TKey)"/> for that.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="this">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, IDictionary<TKey, TValue>>, TValue> WithCheckedKey<TParentArgumentAssertionBuilder, TKey, TValue>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, IDictionary<TKey, TValue>> @this, TKey key)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            return Ensure.Nested(@this.HasKey(key), @this.Argument[key], $"{@this.ArgumentName}[\"{key}\"]");
        }
    }
}
