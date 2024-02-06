using Microsoft.AspNetCore.Mvc.Filters;
using System.Xml.Linq;

namespace demo_filters
{
    public class MySampleResourceFilterAttribute : Attribute, IResourceFilter
    {
        private readonly string _name;
        public MySampleResourceFilterAttribute(string name) 
        {
            _name = name;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Action Filter - Before - OnActionExecuted - {_name} ");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Action Filter - Before - OnActionExecuted - {_name} ");
        }
    }
}
