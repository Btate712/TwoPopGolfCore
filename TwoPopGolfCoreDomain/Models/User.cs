namespace TwoPopGolfCoreDomain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Handle { get; set; } = string.Empty;
}