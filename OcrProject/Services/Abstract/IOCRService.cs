using OcrProject.Models;

namespace OcrProject.Services.Abstract;

public interface IOCRService
{
    Task<IEnumerable<AzureOCRResult>> OcrWithAzure(IFormFile file, CancellationToken cancellationToken = default);
}
