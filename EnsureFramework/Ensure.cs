using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

using EnsureFramework.Assertions;
using EnsureFramework.Resources;

namespace EnsureFramework
{
    /// <summary>
    /// The core assertion entry point
    /// </summary>
    [DebuggerNonUserCode]
    public sealed class Ensure
    {
        [DebuggerNonUserCode]
        private class ArgumentAssertionBuilder<T> : IArgumentAssertionBuilder<T>
        {
            public T? Argument { get; set; }

            public string? ArgumentName { get; set; }

            object? IArgumentAssertionBuilder.Argument => this.Argument;
        }

        /// <summary>
        /// Provides the helpers for validation
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>([NotNull] T? arg, [CallerArgumentExpression(nameof(arg))] string? argName = null)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(argName);
            }

            return new ArgumentAssertionBuilder<T>
            {
                Argument = arg,
                ArgumentName = argName,
            };
        }

        /// <summary>
        /// Provides the helpers for validation
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>([NotNull] T? arg, [CallerArgumentExpression(nameof(arg))] string? argName = null)
            where T : struct
        {
            if (!arg.HasValue)
            {
                throw new ArgumentNullException(argName);
            }

            return new ArgumentAssertionBuilder<T>
            {
                Argument = arg.Value,
                ArgumentName = argName,
            };
        }
    }
}
