﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core
{
    public class XWwwFormUrlEncodedFormatter : IInputFormatter
    {
        private readonly ILogger _logger;

        public XWwwFormUrlEncodedFormatter(ILogger<XWwwFormUrlEncodedFormatter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private const string ApplicationXWwwFormUrlencoded = "application/x-www-form-urlencoded";
        private const string FormData = "multipart/form-data";

        public bool CanRead(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            bool isXwwwFormUrlEncoded = context.HttpContext.Request.ContentType.Equals(
                ApplicationXWwwFormUrlencoded,
                StringComparison.OrdinalIgnoreCase);

            bool isMultipartFormData = context.HttpContext.Request.ContentType.StartsWith(
                FormData,
                StringComparison.OrdinalIgnoreCase);

            bool hasSupportedContenetType = isXwwwFormUrlEncoded ||
                                            isMultipartFormData;

            TypeInfo typeInfo = context.ModelType.GetTypeInfo();

            bool canBeDeserialized = typeInfo.IsClass && !typeInfo.IsAbstract;

            return hasSupportedContenetType && canBeDeserialized;
        }

        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

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