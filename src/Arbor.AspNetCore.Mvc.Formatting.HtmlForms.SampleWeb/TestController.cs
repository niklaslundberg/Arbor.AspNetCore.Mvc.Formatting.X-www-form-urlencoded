using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.SampleWeb
{
    [Route("")]
    public class TestController : Controller
    {
        [HttpPost]
        [Route("")]
        public IActionResult Index(
            [FromBody] SampleClassWithCtor sampleClassWithCtor,
            IFormFile theFile)
        {
            if (string.IsNullOrWhiteSpace(sampleClassWithCtor?.A))
            {
                return new StatusCodeResult(400);
            }

            if (theFile == null)
            {
                return new StatusCodeResult(400);
            }

            return new StatusCodeResult(200);
        }
    }
}
