using CleanArchitecture.Application.Models.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Models.RequestModels
{
    public class FetchProductQuery : IRequest<IEnumerable<ProductQueryResponseModel>>
    {

    }
}
