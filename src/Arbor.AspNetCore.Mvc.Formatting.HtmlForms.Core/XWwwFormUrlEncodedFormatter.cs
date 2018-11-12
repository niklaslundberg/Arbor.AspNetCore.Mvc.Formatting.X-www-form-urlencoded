using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core
{
    public class XWwwFormUrlEncodedFormatter : IInputFormatter
    {
        private const string ApplicationXWwwFormUrlencoded = "application/x-www-form-urlencoded";
        private const string FormData = "multipart/form-data";
        private readonly ILogger _logger;

        public XWwwFormUrlEncodedFormatter(ILogger<XWwwFormUrlEncodedFormatter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public static bool IsMultipartContentType(string contentType)
        {
            return !string.IsNullOrEmpty(contentType)
                   && contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public bool CanRead(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            bool isXwwwFormUrlEncoded = context.HttpContext.Request.ContentType.Equals(
                ApplicationXWwwFormUrlencoded,
                StringComparison.OrdinalIgnoreCase);

            bool isMultipartFormData = IsMultipartContentType(context.HttpContext.Request.ContentType);

            bool hasSupportedContentType = isXwwwFormUrlEncoded ||
                                            isMultipartFormData;

            TypeInfo typeInfo = context.ModelType.GetTypeInfo();

            bool canBeDeserialized = typeInfo.IsClass && !typeInfo.IsAbstract;

            bool canRead = hasSupportedContentType && canBeDeserialized;

            _logger.LogDebug("x-www-form-url-encoded {isXwwwFormUrlEncoded}, multipart/form-data {isMultipartFormData}, canBeDeserialized {canBeDeserialized}", isXwwwFormUrlEncoded, isMultipartFormData, canBeDeserialized);

            return canRead;
        }

        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            try
            {
                context.HttpContext.Request.EnableRewind();
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
