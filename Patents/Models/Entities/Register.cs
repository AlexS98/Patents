﻿using Patents.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Register : Person
    {
        public int RegisterId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int GetPersonId()
        {
            return RegisterId;
        }
    }
}