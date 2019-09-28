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

namespace AssistCust.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        public UpdateCompanyCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Country = request.Country;
            entity.UserId = request.UserId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
