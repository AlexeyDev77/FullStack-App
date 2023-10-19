using Autofac;
using FullStack.API.Application.Services;
using FullStack.API.Contracts.Services;

namespace FullStack.API.Container
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeesService>().As<IEmployeesService>();
        }
    }
}