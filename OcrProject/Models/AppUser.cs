using System.ComponentModel.DataAnnotations.Schema;

namespace OcrProject.Models;

public class AppUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
}
