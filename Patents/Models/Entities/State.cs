using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class State
    {
        public int StateId { get; set; }
        [Required]
        public string Info { get; set; }
    }
}