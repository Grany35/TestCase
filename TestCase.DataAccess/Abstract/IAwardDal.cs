using TestCase.Core.DataAccess.Abstract;
using TestCase.Entities.Concrete;

namespace TestCase.DataAccess.Abstract;

public interface IAwardDal : IRepository<AwardEntity>
{
}