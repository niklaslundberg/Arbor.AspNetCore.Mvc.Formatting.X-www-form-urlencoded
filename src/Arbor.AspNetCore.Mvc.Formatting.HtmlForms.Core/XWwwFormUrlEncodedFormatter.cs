using System;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core
{
    public class XWwwFormUrlEncodedFormatter : IInputFormatter
    {
        private const string ApplicationXWwwFormUrlencoded = "application/x-www-form-urlencoded";

        public static bool IsMultipartContentType(string contentType) =>
            !string.IsNullOrWhiteSpace(contentType)
            && contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;

        public bool CanRead(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var logger = GetLogger(context);

            string requestContentType = context.HttpContext.Request.ContentType;

            if (string.IsNullOrWhiteSpace(requestContentType))
            {
                return false;
            }

            bool isXwwwFormUrlEncoded = requestContentType.Equals(
                ApplicationXWwwFormUrlencoded,
                StringComparison.OrdinalIgnoreCase);

            bool isMultipartFormData = IsMultipartContentType(requestContentType);

            bool hasSupportedContentType = isXwwwFormUrlEncoded
                                           || isMultipartFormData;

            TypeInfo typeInfo = context.ModelType.GetTypeInfo();

            bool canBeDeserialized = typeInfo.IsClass && !typeInfo.IsAbstract;

            bool canRead = hasSupportedContentType && canBeDeserialized;

            logger?.LogDebug(
                "x-www-form-url-encoded {IsXwwwFormUrlEncoded}, multipart/form-data {IsMultipartFormData}, canRead {CanRead}",
                isXwwwFormUrlEncoded,
                isMultipartFormData,
                canRead);

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
                context.HttpContext.Request.EnableBuffering();
                IFormCollection form = await context.HttpContext.Request.ReadFormAsync();
                object model = form.ParseFromCollection(context.ModelType);

                return InputFormatterResult.Success(model);
            }
            catch (Exception ex)
            {
                var logger = GetLogger(context);
                logger?.LogError(new EventId(1000), ex, "Could not create type {ModelType}", context.ModelType.Name);
                return InputFormatterResult.Failure();
            }
        }

        private static ILogger<XWwwFormUrlEncodedFormatter> GetLogger(InputFormatterContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<XWwwFormUrlEncodedFormatter>>();
            return logger;
        }
    }
}