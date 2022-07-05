using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Products
{
    public class Favorite
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}
