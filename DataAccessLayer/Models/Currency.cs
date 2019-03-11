using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Currency
    {
        public Currency()
        {
            SellItem = new HashSet<SellItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SellItem> SellItem { get; set; }
    }
}
