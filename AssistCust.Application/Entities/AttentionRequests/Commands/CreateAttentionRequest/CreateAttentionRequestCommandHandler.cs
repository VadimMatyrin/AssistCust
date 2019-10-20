using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.AttentionRequests.Commands.CreateAttentionRequest
{
    public class CreateAttentionRequestCommandHandler : IRequestHandler<CreateAttentionRequestCommand, int>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public CreateAttentionRequestCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<int> Handle(CreateAttentionRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = new AttentionRequest
            {
                Message = request.Message,
                CreationDate = request.CreationDate,
                IsResolved = false,
                ManagerId = request.ManagerId,
                SenderId = _userAccessService.UserId,
                CompanyShopId = request.CompanyShopId
            };

            _context.AttentionRequests.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
