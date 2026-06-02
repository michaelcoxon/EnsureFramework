using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.ArgumentAssertionBuilder;

namespace EnsureFramework
{
    /// <summary>
    /// Ensure assertions for <see cref="IComparable{T}"/>'s
    /// </summary>
    public static partial class CompareAssertions
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
            if (@this.Argument.CompareTo(value) < 0)
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName,
                    @this.Argument,
                    string.Format(Resources.Strings.The_argument_argName_is_not_greater_than_or_equal_to_value_Format, @this.ArgumentName, value));
            }
            return @this.AssertionPassed();
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
            if (@this.Argument.CompareTo(value) > 0)
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName,
                    @this.Argument,
                    string.Format(Resources.Strings.The_argument_argName_is_not_greater_than_or_equal_to_value_Format, @this.ArgumentName, value));
            }
            return @this.AssertionPassed();
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
            if (@this.Argument.CompareTo(value) != -1)
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName,
                    @this.Argument, 
                    string.Format(Resources.Strings.The_argument_argName_is_not_less_than_value_Format, @this.ArgumentName, value));
            }
            return @this.AssertionPassed();
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
            if (@this.Argument.CompareTo(value) != 1)
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName, 
                    @this.Argument, 
                    string.Format(Resources.Strings.The_argument_argName_is_not_greater_than_value_Format, @this.ArgumentName, value));
            }
            return @this.AssertionPassed();
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
            if (@this.Argument.CompareTo(value) != 0)
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName,
                    @this.Argument,
                    string.Format(Resources.Strings.The_argument_argName_is_not_equal_to_value_Format, @this.ArgumentName, value));

            }
            return @this.AssertionPassed();
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
            if (@this.Argument.CompareTo(lowerBound) <= 0 || @this.Argument.CompareTo(upperBound) >= 0)
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName, 
                    @this.Argument,
                    string.Format(Resources.Strings.The_argument_argName_is_not_within_and_including_the_range_lowerBound_to_upperBound_Format, @this.ArgumentName, lowerBound, upperBound));
            }
            return @this.AssertionPassed();
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
            if (@this.Argument.CompareTo(lowerBound) < 0 || @this.Argument.CompareTo(upperBound) > 0)
            {
                throw new ArgumentOutOfRangeException(
                    @this.ArgumentName, 
                    @this.Argument,
                    string.Format(Resources.Strings.The_argument_argName_is_not_within_the_range_lowerBound_to_upperBound_Format, @this.ArgumentName, lowerBound, upperBound));
            }
            return @this.AssertionPassed();
        }
    }
}
