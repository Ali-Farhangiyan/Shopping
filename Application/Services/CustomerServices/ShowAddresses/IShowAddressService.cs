using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices.ShowAddresses
{
    public interface IShowAddressService
    {
        Task<List<ShowAddressDto>> ExecuteAsync(string userId);
    }

    public class ShowAddressService : IShowAddressService
    {
        private readonly IDatabaseContext db;

        public ShowAddressService(IDatabaseContext db)
        {
            this.db = db;
        }


        public async Task<List<ShowAddressDto>> ExecuteAsync(string userId)
        {
            var addresses = await db.Addresses
                .Where(a => a.UserId == userId)
                .Select(a => new ShowAddressDto
                {
                    PostalCode = a.PostalCode,
                    WholeAddress = $"{a.State} - {a.City} - {a.Street} - {a.Allay} - {a.Plaque}"
                })
                .ToListAsync();

            return addresses;
        }
    }

    public class ShowAddressDto
    {
        public string PostalCode { get; set; }

        public string WholeAddress { get; set; }
    }
}
