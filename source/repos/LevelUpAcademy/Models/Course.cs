using System;
using System.Collections.Generic;

namespace LevelUpAcademy.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? TeacherId { get; set; } // FK verso ApplicationUser
        public DateTime CreatedDate { get; set; }

        // Navigation Properties
        public ApplicationUser? Teacher { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
