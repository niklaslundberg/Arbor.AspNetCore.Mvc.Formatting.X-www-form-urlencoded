using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Arbor.AspNetCore.Formatting.HtmlForms.Core
{
    public static class FormsExtensions
    {
        public static T ParseFromCollection<T>(this IFormCollection formDataCollection) where T : class
        {
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

            var dynamicObject = new ExpandoObject();

            IDictionary<string, object> dynamicObjectDictionary = dynamicObject;

            IEnumerable<KeyValuePair<string, StringValues>> singleValuePairs =
                formDataCollection.Where(pairGroup => pairGroup.Value.Count == 1);

            foreach (KeyValuePair<string, StringValues> keyValuePair in singleValuePairs)
            {
                dynamicObjectDictionary[keyValuePair.Key] = keyValuePair.Value.Single();
            }

            IEnumerable<KeyValuePair<string, StringValues>> multipleValuesPairs =
                formDataCollection.Where(pairGroup => pairGroup.Value.Count >= 2);

            foreach (KeyValuePair<string, StringValues> keyValuePair in multipleValuesPairs)
            {
                string[] values = keyValuePair.Value;

                dynamicObjectDictionary[keyValuePair.Key] = values;
            }

            string json = JsonConvert.SerializeObject(dynamicObject);

            try
            {
                object instance = JsonConvert.DeserializeObject(json, targetType);

                return instance;
            }
            catch (JsonSerializationException ex)
            {
                throw new InvalidOperationException(
                    $"Could not deserialize type {targetType} from JSON '{json}'", ex);
            }
        }
    }
}