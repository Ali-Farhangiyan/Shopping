using Application.Interfaces;
using Domain.Entites.Customers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Services.CustomerServices.AddNewAddress
{
    public interface IAddNewAddressService
    {
        Task<bool> ExecuteAsync(AddAddressDto address);
    }

    public class AddNewAddressService : IAddNewAddressService
    {
        private readonly IDatabaseContext db;

        public AddNewAddressService(IDatabaseContext db)
        {
            this.db = db;
        }


        public async Task<bool> ExecuteAsync(AddAddressDto address)
        {
            var addr = new Address
            {
                UserId = address.UserId,
                State = address.State,
                Street = address.Street,
                Allay = address.Allay,
                City = address.City,
                Plaque = address.Plaque,
                PostalCode = address.PostalCode
            };

            await db.Addresses.AddAsync(addr);
            var result = await db.SaveChangesAsync(true);

            if(result > 0)
            {
                return true;
            }

            return false;
        }
    }

    public class AddAddressDto
    {
        public string UserId { get; set; }

        public string City { get; set; }
        public SelectList Citites { get; set; }

        public string State { get; set; } 
        public SelectList States { get; set; }

        public string PostalCode { get; set; }

        public string? Street { get; set; }

        public string? Allay { get; set; }

        public string? Plaque { get; set; }
        

    }
}
