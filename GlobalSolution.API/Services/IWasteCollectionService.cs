using GlobalSolution.API.ViewModels;

namespace GlobalSolution.API.Services;

public interface IWasteCollectionService
{
    Task<PagedResult<WasteCollectionViewModel>> GetAllAsync(int page, int pageSize);
    Task<WasteCollectionViewModel?> GetByIdAsync(int id);
    Task<WasteCollectionViewModel> CreateAsync(CreateWasteCollectionViewModel model);
    Task<WasteCollectionViewModel?> UpdateAsync(int id, UpdateWasteCollectionViewModel model);
    Task<bool> DeleteAsync(int id);
}
