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
    public class FetchProductTypeQueryHandler : BaseProductTypeHandler, IRequestHandler<FetchProductTypeQuery, IEnumerable<ProductTypeQueryResponseModel>>
    {
        public FetchProductTypeQueryHandler(IProductTypeService productTypeService) : base(productTypeService)
        {
        }
        public async Task<IEnumerable<ProductTypeQueryResponseModel>> Handle(FetchProductTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productTypeService.FetchProductType();

            return result;
        }
    }
}
