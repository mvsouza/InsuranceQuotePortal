using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceQuotePortal.Webapp.Infrastructure
{
    public class ActionConsumedByFilter : ActionFilterAttribute
    {
        private IActionConsumedRepository _actionConsumedRepository;
        public ActionConsumedByFilter(IActionConsumedRepository actionConsumedRepository) : base()
        {
            _actionConsumedRepository = actionConsumedRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            
                _actionConsumedRepository.Add(new ActionConsumed()
                {
                    UserName = httpContext.User.Identity.Name,
                    Action = context.ActionDescriptor.DisplayName
                });

        }
    }
}
