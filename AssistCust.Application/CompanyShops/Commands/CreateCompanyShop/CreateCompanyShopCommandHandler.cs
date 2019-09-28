using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.CompanyShops.Commands.CreateCompanyShop
{
    public class CreateCompanyShopCommandHandler : IRequestHandler<CreateCompanyShopCommand, int>
    {
        private readonly IAssistDbContext _context;
        public CreateCompanyShopCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCompanyShopCommand request, CancellationToken cancellationToken)
        {
            var entity = new CompanyShop
            {
                ShopName = request.ShopName,
                State = request.State,
                City = request.City,
                AddressField1 = request.AddressField1,
                AddressField2 = request.AddressField2,
                UserId = request.UserId,
                CompanyId = request.CompanyId
            };

            _context.CompanyShops.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
