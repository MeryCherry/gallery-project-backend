using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderTb = new HashSet<OrderTb>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderTb> OrderTb { get; set; }
    }
}
