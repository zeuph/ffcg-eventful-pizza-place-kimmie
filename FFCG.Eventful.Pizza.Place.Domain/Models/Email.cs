namespace FFCG.Eventful.Pizza.Place.Domain.Models;

public class Email
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid? RecipientId { get; set; }
    public string? RecipientEmail { get; set; }
    public string? EmailBody { get; set; }
}
