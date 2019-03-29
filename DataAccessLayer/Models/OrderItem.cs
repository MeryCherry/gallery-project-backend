using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class OrderItem : IDataBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int CartItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual CartItem CartItem { get; set; }
        public virtual OrderTb Order { get; set; }
    }
}
