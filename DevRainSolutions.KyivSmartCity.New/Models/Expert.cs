using System.ComponentModel.DataAnnotations;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class Expert
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Required]
        [StringLength(600)]
        public string Description { get; set; }

    }
}