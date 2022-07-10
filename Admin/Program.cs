using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Services.BrandServices.BrandFacade;
using Application.Services.CategoryServices.FacadeCategory;
using Application.Services.CommentServices.CommentFacade;
using Application.Services.ProductServices.ProductFacade;
using Application.Services.TagsServices.TagFacade;
using Infrastructure.IdentityConfig;
using Infrastructure.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


# region ConncetionString
builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration["ConnectionString:DataBaseConnection"]);
});
# endregion

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IIdentityDatabaseContext, IdentityDatabaseContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICommentService, CommentService>();


builder.Services.AddIdentityService(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
