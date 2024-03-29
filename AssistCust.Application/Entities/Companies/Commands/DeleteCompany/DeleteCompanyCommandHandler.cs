﻿using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public DeleteCompanyCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsCompanyOwnerAsync(request.Id)))
                throw new InsufficientPrivilegesException(nameof(request));

            var entity = await _context.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            var hasOrders = _context.CompanyShops.Any(pd => pd.CompanyId == entity.Id);
            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(Company), request.Id, "There are existing company shops assosiated with this product.");
            }

            _context.Companies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}