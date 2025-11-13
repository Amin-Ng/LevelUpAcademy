using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpAcademy.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string?Question { get; set; }
        public string? Title { get; set; }
        public string? Answer { get; set; }
        public int DifficultyLevel { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }

        public ICollection<ExerciseResult>? ExerciseResults { get; set; }
    }
}
