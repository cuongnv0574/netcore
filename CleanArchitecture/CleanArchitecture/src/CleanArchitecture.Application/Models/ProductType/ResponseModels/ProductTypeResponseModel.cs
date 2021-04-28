using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Models.ResponseModels
{
    public class ProductTypeResponseModel
    {
        public bool IsSuccess { get; set; }
        public Guid ProductTypeID { get; set; }
    }
}
