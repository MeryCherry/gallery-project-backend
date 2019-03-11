using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItem = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public int Iduser { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users IduserNavigation { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
