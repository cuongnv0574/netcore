using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using SqlKata.Execution;
using SqlKata.Compilers;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductService : IProductService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProduct(Product request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());
            var affectedRecords = await db.Query("Product").InsertAsync(new
            {
                ProductID = Guid.NewGuid(),
                ProductKey = request.ProductKey,
                ProductName = request.ProductName,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });
            return affectedRecords > 0;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            using var conn = await _database.CreateConnectionAsync();
            var parameters = new
            {
                ProductID = productId
            };
            var affectedRecords = await conn.ExecuteAsync("DELETE FROM Product WHERE ProductID = @ProductID",
                parameters);
            return affectedRecords > 0;
        }

        public async Task<IEnumerable<Product>> FetchProduct()
        {
            using var conn = await _database.CreateConnectionAsync();
            var result = conn.Query<Product>("SELECT * FROM Product").ToList();
            return result;
        }

        //private async Task<bool> IsProductTypeKeyUnique(QueryFactory db, string productTypeKey, Guid productTypeID)
        //{
        //    var result = await db.Query("ProductType").Where("ProductTypeKey", "=", productTypeKey)
        //        .FirstOrDefaultAsync<ProductType>();

        //    if (result == null)
        //        return true;

        //    return result.ProductTypeID == productTypeID;
        //}
    }
}
