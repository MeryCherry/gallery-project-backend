using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public partial class Country: IDataBaseEntity
    {
        public Country()
        {
            DeliveryDetails = new HashSet<DeliveryDetails>();
        }
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<DeliveryDetails> DeliveryDetails { get; set; }
    }
}
