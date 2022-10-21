using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class EducationalDetail
    {
        [Key]
      public int EducationalDetailId {get; set;}

        [Required]
        public string CourseName {get; set;}

        [Required]
        [StringLength(30)]
        public string Country {get; set;}

        [Required]
        public string InstitutionName {get; set;}

        public int YearOfCompletion { get; set;}

        public ApplicantDetail ApplicantDetail { get; set;}

    }

}
