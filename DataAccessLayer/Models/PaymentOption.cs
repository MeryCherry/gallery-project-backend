using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class PaymentOption : IDataBaseEntity
    {
        public PaymentOption()
        {
            OrderTb = new HashSet<OrderTb>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderTb> OrderTb { get; set; }
    }
}
