using System;
using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        [Required]
        public string PaymentDetails { get; set; }
        [Required]
        public int InventorId { get; set; }
        public Inventor Inventor { get; set; }
        [Required]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}