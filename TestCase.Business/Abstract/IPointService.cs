using TestCase.Entities.Dtos;

namespace TestCase.Business.Abstract;

public interface IPointService
{
    Task<List<PointDto>> GetPointsFromApi();
}