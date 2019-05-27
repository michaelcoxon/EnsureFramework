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

    /// <summary>
    /// Interface that allows the extension of the <see cref="Ensure"/> class.
    /// </summary>
    public interface INestedArgumentAssertionBuilder<TParentAssertion, out T> : INestedArgumentAssertionBuilder<TParentAssertion>, IArgumentAssertionBuilder<T>
        where TParentAssertion: IArgumentAssertionBuilder
    {
    }

    /// <summary>
    /// Interface that allows the extension of the <see cref="Ensure"/> class.
    /// </summary>
    public interface INestedArgumentAssertionBuilder<TParentAssertion> : IArgumentAssertionBuilder
         where TParentAssertion : IArgumentAssertionBuilder
    {
        /// <summary>
        /// Pop the context back to the parent assertion
        /// </summary>
        TParentAssertion Pop();
    }
}
