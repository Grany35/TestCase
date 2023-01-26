using TestCase.Core.Utilities.Params;
using TestCase.Entities.Concrete;

namespace TestCase.Business.Abstract;

public interface ILeaderBoardService
{
    Task AddToLeaderBoard();
    IQueryable<Leaderboard> GetLeaderBoard(LeaderBoardParams lbParams);
}