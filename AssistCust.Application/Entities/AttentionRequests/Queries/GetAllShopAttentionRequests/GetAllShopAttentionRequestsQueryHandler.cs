using AutoMapper;
using AssistCust.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AssistCust.Application.Exceptions;
using MediatR;
using AssistCust.Application.AttentionRequests.Queries.ViewModels;
using System.Collections.Generic;

namespace AssistCust.Application.AttentionRequests.Queries.GetAllShopAttentionRequests
{
    public class GetAllShopAttentionRequestsQueryHandler : IRequestHandler<GetAllShopAttentionRequestsQuery, AttentionRequestsListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public GetAllShopAttentionRequestsQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<AttentionRequestsListViewModel> Handle(GetAllShopAttentionRequestsQuery request, CancellationToken cancellationToken)
        {
            if(!(await _userAccessService.IsCompanyOwnerOrShopManagerAsync(request.CompanyShopId)))
                throw new InsufficientPrivilegesException(nameof(AttentionRequest));

            var shops = await _context.AttentionRequests.Where(p => p.CompanyShopId == request.CompanyShopId).ToListAsync(cancellationToken);

            var model = new AttentionRequestsListViewModel
            {
                AttentionRequests = _mapper.Map<IEnumerable<AttentionRequestViewModel>>(shops)
            };

            return model;
        }
    }
}
