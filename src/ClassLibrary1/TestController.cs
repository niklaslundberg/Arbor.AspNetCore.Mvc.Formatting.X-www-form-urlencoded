using Microsoft.AspNetCore.Mvc;

namespace Arbor.AspNetCore.Formatting.HtmlForms.Tests.Integration
{
    [Route("")]
    public class TestController : Controller
    {
        [HttpPost]
        [Route("")]
        public IActionResult Index([FromBody]SampleClassWithCtor sampleClassWithCtor)
        {
            if (string.IsNullOrWhiteSpace(sampleClassWithCtor?.A))
            {
                return new StatusCodeResult(500);
            }

            return new StatusCodeResult(200);
        }
    }
}