using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InsuranceServiceApp.Utility
{
    public static class GlobalFunctions
    {
        public static string GetModelStateErrors(ModelStateDictionary modelState)
        {
            return string.Join("; ", modelState.Values
                         .SelectMany(v => v.Errors)
                         .Select(e => e.ErrorMessage));
        }
    }
}
