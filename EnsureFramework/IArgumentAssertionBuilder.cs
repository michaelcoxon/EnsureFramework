using System;
using System.Collections.Generic;
using System.Text;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Interface that allows the extension of the <see cref="Ensure"/> class.
    /// </summary>
    public interface IArgumentAssertionBuilder<out T> : IArgumentAssertionBuilder
    {
        /// <summary>
        /// Gets the argument.
        /// </summary>
        new T Argument { get; }
    }

    /// <summary>
    /// Interface that allows the extension of the <see cref="Ensure"/> class.
    /// </summary>
    public interface IArgumentAssertionBuilder
    {
        /// <summary>
        /// Gets the argument.
        /// </summary>
        object Argument { get; }

        /// <summary>
        /// Gets the name of the argument.
        /// </summary>
        string ArgumentName { get; }
    }

}
