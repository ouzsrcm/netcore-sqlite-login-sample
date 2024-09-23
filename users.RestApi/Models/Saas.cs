namespace users.RestApi.Models;

public class Saas
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string ImgUrl { get; set; }
    public  string SaasUrl { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Owner { get; set; }
    public string OwnerPhone { get; set; }
    public string OwnerEmail { get; set; }
    public string OwnerAddress { get; set; }
    public string TaxOffice { get; set; }
    public string TaxNumber { get; set; }
    public string BankName { get; set; }
    public string BankAccountNumber { get; set; }
    public string BankAccountIBAN { get; set; }
    public string BankAccountSwift { get; set; }
}