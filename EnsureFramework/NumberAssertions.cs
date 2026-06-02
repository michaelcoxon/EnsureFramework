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
    }
}
