namespace LatinhasLLC.API.Application.Models.DemandItem.Responses;

public class DemandItemDto
{
    public Guid Id { get; set; }
    public Guid DemandId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string ItemDescription { get; set; } = string.Empty;
    public decimal TotalPlanned { get; set; }
    public decimal TotalProduced { get; set; }
}