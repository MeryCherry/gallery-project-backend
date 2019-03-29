using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class OrderTb : IDataBaseEntity
    {
        public OrderTb()
        {
            OrderItem = new HashSet<OrderItem>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DeliveryOptionId { get; set; }
        [Required]
        public int PaymentOptionId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int OrderStatus { get; set; }
        public string Error { get; set; }

        public virtual DeliveryOption DeliveryOption { get; set; }
        public virtual OrderStatus OrderStatusNavigation { get; set; }
        public virtual PaymentOption PaymentOption { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
