using EnsureFramework.Assertions;

using System;
using System.Diagnostics;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions 
    /// in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> 
    /// and <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class ObjectAssertions
    {
        /// <summary>
        /// Ensures the argument is the exact type of <paramref name="type" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TParentArgumentAssertionBuilder"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> IsTypeOf<TParentArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> @this, Type type)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (typeof(T) != type)
            {
                throw new ArgumentException($"The argument at '{@this.ArgumentName}' must be of type '{type}' but it is actually '{@this.Argument.GetType()}'", @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the argument is of the type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> IsTypeOf<TParentArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> @this)
                 where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (typeof(T) != @this.Argument.GetType())
            {
                throw new ArgumentException($"The argument at '{@this.ArgumentName}' must be of type '{typeof(T)}'", @this.ArgumentName);
            }
            return @this;
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> Matches<TParentArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> @this, Func<T, bool> predicate, string message = null)
                 where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            bool result;
            Exception innerException = null;
            try
            {
                result = predicate(@this.Argument);
            }
            catch (Exception ex)
            {
                innerException = ex;
                result = false;
            }
            if (!result)
            {
                throw new ArgumentException(message, @this.ArgumentName, innerException);
            }

            return @this;
        }
        /*
        /// <summary>
        /// Determines whether the argument is one of the specified options.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> IsOneOf<TParentArgumentAssertionBuilder, T>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> @this, params T[] options)
                 where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (!options.Contains(@this.Argument))
            {
                throw new ArgumentException($"Argument '{@this.ArgumentName}' must be one of ('{string.Join("', '", options)}')", @this.ArgumentName);
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
        public static INestedArgumentAssertionBuilder<INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T>, TProperty> WithProperty<TParentArgumentAssertionBuilder, T, TProperty>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, T> @this, Expression<Func<T, TProperty>> propertySelector)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder<T>
        {
            if (propertySelector is null)
            {
                throw new ArgumentNullException(nameof(propertySelector));
            }
            return Ensure.Nested(@this, propertySelector.Compile().Invoke(@this.Argument), $"{@this.ArgumentName}.\"{(propertySelector.Body as MemberExpression).Member.Name}\"]");
        }
        */
    }
}
