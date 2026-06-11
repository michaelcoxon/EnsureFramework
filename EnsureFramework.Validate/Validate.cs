namespace EnsureFramework
{
    using System.Runtime.CompilerServices;

    using EnsureFramework.Results;

    /// <summary>
    /// Provides static methods for initiating validation of objects and values.
    /// </summary>
    /// <remarks>The Validate class serves as an entry point for fluent validation operations. It is designed
    /// to be used in conjunction with validation result types to enable expressive and type-safe validation
    /// patterns.</remarks>
    public static class Validate
    {
        /// <summary>
        /// Creates a validation result for the specified value, enabling fluent validation of the provided object.
        /// </summary>
        /// <remarks>Use this method as the entry point for fluent validation scenarios. The returned
        /// result can be chained with additional validation methods to build complex validation logic.</remarks>
        /// <typeparam name="T">The type of the value to validate.</typeparam>
        /// <param name="source">The value to be validated. Can be null for reference types or nullable value types.</param>
        /// <param name="sourceName">The name of the argument to use in validation messages. This is automatically supplied by the compiler and
        /// is optional.</param>
        /// <returns>An object that represents the validation result for the specified value, allowing further validation
        /// operations.</returns>
        public static IValidationResult<T> That<T>(T? source, [CallerArgumentExpression(nameof(source))] string? sourceName = null)
        {
            return new ValidationResult<T>
            {
                Name = sourceName,
                Value = source
            };
        }
    }
}
