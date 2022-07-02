using Application.Interfaces;
using Domain.Entites.Attributes;
using Domain.Entites.Baskets;
using Domain.Entites.Customers;
using Domain.Entites.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.CategoryConfigurations;
using Persistence.EntityConfigurations.ProductConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Feature> Features { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Tags> Tags { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<BasketItem> BasketItems { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> Option) : base(Option) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditTableAttribute),true).Length > 0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                    
                }
            }

            modelBuilder.Entity<Product>()
                        .HasQueryFilter(f => EF.Property<bool>(f, "IsRemoved") == false);

            modelBuilder.Entity<Category>()
                        .HasQueryFilter(f => EF.Property<bool>(f, "IsRemoved") == false);

            modelBuilder.Entity<BasketItem>()
                        .HasQueryFilter(f => EF.Property<bool>(f, "IsRemoved") == false);

            modelBuilder.Entity<Basket>()
                        .HasQueryFilter(f => EF.Property<bool>(f, "IsRemoved") == false);

            modelBuilder.Entity<Address>()
                        .HasQueryFilter(f => EF.Property<bool>(f, "IsRemoved") == false);


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());


            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {
            var modifiedEntites = ChangeTracker.Entries()
                .Where(m => m.State == EntityState.Modified || m.State == EntityState.Added || m.State == EntityState.Deleted);

            foreach (var item in modifiedEntites)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                
                

                if (entityType is not null)
                {
                    var inserted = entityType.FindProperty("InsertTime");
                    var updated = entityType.FindProperty("UpdateTime");
                    var RemoveTime = entityType.FindProperty("RemoveTime");
                    var IsRemoved = entityType.FindProperty("IsRemoved");

                    if (item.State == EntityState.Added && inserted != null)
                    {
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Modified && updated != null)
                    {
                        item.Property("UpdateTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                    {
                        item.Property("RemoveTime").CurrentValue = DateTime.Now;
                        item.Property("IsRemoved").CurrentValue = true;
                        item.State = EntityState.Modified;
                    }
                }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var modifiedEntites = ChangeTracker.Entries()
                .Where(m => m.State == EntityState.Modified || m.State == EntityState.Added || m.State == EntityState.Deleted);

            foreach (var item in modifiedEntites)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());


                if (entityType is not null)
                {
                    var inserted = entityType.FindProperty("InsertTime");
                    var updated = entityType.FindProperty("UpdateTime");
                    var RemoveTime = entityType.FindProperty("RemoveTime");
                    var IsRemoved = entityType.FindProperty("IsRemoved");

                    if (item.State == EntityState.Added && inserted != null)
                    {
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Modified && updated != null)
                    {
                        item.Property("UpdateTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                    {
                        item.Property("RemoveTime").CurrentValue = DateTime.Now;
                        item.Property("IsRemoved").CurrentValue = true;
                        item.State = EntityState.Modified;
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
