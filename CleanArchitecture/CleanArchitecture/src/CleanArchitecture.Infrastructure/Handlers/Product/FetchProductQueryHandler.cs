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
    public class FetchProductQueryHandler : BaseProductHandler, IRequestHandler<FetchProductQuery, IEnumerable<ProductQueryResponseModel>>
    {
        public FetchProductQueryHandler(IProductService productService) : base(productService)
        {
        }
        public async Task<IEnumerable<ProductQueryResponseModel>> Handle(FetchProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.FetchProduct();

            return result;
        }
    }
}
