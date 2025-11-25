using GlobalSolution.API.Data;
using GlobalSolution.API.Models;
using GlobalSolution.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.API.Services;

public class WasteCollectionService : IWasteCollectionService
{
    private readonly ApplicationDbContext _context;

    public WasteCollectionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<WasteCollectionViewModel>> GetAllAsync(int page, int pageSize)
    {
        var totalCount = await _context.WasteCollections.CountAsync();
        
        var items = await _context.WasteCollections
            .OrderByDescending(w => w.CollectionDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(w => MapToViewModel(w))
            .ToListAsync();

        return new PagedResult<WasteCollectionViewModel>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<WasteCollectionViewModel?> GetByIdAsync(int id)
    {
        var entity = await _context.WasteCollections.FindAsync(id);
        return entity == null ? null : MapToViewModel(entity);
    }

    public async Task<WasteCollectionViewModel> CreateAsync(CreateWasteCollectionViewModel model)
    {
        var entity = new WasteCollection
        {
            Location = model.Location,
            WasteType = model.WasteType,
            QuantityKg = model.QuantityKg,
            CollectionDate = model.CollectionDate,
            Notes = model.Notes,
            CreatedAt = DateTime.UtcNow
        };

        _context.WasteCollections.Add(entity);
        await _context.SaveChangesAsync();

        return MapToViewModel(entity);
    }

    public async Task<WasteCollectionViewModel?> UpdateAsync(int id, UpdateWasteCollectionViewModel model)
    {
        var entity = await _context.WasteCollections.FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        entity.Location = model.Location;
        entity.WasteType = model.WasteType;
        entity.QuantityKg = model.QuantityKg;
        entity.CollectionDate = model.CollectionDate;
        entity.Notes = model.Notes;
        entity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return MapToViewModel(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.WasteCollections.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.WasteCollections.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    private static WasteCollectionViewModel MapToViewModel(WasteCollection entity)
    {
        return new WasteCollectionViewModel
        {
            Id = entity.Id,
            Location = entity.Location,
            WasteType = entity.WasteType,
            QuantityKg = entity.QuantityKg,
            CollectionDate = entity.CollectionDate,
            Notes = entity.Notes,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}
