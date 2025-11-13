using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpAcademy.Models
{
    public class Lesson
    {
        public  int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Order { get; set; }

        // FK verso Course
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        // Collection di esercizi
        public ICollection<Exercise>? Exercises { get; set; }
    }
}
