using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpAcademy.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
