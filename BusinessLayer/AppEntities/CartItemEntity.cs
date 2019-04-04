using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AppEntities
{
    public class CartItemEntity : IBaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
