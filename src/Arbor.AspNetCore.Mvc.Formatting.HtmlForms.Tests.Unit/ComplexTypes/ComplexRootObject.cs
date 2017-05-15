using System.Collections.Generic;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit.ComplexTypes
{
    public class ComplexRootObject
    {
        public ComplexRootObject(string rootTitle, int rootOtherProperty)
        {
            RootTitle = rootTitle;
            RootOtherProperty = rootOtherProperty;
        }

        public string RootTitle { get; }

        public int RootOtherProperty { get; }

        public ICollection<SubComplexType> SubTypes { get; set; }
    }
}