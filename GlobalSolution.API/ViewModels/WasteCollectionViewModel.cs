using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.API.ViewModels;

public class WasteCollectionViewModel
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public string WasteType { get; set; } = string.Empty;
    public double QuantityKg { get; set; }
    public DateTime CollectionDate { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateWasteCollectionViewModel
{
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
}

public class UpdateWasteCollectionViewModel
{
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
}

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}
