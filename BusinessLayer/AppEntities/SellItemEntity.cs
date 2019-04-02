using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.AppEntities
{
    public class SellItemEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int CurrencyCode { get; set; }
        [Required]
        public int Idtype { get; set; }
        [Required]
        public decimal Length { get; set; }
        [Required]
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
    }
}
