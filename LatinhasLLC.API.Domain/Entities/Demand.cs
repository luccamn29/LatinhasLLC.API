using LatinhasLLC.API.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LatinhasLLC.API.Domain.Entities;

public class Demand
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DemandStatus Status { get; set; } = DemandStatus.Planning;
    public List<Item> Items { get; set; } = new List<Item>();
}
