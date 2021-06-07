using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KeyVaultTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public TestController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            return configuration["Search:IndexName"];
        }
    }
}
