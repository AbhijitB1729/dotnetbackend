using System.ComponentModel.DataAnnotations;

namespace RegisterAPI.Models
{
    public class Detail
    {
        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
