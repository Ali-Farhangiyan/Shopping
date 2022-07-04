using Application.Services.BasketServices.GetOrCreateBasketForUser;
using Application.Services.CustomerServices.AddNewAddress;
using Application.Services.CustomerServices.GetAddress;
using Application.Services.CustomerServices.GetInfo;

namespace ShoppingUI.Models.ViewModels
{
    public class OrderViewModels
    {
        public BasketDto Basket { get; set; }

        public List<GetAddressDto> Addresses { get; set; }
    }
}
