using AutoMapper;
using AssistCust.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AssistCust.Application.CompanyShops.Queries.ViewModels;
using System.Collections.Generic;

namespace AssistCust.Application.CompanyShops.Queries.GetAllUserManagedShops
{
    public class GetAllUserManagedShopsQueryHandler : IRequestHandler<GetAllUserManagedShopsQuery, CompanyShopsListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public GetAllCompanyShopsByCompanyQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<CompanyShopsListViewModel> Handle(GetAllUserManagedShopsQuery request, CancellationToken cancellationToken)
        {
            var shops = await _context.CompanyShops.Where(p => p.UserId == _userAccessService.UserId).ToListAsync(cancellationToken);

            var model = new CompanyShopsListViewModel
            {
                CompanyShops = _mapper.Map<IEnumerable<CompanyShopViewModel>>(shops)
            };

            return model;
        }
    }
}
