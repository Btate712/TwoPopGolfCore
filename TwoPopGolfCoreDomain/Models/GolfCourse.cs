namespace TwoPopGolfCoreDomain.Models;

public class GolfCourse
{
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public IEnumerable<TeeSet> TeeSets { get; set; } = [];
}