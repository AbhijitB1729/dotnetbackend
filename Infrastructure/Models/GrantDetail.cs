using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class GrantDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string GrantName { get; set; }

        [Required]
        public string ProgramCode { get; set; }

        public DateTime StartDate { get; set; } 

        public DateTime EndDate { get; set; }   
    }

}
