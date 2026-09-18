using AutoMapper;
using BranchService.DTOs.BranchDTOs;
using BranchService.Entities;

namespace BranchService.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Branch, ResultBranchDto>().ReverseMap();
        CreateMap<Branch, UpdateBranchDTO>().ReverseMap();
        CreateMap<Branch, GetBranchByIdDTO>().ReverseMap();
        CreateMap<Branch, CreateBranchDto>().ReverseMap();
    }
}