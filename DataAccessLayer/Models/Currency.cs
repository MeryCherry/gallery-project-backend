using DataAccessLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public partial class Currency : IDataBaseEntity
    {
        public Currency()
        {
            SellItem = new HashSet<SellItem>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<SellItem> SellItem { get; set; }
    }
}
