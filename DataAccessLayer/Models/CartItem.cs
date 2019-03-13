using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class CartItem : IDataBaseEntity
    {
        public CartItem()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ShoppingCartId { get; set; }

        public virtual SellItem Product { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
