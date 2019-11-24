using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit.ComplexTypes;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.SampleWeb
{
    [Route("")]
    public class TestController : Controller
    {
        [HttpPost]
        [Route("files")]
        public IActionResult Files(IEnumerable<IFormFile> files)
        {
            if (files is null || !files.Any())
            {
                return new StatusCodeResult(400);
            }

            return new StatusCodeResult(200);
        }

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

        [HttpPost]
        [Route("complex")]
        public IActionResult Index([FromBody] MainType mainType)
        {
            return new ObjectResult(mainType);
        }

        [HttpPost]
        [Route("~/data")]
        public async Task<IActionResult> Index()
        {
            Request.EnableBuffering();

            string data;
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                data = await reader.ReadToEndAsync();
            }

            return new ContentResult()
                   {
                       Content = data,
                       ContentType = "text/plain",
                       StatusCode = 200
                   };
        }
    }
}