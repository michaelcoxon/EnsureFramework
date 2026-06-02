using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Resources;

namespace EnsureFramework
{
    /// <summary>
    /// The core assertion entry point
    /// </summary>
    [DebuggerNonUserCode]
    public static class Ensure
    {
        [DebuggerNonUserCode]
        internal sealed class ArgumentAssertionBuilder<T> : IArgumentAssertionBuilder<T>
        {
            [DisallowNull]
            public required T Argument { get; set; }

            public string? ArgumentName { get; set; }

            public List<string> PassedAssertions { get; } = [];
        }

        /// <summary>
        /// Ensures that the <paramref name="arg"/> is not null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>([NotNull] T? arg, [CallerArgumentExpression(nameof(arg))] string? argName = null)
        {
            ArgumentNullException.ThrowIfNull(arg, argName);

            return new ArgumentAssertionBuilder<T>
            {
                Argument = arg,
                ArgumentName = argName,
            }.AssertionPassed("NotNull");
        }

        /// <summary>
        /// Ensures that the <paramref name="arg"/> is not null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>([NotNull] T? arg, [CallerArgumentExpression(nameof(arg))] string? argName = null)
            where T : struct
        {
            ArgumentNullException.ThrowIfNull(arg, argName);

            return new ArgumentAssertionBuilder<T>
            {
                Argument = arg.Value,
                ArgumentName = argName,
            }.AssertionPassed("NotNull");
        }

    }
}
