using Microsoft.AspNetCore.Mvc;

namespace OcrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost("DocumentAnalysis")]
        public async Task<IActionResult> DocumentAnalysis(IFormFile formFile)
        {
            return Ok(formFile);
        }
    }
}
