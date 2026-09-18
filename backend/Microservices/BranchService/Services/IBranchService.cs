using BranchService.DTOs.BranchDTOs;
using BranchService.Entities;

namespace BranchService.Services;

public interface IBranchService
{
    Task<List<ResultBranchDto>> GetAllAsync();
    Task<GetBranchByIdDTO> GetByIdAsync(string id);
    Task CreateAsync(CreateBranchDto branch);
    Task UpdateAsync(UpdateBranchDTO branch);
    Task DeleteAsync(string id);
    
}