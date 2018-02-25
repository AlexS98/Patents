using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class Inventor : IPerson
    {
        public int InventorId { get; set; }
        [Required]
        public string FullName { get; set; }
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