using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Required]
        [UIHint("HtmlEditor"), AllowHtml]
        public string Description { get; set; }

        [StringLength(300)]
        public string CurrentState { get; set; }

        [StringLength(300)]
        public string Topic { get; set; }


        [StringLength(300)]
        public string Head { get; set; }

        [StringLength(500)]
        [Url]
        public string PresentationUrl { get; set; }

        [StringLength(500)]
        [Url]
        public string ImageUrl { get; set; }
    }
}