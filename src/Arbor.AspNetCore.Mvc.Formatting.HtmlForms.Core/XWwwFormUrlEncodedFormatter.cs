using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;

namespace Arbor.AspNetCore.Formatting.HtmlForms.Core
{
    public class XWwwFormUrlEncodedFormatter : IInputFormatter
    {
        private readonly ILogger _logger;

        public XWwwFormUrlEncodedFormatter(ILogger<XWwwFormUrlEncodedFormatter> logger)
        {
            _logger = logger;
        }
        private const string ApplicationXWwwFormUrlencoded = "application/x-www-form-urlencoded";

        public bool CanRead(InputFormatterContext context)
        {
            bool mediaType = context.HttpContext.Request.ContentType.Equals(ApplicationXWwwFormUrlencoded,
                StringComparison.OrdinalIgnoreCase);

            TypeInfo typeInfo = context.ModelType.GetTypeInfo();

            return mediaType && typeInfo.IsClass && !typeInfo.IsAbstract;
        }

        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            try
            {
                IFormCollection form = await context.HttpContext.Request.ReadFormAsync();

                object model = form.ParseFromCollection(context.ModelType);

                return InputFormatterResult.Success(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(1000), ex, "Could not create type {ModelType}", context.ModelType.Name);
                return InputFormatterResult.Failure();
            }
        }
    }
}