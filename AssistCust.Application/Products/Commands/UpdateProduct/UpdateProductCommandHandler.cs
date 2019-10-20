using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Products.Commands.CreateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public UpdateProductCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            if (!(await _userAccessService.IsCompanyOwnerAsync(entity.CompanyId)))
                throw new InsufficientPrivilegesException(nameof(Product));

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
