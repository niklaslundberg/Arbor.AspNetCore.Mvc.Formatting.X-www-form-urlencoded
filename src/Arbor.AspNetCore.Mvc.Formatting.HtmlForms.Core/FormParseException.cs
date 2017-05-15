using System;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core
{
    public class FormParseException : Exception
    {
        public FormParseException(string message) : base(message)
        {

        }

        public FormParseException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}