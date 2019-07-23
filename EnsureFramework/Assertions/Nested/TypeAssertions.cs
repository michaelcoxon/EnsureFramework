using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureFramework.Assertions;
using System.Reflection;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions 
    /// in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> 
    /// and <see cref="Ensure.Arg{T}(T, string)"/> helpers
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> Is<TParentArgumentAssertionBuilder>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> @this, Type type)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> IsAssignableFrom<TParentArgumentAssertionBuilder>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> @this, Type type)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> IsAssignableTo<TParentArgumentAssertionBuilder>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> @this, Type type)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> Is<TParentArgumentAssertionBuilder,T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> @this)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> IsAssignableFrom<TParentArgumentAssertionBuilder,T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> @this)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> IsAssignableTo<TParentArgumentAssertionBuilder,T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, Type> @this)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (typeof(T).GetTypeInfo().IsAssignableFrom(@this.Argument))
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }
    }
}
