﻿using iCare.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        
        [StringLength(100)]
        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Doctors Instructions")]
        public string DoctorsInstructions { get; set; }


        [Display(Name = "Visited ?")]
        public Boolean Visited { get; set; }

        [Display(Name = "Associated Appointment")]
        public string DoctorAndAppointmentDate
        {
            get
            {
                return $"{DoctorName} on {AppointmentDate}";
            }
        }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public virtual ICollection<AppointmentSymptom> appointmentSymptoms { get; set; }
    }
}





   