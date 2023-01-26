using MongoDB.Driver;
using TestCase.Business.Abstract;
using TestCase.Core.Utilities.Params;
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

    public IQueryable<Leaderboard> GetLeaderBoard(LeaderBoardParams lbParams)
    {
        IQueryable<Leaderboard> leaderBoard = _leaderBoardDal.Get()
            .OrderBy(x => x.Rank);

        leaderBoard = FilterByMonth(leaderBoard, lbParams);
        leaderBoard = FilterByUserId(leaderBoard, lbParams);

        return leaderBoard;
    }

    private static IQueryable<Leaderboard> FilterByUserId(IQueryable<Leaderboard> leaderBoard,
        LeaderBoardParams lbParams)
    {
        if (lbParams.UserId != null)
        {
            leaderBoard = leaderBoard.Where(x => x.User_Id == lbParams.UserId);
        }

        return leaderBoard;
    }

    private static IQueryable<Leaderboard> FilterByMonth(IQueryable<Leaderboard> leaderBoard,
        LeaderBoardParams lbParams)
    {
        if (lbParams.Month != null)
        {
            leaderBoard = leaderBoard.AsEnumerable().Where(x => x.Date.Month == lbParams.Month).AsQueryable();
        }

        return leaderBoard;
    }


    private void CheckIfMonthExists()
    {
        var queryableResult = _leaderBoardDal.Get();

        var result = queryableResult.ToList().Where(x => x.Date.Month == DateTime.Now.Month).ToList();

        if (result.Count != 0)
            throw new Exception("The leaderboard for this month has already been created.");
    }
}