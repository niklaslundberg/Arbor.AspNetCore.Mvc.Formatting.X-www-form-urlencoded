using System.Collections.Generic;
using System.Linq;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit.ComplexTypes
{
    public class ItemWithServices
    {
        public string Description { get; set; }

        public int NumberOfItems { get; set; }

        public List<Service> Services { get; set; }

        public override string ToString()
        {
            string services = Services != null
                ? string.Join(", ", Services.Select(service => service.ToString()))
                : "No Services";

            return $"{nameof(Description)}: {Description}, {nameof(Services)}: {services}";
        }
    }
}
