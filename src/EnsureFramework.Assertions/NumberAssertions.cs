using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Provides assertion methods for validating number arguments.
    /// </summary>
    /// <remarks>These extension methods are intended to be used with argument validation builders to enforce
    /// common constraints on number values. Each method throws an exception if the specified condition is not met,
    /// allowing for fluent and expressive argument validation in application code.</remarks>
    public static class NumberAssertions
    {
        /// <summary>
        /// Determines whether the specified value is negative.
        /// </summary>
        /// <typeparam name="T">The numeric type to evaluate.</typeparam>
        /// <param name="source">The value to test for negativity.</param>
        /// <returns>An <see cref="IAssertionResult"/> indicating whether <paramref name="source"/> is negative. Returns a
        /// successful result if the value is negative; otherwise, returns a failure result.</returns>
        public static IAssertionResult IsNegative<T>(T source) where T : INumberBase<T>
        {
            if (T.IsNegative(source))
            {
                return AssertionResult.Ok;
            }
            return AssertionResult.Fail(Resources.Strings.The_value_is_a_negative_number);
        }

        /// <summary>
        /// Determines whether the specified value is equal to zero.
        /// </summary>
        /// <typeparam name="T">The numeric type to evaluate.</typeparam>
        /// <param name="source">The value to test for equality to zero.</param>
        /// <returns>An <see cref="IAssertionResult"/> indicating whether <paramref name="source"/> is zero. Returns <see
        /// cref="AssertionResult.Ok"/> if the value is zero; otherwise, returns <see cref="AssertionResult.Fail"/>.</returns>
        public static IAssertionResult IsZero<T>(T source) where T : INumberBase<T>
        {
            if (T.IsZero(source))
            {
                return AssertionResult.Ok;
            }
            return AssertionResult.Fail(Resources.Strings.The_value_is_equal_to_zero);
        }
    }
}
