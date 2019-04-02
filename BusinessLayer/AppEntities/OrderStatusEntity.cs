﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.AppEntities
{
    public class OrderStatusEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
