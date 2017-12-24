using System.ComponentModel.DataAnnotations;

namespace Patents.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool Manager { get; set; }
    }
}