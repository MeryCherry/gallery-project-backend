using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.AppEntities
{
    public class PaymentOptionEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
