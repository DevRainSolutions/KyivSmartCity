using System;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using DevRainSolutions.KyivSmartCity.New.App_GlobalResources;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Електронна адреса")]
        [Required(ErrorMessageResourceName = "PropertyValueRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [EmailAddress(ErrorMessage = "Введіть коректну електронну адресу.")]
        [Email(ErrorMessage = "Введіть коректну електронну адресу.")]
        //[Remote("IsVolunteerEmailAllowed", "Home", ErrorMessage = "Волонтер з такою адресою вже існує")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PropertyValueRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "Прізвище")]
        [Required(ErrorMessageResourceName = "PropertyValueRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string LastName { get; set; }

        [Display(Name = "По батькові")]
        [StringLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string MiddleName { get; set; }

        //public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Місто")]
        [Required(ErrorMessageResourceName = "PropertyValueRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string City { get; set; }


        [Display(Name = "Телефон")]
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Required(ErrorMessageResourceName = "PropertyValueRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Phone { get; set; }


        [StringLength(4000, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = "Коментарі")]
        public string Notes { get; set; }

        [Display(Name = "Робоча група")]
        [Required(ErrorMessageResourceName = "PropertyValueRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

    }
}