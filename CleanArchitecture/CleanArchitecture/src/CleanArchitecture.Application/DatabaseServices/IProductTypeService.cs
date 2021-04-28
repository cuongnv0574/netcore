using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DatabaseServices
{
    public interface IProductTypeService
    {
        //Task<bool> CreateProductType(ProductType request);
        //Task<bool> DeleteProductType(Guid productTypeId);
        //Task<IEnumerable<ProductType>> FetchProductType();
        Task<bool> CreateProductType(ProductTypeCommand request);
        Task<bool> DeleteProductType(Guid productTypeId);

        Task<IEnumerable<ProductTypeQueryResponseModel>> FetchProductType();
    }
}
