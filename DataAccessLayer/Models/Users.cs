using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Users
    {
        public Users()
        {
            DeliveryDetails = new HashSet<DeliveryDetails>();
            OrderTb = new HashSet<OrderTb>();
            ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdRole { get; set; }
        public byte[] Password { get; set; }
        public string ProfilePictName { get; set; }
        public string Email { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<DeliveryDetails> DeliveryDetails { get; set; }
        public virtual ICollection<OrderTb> OrderTb { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
