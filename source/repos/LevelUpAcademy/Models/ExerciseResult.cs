using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpAcademy.Models
{
    public class ExerciseResult
    {
        public int Id { get; set; }

        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public string? GivenAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public int Score { get; set; }
        public DateTime AttemptDate { get; set; }
    }
}
