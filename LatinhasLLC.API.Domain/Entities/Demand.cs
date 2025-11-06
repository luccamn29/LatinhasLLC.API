namespace LatinhasLLC.API.Domain.Entities;

public class Demand
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<DemandItem> DemandItems { get; set; } = new List<DemandItem>();
}
