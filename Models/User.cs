using System.ComponentModel.DataAnnotations;

namespace api_both.Models
{
    public class User
    {
        //public User(string fullname, string surname, int age)
        // {

        // }
        //Database colums is Id, fullname, surname, age
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Full Name")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string surname { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int age { get; set; }
    }
}
