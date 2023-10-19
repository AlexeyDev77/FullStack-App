using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace FullStack.API.Configuration
{
    public static class WebApplicationBuilderExtensions
    {
        public static void LoadConfiguration(this WebApplicationBuilder webApplicationBuilder)
        {
            var config = webApplicationBuilder.Configuration;

            config
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"D:/Projects/FullStackApp/FullStack.API.Configuration/appsettings.json");
        }
    }
}


