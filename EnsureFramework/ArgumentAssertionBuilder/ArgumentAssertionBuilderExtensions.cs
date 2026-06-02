namespace EnsureFramework.ArgumentAssertionBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides extension methods for the <see cref="IArgumentAssertionBuilder{T}"/> interface to support custom assertion
    /// tracking, generally used for debugging purposes.
    /// </summary>
    /// <remarks>These extension methods enable additional functionality for argument assertion builders, such
    /// as marking assertions as passed. They are intended to be used in conjunction with the
    /// <see cref="ArgumentAssertionBuilder{T}"/> implementation.</remarks>
    public static class ArgumentAssertionBuilderExtensions
    {
        /// <summary>
        /// Marks the current assertion as passed in the argument assertion builder chain.
        /// </summary>
        /// <remarks>This method is intended for use within custom assertion extensions to indicate that a
        /// specific assertion has succeeded. It does not perform any validation itself.</remarks>
        /// <typeparam name="T">The type of the argument being asserted.</typeparam>
        /// <param name="this">The argument assertion builder to update.</param>
        /// <param name="assertionName">The name of the assertion to mark as passed. If not specified, the caller member name is used.</param>
        /// <returns>The same argument assertion builder instance, enabling method chaining.</returns>
        public static IArgumentAssertionBuilder<T> AssertionPassed<T>(this IArgumentAssertionBuilder<T> @this, [CallerMemberName] string? assertionName = null)
        {
            if (@this is ArgumentAssertionBuilder<T> aab)
            {
                aab.PassedAssertions.Add(assertionName ?? "<unknown>");
            }
            return @this;
        }
    }
}
