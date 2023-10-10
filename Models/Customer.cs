using System.ComponentModel.DataAnnotations;

namespace mvcprojectfinal.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public bool Activated { get; set; } = false;
    }
}
