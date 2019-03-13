using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class OrderTb : IDataBaseEntity
    {
        public OrderTb()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int DeliveryOptionId { get; set; }
        public int PaymentOptionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OrderStatus { get; set; }
        public string Error { get; set; }

        public virtual DeliveryOption DeliveryOption { get; set; }
        public virtual OrderStatus OrderStatusNavigation { get; set; }
        public virtual PaymentOption PaymentOption { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
