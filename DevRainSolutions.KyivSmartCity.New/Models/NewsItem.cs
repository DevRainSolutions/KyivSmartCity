using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class NewsItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DatePublished { get; set; }

        public bool IsPublished { get; set; }

        [Required]
        [StringLength(300)]
        public string Image { get; set; }

        [UIHint("HtmlEditor"), AllowHtml]
        public string Body { get; set; }
    }
}