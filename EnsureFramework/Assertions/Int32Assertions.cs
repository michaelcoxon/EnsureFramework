using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace EnsureFramework.Assertions
{
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
