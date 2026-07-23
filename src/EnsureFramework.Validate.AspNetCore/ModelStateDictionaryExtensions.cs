namespace EnsureFramework
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using EnsureFramework.Results;

    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// Provides extension methods for integrating validation results with <see cref="ModelStateDictionary"/>.
    /// </summary>
    public static class ModelStateDictionaryExtensions
    {
        /// <summary>
        /// Applies validation errors from a validation result to the <see cref="ModelStateDictionary"/>.
        /// </summary>
        /// <typeparam name="T">The type being validated.</typeparam>
        /// <param name="this">The <see cref="ModelStateDictionary"/> to add errors to.</param>
        /// <param name="validationResult">The validation result containing potential errors.</param>
        /// <returns>The <see cref="ModelStateDictionary"/> with validation errors added.</returns>
        public static ModelStateDictionary Apply<T>(this ModelStateDictionary @this, IValidationResult<T> validationResult)
        {
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(validationResult);

            if (validationResult.IsError)
            {
                foreach (var error in validationResult.AssertionResults.Where(r => !r.Success))
                {
                    @this.AddModelError(GetKeyForModelStateDictionary(validationResult.Name), error.Message);
                }
            }
            return @this;
        }

        /// <summary>
        /// Applies validation errors from the validation result to a <see cref="ModelStateDictionary"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value being validated.</typeparam>
        /// <param name="this">The validation result containing potential errors.</param>
        /// <param name="modelState">The <see cref="ModelStateDictionary"/> to which validation errors will be added.</param>
        /// <returns>The original validation result for method chaining.</returns>
        public static IValidationResult<T> ApplyTo<T>(this IValidationResult<T> @this, ModelStateDictionary modelState)
        {
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(modelState);

            if (@this.IsError)
            {
                foreach (var error in @this.AssertionResults.Where(r => !r.Success))
                {
                    modelState.AddModelError(GetKeyForModelStateDictionary(@this.Name), error.Message);
                }
            }
            return @this;
        }

        /// <summary>
        /// Extracts the portion of a name after the first dot separator for use as a <see cref="ModelStateDictionary"/> key.
        /// </summary>
        /// <param name="name">The hierarchical name to process, which may contain dot-separated segments.</param>
        /// <returns>The substring after the first dot, or an empty string if no dot exists or the name is null.</returns>
        public static string GetKeyForModelStateDictionary(string? name)
        {
            if (name is null)
            {
                return string.Empty;
            }

            var splits = name.Split(['.'], 2);

            if (splits.Length > 1)
            {
                return splits.LastOrDefault() ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
