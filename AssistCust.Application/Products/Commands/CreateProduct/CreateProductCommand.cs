using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
