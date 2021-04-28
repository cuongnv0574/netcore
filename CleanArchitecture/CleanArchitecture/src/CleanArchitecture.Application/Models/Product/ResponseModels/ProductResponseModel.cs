using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Models.ResponseModels
{
    public class ProductResponseModel
    {
        public bool IsSuccess { get; set; }
        public Guid ProductID { get; set; }
    }
}
