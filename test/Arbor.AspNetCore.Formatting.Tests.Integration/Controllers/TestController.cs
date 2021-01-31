using Microsoft.AspNetCore.Mvc;

namespace Arbor.AspNetCore.Formatting.Tests.Integration.Controllers
{
    [Route("/")]
    public class TestController : Controller
    {
        [HttpPost]
        public object Post([FromBody] ComplexRootObject complexRootObject)
        {
            return complexRootObject;
        }
    }
}
