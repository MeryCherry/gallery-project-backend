using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.AppEntities
{
    public class OrderTbEntity : IBaseEntity
    {
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
    }
}
