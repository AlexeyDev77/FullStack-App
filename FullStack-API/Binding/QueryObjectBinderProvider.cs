using FullStack.FrameWork.Common.Query;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace FullStack_API.Binding
{
    public class QueryObjectBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var options = context.Services.GetRequiredService<IOptions<JsonOptions>>();

            return typeof(QueryObject).IsAssignableFrom(context.Metadata.ModelType)
                ? new QueryObjectBinder(options.Value.SerializerOptions)
                : null;
        }
    }
}
