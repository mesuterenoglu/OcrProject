using OcrProject.Models;

namespace OcrProject.Services.Abstract
{
    public interface IInsuredService
    {
        Task<Insured> CreateInsuredsByOcrAsync(IEnumerable<AzureOCRResult> azureOCRResults,CancellationToken cancellationToken = default);
    }
}
