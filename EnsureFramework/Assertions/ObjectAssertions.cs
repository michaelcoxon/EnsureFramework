using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

using EnsureFramework;
using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class ObjectAssertions
    {
        public static IAssertionResult IsExactTypeOf(Type sourceType, Type type)
        {
            if (sourceType == type)
            {
                return AssertionResult.Ok;
            }
            return AssertionResult.Fail(string.Format(Resources.Strings.The_value_must_be_of_type_typeName_Format, type));
        }

        public static IAssertionResult IsInheritsTypeOf(Type sourceType, Type type)
        {
            if (sourceType.IsAssignableTo(type))
            {
                return AssertionResult.Ok;
            }
            return AssertionResult.Fail(string.Format(Resources.Strings.The_value_must_inherit_from_type_typeName_Format, type));
        }

        public static IAssertionResult Matches<T>(T source, Func<T, bool> predicate, out Exception? innerException)
        {
            ArgumentNullException.ThrowIfNull(source);
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
                    return AssertionResult.Fail("Predicate did not match.");
                }
            }
            catch (Exception ex)
            {
                innerException = ex;
                return AssertionResult.Fail("An exception occurred.");
            }
        }

        public static IAssertionResult IsOneOf<T>(T source, params T[] options)
        {
            if (!options.Contains(source))
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_value_must_be_one_of_valueList_Format, string.Join("', '", options)));
            }
            return AssertionResult.Ok;
        }
    }
}
