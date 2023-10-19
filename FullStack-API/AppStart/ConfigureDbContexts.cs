using FullStack.API.Application.Contexts;
using Microsoft.EntityFrameworkCore;


namespace FullStack_API.AppStart
{
    public static partial class Configure
    {
        public static WebApplicationBuilder ConfigureApplicationContexts(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContextFactory<MainContext>(options =>
                options
                //.UseNpgsql(connectionString)
                .UseNpgsql(connectionString, b =>
                {
                    b.MigrationsAssembly("FullStack.API.Migrations");
                    b.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalMilliseconds);

                })
                .UseSnakeCaseNamingConvention()

                );

            return builder;
 
        }

    }
}
