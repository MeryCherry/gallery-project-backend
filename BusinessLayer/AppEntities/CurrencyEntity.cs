using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AppEntities
{
    public class CurrencyEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
