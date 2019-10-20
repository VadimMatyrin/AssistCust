using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.AttentionRequests.Commands.UpdateAttentionRequest
{
    public class UpdateAttentionRequestCommandHandler : IRequestHandler<UpdateAttentionRequestCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public UpdateAttentionRequestCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(UpdateAttentionRequestCommand request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsAttentionRequestCreatorOrShopManagerAsync(request.Id)))
                throw new InsufficientPrivilegesException(nameof(AttentionRequest));

            var entity = await _context.AttentionRequests.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AttentionRequest), request.Id);
            }

            entity.Id = request.Id;
            entity.IsResolved = request.IsResolved;
            entity.Message = request.Message;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
