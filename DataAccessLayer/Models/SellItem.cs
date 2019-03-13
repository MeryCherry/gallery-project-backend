using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class SellItem : IDataBaseEntity
    {
        public SellItem()
        {
            CartItem = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int CurrencyCode { get; set; }
        public int Idtype { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }

        public virtual Currency CurrencyCodeNavigation { get; set; }
        public virtual CartItemTypes IdtypeNavigation { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
