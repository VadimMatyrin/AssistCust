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
using AssistCust.Application.AttentionRequests.Queries.ViewModels;

namespace AssistCust.Application.AttentionRequests.Queries.GetAttentionRequest
{
    public class AttentionRequestsQueryHandler : IRequestHandler<GetAttentionRequestQuery, AttentionRequestViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public AttentionRequestsQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<AttentionRequestViewModel> Handle(GetAttentionRequestQuery request, CancellationToken cancellationToken)
        {
            var attentionRequest = _mapper.Map<AttentionRequestViewModel>(await _context
                .AttentionRequests.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (attentionRequest == null)
            {
                throw new NotFoundException(nameof(AttentionRequest), request.Id);
            }

            if (!(await _userAccessService.IsAttentionRequestCreatorOrShopManagerAsync(attentionRequest.Id)))
                throw new InsufficientPrivilegesException(nameof(AttentionRequest));

            return attentionRequest;
        }
    }
}
