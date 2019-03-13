using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class DeliveryDetails : IDataBaseEntity
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

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Users IduserNavigation { get; set; }
    }
}
