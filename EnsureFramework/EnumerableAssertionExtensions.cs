using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using EnsureFramework;
using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Assertions;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class EnumerableAssertionExtensions
    {
        /// <summary>
        /// Ensures the enumerable argument is not empty.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable> IsNotEmpty([NotNull] this IArgumentAssertionBuilder<IEnumerable> @this)
        {
            var result = EnumerableAssertions.IsNotEmpty(@this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }

        /// <summary>
        /// Ensures the enumerable argument is not empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable<T>> IsNotEmpty<T>([NotNull] this IArgumentAssertionBuilder<IEnumerable<T>> @this)
        {
            var result = EnumerableAssertions.IsNotEmpty(@this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
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
            var result = EnumerableAssertions.Contains(@this.Argument, item);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }

        /// <summary>
        /// Ensures that the specified enumerable argument contains the given item, throwing an exception if it does
        /// </summary>
        /// <param name="this">The argument assertion builder for the enumerable to validate. Cannot be null.</param>
        /// <param name="item">The item to locate within the enumerable. Can be null.</param>
        /// <returns>The original argument assertion builder, enabling method chaining.</returns>
        /// <exception cref="ArgumentException">Thrown if the enumerable does not contain the specified item.</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable> Contains([NotNull] this IArgumentAssertionBuilder<IEnumerable> @this, object item)
        {
            var result = EnumerableAssertions.Contains(@this.Argument, item);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }

        /// <summary>
        /// Ensures that the argument sequence contains at least one element that matches the
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
            var result = EnumerableAssertions.Any(@this.Argument, predicate);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }

        /// <summary>
        /// Ensures that at least one element in the argument sequence satisfies the specified predicate.
        /// </summary>
        /// <param name="this">The argument assertion builder containing the sequence to validate. Cannot be null.</param>
        /// <param name="predicate">A function that defines the condition to test each element for. Cannot be null.</param>
        /// <returns>The original argument assertion builder if at least one element matches the predicate.</returns>
        /// <exception cref="ArgumentException">Thrown if no elements in the sequence satisfy the predicate.</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable> Any([NotNull] this IArgumentAssertionBuilder<IEnumerable> @this, Func<object, bool> predicate)
        {
            var result = EnumerableAssertions.Any(@this.Argument, predicate);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
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
            var result = EnumerableAssertions.Any(@this.Argument, predicate);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }

        /// <summary>
        /// Ensures that all elements in the argument sequence satisfy the specified predicate.
        /// </summary>
        /// <remarks>Use this method to assert that every item in the provided sequence meets a specific
        /// condition. This method is typically used in fluent validation scenarios.</remarks>
        /// <param name="this">The argument assertion builder containing the sequence to validate. Cannot be null.</param>
        /// <param name="predicate">A function that defines the condition each element in the sequence must satisfy. Cannot be null.</param>
        /// <returns>The original argument assertion builder, enabling further assertion chaining.</returns>
        /// <exception cref="ArgumentException">Thrown if any element in the sequence does not satisfy the predicate.</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<IEnumerable> All([NotNull] this IArgumentAssertionBuilder<IEnumerable> @this, Func<object, bool> predicate)
        {
            var result = EnumerableAssertions.Any(@this.Argument, predicate);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }
    }
}
