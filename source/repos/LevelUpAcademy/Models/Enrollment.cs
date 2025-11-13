using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpAcademy.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public float Progress { get; set; } // percentuale completamento
    }
}
