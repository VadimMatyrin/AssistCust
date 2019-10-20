using MediatR;

namespace AssistCust.Application.CompanyShops.Commands.UpdateCompanyShop
{
    public class UpdateCompanyShopCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public string UserId { get; set; }
    }
}
