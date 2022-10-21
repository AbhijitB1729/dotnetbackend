using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ApplicantDetail
    {
        [Key]
        public int ApplicantId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int Country { get; set; }

        public int State { get; set; }

        public Boolean IsPhysicallyDisabled { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Phone { get; set; }

        
        public GrantDetail GrantDetail { get; set; }






    }
}
