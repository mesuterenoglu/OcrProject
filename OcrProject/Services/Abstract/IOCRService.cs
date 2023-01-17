using OcrProject.Models;

namespace OcrProject.Services.Abstract;

public interface IOCRService
{
    Task<IEnumerable<AzureOCRResult>> OcrWithAzureAsync(IFormFile file, CancellationToken cancellationToken = default);
}
