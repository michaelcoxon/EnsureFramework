using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class GuidAssertions
    {
        /// <summary>
        /// Ensures the <see cref="Guid" /> argument is not equal to <see cref="Guid.Empty" />.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Guid> IsValidGuid([NotNull] this IArgumentAssertionBuilder<Guid> @this)
        {
            if (@this.Argument == Guid.Empty)
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }
    }
}
