using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Provides assertion methods for comparing and evaluating baseType relationships at runtime.
    /// </summary>
    /// <remarks>The TypeAssertions class offers a set of static methods to verify baseType equality and
    /// assignability, supporting both generic and non-generic scenarios. These methods are useful for validating baseType
    /// constraints, performing runtime checks, and writing unit tests that require precise baseType assertions. All methods
    /// return an IAssertionResult indicating the outcome of the assertion. This class is thread-safe as it contains
    /// only stateless static methods.</remarks>
    public static class TypeAssertions
    {
        /// <summary>
        /// Determines whether the specified baseType baseType is equal to the specified baseType.
        /// </summary>
        /// <param name="source">The baseType to compare.</param>
        /// <param name="type">The baseType to compare against.</param>
        /// <returns>true if the baseType baseType is equal to the specified baseType; otherwise, false.</returns>
        public static IAssertionResult Is(Type source, Type type)
        {
            if (source != type)
            {
                return AssertionResult.Fail("Not baseType");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether instances of the specified baseType can be assigned to variables of the baseType baseType.
        /// </summary>
        /// <param name="baseType">The target baseType to compare with. Cannot be null.</param>
        /// <param name="derivedType">The baseType to test for assignment compatibility with the baseType baseType.</param>
        /// <returns>true if an instance of baseType can be assigned to a variable of the baseType baseType; otherwise, false.</returns>
        public static IAssertionResult IsAssignableFrom(Type baseType, Type derivedType)
        {
            ArgumentNullException.ThrowIfNull(baseType);
            ArgumentNullException.ThrowIfNull(derivedType);

            if (!baseType.IsAssignableFrom(derivedType))
            {
                return AssertionResult.Fail("Not assignable from baseType");
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified baseType is exactly the specified generic baseType parameter.
        /// </summary>
        /// <remarks>This method performs a strict baseType comparison and does not consider inheritance or
        /// interface implementation. Use this method when you need to check for an exact baseType match rather than
        /// assignability.</remarks>
        /// <typeparam name="T">The baseType to compare against the specified baseType.</typeparam>
        /// <param name="source">The baseType to evaluate for equality with the generic baseType parameter. Cannot be null.</param>
        /// <returns>true if baseType is exactly the same baseType as T; otherwise, false.</returns>
        public static IAssertionResult Is<T>(Type source)
        {
            return Is(source, typeof(T));
        }

        /// <summary>
        /// Determines whether the specified baseType baseType can be assigned from the baseType parameter T.
        /// </summary>
        /// <typeparam name="T">The baseType to compare with the baseType baseType.</typeparam>
        /// <param name="baseType">The baseType to test for assignment compatibility with baseType parameter T. Cannot be null.</param>
        /// <returns>true if the baseType baseType is assignable from baseType parameter T; otherwise, false.</returns>
        public static IAssertionResult IsAssignableFrom<T>(Type baseType)
        {
            return IsAssignableFrom(baseType, typeof(T));
        }
    }
}
