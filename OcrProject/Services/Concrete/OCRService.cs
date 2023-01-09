using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Microsoft.Extensions.Options;
using OcrProject.DataAccess;
using OcrProject.Extension;
using OcrProject.Models;
using OcrProject.Services.Abstract;

namespace OcrProject.Services.Concrete
{
    public class OCRService : IOCRService
    {
        readonly SQLContext _context;
        readonly AzureSettings _azureSettings;

        public OCRService(SQLContext context, IOptions<AzureSettings> options)
        {
            _context = context;
            _azureSettings = options.Value;
        }

        public async Task<IEnumerable<AzureOCRResult>> OcrWithAzure(IFormFile file, CancellationToken cancellationToken = default)
        {
            var credential = new AzureKeyCredential(_azureSettings.ApiKey);
            var client = new DocumentAnalysisClient(new Uri(_azureSettings.Endpoint), credential);

            var doc = await file.GetBytes(cancellationToken);
            var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, _azureSettings.ModelName, new MemoryStream(doc));


            var results = operation.Value.Documents.SelectMany(doc => doc.Fields);
            var azureOcrResults = results
                                .Select(field =>
                                            new AzureOCRResult(
                                                field.Key,
                                                field.Value.Content,
                                                field.Value.FieldType.ToString(),
                                                field.Value.Confidence * 100,
                                                field.Value.BoundingRegions.Select(x => x.PageNumber).FirstOrDefault(),
                                                field.Value.BoundingRegions.Select(x => x.BoundingPolygon.ToString()).FirstOrDefault()));
            _context.AzureOCRResults.AddRange(azureOcrResults);
            await _context.SaveChangesAsync(cancellationToken);
            return azureOcrResults;
        }
    }
}
