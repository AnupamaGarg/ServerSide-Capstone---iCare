using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iCare.Models.ViewModels
{
    public class AppointmentWithSymptomListViewModel
    {
        public int Id { get; set; }
        public int AppointmentID { get; set; }
        public Appointment Appointment { get; set; }


        public List<int> SelectedSymptomIds { get; set; } = new List<int>();
        public List<Symptom> Symptoms { get; set; }



        public List<SelectListItem> SymptomOptions
        {
            get
            {
                if (Symptoms == null)
                {
                    return null;
                }
                return Symptoms.Select(s => new SelectListItem
                {
                    Value = s.SymptomID.ToString(),
                    Text = s.SymptomDescription
                }).ToList();
            }
        }
        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}


        