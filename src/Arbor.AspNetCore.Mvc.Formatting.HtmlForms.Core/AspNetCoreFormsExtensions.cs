using System;
using Arbor.ModelBinding.Core;
using Microsoft.AspNetCore.Http;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms
{
    public static class AspNetCoreFormsExtensions
    {
        public static T? ParseFromCollection<T>(this IFormCollection formDataCollection) where T : class
        {
            if (formDataCollection == null)
            {
                throw new ArgumentNullException(nameof(formDataCollection));
            }

            return ParseFromCollection(formDataCollection, typeof(T)) as T;
        }

        public static object ParseFromCollection(this IFormCollection formDataCollection, Type targetType)
        {
            if (formDataCollection == null)
            {
                throw new ArgumentNullException(nameof(formDataCollection));
            }

            if (targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType));
            }

            return FormsExtensions.ParseFromPairs(formDataCollection, targetType);
        }
    }
}
