using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using EnsureFramework.ArgumentAssertionBuilder;

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
        public static bool IsNegative<T>(T source) where T : INumberBase<T>
        {
            if (T.IsNegative(source))
            {
                return true;
            }
            return false;
        }

        public static bool IsZero<T>(T source) where T : INumberBase<T>
        {
            if (T.IsZero(source))
            {
                return true;
            }
            return false;
        }
    }
}
