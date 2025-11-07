namespace LatinhasLLC.API.Application.Models.DemandItem.Requests;

public class DemandItemRequest
{
    public Guid DemandId { get; set; }
    public string SKU { get; set; } = string.Empty;
    public decimal TotalPlanned { get; set; }
    public decimal TotalProduced { get; set; }
}