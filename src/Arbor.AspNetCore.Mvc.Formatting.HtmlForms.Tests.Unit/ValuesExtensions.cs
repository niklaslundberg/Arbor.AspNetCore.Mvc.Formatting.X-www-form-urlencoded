using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit
{
    public static class ValuesExtensions
    {
        public static string AsXwwwFormUrlEncoded(this IEnumerable<KeyValuePair<string, string>> values)
        {
            string xWwwFormUrlEncodedData = string.Join("&",
                values.Select(value => string.Format("{0}={1}", value.Key, Uri.EscapeDataString(value.Value))));

            return xWwwFormUrlEncodedData;
        }

        public static Stream ToInMemoryStream(this string xWwwFormUrlEncodedData)
        {
            byte[] dataAsBytes = Encoding.UTF8.GetBytes(xWwwFormUrlEncodedData);

            var stream = new MemoryStream(dataAsBytes);

            return stream;
        }
    }
}