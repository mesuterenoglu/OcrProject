using System.ComponentModel.DataAnnotations.Schema;

namespace OcrProject.Models;

public class Insured
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public Insured()
    {

    }
    public Insured(string firstName, string lastName, string phone, string email, string addressLine, string city, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        AddressLine = addressLine;
        City = city;
        ZipCode = zipCode;
    }
}
