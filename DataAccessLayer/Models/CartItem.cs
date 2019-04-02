using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public partial class CartItem : IDataBaseEntity
    {
        public CartItem()
        {
            OrderItem = new HashSet<OrderItem>();
        }
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }

        public virtual SellItem Product { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
