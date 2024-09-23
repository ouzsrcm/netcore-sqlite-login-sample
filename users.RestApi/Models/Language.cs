namespace users.RestApi.Models;

public class Language
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public  string ImgUrl { get; set; }
    public required string ShortName { get; set; }
}