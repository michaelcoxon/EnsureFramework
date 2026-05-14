using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using EnsureFramework.Assertions;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class EnumerableAssertions
    {
        /// <summary>
        /// Ensures the enumerable argument is not <c>null</c> or empty.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable> IsNotNullOrEmpty([NotNull] this IArgumentAssertionBuilder<IEnumerable> @this)
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

        /// <summary>
        /// Ensures the enumerable argument is not <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> IsNotNullOrEmpty<T>([NotNull] this IArgumentAssertionBuilder<IEnumerable<T>> @this)
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

        /// <summary>
        /// Ensures that the specified enumerable argument contains the given item, throwing an exception if it does
        /// not.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable argument.</typeparam>
        /// <param name="this">The argument assertion builder for an enumerable to validate. Cannot be null.</param>
        /// <param name="item">The item to check for within the enumerable argument.</param>
        /// <returns>The original argument assertion builder, enabling method chaining.</returns>
        /// <exception cref="ArgumentException">Thrown if the enumerable argument does not contain the specified item.</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> Contains<T>([NotNull] this IArgumentAssertionBuilder<IEnumerable<T>> @this, T item)
        {
            if (!@this.Argument.Contains(item))
            {
                throw new ArgumentException(Resources.Strings.Item_is_not_in_eumerable, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Ensures that the argument sequence contains at least one element.
        /// </summary>
        /// <remarks>Use this method to assert that a collection or sequence is not empty before
        /// proceeding with further operations. This is typically used in argument validation scenarios to enforce
        /// non-empty collections.</remarks>
        /// <param name="this">An argument assertion builder that encapsulates the sequence to validate. Cannot be null.</param>
        /// <returns>The same argument assertion builder instance, enabling method chaining.</returns>
        /// <exception cref="ArgumentException">Thrown if the argument sequence does not contain any elements.</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable> Any([NotNull] this IArgumentAssertionBuilder<IEnumerable> @this)
        {
            if (!@this.Argument.Cast<dynamic>().Any())
            {
                throw new ArgumentException(Resources.Strings.No_items, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Ensures that the argument sequence contains at least one element, or at least one element that matches the
        /// specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="this">The argument assertion builder containing the sequence to validate. Cannot be null.</param>
        /// <param name="predicate">An optional function to test each element for a condition. If null, the method checks whether the sequence
        /// contains any elements.</param>
        /// <returns>The original argument assertion builder, to support method chaining.</returns>
        /// <exception cref="ArgumentException">Thrown if the sequence is empty or, if a predicate is specified, if no elements match the predicate.</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> Any<T>([NotNull] this IArgumentAssertionBuilder<IEnumerable<T>> @this, Func<T, bool> predicate)
        {
            if (!@this.Argument.Any(predicate))
            {
                throw new ArgumentException(Resources.Strings.No_items_match_the_predicate, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Ensures that all elements in the argument sequence satisfy the specified predicate.
        /// </summary>
        /// <remarks>Use this method to assert that every item in a collection meets a specific condition
        /// as part of argument validation. This method is typically used in fluent validation scenarios.</remarks>
        /// <typeparam name="T">The type of the elements in the sequence to validate.</typeparam>
        /// <param name="this">The argument assertion builder containing the sequence to validate.</param>
        /// <param name="predicate">An optional predicate to test each element for a condition. If null, all elements are considered to match.</param>
        /// <returns>The original argument assertion builder, enabling method chaining.</returns>
        /// <exception cref="ArgumentException">Thrown if any element in the sequence does not satisfy the predicate.</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> All<T>([NotNull] this IArgumentAssertionBuilder<IEnumerable<T>> @this, Func<T, bool> predicate)
        {
            if (!@this.Argument.All(predicate))
            {
                throw new ArgumentException(Resources.Strings.All_items_do_not_match_the_predicate, @this.ArgumentName);
            }
            return @this;
        }
    }
}
