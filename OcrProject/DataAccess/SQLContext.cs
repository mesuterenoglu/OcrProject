using Microsoft.EntityFrameworkCore;
using OcrProject.Models;

namespace OcrProject.DataAccess;

public class SQLContext : DbContext
{
	public SQLContext(DbContextOptions<SQLContext> options) : base(options)
	{

	}
	public DbSet<Insured> Insureds { get; set; }
	public DbSet<AzureOCRResult> AzureOCRResults { get; set; }
}
