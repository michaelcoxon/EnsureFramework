using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Provides assertion methods for comparing and evaluating type relationships at runtime.
    /// </summary>
    /// <remarks>The TypeAssertions class offers a set of static methods to verify type equality and
    /// assignability, supporting both generic and non-generic scenarios. These methods are useful for validating type
    /// constraints, performing runtime checks, and writing unit tests that require precise type assertions. All methods
    /// return an IAssertionResult indicating the outcome of the assertion. This class is thread-safe as it contains
    /// only stateless static methods.</remarks>
    public static class TypeAssertions
    {
        /// <summary>
        /// Determines whether the specified source type is equal to the specified type.
        /// </summary>
        /// <param name="source">The type to compare.</param>
        /// <param name="type">The type to compare against.</param>
        /// <returns>true if the source type is equal to the specified type; otherwise, false.</returns>
        public static IAssertionResult Is(Type source, Type type)
        {
            if (source != type)
            {
                return AssertionResult.Fail("Not type");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether instances of the specified type can be assigned to variables of the source type.
        /// </summary>
        /// <param name="source">The target type to compare with. Cannot be null.</param>
        /// <param name="type">The type to test for assignment compatibility with the source type.</param>
        /// <returns>true if an instance of type can be assigned to a variable of the source type; otherwise, false.</returns>
        public static IAssertionResult IsAssignableFrom(Type source, Type type)
        {
            if (!source.IsAssignableFrom(type))
            {
                return AssertionResult.Fail("Not assignable from type");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified source type can be assigned to the specified target type.
        /// </summary>
        /// <param name="source">The type to test for assignment compatibility.</param>
        /// <param name="type">The target type to test assignment compatibility against.</param>
        /// <returns>true if an instance of the source type can be assigned to the target type; otherwise, false.</returns>
        public static IAssertionResult IsAssignableTo(Type source, Type type)
        {         
            if (!type.IsAssignableFrom(source))
            {
                return AssertionResult.Fail("Not assignable to type");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified type is exactly the specified generic type parameter.
        /// </summary>
        /// <remarks>This method performs a strict type comparison and does not consider inheritance or
        /// interface implementation. Use this method when you need to check for an exact type match rather than
        /// assignability.</remarks>
        /// <typeparam name="T">The type to compare against the specified type.</typeparam>
        /// <param name="source">The type to evaluate for equality with the generic type parameter. Cannot be null.</param>
        /// <returns>true if source is exactly the same type as T; otherwise, false.</returns>
        public static IAssertionResult Is<T>(Type source)
        {
            if (source != typeof(T))
            {
                return AssertionResult.Fail("Not type");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified source type can be assigned from the type parameter T.
        /// </summary>
        /// <typeparam name="T">The type to compare with the source type.</typeparam>
        /// <param name="source">The type to test for assignment compatibility with type parameter T. Cannot be null.</param>
        /// <returns>true if the source type is assignable from type parameter T; otherwise, false.</returns>
        public static IAssertionResult IsAssignableFrom<T>(Type source)
        {
            if (!source.IsAssignableFrom(typeof(T)))
            {
                return AssertionResult.Fail("Not assignable from type");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified type can be assigned to a variable of type T.
        /// </summary>
        /// <remarks>Use this method to check type compatibility at runtime, such as when working with
        /// reflection or dynamically loaded types.</remarks>
        /// <typeparam name="T">The target type to check assignability against.</typeparam>
        /// <param name="source">The type to test for assignability to type T. Cannot be null.</param>
        /// <returns>true if an instance of the specified type can be assigned to a variable of type T; otherwise, false.</returns>
        public static IAssertionResult IsAssignableTo<T>(Type source)
        {
            if (!typeof(T).GetTypeInfo().IsAssignableFrom(source))
            {
                return AssertionResult.Fail("Not assignable to type");
            }
            return AssertionResult.Ok;
        }
    }
}
