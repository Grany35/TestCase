using TestCase.Core.Utilities.Params;
using TestCase.Entities.Concrete;
using TestCase.Entities.Dtos;

namespace TestCase.Business.Abstract;

public interface IAwardService
{
    Task DistributeAwards(IEnumerable<Leaderboard> leaderboards);
    IQueryable<AwardEntity> GetAwards(AwardParams awardParams);
}