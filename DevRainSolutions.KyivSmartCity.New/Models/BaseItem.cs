using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class BaseItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [UIHint("HtmlEditor"), AllowHtml]
        [Display(Name = "Опис / контент")]
        public string Description { get; set; }
    }
}