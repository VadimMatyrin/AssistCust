using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly IAssistDbContext _context;
        public CreateCompanyCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = new Company
            {
                Name = request.Name,
                Country = request.Country,
                UserId = request.UserId
            };

            _context.Companies.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
