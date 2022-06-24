using Domain.Entites.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Slug).HasMaxLength(500).IsRequired();
            builder.HasIndex(p => p.Slug).IsUnique();
        }
    }
}
