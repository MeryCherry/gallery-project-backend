using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.AppEntities
{
    public class OrderItemEntity
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
    }
}
