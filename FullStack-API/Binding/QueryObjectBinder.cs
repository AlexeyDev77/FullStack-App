using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace FullStack_API.Binding
{
    public class QueryObjectBinder : IModelBinder
    {
        private readonly JsonSerializerOptions _options;
        public QueryObjectBinder(JsonSerializerOptions options)
        {
            _options = options;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var query = bindingContext.ActionContext.HttpContext.Request.Query;

            if (!query.ContainsKey(bindingContext.ModelName))
            {
                bindingContext.Result = ModelBindingResult.Success(Activator.CreateInstance(bindingContext.ModelType));
                return Task.CompletedTask;
            }

            var jsonString = query[bindingContext.ModelName];

            var result = JsonSerializer.Deserialize(jsonString, bindingContext.ModelType, _options);
            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}
