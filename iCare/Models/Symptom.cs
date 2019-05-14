using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iCare.Models
{
    public class Symptom
    {
        [Key]
        public int SymptomID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Symptom Description")]
        public string SymptomDescription { get; set; }

        

        
        [StringLength(500)]
        public string Detail { get; set; }

        //[MaxLength(10)]
        //[MinLength(1)]
        public int Severity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        //[Display(Name = "Discuss this Symptom in Upcoming Appointments")]
       // public int?  AppointmentId { get; set; }

        //[Display(Name = "Associated Appointment")]
       // public Appointment appointment { get; set; }



        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public virtual ICollection<AppointmentSymptom> appointmentSymptoms { get; set; }


    }
}

