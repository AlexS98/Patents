using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Patent
    {
        public int PatentId { get; set; }
        public decimal Sum { get; set; }
        [Required]
        public int InventorId { get; set; }
        public Inventor Inventor { get; set; }
        [Required]
        public int RegisterId { get; set; }
        public Register Register { get; set; }
        [Required]
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }
        [Required]
        public int StatementId { get; set; }
        public Statement Statement { get; set; }
    }
}