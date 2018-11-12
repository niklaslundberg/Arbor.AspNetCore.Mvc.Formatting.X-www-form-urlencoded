using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Arbor.AspNetCore.Formatting.Tests.Integration.Controllers
{
    [Route("/")]
    public class TestController : Controller
    {
        [HttpPost]
        public object Post([FromBody]ComplexRootObject complexRootObject)
        {
            return complexRootObject;
        }
    }
}
