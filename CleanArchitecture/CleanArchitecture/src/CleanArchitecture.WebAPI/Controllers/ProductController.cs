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
    public class ProductsController : CustomBaseApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public async Task<IEnumerable<ProductQueryResponseModel>> Get()
        {
            var query = new FetchProductQuery();
            return await Mediator.Send(query);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<bool>> Post(ProductCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}