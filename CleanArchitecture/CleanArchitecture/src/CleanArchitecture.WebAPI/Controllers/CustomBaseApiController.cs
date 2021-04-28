using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.WebAPI.Controllers
{
    public class CustomBaseApiController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator;
        public CustomBaseApiController(IMediator mediator)
        {
            _mediator = mediator;
            Mediator = _mediator;
        }

        public CustomBaseApiController()
        {
            if (_mediator == null)
            {
                Mediator = HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
