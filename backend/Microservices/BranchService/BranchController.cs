using BranchService.DTOs.BranchDTOs;
using BranchService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BranchService;

[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<ResultBranchDto> branches = await _branchService.GetAllAsync();
        return Ok(branches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string? id)
    {
        GetBranchByIdDTO? value = await _branchService.GetByIdAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBranchDto dto)
    {
        await  _branchService.CreateAsync(dto);
        return Ok("Branş başarıyla oluşturuldu.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBranchDTO dto)
    {
        await _branchService.UpdateAsync(dto);
        return Ok("Branş başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string? id)
    {
        await _branchService.DeleteAsync(id);
        return Ok("Branş başarıyla silindi");
    }
}