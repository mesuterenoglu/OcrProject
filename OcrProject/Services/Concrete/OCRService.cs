using OcrProject.DataAccess;
using OcrProject.Models;
using OcrProject.Services.Abstract;

namespace OcrProject.Services.Concrete
{
    public class OCRService : IOCRService
    {
        readonly SQLContext _context;

        public OCRService(SQLContext context)
        {
            _context = context;
        }

        public Task<Insured> OcrWithAzure(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
