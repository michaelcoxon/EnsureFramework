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
        /// Verifies that two types are identical.
        /// </summary>
        /// <param name="source">The type to verify.</param>
        /// <param name="type">The expected type.</param>
        /// <returns>An assertion result indicating success if the types are identical, or failure otherwise.</returns>
        public static IAssertionResult IsExactType(Type source, Type type)
        {
            if (source != type)
            {
                return AssertionResult.Fail("Not same type");
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
    }
}
