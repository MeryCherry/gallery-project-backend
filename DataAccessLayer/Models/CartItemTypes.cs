using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class CartItemTypes : IDataBaseEntity
    {
        public CartItemTypes()
        {
            SellItem = new HashSet<SellItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SellItem> SellItem { get; set; }
    }
}
