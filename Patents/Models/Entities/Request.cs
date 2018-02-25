using System;
using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
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