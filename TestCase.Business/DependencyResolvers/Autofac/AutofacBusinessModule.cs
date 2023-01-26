using Autofac;
using TestCase.Business.Abstract;
using TestCase.Business.Concrete;
using TestCase.DataAccess.Abstract;
using TestCase.DataAccess.Concrete;
using TestCase.Entities.Concrete;

namespace TestCase.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<LeaderBoardManager>().As<ILeaderBoardService>();
        builder.RegisterType<LeaderBoardDal>().As<ILeaderBoardDal>();

        builder.RegisterType<AwardManager>().As<IAwardService>();
        builder.RegisterType<AwardDal>().As<IAwardDal>();

        builder.RegisterType<PointManager>().As<IPointService>();
    }
}