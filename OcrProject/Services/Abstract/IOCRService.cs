using OcrProject.Models;

namespace OcrProject.Services.Abstract;

public interface IOCRService
{
    Task<Insured> OcrWithAzure(IFormFile file); 
}
