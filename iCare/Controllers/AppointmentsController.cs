using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iCare.Data;
using iCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using iCare.Models.ViewModels;

namespace iCare.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        public AppointmentsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var activeUser = await GetCurrentUserAsync();
            var applicationDbContext = _context.Appointments.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");

            var ViewModel = new AppointmentWithSymptomListViewModel();
            ApplicationDbContext applicationDbContext = _context;

            ViewModel.Symptoms = applicationDbContext.Symptoms.ToList();



            return View(ViewModel);
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentWithSymptomListViewModel AppointmentViewModel)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            ModelState.Remove("Appointment.User");
            ModelState.Remove("Appointment.UserId");


            //ModelState.Remove("AppointmentSymptom.appointment.User");
            //ModelState.Remove("AppointmentSymptom.appointment.UserId");

            //ApplicationUser user = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                AppointmentViewModel.UserId = user.Id;
                AppointmentViewModel.Appointment.UserId = user.Id;

                _context.Add(AppointmentViewModel.Appointment);

                foreach (int symptomId in AppointmentViewModel.SelectedSymptomIds)
                {
                    AppointmentSymptom newAS = new AppointmentSymptom()
                    {
                        AppointmentID = AppointmentViewModel.Appointment.AppointmentID,
                        SymptomID = symptomId,
                        UserId = user.Id
                    };
                    _context.Add(newAS);
                }

                // _context.Add(Appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", AppointmentViewModel.UserId);
            return View(AppointmentViewModel);
        }



        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", appointment.UserId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentID,DoctorName,Address,Phone,AppointmentDate,AppointmentReason,DoctorsInstructions,Visited,UserId")] Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", appointment.UserId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentSymptom = await _context.AppointmentSymptoms
            .Where(AS => AS.AppointmentID == id).ToListAsync();

            foreach ( AppointmentSymptom AS in appointmentSymptom)
            {
                _context.AppointmentSymptoms.Remove(AS);
                 } 
                




                var appointment = await _context.Appointments.FindAsync(id);
           
            _context.Appointments.Remove(appointment);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentID == id);
        }
    }
}
