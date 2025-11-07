using LatinhasLLC.API.Application.Models.DemandItem.Responses;

namespace LatinhasLLC.API.Application.Models.Demand.Responses;

public class DemandDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status
    {
        get
        {
            if (DemandItems == null || !DemandItems.Any())
                return DemandStatus.Planning.ToString();

            if (DemandItems.All(i => i.TotalProduced == 0))
                return DemandStatus.Planning.ToString();

            if (DemandItems.All(i => i.TotalProduced >= i.TotalPlanned))
                return DemandStatus.Completed.ToString();

            return DemandStatus.InProgress.ToString();
        }
    }
    public IEnumerable<DemandItemDto> DemandItems { get; set; } = new List<DemandItemDto>();
    public decimal TotalPlanned => DemandItems?.Sum(i => i.TotalPlanned) ?? 0;
    public decimal TotalProduced => DemandItems?.Sum(i => i.TotalProduced) ?? 0;
}

public enum DemandStatus
{
    Planning = 0,
    InProgress = 1,
    Completed = 2
}