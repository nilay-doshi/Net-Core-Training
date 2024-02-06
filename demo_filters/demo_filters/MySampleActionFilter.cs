using Microsoft.AspNetCore.Mvc.Filters;

namespace demo_filters
{
    public class MySampleActionFilter : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly string _name;
        public MySampleActionFilter(string name, int order = 0 ) 
        { 
            _name = name;
            Order = order;
        }

        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action Filter - Before - OnActionExecuted - {_name} - {Order} ");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($" Action Filter - After - OnActionExecuting - {_name} - {Order} ");
        }


        public int Order { get; set; }
    }
}
