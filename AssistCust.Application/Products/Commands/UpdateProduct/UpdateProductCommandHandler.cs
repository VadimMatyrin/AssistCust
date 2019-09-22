using AssistCust.Application.Exceptions;
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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        public UpdateProductCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.CompanyId = request.CompanyId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
