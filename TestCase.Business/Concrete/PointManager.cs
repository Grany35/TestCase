using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;
using TestCase.Business.Abstract;
using TestCase.Entities.Dtos;

namespace TestCase.Business.Concrete;

public class PointManager : IPointService
{
    public async Task<List<PointDto>> GetPointsFromApi()
    {
        using var httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync("https://cdn.mallconomy.com/testcase/points.json");
        var json = await response.Content.ReadAsStringAsync();
        List<PointDto> points = JsonConvert.DeserializeObject<List<PointDto>>(json);
        return points;
    }
}