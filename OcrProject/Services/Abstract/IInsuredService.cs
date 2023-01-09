using OcrProject.Models;

namespace OcrProject.Services.Abstract
{
    public interface IInsuredService
    {
        Task<Insured> CreateInsuredsByOcr(IEnumerable<AzureOCRResult> azureOCRResults,CancellationToken cancellationToken = default);
    }
}
