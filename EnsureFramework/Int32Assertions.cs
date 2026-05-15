using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace EnsureFramework
{
    /// <summary>
    /// Provides assertion methods for validating 32-bit integer arguments.
    /// </summary>
    /// <remarks>These extension methods are intended to be used with argument validation builders to enforce
    /// common constraints on integer values. Each method throws an exception if the specified condition is not met,
    /// allowing for fluent and expressive argument validation in application code.</remarks>
    public static partial class Int32Assertions
    {
        /// <summary>
        /// Asserts that the int is not negative.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<int> IsNotNegative([NotNull] this IArgumentAssertionBuilder<int> @this)
        {
            if (@this.Argument < 0)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, $"The argument '{@this.ArgumentName}' is a negative number");
            }
            return @this;
        }

        /// <summary>
        /// Asserts that the int is not zero.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<int> IsNotZero([NotNull] this IArgumentAssertionBuilder<int> @this)
        {
            if (@this.Argument == 0)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, $"The argument '{@this.ArgumentName}' is equal to zero");
            }
            return @this;
        }
    }
}
