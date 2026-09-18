using BranchService.Entities;
namespace BranchService.Repositories;

public interface IBranchRepository
{
    Task<List<Branch>> GetAllAsync();
    Task<Branch?> GetByIdAsync(string id);
    Task CreateAsync(Branch branch);
    Task UpdateAsync(string id, Branch branch);
    Task DeleteAsync(string id);
}