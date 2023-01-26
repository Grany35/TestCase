using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestCase.Entities.Concrete;

public class Leaderboard
{
    [BsonId]
    [BsonRepresentation((BsonType.ObjectId))]
    public string Id { get; set; }
    
    [BsonRepresentation((BsonType.ObjectId))]
    public string User_Id { get; set; }

    public int Rank { get; set; }
    public int Total_Points { get; set; }
    
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Date { get; set; }  
}