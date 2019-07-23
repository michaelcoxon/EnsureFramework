using EnsureFramework.Assertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> and <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class EnumerableAssertions
    {
        /// <summary>
        /// Ensures the enumerable argument is not <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="TArgumentAssertionBuilder"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable> IsNotNullOrEmpty<TArgumentAssertionBuilder>(this INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable> @this)
            where TArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (@this.Argument == null)
            {
                throw new ArgumentNullException(@this.ArgumentName);
            }
            if (!@this.Argument.Cast<dynamic>().Any())
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }

        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> IsNotNullOrEmpty<TArgumentAssertionBuilder,T>(this INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> @this)
            where TArgumentAssertionBuilder : IArgumentAssertionBuilder
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
        public static INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> Contains<TArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> @this, T item)
            where TArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (!@this.Argument.Contains(item))
            {
                throw new ArgumentException(Resources.Strings.Item_is_not_in_eumerable, @this.ArgumentName);
            }
            return @this;
        }

        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable> Any<TArgumentAssertionBuilder>(this INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable> @this)
            where TArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (!@this.Argument.Cast<dynamic>().Any())
            {
                throw new ArgumentException(Resources.Strings.No_items, @this.ArgumentName);
            }
            return @this;
        }

        
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> Any<TArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> @this, Func<T, bool> predicate = null)
            where TArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (!@this.Argument.Any(predicate))
            {
                throw new ArgumentException(Resources.Strings.No_items_match_the_predicate, @this.ArgumentName);
            }
            return @this;
        }
        
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> All<TArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TArgumentAssertionBuilder, IEnumerable<T>> @this, Func<T, bool> predicate = null)
            where TArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (!@this.Argument.All(predicate))
            {
                throw new ArgumentException(Resources.Strings.All_items_do_not_match_the_predicate, @this.ArgumentName);
            }
            return @this;
        }        
    }
}
