using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

using EnsureFramework;
using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Assertions;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class ObjectAssertionExtensions
    {
        /// <summary>
        /// Ensures the argument is the exact type of <paramref name="type" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsExactTypeOf<T>([NotNull] this IArgumentAssertionBuilder<T> @this, Type type)
        {
            var result = @this.PushResult(ObjectAssertions.IsExactTypeOf(typeof(T), type));

            if (result.Success)
            {
                return @this;
            }

            throw new ArgumentException(result.Message, @this.ArgumentName);
        }

        /// <summary>
        /// Ensures the argument inherits the type of <paramref name="type" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsInheritsTypeOf<T>([NotNull] this IArgumentAssertionBuilder<T> @this, Type type)
        {
            var result = @this.PushResult(ObjectAssertions.IsInheritsTypeOf(typeof(T), type));

            if (result.Success)
            {
                return @this;
            }

            throw new ArgumentException(result.Message, @this.ArgumentName);
        }

        /// <summary>
        /// Asserts on the value of <paramref name="predicate" /> to whether the assertion is valid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="predicate">The predicate to test to see if the assertion is valid.</param>
        /// <param name="message">The message to use if the assertion is invalid.</param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Matches<T>([NotNull] this IArgumentAssertionBuilder<T> @this, Func<T, bool> predicate, string? message = null)
        {
            var result = @this.PushResult(ObjectAssertions.Matches(@this.Argument, predicate, out var innerException));
            if (!result.Success)
            {
                throw new ArgumentException(result.Message + $"\n{message}", @this.ArgumentName, innerException);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether the argument is one of the specified options.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsOneOf<T>([NotNull] this IArgumentAssertionBuilder<T> @this, params T[] options)
        {
            var result = @this.PushResult(ObjectAssertions.IsOneOf(@this.Argument, options));
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }
    }
}
