using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patents.Models
{
    public class Patent
    {
        public int PatentId { get; set; }
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
        public int RequestId { get; set; }
        public Request Request { get; set; }
        [Required]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}