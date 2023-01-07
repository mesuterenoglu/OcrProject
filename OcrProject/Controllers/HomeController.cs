using Microsoft.AspNetCore.Mvc;
using OcrProject.Services.Abstract;

namespace OcrProject.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly IOCRService _ocrService;

        public HomeController(IOCRService ocrService)
        {
            _ocrService = ocrService;
        }

        [HttpPost("documentanalysis")]
        public async Task<IActionResult> DocumentAnalysis(IFormFile formFile)
        {
            var insured = await _ocrService.OcrWithAzure(formFile,new CancellationToken());
            return Ok(insured);
        }
    }
}
