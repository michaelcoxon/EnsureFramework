using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework
{
    public static partial class Int32Assertions
    {
        /// <summary>
        /// Asserts that the int is not negative.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, int> IsNotNegative<TParentArgumentAssertionBuilder>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, int> @this)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
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
        public static INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, int> IsNotZero<TParentArgumentAssertionBuilder>(this INestedArgumentAssertionBuilder<TParentArgumentAssertionBuilder, int> @this)
            where TParentArgumentAssertionBuilder : IArgumentAssertionBuilder
        {
            if (@this.Argument == 0)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, $"The argument '{@this.ArgumentName}' is equal to zero");
            }
            return @this;
        }
    }
}
