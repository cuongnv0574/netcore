using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductTypesController : CustomBaseApiController
    {
        public ProductTypesController(IMediator mediator) : base(mediator)
        {

        }

        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<ProductTypeQueryResponseModel>> Get()
        {
            var query = new FetchProductTypeQuery();
            return await Mediator.Send(query);
        }

       

        // POST
        [HttpPost]
        public async Task<ActionResult<bool>> Post(ProductCommand command)
        {
            return await Mediator.Send(command);
        }

      

    }
}