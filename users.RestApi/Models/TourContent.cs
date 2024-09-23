namespace users.RestApi.Models;

public class TourContent
{
    public int Id { get; set; }
    public int TourId { get; set; }
    public string Content { get; set; } // İçerik
    public string Name { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
    public string TermsAndConditions { get; set; }
    public string CancellationPolicy { get; set; }
    public string ContactInformation { get; set; }
    public string AdditionalInformation { get; set; }
    public string IncludeAttributes { get; set; }
    public string ExcludeAttributes { get; set; }
    public string Meals { get; set; }
    public string Accommodation { get; set; }
    public string Activities { get; set; }
    public string Highlights { get; set; }
    public string Itinerary { get; set; }
    public string Notes { get; set; }

    public Tour Tour { get; set; }
}