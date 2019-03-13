using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class DeliveryOption : IDataBaseEntity
    {
        public DeliveryOption()
        {
            OrderTb = new HashSet<OrderTb>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderTb> OrderTb { get; set; }
    }
}
