using TestCase.Entities.Concrete;

namespace TestCase.Business.Abstract;

public interface IAwardService
{
    Task DistributeAwards(IEnumerable<Leaderboard> leaderboards);
}