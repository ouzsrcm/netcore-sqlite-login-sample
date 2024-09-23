using System.Security.Cryptography.Pkcs;

namespace users.RestApi.Models;

public class Tour
{
    public int Id { get; set; }
    public int SaasId { get; set; }

    public string ImageUrl { get; set; }
    public string Duration { get; set; }
    public string Difficulty { get; set; }
    public string Price { get; set; }
    public string Location { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string MaxParticipants { get; set; }
    public string MinParticipants { get; set; }
    public string PaymentMethods { get; set; }

    public string Transportation { get; set; }

    public Saas Saas { get; set; }

    public ICollection<TourContent> TourContents { get; set; }
}