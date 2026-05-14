using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EnsureFramework
{
    /// <summary>
    /// Interface that allows the extension of the <see cref="Ensure"/> class.
    /// </summary>
    public interface IArgumentAssertionBuilder<out T> : IArgumentAssertionBuilder
    {
        /// <summary>
        /// Gets the argument.
        /// </summary>
        [NotNull] new T Argument { get; }
    }

    /// <summary>
    /// Interface that allows the extension of the <see cref="Ensure"/> class.
    /// </summary>
    public interface IArgumentAssertionBuilder
    {
        /// <summary>
        /// Gets the argument.
        /// </summary>
        [NotNull] object Argument { get; }

        /// <summary>
        /// Gets the name of the argument.
        /// </summary>
        string? ArgumentName { get; }
    }
}
