using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class Register : IPerson
    {
        public int RegisterId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
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