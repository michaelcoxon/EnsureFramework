using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Assertions;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class GuidAssertionExtenstions
    {
        /// <summary>
        /// Ensures the <see cref="Guid" /> argument is not equal to <see cref="Guid.Empty" />.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Guid> IsValidGuid([NotNull] this IArgumentAssertionBuilder<Guid> @this)
        {
            var result = GuidAssertions.IsValidGuid(@this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }
    }
}
