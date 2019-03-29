using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class Role : IDataBaseEntity
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool CanRegister { get; set; }
        [Required]
        public bool CanResetPass { get; set; }
        [Required]
        public bool CanEditProfile { get; set; }
        [Required]
        public bool HasCart { get; set; }
        [Required]
        public bool CanDisplayList { get; set; }
        [Required]
        public bool CanManageItems { get; set; }
        [Required]
        public bool CanSetPromotion { get; set; }
        [Required]
        public bool CanManageOrder { get; set; }
        [Required]
        public bool CanManageUsers { get; set; }
        [Required]
        public bool CanManageUserRole { get; set; }
        [Required]
        public bool CanManageDeliveryOption { get; set; }
        [Required]
        public bool CanManagePaymentOption { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
