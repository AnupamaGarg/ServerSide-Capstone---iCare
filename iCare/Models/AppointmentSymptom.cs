using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iCare.Models
{
    public class AppointmentSymptom
    {
        public int AppointmentSymptomID { get; set; }

        [ForeignKey("AppointmentFK")]
        public int AppointmentID { get; set; }

        [ForeignKey("SymptomFK")]
        public int SymptomID { get; set; }

        public Appointment appointment { get; set; }
        public Symptom symptom { get; set; }
        

    }
}
