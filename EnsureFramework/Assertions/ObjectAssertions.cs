﻿using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> and <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class ObjectAssertions
    {
        /// <summary>
        /// Ensures the argument is not <c>null</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsNotNull<T>(this IArgumentAssertionBuilder<T> @this)
        {
            if (@this.Argument == null)
            {
                throw new ArgumentNullException(@this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the argument is of the type <paramref name="type" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsTypeOf<T>(this IArgumentAssertionBuilder<T> @this, Type type)
        {
            if (typeof(T) != type)
            {
                throw new ArgumentException($"The argument at '{@this.ArgumentName}' must be of type '{type}'", @this.ArgumentName);
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
        public static IArgumentAssertionBuilder IsTypeOf<T>(this IArgumentAssertionBuilder @this)
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
        public static IArgumentAssertionBuilder<T> Matches<T>(this IArgumentAssertionBuilder<T> @this, Func<T, bool> predicate, string message = null)
        {
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

        /// <summary>
        /// Determines whether the argument is one of the specified options.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsOneOf<T>(this IArgumentAssertionBuilder<T> @this, params T[] options)
        {
            if (!options.Contains(@this.Argument))
            {
                throw new ArgumentException($"Argument '{@this.ArgumentName}' must be one of ('{string.Join("', '", options)}')", @this.ArgumentName);
            }
            return @this;
        }
    }
}