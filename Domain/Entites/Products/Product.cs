using Domain.Entites.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Products
{
    [AuditTable]
    public class Product
    {
        public int Id { get; set; }

        public string Slug { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public double Rate { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaTitle { get; set; }

        public string Description { get; set; } = null!;

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public Brand? Brand { get; set; }

        public int BrandId { get; set; }

        public ICollection<Image>? Images { get; set; }

        public ICollection<Tags>? Tags { get; set; }

        public ICollection<Feature>? Features { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
