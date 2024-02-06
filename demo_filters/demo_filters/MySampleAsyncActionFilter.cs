using Microsoft.AspNetCore.Mvc.Filters;

namespace demo_filters
{
    public class MySampleAsyncActionFilter : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public MySampleAsyncActionFilter(string name)
        {
            _name = name;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($" Action Filter - Before Async - execution {_name}");
            await next();
            Console.WriteLine($"Action Filter - After Async execution {_name}");
        }
    }
}
