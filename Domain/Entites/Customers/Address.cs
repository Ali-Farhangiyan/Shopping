using Domain.Entites.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Customers
{
    [AuditTable]
    public class Address
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public string? Street { get; set; }

        public string? Allay { get; set; }

        public string? Plaque { get; set; }

        
    }
}
