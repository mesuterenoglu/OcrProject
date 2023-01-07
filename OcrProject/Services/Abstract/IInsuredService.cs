using OcrProject.Models;

namespace OcrProject.Services.Abstract
{
    public interface IInsuredService
    {
        Task<IEnumerable<Insured>> AddInsuredsByOcr(IEnumerable<AzureOCRResult> azureOCRResults);
    }
}
