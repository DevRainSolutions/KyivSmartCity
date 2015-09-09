using System.ComponentModel.DataAnnotations;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Twitter { get; set; }

        [StringLength(200)]
        public string Facebook { get; set; }

        [StringLength(200)]
        public string LinkedIn { get; set; }

        public int Index { get; set; }
    }
}