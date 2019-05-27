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
        /// <typeparam name="TNestedArgumentAssertionBuilder"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static TNestedArgumentAssertionBuilder IsNotNullOrEmpty<TNestedArgumentAssertionBuilder>(this TNestedArgumentAssertionBuilder @this)
            where TNestedArgumentAssertionBuilder : INestedArgumentAssertionBuilder<IArgumentAssertionBuilder, IEnumerable>
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
        public static TNestedArgumentAssertionBuilder Contains<TNestedArgumentAssertionBuilder, T>(this TNestedArgumentAssertionBuilder @this, T item)
            where TNestedArgumentAssertionBuilder : INestedArgumentAssertionBuilder<IArgumentAssertionBuilder, IEnumerable<T>>
        {
            if (!@this.Argument.Contains(item))
            {
                throw new ArgumentException(Resources.Strings.Item_is_not_in_eumerable, @this.ArgumentName);
            }
            return @this;
        }

        [DebuggerNonUserCode]
        public static TNestedArgumentAssertionBuilder Any<TNestedArgumentAssertionBuilder>(this TNestedArgumentAssertionBuilder @this)
            where TNestedArgumentAssertionBuilder : INestedArgumentAssertionBuilder<IArgumentAssertionBuilder, IEnumerable>
        {
            if (!@this.Argument.Cast<dynamic>().Any())
            {
                throw new ArgumentException(Resources.Strings.No_items, @this.ArgumentName);
            }
            return @this;
        }

        
        [DebuggerNonUserCode]
        public static TNestedArgumentAssertionBuilder Any<TNestedArgumentAssertionBuilder, T>(this TNestedArgumentAssertionBuilder @this, Func<T, bool> predicate = null)
            where TNestedArgumentAssertionBuilder : INestedArgumentAssertionBuilder<IArgumentAssertionBuilder, IEnumerable<T>>
        {
            if (!@this.Argument.Any(predicate))
            {
                throw new ArgumentException(Resources.Strings.No_items_match_the_predicate, @this.ArgumentName);
            }
            return @this;
        }
        
        [DebuggerNonUserCode]
        public static TNestedArgumentAssertionBuilder All<TNestedArgumentAssertionBuilder,T>(this TNestedArgumentAssertionBuilder @this, Func<T, bool> predicate = null)
            where TNestedArgumentAssertionBuilder : INestedArgumentAssertionBuilder<IArgumentAssertionBuilder, IEnumerable<T>>
        {
            if (!@this.Argument.All(predicate))
            {
                throw new ArgumentException(Resources.Strings.All_items_do_not_match_the_predicate, @this.ArgumentName);
            }
            return @this;
        }        
    }
}
