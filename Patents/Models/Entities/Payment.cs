using Patents.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        [Required]
        public int PayerId { get; set; }
        public Inventor Payer { get; set; }
        [Required]
        public int RegistrarId { get; set; }
        public Register Registrar { get; set; }
        [Required]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}