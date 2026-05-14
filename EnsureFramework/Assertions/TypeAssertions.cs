using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class TypeAssertions
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
            if (@this.Argument == type)
            {
                throw new ArgumentException(null, @this.ArgumentName);
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
            if (@this.Argument.GetTypeInfo().IsAssignableFrom(type))
            {
                throw new ArgumentException(null, @this.ArgumentName);
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
            if (type.GetTypeInfo().IsAssignableFrom(@this.Argument))
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether the argument is the specified type
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">null</exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Type> Is<T>([NotNull] this IArgumentAssertionBuilder<Type> @this)
        {
            if (@this.Argument == typeof(T))
            {
                throw new ArgumentException(null, @this.ArgumentName);
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
        public static IArgumentAssertionBuilder<Type> IsAssignableFrom<T>([NotNull] this IArgumentAssertionBuilder<Type> @this)
        {
            if (@this.Argument.GetTypeInfo().IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException(null, @this.ArgumentName);
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
        public static IArgumentAssertionBuilder<Type> IsAssignableTo<T>([NotNull] this IArgumentAssertionBuilder<Type> @this)
        {
            if (typeof(T).GetTypeInfo().IsAssignableFrom(@this.Argument))
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }
    }
}
