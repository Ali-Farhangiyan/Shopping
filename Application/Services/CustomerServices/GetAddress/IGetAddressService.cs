using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices.GetAddress
{
    public interface IGetAddressService
    {
        Task<List<GetAddressDto>> ExecuteAsync(string userId);
    }

    public class GetAddressService : IGetAddressService
    {
        private readonly IDatabaseContext db;

        public GetAddressService(IDatabaseContext db)
        {
            this.db = db;
        }

        public async Task<List<GetAddressDto>> ExecuteAsync(string userId)
        {
            var address = await db.Addresses
                .Where(a => a.UserId == userId)
                .Select(a => new GetAddressDto
                {
                    Id = a.Id,
                    City = a.City,
                    State = a.State,
                    PostalCode = a.PostalCode,
                    CompleteAddress = $"{a.State} - {a.City} - {a.Street} - {a.Allay} - {a.Plaque}"
                }).ToListAsync();

            return address;
        }
    }

    public class GetAddressDto
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }

        public string CompleteAddress { get; set; }
    }
}
