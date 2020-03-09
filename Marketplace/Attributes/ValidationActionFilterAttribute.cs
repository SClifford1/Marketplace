using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Marketplace.Attributes
{
    public class ValidationActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext _context)
        {
            if (!_context.ModelState.IsValid)
            {
                _context.Result = new BadRequestObjectResult("Invalid request data");
            }

            base.OnActionExecuting(_context);
        }
    }
}
