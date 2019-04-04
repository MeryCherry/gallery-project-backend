using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AppEntities
{
    public class DeliveryDetailsEntity : IBaseEntity
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountryCode { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string FlatNr { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
