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

        public async Task<Insured> CreateInsuredsByOcr(IEnumerable<AzureOCRResult> azureOCRResults, CancellationToken cancellationToken = default)
        {
            var insured = new Insured();
            insured.FirstName = azureOCRResults.FirstOrDefault(x => x.Field == "FirstName").Content;
            insured.LastName = azureOCRResults.FirstOrDefault(x => x.Field == "LastName").Content;
            insured.Phone = azureOCRResults.FirstOrDefault(x => x.Field == "Phone").Content;
            insured.Email = azureOCRResults.FirstOrDefault(x => x.Field == "Email").Content;
            insured.AddressLine = azureOCRResults.FirstOrDefault(x => x.Field == "Address").Content;
            insured.City = azureOCRResults.FirstOrDefault(x => x.Field == "City").Content;
            insured.ZipCode = azureOCRResults.FirstOrDefault(x => x.Field == "ZipCode").Content;

            _context.Insureds.Add(insured);
            await _context.SaveChangesAsync(cancellationToken);
            return insured;
        }
    }
}
