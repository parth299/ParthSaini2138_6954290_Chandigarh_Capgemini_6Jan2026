using Microsoft.AspNetCore.Mvc;

namespace ProductionLog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet("fast")]
        public IActionResult FastApi()
        {
            return Ok("Fast response");
        }

        [HttpGet("slow")]
        public IActionResult SlowApi()
        {
            Thread.Sleep(5000); 
            return Ok("Slow response");
        }

        [HttpGet("error")]
        public IActionResult ErrorApi()
        {
            throw new Exception("Test exception");
        }
    }
}