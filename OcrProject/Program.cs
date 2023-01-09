using Microsoft.EntityFrameworkCore;
using OcrProject.DataAccess;
using OcrProject.Models;
using OcrProject.Services.Abstract;
using OcrProject.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<AzureSettings>(builder.Configuration.GetSection("AzureSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SQLContext>(x => x.UseSqlite("DataSource = ..\\OcrProject\\DataAccess\\Data\\app.db"));
builder.Services.AddScoped<IOCRService, OCRService>();
builder.Services.AddScoped<IInsuredService, InsuredService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
