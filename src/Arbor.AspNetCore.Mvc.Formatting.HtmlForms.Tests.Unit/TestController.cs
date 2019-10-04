using Microsoft.AspNetCore.Mvc;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit
{
    [Route("")]
    public class TestController : Controller
    {
        [HttpPost]
        [Route("")]
        public IActionResult Index([FromBody] SampleClassWithCtor sampleClassWithCtor)
        {
            if (string.IsNullOrWhiteSpace(sampleClassWithCtor?.A))
            {
                return new StatusCodeResult(500);
            }

            return new StatusCodeResult(200);
        }
    }
}
