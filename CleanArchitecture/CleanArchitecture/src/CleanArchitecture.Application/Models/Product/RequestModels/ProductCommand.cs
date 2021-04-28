using CleanArchitecture.Application.Models.ResponseModels;
using CleanArchitecture.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Models.RequestModels
{
    public class ProductCommand: IRequest<bool>
    {
        public Guid ProductID { get; set; }
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUri { get; set; }
        public Guid ProductTypeID { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
