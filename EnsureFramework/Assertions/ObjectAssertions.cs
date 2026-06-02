using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

using EnsureFramework;
using EnsureFramework.ArgumentAssertionBuilder;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class ObjectAssertions
    {
        public static bool IsExactTypeOf<T>(Type type)
        {
            return typeof(T) == type;
        }

        public static bool IsInheritsTypeOf<T>(Type type)
        {
            return typeof(T).IsAssignableTo(type);
        }

        public static bool Matches<T>(T source, Func<T, bool> predicate, out Exception? innerException)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            try
            {
                innerException = null;
                return predicate(source);
            }
            catch (Exception ex)
            {
                innerException = ex;
                return false;
            }
        }

        public static bool IsOneOf<T>(T source, params T[] options)
        {
            if (!options.Contains(source))
            {
                return false;
            }
            return true;
        }
    }
}
