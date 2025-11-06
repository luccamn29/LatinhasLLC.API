namespace LatinhasLLC.API.Application.DTOs;

public class DemandDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public IEnumerable<DemandItemDto> DemandItems { get; set; } = new List<DemandItemDto>();
    public decimal TotalPlanned => DemandItems?.Sum(i => i.TotalPlanned) ?? 0;
    public decimal TotalProduced => DemandItems?.Sum(i => i.TotalProduced) ?? 0;
}
