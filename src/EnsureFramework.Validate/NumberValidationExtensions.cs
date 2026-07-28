using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using EnsureFramework.Assertions;
using EnsureFramework.Results;

namespace EnsureFramework
{
    /// <summary>
    /// Provides assertion methods for validating number arguments.
    /// </summary>
    /// <remarks>These extension methods are intended to be used with argument validation builders to enforce
    /// common constraints on number values. Each method throws an exception if the specified condition is not met,
    /// allowing for fluent and expressive argument validation in application code.</remarks>
    public static partial class NumberValidationExtensions
    {
        /// <summary>
        /// Asserts that the number is not negative.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DebuggerNonUserCode]
        public static IValidationResult<T> IsNotNegative<T>([NotNull] this IValidationResult<T> @this) where T : INumberBase<T>
        {
            ArgumentNullException.ThrowIfNull(@this);
            @this.AssertionResults.Add(NumberAssertions.IsNegative(@this.Value));
            return @this;
        }

        /// <summary>
        /// Asserts that the argument is a negative number.
        /// </summary>
        /// <remarks>Use this method to ensure that a numeric argument is negative before proceeding with
        /// further logic. This method supports method chaining for additional assertions.</remarks>
        /// <typeparam name="T">The numeric type of the argument.</typeparam>
        /// <param name="this">The argument assertion builder containing the value to validate. Cannot be null.</param>
        /// <returns>The same assertion builder instance if the argument is negative, enabling further assertions.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the argument is not a negative number.</exception>
        [DebuggerNonUserCode]
        public static IValidationResult<T> IsNegative<T>([NotNull] this IValidationResult<T> @this) where T : INumberBase<T>
        {
            ArgumentNullException.ThrowIfNull(@this);
            @this.AssertionResults.Add(NumberAssertions.IsNegative(@this.Value));
            return @this;
        }

        /// <summary>
        /// Asserts that the number is not zero.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DebuggerNonUserCode]
        public static IValidationResult<T> IsNotZero<T>([NotNull] this IValidationResult<T> @this) where T : INumberBase<T>
        {
            ArgumentNullException.ThrowIfNull(@this);
            @this.AssertionResults.Add(NumberAssertions.IsZero(@this.Value));
            return @this;
        }

        /// <summary>
        /// Asserts that the argument is zero.
        /// </summary>
        /// <remarks>Use this method to ensure that a numeric argument is exactly zero. This assertion is
        /// type-safe for any numeric type.</remarks>
        /// <typeparam name="T">The numeric type of the argument.</typeparam>
        /// <param name="this">The argument assertion builder containing the value to check. Cannot be null.</param>
        /// <returns>The current assertion builder if the argument is zero.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the argument is not zero.</exception>
        [DebuggerNonUserCode]
        public static IValidationResult<T> IsZero<T>([NotNull] this IValidationResult<T> @this) where T : INumberBase<T>
        {
            ArgumentNullException.ThrowIfNull(@this);
            @this.AssertionResults.Add(NumberAssertions.IsZero(@this.Value));
            return @this;
        }
    }
}
