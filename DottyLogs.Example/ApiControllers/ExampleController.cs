using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DottyLogs.Example.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet("delay")]
        public async Task Delay()
        {
            _logger.LogInformation("Starting delay");
            await Task.Delay(5000);
            _logger.LogInformation("Finished delay");
        }
    }
}
