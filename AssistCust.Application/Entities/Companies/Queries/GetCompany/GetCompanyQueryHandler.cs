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

namespace AssistCust.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompanyViewModel> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<CompanyViewModel>(await _context
                .Companies.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (company == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            return company;
        }
    }
}
