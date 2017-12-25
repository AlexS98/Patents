using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}