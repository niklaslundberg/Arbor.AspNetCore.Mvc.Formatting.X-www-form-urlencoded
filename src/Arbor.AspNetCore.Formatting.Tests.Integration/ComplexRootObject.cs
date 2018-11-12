using System.Collections.Generic;

namespace Arbor.AspNetCore.Formatting.Tests.Integration
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