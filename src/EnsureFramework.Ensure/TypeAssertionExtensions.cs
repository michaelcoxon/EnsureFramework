using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Assertions;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class TypeAssertionExtensions
    {
        /// <summary>
        /// Determines whether the argument is the specified type
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">null</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Type> Is([NotNull] this IArgumentAssertionBuilder<Type> @this, Type type)
        {
            var result = TypeAssertions.Is(@this.Argument, type);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether an instance of the specified type can be assigned to an instance
        /// of the argument.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">null</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Type> IsAssignableFrom([NotNull] this IArgumentAssertionBuilder<Type> @this, Type type)
        {
            var result = TypeAssertions.IsAssignableFrom(@this.Argument, type);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether an instance of the argument can be assigned to an instance
        /// of the specified type.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">null</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Type> IsAssignableTo([NotNull] this IArgumentAssertionBuilder<Type> @this, Type type)
        {
            var result = TypeAssertions.IsAssignableFrom(type, @this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether the argument is the specified type
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">null</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Type> Is<T>([NotNull] this IArgumentAssertionBuilder<Type> @this)
        {
            var result = TypeAssertions.Is<T>(@this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether an instance of the specified type can be assigned to an instance
        /// of the argument.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">null</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Type> IsAssignableFrom<T>([NotNull] this IArgumentAssertionBuilder<Type> @this)
        {
            var result = TypeAssertions.IsAssignableFrom<T>(@this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether an instance of the argument can be assigned to an instance
        /// of the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">null</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Type> IsAssignableTo<T>([NotNull] this IArgumentAssertionBuilder<Type> @this)
        {
            var baseType = typeof(T);
            var result = TypeAssertions.IsAssignableFrom(baseType, @this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this;
        }
    }
}
