using System.Collections.Generic;

namespace LevelUpAcademy.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public int? XPRequired { get; set; }

        public ICollection<UserBadge>? UserBadges { get; set; } // relazione molti a molti
    }
}
