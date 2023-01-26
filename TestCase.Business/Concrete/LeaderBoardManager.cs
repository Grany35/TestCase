using MongoDB.Driver;
using TestCase.Business.Abstract;
using TestCase.DataAccess.Abstract;
using TestCase.Entities.Concrete;
using TestCase.Entities.Dtos;

namespace TestCase.Business.Concrete;

public class LeaderBoardManager : ILeaderBoardService
{
    private readonly ILeaderBoardDal _leaderBoardDal;
    private readonly IPointService _pointService;
    private readonly IAwardService _awardService;

    public LeaderBoardManager(ILeaderBoardDal leaderBoardDal, IPointService pointService, IAwardService awardService)
    {
        _leaderBoardDal = leaderBoardDal;
        _pointService = pointService;
        _awardService = awardService;
    }

    public async Task AddToLeaderBoard()
    {
        CheckIfMonthExists();

        var pointsResult = await _pointService.GetPointsFromApi();

        var approvedPoints = pointsResult.Where(x => x.approved);

        var userPoints = approvedPoints.GroupBy(u => u.user_id.oid)
            .Select(g => new Leaderboard
                {
                    User_Id = g.Key,
                    Total_Points = g.Sum(p => p.point)
                }
            );

        var leaderBoards = userPoints.OrderByDescending(o => o.Total_Points)
            .Select((p, i) => new Leaderboard
            {
                Rank = i + 1,
                User_Id = p.User_Id,
                Total_Points = p.Total_Points,
                Date = DateTime.Now,
            }).Where(x => x.Rank <= 1000);

        await _awardService.DistributeAwards(leaderBoards);

        await _leaderBoardDal.AddManyAsync(leaderBoards);
    }


    private void CheckIfMonthExists()
    {
        var queryableResult = _leaderBoardDal.Get();

        var result = queryableResult.ToList().Where(x => x.Date.Month == DateTime.Now.Month).ToList();

        if (result.Count != 0)
            throw new Exception("The leaderboard for this month has already been created.");
    }
}