using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceQuotePortal.Webapp.Infrastructure
{
    public class ConsumedActionByFilter : ActionFilterAttribute
    {
        private IConsumedActionRepository _actionConsumedRepository;
        public ConsumedActionByFilter(IConsumedActionRepository actionConsumedRepository) : base()
        {
            _actionConsumedRepository = actionConsumedRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var action = context.RouteData.Values["action"];
            _actionConsumedRepository.Save(new ConsumedAction()
            {
                UserName = httpContext.User.Identity.Name,
                Action = action.ToString()
            });
            _actionConsumedRepository.UnitOfWork.SaveEntities();

        }
    }
}
