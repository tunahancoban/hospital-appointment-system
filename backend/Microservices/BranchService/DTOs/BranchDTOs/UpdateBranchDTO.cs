namespace BranchService.DTOs.BranchDTOs;

public class UpdateBranchDTO
{
        
    public string branchId { get; set; }
    public string branchName { get; set; }
    public string description { get; set; }
    public string iconUrl { get; set; }
    public bool isActive { get; set; }
}