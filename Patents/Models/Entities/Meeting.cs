using System;
using System.ComponentModel.DataAnnotations;

namespace Patents.Models.Entities
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string Additions { get; set; }
        [Required]
        public int InventorId { get; set; }
        public Inventor Inventor { get; set; }
        [Required]
        public int RegisterId { get; set; }
        public Register Register { get; set; }
        [Required]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}