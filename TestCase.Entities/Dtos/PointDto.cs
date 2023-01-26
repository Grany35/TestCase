using Newtonsoft.Json;

namespace TestCase.Entities.Dtos;

public class PointDto
{
    public Id _id { get; set; }
    public bool approved { get; set; }
    public UserId user_id { get; set; }
    public int point { get; set; }
}

public class Id
{
    [JsonProperty("$oid")]
    public string oid { get; set; }
}

public class UserId
{
    [JsonProperty("$oid")] 
    public string oid { get; set; }
}