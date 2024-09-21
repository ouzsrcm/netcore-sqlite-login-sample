namespace users.Models;

public class DefaultApiResponse
{
    public bool Success { get; set; }
    public int HttpStatusCode { get; set; }
    public String HttpStatusMessage { get; set; }
}
