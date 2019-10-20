using AutoMapper;
using AssistCust.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AssistCust.Application.Exceptions;
using MediatR;
using AssistCust.Application.CompanyShops.Queries.ViewModels;

namespace AssistCust.Application.CompanyShops.Queries.GetCompanyShop
{
    public class GetCompanyShopQueryHandler : IRequestHandler<GetCompanyShopQuery, CompanyShopViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyShopQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompanyShopViewModel> Handle(GetCompanyShopQuery request, CancellationToken cancellationToken)
        {
            var companyShop = _mapper.Map<CompanyShopViewModel>(await _context
                .CompanyShops.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (companyShop == null)
            {
                throw new NotFoundException(nameof(CompanyShop), request.Id);
            }

            return companyShop;
        }
    }
}
