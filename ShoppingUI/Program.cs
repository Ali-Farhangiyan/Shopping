using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

using Infrastructure.IdentityConfig;
using Application.Interfaces;
using Application.Services.ProductServices.ProductFacade;
using Application.ImageServices.FacadeImage;
using Application.Services.CategoryServices.FacadeCategory;
using Application.Services.TagsServices.TagFacade;
using Application.Services.BrandServices.BrandFacade;
using Infrastructure.MappingProfiles;
using Application.Services.BasketServices.BasketFacade;
using Application.Services.CustomerServices.CustomerFacade;

using Application.Services.OrderServices.OrderFacade;
using Application.Services.CommentServices.CommentFacade;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


# region ConncetionString
// For Database Context
builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration["ConnectionString:DataBaseConnection"]);
});


# endregion


builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IIdentityDatabaseContext, IdentityDatabaseContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddIdentityService(builder.Configuration);






var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    //app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "prducts",
    pattern: "product/{Slug}",
    defaults: new {controller="Product", action="Details"}) ;

app.MapControllerRoute(
    name: "categories",
    pattern: "category/{CategorySlug}",
    defaults: new { controller = "Product", action ="Index"}
    ); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
