using AutoMapper;
using AssistCust.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AssistCust.Application.CompanyShops.Queries.ViewModels;
using System.Collections.Generic;

namespace AssistCust.Application.CompanyShops.Queries.GetAllCompanyShopsByCompany
{
    public class GetAllCompanyShopsByCompanyQueryHandler : IRequestHandler<GetAllCompanyShopsByCompanyQuery, CompanyShopsListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCompanyShopsByCompanyQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompanyShopsListViewModel> Handle(GetAllCompanyShopsByCompanyQuery request, CancellationToken cancellationToken)
        {
            var shops = await _context.CompanyShops.Where(p => p.CompanyId == request.CompanyId).ToListAsync(cancellationToken);

            var model = new CompanyShopsListViewModel
            {
                CompanyShops = _mapper.Map<IEnumerable<CompanyShopViewModel>>(shops)
            };

            return model;
        }
    }
}
