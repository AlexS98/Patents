﻿using Patents.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Inventor : Person
    {
        public int InventorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Password { get; set; }

        public int GetPersonId()
        {
            return InventorId;
        }
    }
}