using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LatinhasLLC.API.Domain.Entities;

public class DemandItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid DemandId { get; set; }

    [Required]
    public string SKU { get; set; } = string.Empty;

    [ForeignKey(nameof(DemandId))]
    public Demand Demand { get; set; } = null!;

    [ForeignKey(nameof(SKU))]
    public Item Item { get; set; } = null!;
    public decimal TotalPlanned { get; set; }
    public decimal TotalProduced { get; set; }
}
