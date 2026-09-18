using AutoMapper;
using BranchService.DTOs.BranchDTOs;
using BranchService.Entities;
using BranchService.Repositories;

namespace BranchService.Services;

public class BranchService : IBranchService
{
    private readonly IBranchRepository _repository;
    private readonly IMapper _mapper;


    public BranchService(IBranchRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultBranchDto>> GetAllAsync()
    {
        List<Branch> branches= await _repository.GetAllAsync();
        List<ResultBranchDto> branchDtos = _mapper.Map<List<ResultBranchDto>>(branches);
        return branchDtos;
    }

    public async Task<GetBranchByIdDTO> GetByIdAsync(string id)
    {
        Branch? branch = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetBranchByIdDTO>(branch);
    }

    public async Task CreateAsync(CreateBranchDto dto)
    {
        Branch branch = _mapper.Map<Branch>(dto);
        await _repository.CreateAsync(branch);
    }

    public async Task UpdateAsync(UpdateBranchDTO dto)
    {
        Branch branch = _mapper.Map<Branch>(dto);
        await _repository.UpdateAsync(branch.branchId, branch);
        
    }

    public async Task DeleteAsync(string id)
    {
        //Soft Delete
        await _repository.DeleteAsync(id);
    }
}