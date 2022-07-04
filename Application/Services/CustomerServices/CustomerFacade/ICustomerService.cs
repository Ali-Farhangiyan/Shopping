using Application.Interfaces;
using Application.Services.CustomerServices.AddNewAddress;
using Application.Services.CustomerServices.DivisionCountry;
using Application.Services.CustomerServices.GetAddress;
using Application.Services.CustomerServices.GetInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices.CustomerFacade
{
    public interface ICustomerService
    {
        IAddNewAddressService AddAddress { get; }

        IGetInfoService GetInfo { get; }

        IGetAddressService GetAddress { get; }

        IDivisionCountryService GetDivisionCountry { get; }
    }

    public class CustomerService : ICustomerService
    {
        private readonly IDatabaseContext db;
        private readonly IIdentityDatabaseContext identityDb;

        public CustomerService(IDatabaseContext db, IIdentityDatabaseContext identityDb)
        {
            this.db = db;
            this.identityDb = identityDb;
        }

        private IAddNewAddressService addAddress;
        public IAddNewAddressService AddAddress =>
            addAddress ?? new AddNewAddressService(db);



        private IGetInfoService getInfo;
        public IGetInfoService GetInfo =>
            getInfo ?? new GetInfoService(identityDb,db);



        private IGetAddressService getAddress;
        public IGetAddressService GetAddress =>
            getAddress ?? new GetAddressService(db);


        private IDivisionCountryService getDivisionCountry;
        public IDivisionCountryService GetDivisionCountry =>
            getDivisionCountry ?? new DivisionCountryService(db);
    }
}
