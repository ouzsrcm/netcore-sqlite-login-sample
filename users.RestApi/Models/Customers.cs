namespace users.RestApi.Models;

public class Customer
{
    public int Id { get; set; }
    public int SaasId { get; set; }
    public Saas Saas { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Nationality { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    public string Language { get; set; }
    public string Currency { get; set; }
    public string Hotel { get; set; }
    public string Room { get; set; }
    public string CheckIn { get; set; }
    public string CheckOut { get; set; }
    public string Adults { get; set; }
    public string Children { get; set; }
    public string Infants { get; set; }
    public string Notes { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public DateTime CreatedBy { get; set; }
    public DateTime UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }
    public int? DeletedBy { get; set; }
    public string DeletedReason { get; set; }
    // Diğer özellikler...
}