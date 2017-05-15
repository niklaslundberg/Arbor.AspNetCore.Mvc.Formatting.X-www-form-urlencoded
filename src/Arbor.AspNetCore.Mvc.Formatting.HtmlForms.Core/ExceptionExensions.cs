using System;
using Newtonsoft.Json;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core
{
    internal static class ExceptionExensions
    {
        public static bool ShouldCatch(this Exception ex)
        {
            return ex is FormatException ||
                   ex is ArgumentNullException ||
                   ex is ArgumentException ||
                   ex is JsonSerializationException;
        }
    }
}