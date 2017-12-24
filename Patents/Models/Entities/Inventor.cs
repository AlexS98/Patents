using Patents.Models.Entities;

namespace Patents.Models
{
    public class Inventor : Person
    {
        public int InventorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }

        public int GetPersonId()
        {
            return InventorId;
        }
    }
}