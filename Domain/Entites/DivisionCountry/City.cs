using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.DivisionCountry
{
    public class City
    {
        public int Id { get; set; }

        public string? CityName { get; set; }

        public State State { get; set; }

        public int? StateId { get; set; }
    }

    public class State
    {
        public int Id { get; set; }

        public string? StateName { get; set; }

        public ICollection<City>? Cities { get; set; }
    }
}
