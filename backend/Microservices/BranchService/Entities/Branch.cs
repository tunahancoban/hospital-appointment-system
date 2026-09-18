using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BranchService.Entities;

public class Branch
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string branchId { get; set; }
    public string branchName { get; set; }
    public string description { get; set; }
    public string iconUrl { get; set; }
    public bool isActive { get; set; }
}