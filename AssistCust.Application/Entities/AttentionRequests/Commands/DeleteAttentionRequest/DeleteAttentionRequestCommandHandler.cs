using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.AttentionRequests.Commands.DeleteAttentionRequest
{
    public class DeleteAttentionRequestCommandHandler : IRequestHandler<DeleteAttentionRequestCommand>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public DeleteAttentionRequestCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(DeleteAttentionRequestCommand request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsAttentionRequestCreatorOrShopManagerAsync(request.Id)))
                throw new InsufficientPrivilegesException(nameof(AttentionRequest));

            var entity = await _context.AttentionRequests.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AttentionRequest), request.Id);
            }

            _context.AttentionRequests.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}