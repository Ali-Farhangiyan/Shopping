using Domain.Entites.Attributes;
using Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Orders
{
    [AuditTable]
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get;private set; }

        private readonly List<OrderItem> orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems =>
            orderItems.AsReadOnly();

        public PaymentMethode PaymentMethode { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public UserAddress UserAddress { get; private set; }

        public Order()
        {

        }

        public Order(string userId, List<OrderItem> orderItems,
            UserAddress address, PaymentMethode paymentMethode)
        {
            UserId = userId;
            this.orderItems = orderItems;
            UserAddress = address;
            PaymentMethode = paymentMethode;
        }
    }

    [AuditTable]
    public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }
        public OrderItem(int productId, string productName,
            string pictureUri, int unitPrice, int units)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUri = pictureUri;
            UnitPrice = unitPrice;
            Units = units;
        }


        //ef core
        public OrderItem()
        {

        }
    }

    public class UserAddress
    {
        public string State { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }

        public string CompleteAddress { get; set; }
        public UserAddress(string city, string state,
            string postalCode, string completeAddress)
        {
            City = city;
            State = state;
            PostalCode = postalCode;
            CompleteAddress = completeAddress;
        }
    }

    public enum PaymentMethode
    {
        OnlinePayment=0,
        PaymentOnTheSpot = 1
    }

    public enum PaymentStatus
    {
        WaitingForPayment = 0,
        Paid = 1
    }

    public enum OrderStatus
    {
        Processing = 0,
        Delivered = 1,
        Returned = 2,
        Cancelled = 3
    }
}
