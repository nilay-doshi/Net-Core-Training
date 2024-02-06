using Microsoft.AspNetCore.Mvc.Filters;

namespace demo_filters
{
    public class MySampleResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<MySampleResultFilterAttribute> _logger;
        private Guid _randomId;
        private readonly string _name; 

        public MySampleResultFilterAttribute(ILogger<MySampleResultFilterAttribute> logger, string name="Global")
        {
            _logger = logger;
            _name = name;
            _randomId = Guid.NewGuid();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($"Result Filter - Before - {_name} - {_randomId} ");
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($"Result Filter - After - {_name} - {_randomId}");
        }

    }
}
