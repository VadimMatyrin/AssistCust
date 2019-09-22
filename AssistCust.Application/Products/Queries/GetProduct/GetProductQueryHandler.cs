using AutoMapper;
using AssistCust.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AssistCust.Application.Exceptions;

namespace AssistCust.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductViewModel>(await _context
                .Products.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return product;
        }
    }
}
