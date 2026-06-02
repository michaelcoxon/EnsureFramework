namespace EnsureFramework.Assertions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides assertion methods for validating <see cref="System.Guid"/> values.
    /// </summary>
    public static class GuidAssertions
    {
        /// <summary>
        /// Determines whether the specified <see cref="Guid"/> value is not empty.
        /// </summary>
        /// <param name="this">The <see cref="Guid"/> value to validate.</param>
        /// <returns><see langword="true"/> if the specified <see cref="Guid"/> is not <see cref="Guid.Empty"/>; otherwise, <see
        /// langword="false"/>.</returns>
        public static bool IsValidGuid(Guid @this)
        {
            return @this != Guid.Empty;
        }
    }
}
