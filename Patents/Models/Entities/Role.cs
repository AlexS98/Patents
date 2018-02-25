using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}