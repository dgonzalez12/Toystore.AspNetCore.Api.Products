using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Toystore.AspNetCore.Api.Products.Util
{
    public static class ModelStateDictionaryExtension
    {
        public static string GetErrors(this ModelStateDictionary modelState)
        {
            if (modelState == null)
            {
                return string.Empty;
            }
            var entries = modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            var errors = string.Join("; ", entries);
            return errors;
        }
    }
}
