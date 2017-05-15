using System.Collections.Generic;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit.ComplexTypes
{
    public class SubComplexType
    {
        public SubComplexType(string subTitle, int subOtherProperty)
        {
            SubTitle = subTitle;
            SubOtherProperty = subOtherProperty;
        }

        public string SubTitle { get; }

        public int SubOtherProperty { get; }

        public ICollection<SubListItem> SubListItems { get; set; }
    }
}