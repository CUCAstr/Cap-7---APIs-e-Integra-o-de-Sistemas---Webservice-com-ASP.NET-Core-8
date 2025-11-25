using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.API.Models;

public class WasteCollection
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Location { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string WasteType { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue)]
    public double QuantityKg { get; set; }

    [Required]
    public DateTime CollectionDate { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}
