using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class ShoppingCart : IDataBaseEntity
    {
        public ShoppingCart()
        {
            CartItem = new HashSet<CartItem>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int Iduser { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users IduserNavigation { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
