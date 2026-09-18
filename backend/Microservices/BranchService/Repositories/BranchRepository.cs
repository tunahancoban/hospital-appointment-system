using BranchService.DTOs.BranchDTOs;
using BranchService.Entities;
using BranchService.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BranchService.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly IMongoCollection<Branch> _branchCollection;
    
    public BranchRepository(IDatabaseSettings databaseSettings)
    {

        var mongoClient = new MongoClient(databaseSettings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);

        _branchCollection = mongoDatabase.GetCollection<Branch>(databaseSettings.CollectionName);
    }
    
    public async Task<List<Branch>> GetAllAsync()
    {
        return await _branchCollection.Find(_ => true).ToListAsync();    }

    public async Task<Branch?> GetByIdAsync(string id)
    {
        return await _branchCollection.Find(x => x.branchId == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Branch branch)
    {

        await _branchCollection.InsertOneAsync(branch);
        
    }

    public async Task UpdateAsync(string id, Branch branch)
    {
        await _branchCollection.ReplaceOneAsync(x => x.branchId == id, branch);
    }

    public async Task DeleteAsync(string id)
    {
        //Soft Delete
        FilterDefinition<Branch> filter = Builders<Branch>.Filter.Eq(x => x.branchId, id);
        UpdateDefinition<Branch> update = Builders<Branch>.Update.Set(x => x.isActive, false);

        await _branchCollection.UpdateOneAsync(filter, update);    }
}