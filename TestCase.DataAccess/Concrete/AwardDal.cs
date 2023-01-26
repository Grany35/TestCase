using TestCase.Core.DataAccess.Concrete;
using TestCase.Core.Settings;
using TestCase.DataAccess.Abstract;
using TestCase.Entities.Concrete;

namespace TestCase.DataAccess.Concrete;

public class AwardDal : MongoDbRepositoryBase<AwardEntity>, IAwardDal
{
    public AwardDal(IMongoSettings settings) : base(settings)
    {
    }
}