using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class Idea
    {
        public int IdeaId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string References { get; set; }
    }
}