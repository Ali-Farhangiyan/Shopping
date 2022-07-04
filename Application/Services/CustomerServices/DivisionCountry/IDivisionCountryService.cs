using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices.DivisionCountry
{
    public interface IDivisionCountryService
    {
        Task<List<StateDto>> GetAllStateAsync();

        Task<List<CityDto>> GetAllCityAsync(int stateId);
    }

    public class DivisionCountryService : IDivisionCountryService
    {
        private readonly IDatabaseContext db;

        public DivisionCountryService(IDatabaseContext db)
        {
            this.db = db;
        }



        public async Task<List<CityDto>> GetAllCityAsync(int stateId)
        {
            var cities = await db.Cities
                .Where(c => c.StateId == stateId)
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    CityName = c.CityName,
                    StateId = c.StateId
                }).ToListAsync();

            return cities;
        }

        public async Task<List<StateDto>> GetAllStateAsync()
        {
            var states = await db.States
                .Select(s => new StateDto
                {
                    Id = s.Id,
                    StateName = s.StateName
                }).ToListAsync();

            return states;
        }
    }

    public class CityDto
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public int? StateId { get; set; }
    }

    public class StateDto
    {
        public int Id { get; set; }

        public string StateName { get; set; }
    }


}
