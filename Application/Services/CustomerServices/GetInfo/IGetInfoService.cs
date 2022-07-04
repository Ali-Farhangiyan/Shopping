using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices.GetInfo
{
    public interface IGetInfoService
    {
        Task<GetInfoDto> ExecuteAsync(string userId);
    }

    public class GetInfoService : IGetInfoService
    {
        private readonly IIdentityDatabaseContext identityDb;
        private readonly IDatabaseContext db;

        public GetInfoService( IIdentityDatabaseContext identityDb, IDatabaseContext db)
        {
            this.identityDb = identityDb;
            this.db = db;
        }


        public async Task<GetInfoDto> ExecuteAsync(string userId)
        {
            var user = await identityDb.Users.FindAsync(userId);

            var userShow = new GetInfoDto
            {
                Email = user.Email,
                FirstName = user.FullName.Split(" ").FirstOrDefault(),
                LastName = user.FullName.Split(" ").LastOrDefault(),
                PhoneNumber = user.PhoneNumber,
                Addresses = await db.Addresses.Where(p => p.UserId == userId).Select(p => new ShowAddressDto
                {
                    PostalCode = p.PostalCode,
                    WholeAddress = $"{p.State} - {p.City} - {p.Street} - {p.Allay} - {p.Plaque}"
                }).ToListAsync()

            };

            return userShow;
        }
    }

    public class GetInfoDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


        public List<ShowAddressDto> Addresses { get; set; }
    }

    public class ShowAddressDto
    {
        public string PostalCode { get; set; }

        public string WholeAddress { get; set; }
    }
}
