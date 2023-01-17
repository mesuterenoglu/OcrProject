using Microsoft.AspNetCore.Mvc;
using OcrProject.Services.Abstract;

namespace OcrProject.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly IOCRService _ocrService;
        readonly IInsuredService _insuredService;

        public HomeController(IOCRService ocrService, IInsuredService insuredService)
        {
            _ocrService = ocrService;
            _insuredService = insuredService;
        }

        [HttpPost("documentanalysis")]
        public async Task<IActionResult> DocumentAnalysis(IFormFile formFile)
        {
            var cancellationToken = new CancellationToken();
            var ocrResults = await _ocrService.OcrWithAzureAsync(formFile,cancellationToken);
            var insured = await _insuredService.CreateInsuredsByOcrAsync(ocrResults,cancellationToken);
            return Ok(insured);
        }
    }
}
