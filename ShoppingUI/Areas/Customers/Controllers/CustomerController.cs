using Application.Interfaces;
using Application.Services.CustomerServices.AddNewAddress;
using Application.Services.CustomerServices.CustomerFacade;
using Domain.Entites.DivisionCountry;

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

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        
        public async Task<IActionResult> Index()
        {
            var userId = ClaimUtility.GetUserId(User);
            var user = await customerService.GetInfo.ExecuteAsync(userId);
            return View(user);
        }

        public IActionResult Iran(string? ir)
        {
            return View(ir);
        }

        [HttpGet]
        public async Task<IActionResult> AddAddress(int stateId)
        
        {
            var data = new AddAddressDto
            {
                Citites =
                new SelectList(await customerService.GetDivisionCountry.GetAllCityAsync(stateId), "Id", "CityName"),
                States =
                new SelectList(await customerService.GetDivisionCountry.GetAllStateAsync(), "Id", "StateName")
            };

            data.UserId = ClaimUtility.GetUserId(User);
            return View(data);

        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressDto address)
        {

            var result = await customerService.AddAddress.ExecuteAsync(address);

            if(result == true)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

        
        public async Task<JsonResult> ShowCities(int stateId)
        {
            var cities = await customerService.GetDivisionCountry.GetAllCityAsync(stateId);

            var list = new List<AddressViewModel>();
            foreach (var item in cities.OrderBy(p => p.CityName))
            {
                list.Add(new AddressViewModel
                {
                    Id = item.Id,
                    Name = item.CityName
                });
            }

            return new JsonResult(list);
        }


    }
}
