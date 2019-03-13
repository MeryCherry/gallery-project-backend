using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class OrderItem : IDataBaseEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual CartItem CartItem { get; set; }
        public virtual OrderTb Order { get; set; }
    }
}
