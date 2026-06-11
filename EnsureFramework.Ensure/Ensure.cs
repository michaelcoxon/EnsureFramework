using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Results;

namespace EnsureFramework
{
    /// <summary>
    /// The core assertion entry point
    /// </summary>
    [DebuggerNonUserCode]
    public static class Ensure
    {
        /// <summary>
        /// Creates an assertion builder for the specified argument, ensuring that the argument is not null.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="arg">The argument value to validate. Cannot be null.</param>
        /// <param name="argName">The name of the argument to use in exception messages. If not specified, the compiler will supply the
        /// expression used for the argument.</param>
        /// <returns>An assertion builder that can be used to perform additional validations on the argument.</returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>([NotNull] T? arg, [CallerArgumentExpression(nameof(arg))] string? argName = null)
        {
            ArgumentNullException.ThrowIfNull(arg, argName);
            return new ArgumentAssertionBuilder<T>(arg, argName, [("NotNull", AssertionResult.Fail("Value is null."))]);
        }

        /// <summary>
        /// Creates an assertion builder for a non-nullable value type argument, ensuring the argument is not null.
        /// </summary>
        /// <remarks>Use this method to begin a fluent validation chain for value type arguments that may
        /// be nullable. If the argument is null, an ArgumentNullException is thrown before any further validation can
        /// occur.</remarks>
        /// <typeparam name="T">The value type of the argument to be validated.</typeparam>
        /// <param name="arg">The value type argument to validate. Must not be null.</param>
        /// <param name="argName">The name of the argument to include in exception messages. This parameter is optional and is automatically
        /// provided by the compiler.</param>
        /// <returns>An assertion builder that can be used to perform further validations on the specified argument.</returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>([NotNull] T? arg, [CallerArgumentExpression(nameof(arg))] string? argName = null)
            where T : struct
        {
            ArgumentNullException.ThrowIfNull(arg, argName);
            return new ArgumentAssertionBuilder<T>(arg.Value, argName, [("NotNull", AssertionResult.Fail("Value is null."))]);
        }

        /// <summary>
        /// Throws an exception if the specified argument is not null.
        /// </summary>
        /// <remarks>Use this method to enforce that an argument is null in scenarios where null is
        /// required, such as for parameter validation in APIs that expect null values.</remarks>
        /// <param name="arg">The argument to validate as null.</param>
        /// <param name="argName">The name of the argument to include in the exception message. This value is typically provided automatically
        /// by the compiler.</param>
        /// <exception cref="ArgumentException">Thrown if the argument is not null.</exception>
        [DebuggerNonUserCode]        
        public static void ArgIsNull(object? arg, [CallerArgumentExpression(nameof(arg))] string? argName = null)
        {
            if (arg is not null)
            {
                throw new ArgumentException($"Expected a null value for '{argName}'.", argName);
            }
        }
    }
}
