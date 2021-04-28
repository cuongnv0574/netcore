using CleanArchitecture.Application.Models.ResponseModels;
using CleanArchitecture.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Models.RequestModels
{
    public class ProductTypeCommand : IRequest<bool>
    {

        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
