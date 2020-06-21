using Application.Services;
using Autofac;
using AutoMapper;

namespace Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(
                    ctx =>
                    {
                        var scope = ctx.Resolve<ILifetimeScope>();
                        return new Mapper(
                            ctx.Resolve<IConfigurationProvider>(),
                            scope.Resolve);
                    })
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().AsImplementedInterfaces();
            builder.RegisterType<EnrollmentsService>().AsImplementedInterfaces();
        }
    }
}