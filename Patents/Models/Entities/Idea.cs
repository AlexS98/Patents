using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Idea
    {
        public int IdeaId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string References { get; set; }
    }
}