using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LevelUpAcademy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Role { get; set; } // Studente, Docente, Admin
        public int? Level { get; set; } = 1;
        public int? XP { get; set; } = 0;
        public DateTime DateRegistered { get; set; }

        // Navigation Properties
        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<ExerciseResult>?  ExerciseResults { get; set; }
        public ICollection<XpHistory>? XpHistory { get; set; }
        public  ICollection<UserBadge>? UserBadges { get; set; } // relazione molti a molti con Badge
        public ICollection<Notification>? Notifications { get; set; }
    }
}
