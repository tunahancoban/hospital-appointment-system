using AutoMapper;
using BranchService.DTOs.BranchDTOs;
using BranchService.Entities;
using BranchService.Mapping;
using BranchService.Repositories;
using Microsoft.Extensions.Logging.Abstractions;
using FluentAssertions;
using Moq;
using Xunit;

using ServiceClass = global::BranchService.Services.BranchService;

namespace BranchService.Test;
public class BranchServiceTest
{
    private readonly Mock<IBranchRepository> _repositoryMock;
    private readonly IMapper _mapper;
    private readonly ServiceClass _branchService;
    public BranchServiceTest()
    {
        _repositoryMock = new Mock<IBranchRepository>();
        
        var configExpression = new MapperConfigurationExpression();
        configExpression.AddProfile(new GeneralMapping());
        
        var mapperConfig = new MapperConfiguration(configExpression, NullLoggerFactory.Instance);
        _mapper = mapperConfig.CreateMapper();
        
        _branchService = new ServiceClass(_repositoryMock.Object, _mapper);
    }
    [Fact]
    
    public async Task GetAllAsync_WhenBranchesExist_ShouldReturnMappedResultBranchDtoList()
    {
        // ARRANGE 
        var fakeBranches = new List<Branch>
        {
            new Branch { branchId = "1", branchName = "Kardiyoloji", description = "Kalp Hastalıkları", iconUrl = "kalp.png" },
            new Branch { branchId = "2", branchName = "Nöroloji", description = "Beyin Cerrahisi", iconUrl = "beyin.png" }
        };

        _repositoryMock
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(fakeBranches);

        // ACT 
        var result = await _branchService.GetAllAsync();

        // ASSERT 
        result.Should().NotBeNull();
        result.Should().HaveCount(2);

        // Mapping check
        result[0].branchId.Should().Be("1");
        result[0].branchName.Should().Be("Kardiyoloji");
        result[0].description.Should().Be("Kalp Hastalıkları");

        result[1].branchId.Should().Be("2");
        result[1].branchName.Should().Be("Nöroloji");

        _repositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
    }
}