using AssistCust.Application.Interfaces;
using AssistCust.Application.Products.Queries.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Products.Queries.GetAllProductsByCompany
{
    public class GetAllProductsByCompanyQueryHandler : IRequestHandler<GetAllProductsByCompanyQuery, ProductsListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsByCompanyQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsListViewModel> Handle(GetAllProductsByCompanyQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Where(p => p.CompanyId == request.CompanyId).ToListAsync(cancellationToken);

            var model = new ProductsListViewModel
            {
                Products = _mapper.Map<IEnumerable<ProductViewModel>>(products)
            };

            return model;
        }
    }
}
