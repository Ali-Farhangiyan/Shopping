﻿using Domain.Entites.Products;
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


        int SaveChanges();
    }
}