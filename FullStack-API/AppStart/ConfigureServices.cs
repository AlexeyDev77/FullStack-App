using Autofac;
using Autofac.Extensions.DependencyInjection;
using FullStack.API.Container;

namespace FullStack_API.AppStart
{
    public static partial class Configure
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(b => b.AddAutofacServices());

            return builder;
        }
    }
}
