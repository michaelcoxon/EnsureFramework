using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Ensure assertions for <see cref="IComparable{T}"/>'s
    /// </summary>
    public static class CompareAssertions
    {
        /// <summary>
        /// Determines whether the current value is greater than or equal to the specified value.
        /// </summary>
        /// <typeparam name="T">The type of the values to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="source">The value to compare against <paramref name="value"/>. Cannot be null.</param>
        /// <param name="value">The value to compare to the current value.</param>
        /// <returns><see langword="true"/> if the current value is greater than or equal to <paramref name="value"/>; otherwise,
        /// <see langword="false"/>.</returns>
        public static IAssertionResult IsGreaterThanOrEqualTo<T>(T? source, T value)
            where T : IComparable<T>
        {
            if (source is null || source.CompareTo(value) < 0)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_is_not_greater_than_or_equal_to_value_Format, value));
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the current object is less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="source">The object to compare to the specified value. Cannot be null.</param>
        /// <param name="value">The value to compare with the current object.</param>
        /// <returns><see langword="true"/> if the current object is less than or equal to <paramref name="value"/>; otherwise,
        /// <see langword="false"/>.</returns>
        public static IAssertionResult IsLessThanOrEqualTo<T>(T? source, T value)
            where T : IComparable<T>
        {
            if (source is null || source.CompareTo(value) > 0)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_is_not_greater_than_or_equal_to_value_Format, value));
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the current object is less than the specified value using the default comparer.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="source">The object to compare.</param>
        /// <param name="value">The value to compare against the current object.</param>
        /// <returns><see langword="true"/> if the current object is less than <paramref name="value"/>; otherwise, <see
        /// langword="false"/>.</returns>
        public static IAssertionResult IsLessThan<T>(T? source, T value)
            where T : IComparable<T>
        {
            if (source is null || source.CompareTo(value) != -1)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_is_not_less_than_value_Format, value));
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the current object is greater than the specified value using the default comparer.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="source">The object to compare.</param>
        /// <param name="value">The value to compare against the current object.</param>
        /// <returns><see langword="true"/> if the current object is greater than <paramref name="value"/>; otherwise, <see
        /// langword="false"/>.</returns>
        public static IAssertionResult IsGreaterThan<T>(T? source, T value)
            where T : IComparable<T>
        {
            if (source is null || source.CompareTo(value) != 1)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_is_not_greater_than_value_Format, value));
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the current object is equal to the specified value using the default comparison logic.
        /// </summary>
        /// <remarks>This method uses the <see cref="IComparable{T}.CompareTo(T)"/> implementation of
        /// <typeparamref name="T"/> to determine equality. It is an extension method and can be called on any object of
        /// type <typeparamref name="T"/> that implements <see cref="IComparable{T}"/>.</remarks>
        /// <typeparam name="T">The type of objects to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="source">The object to compare.</param>
        /// <param name="value">The value to compare with the current object.</param>
        /// <returns><see langword="true"/> if the current object is equal to <paramref name="value"/>; otherwise, <see
        /// langword="false"/>.</returns>
        public static IAssertionResult IsEqualTo<T>(T? source, T value)
            where T : IComparable<T>
        {
            if (source is null || source.CompareTo(value) != 0)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_is_not_equal_to_value_Format, value));
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the current value is strictly within the specified lower and upper bounds.
        /// </summary>
        /// <remarks>The comparison is exclusive; the method returns false if the value is equal to either
        /// bound. The method uses the default comparer for type T.</remarks>
        /// <typeparam name="T">The type of the values to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="source">The value to test for inclusion within the specified range.</param>
        /// <param name="lowerBound">The exclusive lower bound of the range. The value must be greater than this bound to be considered within
        /// range.</param>
        /// <param name="upperBound">The exclusive upper bound of the range. The value must be less than this bound to be considered within
        /// range.</param>
        /// <returns>true if the value is greater than the lower bound and less than the upper bound; otherwise, false.</returns>
        public static IAssertionResult IsWithinRange<T>(T? source, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (source is null || source.CompareTo(lowerBound) <= 0 || source.CompareTo(upperBound) >= 0)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_is_not_within_and_including_the_range_lowerBound_to_upperBound_Format, lowerBound, upperBound));
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the current value is greater than or equal to the specified lower bound and less than or
        /// equal to the specified upper bound.
        /// </summary>
        /// <remarks>The comparison uses the <see cref="IComparable{T}.CompareTo(T)"/> method. Both bounds
        /// are inclusive. No validation is performed to ensure that lowerBound is less than or equal to
        /// upperBound.</remarks>
        /// <typeparam name="T">The type of the values to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="source">The value to test for inclusion within the specified range.</param>
        /// <param name="lowerBound">The inclusive lower bound of the range.</param>
        /// <param name="upperBound">The inclusive upper bound of the range.</param>
        /// <returns>true if the value is within the specified range, including the lower and upper bounds; otherwise, false.</returns>
        public static IAssertionResult IsWithinAndIncludingRange<T>(T? source, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (source is null || source.CompareTo(lowerBound) < 0 || source.CompareTo(upperBound) > 0)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_is_not_within_the_range_lowerBound_to_upperBound_Format, lowerBound, upperBound));
            }
            return AssertionResult.Ok;
        }
    }
}
