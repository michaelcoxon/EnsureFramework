using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> and <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class ObjectAssertions
    {
        /// <summary>
        /// Ensures the argument is not <c>null</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> IsNotNull<TParentArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T?> @this)
            where T : struct
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (!@this.Argument.HasValue)
            {
                throw new ArgumentNullException(@this.ArgumentName);
            }
            return Ensure.Arg(@this.Pop(), @this.Argument.Value, @this.ArgumentName);
        }

        /// <summary>
        /// Ensures the argument is the exact type of <paramref name="type" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T>  IsTypeOf<TParentArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> @this, Type type)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (typeof(T) != type)
            {
                throw new ArgumentException($"The argument at '{@this.ArgumentName}' must be of type '{type}'", @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Makes assertions against the property of an object.
        /// </summary>
        /// <typeparam name="T">the object type</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="this">The object.</param>
        /// <param name="propertySelector">The property selector.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<IArgumentAssertionBuilder<T>, TProperty> WithProperty<T, TProperty>(this IArgumentAssertionBuilder<T> @this, Expression<Func<T, TProperty>> propertySelector)
        {
            return Ensure.Arg(@this, propertySelector.Compile().Invoke(@this.Argument), $"{@this.ArgumentName}.\"{(propertySelector.Body as MemberExpression).Member.Name}\"]");
        }
    }
}
