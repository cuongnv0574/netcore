using CleanArchitecture.Application.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Handlers
{
    public class BaseProductHandler
    {
        public readonly IProductService _productService;
        public BaseProductHandler(IProductService productService)
        {
            _productService = productService;
        }
    }

}
