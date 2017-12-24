using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Register
    {
        public int RegisterId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}