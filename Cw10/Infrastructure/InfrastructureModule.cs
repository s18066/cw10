using Autofac;
using AutoMapper;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().AsImplementedInterfaces();
            builder.RegisterType<EnrollmentRepository>().AsImplementedInterfaces();
            builder.RegisterType<StudiesRepository>().AsImplementedInterfaces();
        }
    }
}