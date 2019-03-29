using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class DeliveryDetails : IDataBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Iduser { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int CountryCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNr { get; set; }
        [Required]
        public string FlatNr { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Users IduserNavigation { get; set; }
    }
}
