using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using EnsureFramework.ArgumentAssertionBuilder;

namespace EnsureFramework
{
    /// <summary>
    /// Provides assertion methods for validating number arguments.
    /// </summary>
    /// <remarks>These extension methods are intended to be used with argument validation builders to enforce
    /// common constraints on number values. Each method throws an exception if the specified condition is not met,
    /// allowing for fluent and expressive argument validation in application code.</remarks>
    public static partial class NumberAssertions
    {
        /// <summary>
        /// Asserts that the number is not negative.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsNotNegative<T>([NotNull] this IArgumentAssertionBuilder<T> @this) where T : INumberBase<T>
        {
            if (T.IsNegative(@this.Argument))
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName,
                    @this.Argument,
                    string.Format(Resources.Strings.The_argument_argName_is_a_negative_number_Format, @this.ArgumentName));
            }
            return @this.AssertionPassed();
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
        public static IArgumentAssertionBuilder<T> IsNegative<T>([NotNull] this IArgumentAssertionBuilder<T> @this) where T : INumberBase<T>
        {
            if (T.IsNegative(@this.Argument))
            {
                return @this.AssertionPassed();
            }
            throw new ArgumentOutOfRangeException(
                @this.ArgumentName,
                @this.Argument,
                string.Format(Resources.Strings.The_argument_argName_is_a_negative_number_Format, @this.ArgumentName));
        }

        /// <summary>
        /// Asserts that the number is not zero.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsNotZero<T>([NotNull] this IArgumentAssertionBuilder<T> @this) where T : INumberBase<T>
        {
            if (T.IsZero(@this.Argument))
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName,
                    @this.Argument,
                    string.Format(Resources.Strings.The_argument_argName_is_equal_to_zero_Format, @this.ArgumentName));
            }
            return @this.AssertionPassed();
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
        public static IArgumentAssertionBuilder<T> IsZero<T>([NotNull] this IArgumentAssertionBuilder<T> @this) where T : INumberBase<T>
        {
            if (T.IsZero(@this.Argument))
            {
                return @this.AssertionPassed();
            }

            throw new ArgumentOutOfRangeException(
                @this.ArgumentName,
                @this.Argument,
                string.Format(Resources.Strings.The_argument_argName_is_equal_to_zero_Format, @this.ArgumentName));

        }
    }
}
