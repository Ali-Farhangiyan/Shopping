using Application.Services.CustomerServices.AddNewAddress;
using Application.Services.CustomerServices.CustomerFacade;
using Iran.AspNet.CountryDivisions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using ShoppingUI.Areas.Customers.Models.ViewModels;
using ShoppingUI.Utilities;

namespace ShoppingUI.Areas.Customers.Controllers
{
    [Area("Customers")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IIranCountryDivisions iranCountryDivisions;

        public CustomerController(ICustomerService customerService
            , IIranCountryDivisions iranCountryDivisions)
        {
            this.customerService = customerService;
            this.iranCountryDivisions = iranCountryDivisions;
        }
        
        public async Task<IActionResult> Index()
        {
            var userId = ClaimUtility.GetUserId(User);
            var user = await customerService.GetInfo.ExecuteAsync(userId);
            return View(user);
        }


        public async Task<IActionResult> AddAddress(string ostanId)
        
        {
            var states = await iranCountryDivisions.GetOstansAsync();
            states = states.OrderBy(p => p.Name);
            

            var data = new AddAddressDto
            {
                Citites =
                new SelectList(await iranCountryDivisions.GetShahrestansAsync(p => p.OstanId == ostanId), "Id", "Name"),
                States =
                new SelectList(states, "Id", "Name")
            };

            data.UserId = ClaimUtility.GetUserId(User);
            return View(data);

        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressDto address)
        {
            var city = await iranCountryDivisions.GetShahrsAsync(p => p.id == address.City);
            var state = await iranCountryDivisions.GetOstansAsync(p => p.Id == address.State);

            address.City = city.FirstOrDefault().Name;
            address.State = state.FirstOrDefault().Name;


            var result = await customerService.AddAddress.ExecuteAsync(address);


            if(result == true)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

        
        public async Task<JsonResult> ShowCities(string ostanId)
        {
            var cities = await iranCountryDivisions.GetShahrsAsync(p => p.OstanId == ostanId);

            var list = new List<AddressViewModel>();
            foreach (var item in cities.ToList().OrderBy(p => p.Name))
            {
                list.Add(new AddressViewModel
                {
                    Id = item.id,
                    Name = item.Name
                });
            }

            return new JsonResult(list);
        }


    }
}
