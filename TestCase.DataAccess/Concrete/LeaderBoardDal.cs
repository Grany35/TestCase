using Microsoft.Extensions.Options;
using TestCase.Core.DataAccess.Concrete;
using TestCase.Core.Settings;
using TestCase.DataAccess.Abstract;
using TestCase.Entities.Concrete;

namespace TestCase.DataAccess.Concrete;

public class LeaderBoardDal : MongoDbRepositoryBase<Leaderboard>, ILeaderBoardDal
{
    public LeaderBoardDal(IMongoSettings settings) : base(settings)
    {
    }
}