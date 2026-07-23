using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Provides a set of static methods for performing common object assertions, such as null checks, type checks, and
    /// predicate-based validations.
    /// </summary>
    /// <remarks>These assertion methods return an <see cref="IAssertionResult"/> indicating whether the
    /// assertion succeeded or failed, along with an appropriate message. The methods are intended for use in validation
    /// or assurance scenarios where clear, consistent assertion results are required. All methods are thread-safe and do not modify
    /// the input values.</remarks>
    public static class ObjectAssertions
    {
        /// <summary>
        /// Determines whether the specified value is not null and returns an assertion result indicating the outcome.
        /// </summary>
        /// <typeparam name="T">The type of the value to check for nullity.</typeparam>
        /// <param name="this">The value to be checked for null.</param>
        /// <returns>An assertion result that is successful if the value is not null; otherwise, a failed assertion result.</returns>
        public static IAssertionResult IsNotNull<T>(T @this)
        {
            if (@this is null)
            {
                return AssertionResult.Fail("Value should not be null.");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified value is null and returns an assertion result indicating the outcome.
        /// </summary>
        /// <remarks>Use this method to assert that a value is null in test scenarios or validation logic.
        /// The result can be used to provide feedback or control flow based on the nullity of the value.</remarks>
        /// <typeparam name="T">The type of the value to check for null.</typeparam>
        /// <param name="this">The value to evaluate for nullity.</param>
        /// <returns>An assertion result that is successful if the value is null; otherwise, a failed assertion result.</returns>
        public static IAssertionResult IsNull<T>(T @this)
        {
            if (@this is not null)
            {
                return AssertionResult.Fail("Value should be null.");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified source type is exactly the same as the specified target type.
        /// </summary>
        /// <param name="sourceType">The type to compare against the target type. Cannot be null.</param>
        /// <param name="type">The target type to compare to. Cannot be null.</param>
        /// <returns>An assertion result indicating success if the source type is exactly the same as the target type; otherwise,
        /// a failure result.</returns>
        public static IAssertionResult IsExactTypeOf(Type sourceType, Type type)
        {
            ArgumentNullException.ThrowIfNull(sourceType);
            ArgumentNullException.ThrowIfNull(type);

            if (sourceType == type)
            {
                return AssertionResult.Ok;
            }
            return AssertionResult.Fail(string.Format(Resources.Strings.The_value_must_be_of_type_typeName_Format, type));
        }

        /// <summary>
        /// Determines whether the specified source type inherits from or implements the specified type.
        /// </summary>
        /// <param name="sourceType">The type to test for inheritance or interface implementation. Cannot be null.</param>
        /// <param name="type">The base type or interface to check against. Cannot be null.</param>
        /// <returns>An assertion result indicating whether the source type inherits from or implements the specified type.
        /// Returns a successful result if the condition is met; otherwise, a failed result with an appropriate message.</returns>
        public static IAssertionResult IsInheritsTypeOf(Type sourceType, Type type)
        {
            ArgumentNullException.ThrowIfNull(sourceType);
            ArgumentNullException.ThrowIfNull(type);

            if (sourceType.IsAssignableTo(type))
            {
                return AssertionResult.Ok;
            }
            return AssertionResult.Fail(string.Format(Resources.Strings.The_value_must_inherit_from_type_typeName_Format, type));
        }

        /// <summary>
        /// Evaluates whether the specified source object satisfies the given predicate and returns an assertion result
        /// indicating success or failure.
        /// </summary>
        /// <remarks>If the predicate throws an exception, the method returns a failure result and assigns
        /// the exception to the out parameter. This method does not throw exceptions from the predicate to the
        /// caller.</remarks>
        /// <typeparam name="T">The type of the object to evaluate.</typeparam>
        /// <param name="source">The object to test against the predicate.</param>
        /// <param name="predicate">A function that defines the condition to test the source object. Cannot be null.</param>
        /// <param name="message"></param>
        /// <param name="innerException">When this method returns, contains the exception that was thrown by the predicate, if any; otherwise, null.
        /// This parameter is passed uninitialized.</param>
        /// <returns>An assertion result indicating whether the source object satisfies the predicate. Returns a failure result
        /// if the predicate returns false or throws an exception.</returns>
        public static IAssertionResult Matches<T>(T source, Func<T, bool> predicate, string? message, out Exception? innerException)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            try
            {
                innerException = null;
                if (predicate(source))
                {
                    return AssertionResult.Ok;
                }
                else
                {
                    return AssertionResult.Fail(message ?? "Predicate did not match.");
                }
            }
            catch (Exception ex)
            {
                innerException = ex;
                var sb = new StringBuilder();
                if (string.IsNullOrWhiteSpace(message))
                {
                    sb.AppendLine(message);
                }
                sb.AppendLine(ex.Message);
                return AssertionResult.Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Determines whether the specified value is equal to any of the provided options.
        /// </summary>
        /// <remarks>Use this method to assert that a value is one of a predefined set of valid options.
        /// The comparison uses the default equality comparer for the type.</remarks>
        /// <typeparam name="T">The type of the value to compare.</typeparam>
        /// <param name="source">The value to test for membership in the options list.</param>
        /// <param name="options">An array of values to compare against the source value. Cannot be null.</param>
        /// <returns>An assertion result indicating success if the source value matches any of the options; otherwise, a failure
        /// result.</returns>
        public static IAssertionResult IsOneOf<T>(T source, params T[] options)
        {
            if (!options.Contains(source))
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_must_be_one_of_valueList_Format, string.Join("', '", options)));
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Verifies that a value is equal to one of the specified options using the provided equality comparer.
        /// </summary>
        /// <typeparam name="T">The type of the value to verify and the options.</typeparam>
        /// <param name="source">The value to verify.</param>
        /// <param name="equalityComparer">The equality comparer to use for comparing values.</param>
        /// <param name="options">The collection of valid options.</param>
        /// <returns>An assertion result indicating success if the value is one of the options, or failure otherwise.</returns>
        public static IAssertionResult IsOneOf<T>(T source, IEqualityComparer<T> equalityComparer, params T[] options)
        {
            if (!options.Contains(source, equalityComparer))
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_must_be_one_of_valueList_Format, string.Join("', '", options)));
            }
            return AssertionResult.Ok;
        }
    }
}
