using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> and <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class EnumerableAssertions
    {
        /// <summary>
        /// Ensures the enumerable argument is not <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> IsNotNullOrEmpty<T>(this IArgumentAssertionBuilder<IEnumerable<T>> @this)
        {
            if (@this.Argument == null)
            {
                throw new ArgumentNullException(@this.ArgumentName);
            }
            if (!@this.Argument.Any())
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }

        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> Contains<T>(this IArgumentAssertionBuilder<IEnumerable<T>> @this, T item)
        {
            if (!@this.Argument.Contains(item))
            {
                throw new ArgumentException("Item is not in eumerable.", @this.ArgumentName);
            }
            return @this;
        }

        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> Any<T>(this IArgumentAssertionBuilder<IEnumerable<T>> @this)
        {
            if (!@this.Argument.Any())
            {
                throw new ArgumentException("No items", @this.ArgumentName);
            }
            return @this;
        }

        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> Any<T>(this IArgumentAssertionBuilder<IEnumerable<T>> @this, Func<T, bool> predicate = null)
        {
            if (!@this.Argument.Any(predicate))
            {
                throw new ArgumentException("No items match the predicate", @this.ArgumentName);
            }
            return @this;
        }
    }
}
