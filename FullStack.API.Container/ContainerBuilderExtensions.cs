using Autofac;

namespace FullStack.API.Container
{
    public static class ContainerBuilderExtensions
    {
        public static void AddAutofacServices(this ContainerBuilder builder)
        {
            builder.RegisterModule(new CommonModule());
        }
    }
}
