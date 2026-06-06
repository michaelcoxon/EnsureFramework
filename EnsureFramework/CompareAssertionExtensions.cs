using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Assertions;

namespace EnsureFramework
{
    /// <summary>
    /// Ensure assertions for <see cref="IComparable{T}"/>'s
    /// </summary>
    public static partial class CompareAssertionExtensions
    {
        /// <summary>
        /// Ensures the argument is greater than or equal to the specified value.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsGreaterThanOrEqualTo<T>([NotNull] this IArgumentAssertionBuilder<T> @this, T value)
            where T : IComparable<T>
        {
            var result = @this.PushResult(CompareAssertions.IsGreaterThanOrEqualTo(@this.Argument, value));
            if (!result.Success)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, result.Message);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the argument is less than or equal to the specified value.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsLessThanOrEqualTo<T>([NotNull] this IArgumentAssertionBuilder<T> @this, T value)
            where T : IComparable<T>
        {
            var result = @this.PushResult(CompareAssertions.IsLessThanOrEqualTo(@this.Argument, value));
            if (!result.Success)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, result.Message);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the argument is less than the specified value.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsLessThan<T>([NotNull] this IArgumentAssertionBuilder<T> @this, T value)
            where T : IComparable<T>
        {
            var result = @this.PushResult(CompareAssertions.IsLessThan(@this.Argument, value));
            if (!result.Success)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, result.Message);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the argument is greater than the specified value.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsGreaterThan<T>([NotNull] this IArgumentAssertionBuilder<T> @this, T value)
            where T : IComparable<T>
        {
            var result = @this.PushResult(CompareAssertions.IsGreaterThan(@this.Argument, value));
            if (!result.Success)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, result.Message);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the argument is equal to the specified value.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsEqualTo<T>([NotNull] this IArgumentAssertionBuilder<T> @this, T value)
            where T : IComparable<T>
        {
            var result = @this.PushResult(CompareAssertions.IsEqualTo(@this.Argument, value));
            if (!result.Success)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, result.Message);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether the argument is between (not including) the lower bound and upper bound.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsWithinRange<T>([NotNull] this IArgumentAssertionBuilder<T> @this, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            var result = @this.PushResult(CompareAssertions.IsWithinRange(@this.Argument, lowerBound, upperBound));
            if (!result.Success)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, result.Message);
            }
            return @this;
        }

        /// <summary>
        /// Determines whether the argument is between and including the lower bound and upper bound.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> IsWithinAndIncludingRange<T>([NotNull] this IArgumentAssertionBuilder<T> @this, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            var result = @this.PushResult(CompareAssertions.IsWithinAndIncludingRange(@this.Argument, lowerBound, upperBound));
            if (@this.Argument.CompareTo(lowerBound) < 0 || @this.Argument.CompareTo(upperBound) > 0)
            {
                throw new ArgumentOutOfRangeException(@this.ArgumentName, @this.Argument, result.Message);
            }
            return @this;
        }
    }
}
