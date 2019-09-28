using MediatR;

namespace AssistCust.Application.CompanyShops.Commands.DeleteCompanyShop
{
    public class DeleteCompanyShopCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}