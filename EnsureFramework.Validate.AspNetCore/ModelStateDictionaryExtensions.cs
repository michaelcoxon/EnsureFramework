namespace EnsureFramework
{
    using EnsureFramework.Results;

    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public static class ModelStateDictionaryExtensions
    {
        public static ModelStateDictionary Apply<T>(this ModelStateDictionary @this, IValidationResult<T> validationResult)
        {
            if (validationResult.IsError)
            {
                foreach (var error in validationResult.AssertionResults.Where(r => !r.Success))
                {
                    @this.AddModelError(GetKeyForModelStateDictionary(validationResult.Name), error.Message);
                }
            }
            return @this;
        }

        public static IValidationResult<T> ApplyTo<T>(this IValidationResult<T> @this, ModelStateDictionary modelState)
        {
            if (@this.IsError)
            {
                foreach (var error in @this.AssertionResults.Where(r => !r.Success))
                {
                    modelState.AddModelError(GetKeyForModelStateDictionary(@this.Name), error.Message);
                }
            }
            return @this;
        }

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
