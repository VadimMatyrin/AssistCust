using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Products.Commands.CreateProduct
{
    class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IAssistDbContext _context;
        public CreateProductCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                CompanyId = request.CompanyId
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
