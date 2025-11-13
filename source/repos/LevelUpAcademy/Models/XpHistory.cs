using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpAcademy.Models
{
    public class XpHistory
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int? XP_Gained { get; set; }
        public int? Points { get; set; }
        public string? Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
