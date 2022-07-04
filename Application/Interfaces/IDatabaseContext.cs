using Domain.Entites.Baskets;
using Domain.Entites.Customers;
using Domain.Entites.DivisionCountry;
using Domain.Entites.Orders;
using Domain.Entites.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Tags> Tags { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<State> States { get; set; }


        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default);
    }
}
