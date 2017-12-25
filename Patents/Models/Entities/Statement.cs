using Patents.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Patents.Models
{
    public class Statement
    {
        public int StatementId { get; set; }
        public DateTime SubmitDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime ConsidDate { get; set; }
        public string DenialReason { get; set; }
        [Required]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}