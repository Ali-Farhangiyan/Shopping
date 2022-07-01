using Domain.Entites.Attributes;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Baskets
{
    [AuditTable]
    public class Basket
    {
        public Basket(string buyerId)
        {
            this.BuyerId = buyerId;
        }
        public int Id { get; set; }

        public string BuyerId { get;private set; } = null!;

        private readonly List<BasketItem> basketItems = new List<BasketItem>();
        public ICollection<BasketItem> BasketItems =>
            basketItems.AsReadOnly();

        public void AddItem(int productId, int quantity, int price)
        {

            if (!BasketItems.Any(b => b.ProductId == productId))
            {
                basketItems.Add(new BasketItem(productId, quantity, price));
                return;
            }

            var exitedBasketItem = BasketItems.SingleOrDefault(b => b.ProductId == productId);
            if(exitedBasketItem is not null)
            {
                exitedBasketItem.AddQuantity();
            }
        } 


    }

    [AuditTable]
    public class BasketItem
    {
        public int Id { get; set; }

        public Basket Basket { get;private set; }

        public int BasketId { get;private set; }

        public Product Product { get;private set; }

        public int ProductId { get;private set; }

        public int Price { get;private set; }

        public int Quantity { get;private set; }

        public BasketItem(int productId, int quantity, int price)
        {
            this.ProductId = productId;
            this.Price = price;
            SetQuantity(quantity);
        }

        private void SetQuantity(int quantity)
        {
            this.Quantity = quantity;
        }

        public void AddQuantity()
        {
            this.Quantity += 1;
        }
    }
}
