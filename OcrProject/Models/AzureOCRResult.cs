using System.ComponentModel.DataAnnotations.Schema;

namespace OcrProject.Models;

public class AzureOCRResult
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Field { get; set; }
    public string Content { get; set; }
    public string ValueType { get; set; }
    public float? Confidence { get; set; }
    public int? PageNumber { get; set; }
    public string BoundingPolygon { get; set; }
    public AzureOCRResult()
    {

    }

    public AzureOCRResult(string field, string content, string valueType, float? confidence, int? pageNumber, string boundingPolygon)
    {
        Field = field;
        Content = content;
        ValueType = valueType;
        Confidence = confidence;
        PageNumber = pageNumber;
        BoundingPolygon = boundingPolygon;
    }
}
