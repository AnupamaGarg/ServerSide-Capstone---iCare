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
        [StringLength(55)]
        public string SymptomDescription { get; set; }

        [Required]
        [StringLength(100)]
        public string Detail { get; set; }

        public int Severity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public int?  AppointmentId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }


    }
}

