using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.AppEntities
{
    public class ShoppingCartEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Iduser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
