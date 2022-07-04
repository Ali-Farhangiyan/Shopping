using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Services.CustomerServices.GetAddress;
using Domain.Entites.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OrderServices.CreateOrder
{
    public interface ICreateOrderService
    {
        Task<int> ExecuteAsync(string userId, int addressId, PaymentMethode paymentMethode);
    }

    public class CreateOrderService : ICreateOrderService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageService;

        public CreateOrderService(IDatabaseContext db,
            IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }
        public async Task<int> ExecuteAsync(string userId, int addressId, PaymentMethode paymentMethode)
        {
            var basket = await db.Baskets
                .Include(b => b.BasketItems)
                .ThenInclude(b => b.Product)
                .ThenInclude(b => b.Images)
                .Where(b => b.BuyerId == userId)
                .SingleOrDefaultAsync();

            var address = await db.Addresses
                .Where(a => a.Id == addressId)
                .Select(a => new UserAddress(
                    a.City,
                    a.State,
                    a.PostalCode,
                    $"{a.State} - {a.City} - {a.Street} - {a.Allay} - {a.Plaque}"
                    )).SingleOrDefaultAsync(); 

            

            var orderItems = new List<OrderItem>();

            foreach (var item in basket.BasketItems)
            {
                orderItems.Add(new OrderItem(
                    item.ProductId,
                    item.Product.Name,
                    imageService.ImageComposer.Execute(item?.Product?.Images?.FirstOrDefault()?.Src ?? ""),
                    item.Price, item.Quantity));
            }

            var order = new Order(userId, orderItems, address, paymentMethode);

            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync(true);

            return order.Id;

        }
    }
}
