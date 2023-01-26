using TestCase.Business.Abstract;
using TestCase.Core.Utilities.Params;
using TestCase.DataAccess.Abstract;
using TestCase.Entities.Concrete;
using TestCase.Entities.Dtos;

namespace TestCase.Business.Concrete;

public class AwardManager : IAwardService
{
    private readonly IAwardDal _awardDal;

    public AwardManager(IAwardDal awardDal)
    {
        _awardDal = awardDal;
    }

    public async Task DistributeAwards(IEnumerable<Leaderboard> leaderboards)
    {
        List<AwardEntity> awards = new List<AwardEntity>();

        var firstUser = leaderboards.First();
        awards.Add(new AwardEntity
        {
            User_Id = firstUser.User_Id,
            Award = "First Prize",
        });

        var secondUser = leaderboards.Skip(1).First();
        awards.Add(new AwardEntity
        {
            User_Id = secondUser.User_Id,
            Award = "Second Prize",
        });

        var thirdUser = leaderboards.Skip(2).First();
        awards.Add(new AwardEntity
        {
            User_Id = thirdUser.User_Id,
            Award = "Third Prize",
        });

        var first100Users = leaderboards.Take(100);
        foreach (var user in first100Users)
        {
            awards.Add(new AwardEntity
            {
                User_Id = user.User_Id,
                Award = "25$",
            });
        }

        var first1000Users = leaderboards.Take(1000);
        double consolationPrize = 12500.0 / first1000Users.Count();
        foreach (var user in first1000Users)
        {
            awards.Add(new AwardEntity
            {
                User_Id = user.User_Id,
                Award = $"Consolation Prize - {consolationPrize}$",
            });
        }

        await _awardDal.AddManyAsync(awards);
    }

    public IQueryable<AwardEntity> GetAwards(AwardParams awardParams)
    {
        IQueryable<AwardEntity> awards = _awardDal.Get();

        if (awardParams.UserId != null)
        {
            awards = awards.Where(x => x.User_Id == awardParams.UserId);
        }
        return awards;
    }
}