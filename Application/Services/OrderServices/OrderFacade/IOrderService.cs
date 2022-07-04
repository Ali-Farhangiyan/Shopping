using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Services.OrderServices.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OrderServices.OrderFacade
{
    public interface IOrderService
    {
        ICreateOrderService CreateOrder { get; }
    }

    public class OrderService : IOrderService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageService;

        public OrderService(IDatabaseContext db,IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }




        private ICreateOrderService createOrder;
        public ICreateOrderService CreateOrder =>
            createOrder ?? new CreateOrderService(db, imageService);
    }
}
