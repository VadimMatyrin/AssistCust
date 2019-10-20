using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}