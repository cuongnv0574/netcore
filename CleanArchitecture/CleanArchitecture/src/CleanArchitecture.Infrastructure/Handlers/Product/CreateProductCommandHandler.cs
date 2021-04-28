using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<ProductCommand, bool>
    {
        public readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(ProductCommand request, CancellationToken cancellationToken)
        {

            var result = await _productService.CreateProduct(request);
            return result;
        }


    }

}
