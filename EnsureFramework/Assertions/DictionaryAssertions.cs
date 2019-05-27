using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework
{
    public static class DictionaryAssertions
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
        public static IArgumentAssertionBuilder<IDictionary<TKey, TValue>> HasKey<TKey, TValue>(this IArgumentAssertionBuilder<IDictionary<TKey, TValue>> @this, TKey key)
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
        public static INestedArgumentAssertionBuilder<IArgumentAssertionBuilder<IDictionary<TKey, TValue>>, TValue> WithKey<TKey, TValue>(this IArgumentAssertionBuilder<IDictionary<TKey, TValue>> @this, TKey key)
        {
            return Ensure.Arg(@this, @this.Argument[key], $"{@this.ArgumentName}[\"{key}\"]");
        }
    }
}
