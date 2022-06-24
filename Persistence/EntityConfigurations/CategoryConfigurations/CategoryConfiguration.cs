using Domain.Entites.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations.CategoryConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Slug).HasMaxLength(500).IsRequired();
            builder.HasIndex(p => p.Slug).IsUnique();

            

            builder.HasOne(p => p.ParentCategory).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
