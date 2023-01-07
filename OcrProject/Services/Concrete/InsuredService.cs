using OcrProject.DataAccess;
using OcrProject.Models;
using OcrProject.Services.Abstract;

namespace OcrProject.Services.Concrete
{
    public class InsuredService : IInsuredService
    {
        readonly SQLContext _context;

        public InsuredService(SQLContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Insured>> AddInsuredsByOcr(IEnumerable<AzureOCRResult> azureOCRResults)
        {
            var insured = new Insured;
        }
    }
}
