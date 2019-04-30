using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iCare.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        [StringLength(55)]
        public string DoctorName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(100)]
        public string AppointmentReason { get; set; }

        [Required]
        [StringLength(100)]
        public string DoctorsInstructions { get; set; }

        [Required]
        
        public Boolean Visited { get; set; }



        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

    }
}

