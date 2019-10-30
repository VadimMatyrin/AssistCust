using AutoMapper;
using AssistCust.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AssistCust.Application.Exceptions;
using AssistCust.Application.Products.Queries.ViewModels;
using MediatR;
using AssistCust.Application.Companies.Queries.ViewModels;
using System.Collections.Generic;

namespace AssistCust.Application.Companies.Queries.GetAllCompaniesByUser
{
    public class GetAllCompaniesByUserQueryHandler : IRequestHandler<GetAllCompaniesByUserQuery, CompanyListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public GetAllCompaniesByUserQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<CompanyListViewModel> Handle(GetAllCompaniesByUserQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _context.Companies.Where(p => p.UserId == _userAccessService.UserId).ToListAsync();

            var model = new CompanyListViewModel
            {
                Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(purchases)
            };

            return model;
        }
    }
}
