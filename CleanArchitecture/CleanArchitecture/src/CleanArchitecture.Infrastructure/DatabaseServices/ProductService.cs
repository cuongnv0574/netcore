using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using SqlKata.Execution;
using SqlKata.Compilers;
using CleanArchitecture.Application.Models.ResponseModels;
using CleanArchitecture.Application.Models.RequestModels;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductService : IProductService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProduct(ProductCommand request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            if (!await IsProductKeyUnique(db, request.ProductKey, Guid.Empty))
                return false;

            var affectedRecords = await db.Query("Product").InsertAsync(new
            {
                ProductId = Guid.NewGuid(),
                ProductKey = request.ProductKey,
                ProductName = request.ProductName,
                ProductImageUri = request.ProductImageUri,
                ProductTypeID = request.ProductTypeID,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });

            return affectedRecords > 0;
        }

        public Task<bool> DeleteProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductQueryResponseModel>> FetchProduct()
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var result = db.Query("Product")
                .Select(
                "ProductID",
                "ProductKey",
                "ProductName",
                "ProductImageUri",
                "ProductTypeName",
                "Product.RecordStatus")
                .Join("ProductType", "ProductType.ProductTypeID", "Product.ProductTypeID")
                .OrderByDesc("Product.UpdatedDate")
                .OrderByDesc("Product.CreatedDate");

            return await result.GetAsync<ProductQueryResponseModel>();
        }

        private async Task<bool> IsProductKeyUnique(QueryFactory db, string productKey, Guid productID)
        {
            var result = await db.Query("Product").Where("ProductKey", "=", productKey)
                .FirstOrDefaultAsync<ProductResponseModel>();

            if (result == null)
                return true;

            return result.ProductID == productID;
        }


    }
}
