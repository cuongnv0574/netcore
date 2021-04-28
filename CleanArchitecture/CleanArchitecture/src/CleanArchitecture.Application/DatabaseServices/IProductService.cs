using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DatabaseServices
{
  
        public interface IProductService
        {
            Task<bool> CreateProduct(ProductCommand request);
            Task<bool> DeleteProduct(Guid productTypeId);
            Task<IEnumerable<ProductQueryResponseModel>> FetchProduct();
        }
  
}
