using CleanArchitecture.Application.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Handlers
{
    public class BaseProductTypeHandler
    {
        public readonly IProductTypeService _productTypeService;
        public BaseProductTypeHandler(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }
    }

}
