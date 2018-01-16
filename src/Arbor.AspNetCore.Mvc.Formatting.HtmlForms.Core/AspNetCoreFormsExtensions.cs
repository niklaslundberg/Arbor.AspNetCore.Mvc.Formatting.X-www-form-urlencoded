using System;
using Microsoft.AspNetCore.Http;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core
{
    public static class AspNetCoreFormsExtensions
    {
        public static T ParseFromCollection<T>(this IFormCollection formDataCollection) where T : class
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

            return ModelBinding.Core.FormsExtensions.ParseFromPairs(formDataCollection, targetType);
        }
    }
}
