using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCare.Models
{
    public class ApplicationUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<Symptom> Symptoms { get; set; }

        
    }
}
