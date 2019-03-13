using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Country: IDataBaseEntity
    {
        public Country()
        {
            DeliveryDetails = new HashSet<DeliveryDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DeliveryDetails> DeliveryDetails { get; set; }
    }
}
