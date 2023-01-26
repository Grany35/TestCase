namespace TestCase.Core.Settings;

public interface IMongoSettings
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
}