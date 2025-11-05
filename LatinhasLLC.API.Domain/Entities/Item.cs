using System.ComponentModel.DataAnnotations;

namespace LatinhasLLC.API.Domain.Entities;

public class Item
{
    [Key]
    [Required]
    public string SKU { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public decimal TotalPlan { get; set; }
    public Guid DemandId { get; set; }
    public Demand? Demand { get; set; }
}
