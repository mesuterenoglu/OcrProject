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
            var ocrResults = await _ocrService.OcrWithAzure(formFile);
            var insured = await _insuredService.CreateInsuredsByOcr(ocrResults);
            return Ok(insured);
        }
    }
}
