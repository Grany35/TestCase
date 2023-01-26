using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestCase.Entities.Concrete;

public class Award
{
    [BsonId]
    [BsonRepresentation((BsonType.ObjectId))]
    public string Id { get; set; }
    
    [BsonRepresentation((BsonType.ObjectId))]
    public string User_Id { get; set; }
    
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Date { get; set; }  
}