using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public partial class Users: IDataBaseEntity
    {
        public Users()
        {
            DeliveryDetails = new HashSet<DeliveryDetails>();
            OrderTb = new HashSet<OrderTb>();
            ShoppingCart = new HashSet<ShoppingCart>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int IdRole { get; set; }
        [Required]
        public byte[] Password { get; set; }
        public string ProfilePictName { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<DeliveryDetails> DeliveryDetails { get; set; }
        public virtual ICollection<OrderTb> OrderTb { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
