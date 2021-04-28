using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;
using CleanArchitecture.Infrastructure.DatabaseServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers
{
    public class CreateProductTypeCommandHandler : IRequestHandler<ProductTypeCommand, bool>
    {
        public readonly IProductTypeService _productTypeService;

        public CreateProductTypeCommandHandler(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public async Task<bool> Handle(ProductTypeCommand request, CancellationToken cancellationToken)
        {

            var result = await _productTypeService.CreateProductType(request);
            return result;
        }


    }

}
