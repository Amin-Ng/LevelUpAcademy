using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpAcademy.Models
{
    public class UserBadge
    {
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Badge")]
        public int BadgeId { get; set; }
        public Badge? Badge { get; set; }

        public DateTime DateEarned { get; set; }
        public ICollection<UserBadge>? UserBadges { get; set; } = new List<UserBadge>();

    }
}
