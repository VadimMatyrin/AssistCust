using MediatR;

namespace AssistCust.Application.CompanyShops.Commands.CreateCompanyShop
{
    public class CreateCompanyShopCommand : IRequest<int>
    {
        public string ShopName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
    }
}
