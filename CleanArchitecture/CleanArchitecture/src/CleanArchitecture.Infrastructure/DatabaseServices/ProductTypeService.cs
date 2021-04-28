using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using SqlKata.Execution;
using SqlKata.Compilers;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductTypeService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProductType(ProductTypeCommand request)
        {
           
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            if (!await IsProductTypeKeyUnique(db, request.ProductTypeKey, Guid.Empty))
                return false;

            var affectedRecords = await db.Query("ProductType").InsertAsync(new
            {
                ProductTypeID = Guid.NewGuid(),
                ProductTypeKey = request.ProductTypeKey,
                ProductTypeName = request.ProductTypeName,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });
           
            return affectedRecords > 0;
        }

        public async Task<bool> DeleteProductType(Guid productTypeId)
        {
            using var conn = await _database.CreateConnectionAsync();
            var parameters = new
            {
                ProductTypeID = productTypeId
            };
            var affectedRecords = await conn.ExecuteAsync("DELETE FROM ProductType where ProductTypeID = @ProductTypeID",
                parameters);
            return affectedRecords > 0;
        }

        public async Task<IEnumerable<ProductTypeQueryResponseModel>> FetchProductType()
        {
            using var conn = await _database.CreateConnectionAsync();
            var result = conn.Query<ProductTypeQueryResponseModel>("Select * from ProductType").ToList();
            return result;
        }

        private async Task<bool> IsProductTypeKeyUnique(QueryFactory db, string productTypeKey, Guid productTypeID)
        {
            var result = await db.Query("ProductType").Where("ProductTypeKey", "=", productTypeKey)
                .FirstOrDefaultAsync<ProductTypeResponseModel>();

            if (result == null)
                return true;

            return result.ProductTypeID == productTypeID;
        }
    }
}
