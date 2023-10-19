using System.Text.Json.Serialization;
using FullStack_API.Binding;
using Microsoft.AspNetCore.Http.Json;

namespace FullStack_API.AppStart
{
    public static partial class Configure { 

        public static WebApplicationBuilder ConfigureSerializer(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
            builder.Services.AddMvcCore(options =>
            {
                options.ModelBinderProviders.Insert(0, new QueryObjectBinderProvider());
            });

            return builder;
        }
    }

   
}


