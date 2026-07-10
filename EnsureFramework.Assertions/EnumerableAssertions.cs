using System.Collections;
using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Provides assertion and utility methods for evaluating conditions on non-generic and generic enumerable
    /// collections.
    /// </summary>
    /// <remarks>This static class offers a set of methods to check for common conditions such as emptiness,
    /// containment, and predicate satisfaction on collections implementing <see cref="IEnumerable"/> or <see
    /// cref="IEnumerable{T}"/>. The methods are designed to simplify assertions and checks in code that works with
    /// collections, supporting both generic and non-generic scenarios.</remarks>
    public static class EnumerableAssertions
    {
        /// <summary>
        /// Determines whether the specified sequence contains at least one element.
        /// </summary>
        /// <param name="source">The sequence to check for elements. Cannot be null.</param>
        /// <returns>true if the sequence contains at least one element; otherwise, false.</returns>
        public static IAssertionResult IsNotEmpty(IEnumerable? source)
        {
            if (source is not null)
            {
                foreach (var _ in source)
                {
                    return AssertionResult.Ok;
                }
            }

            return AssertionResult.Fail(Resources.Strings.No_items);
        }

        /// <summary>
        /// Determines whether the specified sequence contains at least one element.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="source">The sequence to check for elements. Cannot be null.</param>
        /// <returns><see langword="true"/> if the sequence contains at least one element; otherwise, <see langword="false"/>.</returns>
        public static IAssertionResult IsNotEmpty<T>(IEnumerable<T>? source)
        {
            if (source is null || !source.Any())
            {
                return AssertionResult.Fail(Resources.Strings.No_items);
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified sequence contains a specific element.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="source">The sequence in which to locate the specified element. Cannot be null.</param>
        /// <param name="item">The element to locate in the sequence.</param>
        /// <returns>true if the sequence contains the specified element; otherwise, false.</returns>
        public static IAssertionResult Contains<T>(IEnumerable<T>? source, T item)
        {
            if (source is null || !source.Contains(item))
            {
                return AssertionResult.Fail(Resources.Strings.Item_is_not_in_enumerable);
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified item exists within the given non-generic sequence.
        /// </summary>
        /// <remarks>This method performs a linear search using the default equality comparison. The
        /// method does not use generic type information and is intended for use with non-generic sequences
        /// implementing IEnumerable.</remarks>
        /// <param name="source">The non-generic sequence to search. Cannot be null.</param>
        /// <param name="item">The object to locate in the sequence. The search uses the default equality comparison.</param>
        /// <returns>true if the item is found in the sequence; otherwise, false.</returns>
        public static IAssertionResult Contains(IEnumerable? source, object item)
        {
            if (source is not null)
            {
                foreach (var item2 in source)
                {
                    if (Equals(item, item2))
                    {
                        return AssertionResult.Ok;
                    }
                }
            }
            return AssertionResult.Fail(Resources.Strings.Item_is_not_in_enumerable);
        }

        /// <summary>
        /// Determines whether any element of a sequence satisfies a specified condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="source">The sequence of elements to apply the predicate to. Cannot be null.</param>
        /// <param name="predicate">A function to test each element for a condition. Cannot be null.</param>
        /// <returns>true if any elements in the source sequence satisfy the condition in the predicate; otherwise, false.</returns>
        public static IAssertionResult Any<T>(IEnumerable<T>? source, Func<T, bool> predicate)
        {
            if (source is null || !source.Any(predicate))
            {
                return AssertionResult.Fail(Resources.Strings.No_items_match_the_predicate);
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether any element of a non-generic sequence satisfies a specified condition.
        /// </summary>
        /// <remarks>Use this method to determine whether at least one element in a non-generic sequence
        /// meets a specific condition. This method enumerates the sequence and stops as soon as the predicate returns
        /// true for any element.</remarks>
        /// <param name="source">The non-generic sequence to apply the predicate to. Cannot be null.</param>
        /// <param name="predicate">A function to test each element for a condition. Cannot be null.</param>
        /// <returns>true if any element in the sequence satisfies the condition specified by the predicate; otherwise, false.</returns>
        public static IAssertionResult Any(IEnumerable? source, Func<object, bool> predicate)
        {
            if (source is not null)
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        return AssertionResult.Ok;
                    }
                }
            }
            return AssertionResult.Fail(Resources.Strings.No_items_match_the_predicate);
        }

        /// <summary>
        /// Determines whether all elements of a sequence satisfy a specified condition.
        /// </summary>
        /// <remarks>Enumeration is terminated as soon as the result can be determined. If the sequence is
        /// empty, the method returns true.</remarks>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="source">The sequence of elements to test against the predicate. Cannot be null.</param>
        /// <param name="predicate">A function to test each element for a condition. Cannot be null.</param>
        /// <returns>true if every element of the source sequence passes the test in the specified predicate, or if the sequence
        /// is empty; otherwise, false.</returns>
        public static IAssertionResult All<T>(IEnumerable<T>? source, Func<T, bool> predicate)
        {
            if (source is null || !source.All(predicate))
            {
                return AssertionResult.Fail(Resources.Strings.All_items_do_not_match_the_predicate);
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether all elements of a non-generic sequence satisfy a specified condition.
        /// </summary>
        /// <remarks>This method enumerates the entire sequence to determine whether all elements
        /// satisfy the condition. If the sequence is empty, the method returns true.</remarks>
        /// <param name="source">The non-generic sequence whose elements to test against the predicate.</param>
        /// <param name="predicate">A function to test each element for a condition. Cannot be null.</param>
        /// <returns>true if every element of the sequence passes the test in the specified predicate, or if the sequence is
        /// empty; otherwise, false.</returns>
        public static IAssertionResult All(IEnumerable? source, Func<object, bool> predicate)
        {
            if (source is not null)
            {
                foreach (var item in source)
                {
                    if (!predicate(item))
                    {
                        return AssertionResult.Fail(Resources.Strings.All_items_do_not_match_the_predicate);
                    }
                }
            }
            return AssertionResult.Ok;
        }
    }
}
