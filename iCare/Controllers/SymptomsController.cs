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

namespace iCare.Controllers
{
    [Authorize]
    public class SymptomsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        public SymptomsController(ApplicationDbContext context,
             UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Symptoms
        public async Task<IActionResult> Index()
        {
            var activeUser = await GetCurrentUserAsync();
            //var applicationDbContext = _context.Symptoms.Include(s => s.User).Include(s => s.appointment);
            var applicationDbContext = _context.Symptoms.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Symptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptom = await _context.Symptoms
                .Include(s => s.User)
               // .Include(s => s.appointment)
                .FirstOrDefaultAsync(m => m.SymptomID == id);
            if (symptom == null)
            {
                return NotFound();
            }

            return View(symptom);
        }

        // GET: Symptoms/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentID", "DoctorAndAppointmentDate");
            return View();
        }

        // POST: Symptoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SymptomID,SymptomDescription,Detail,Severity,DateCreated,AppointmentId,UserId")] Symptom symptom)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                symptom.UserId = user.Id;
                _context.Add(symptom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", symptom.UserId);
           // ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentID", "DoctorAndAppointmentDate", symptom.AppointmentId);
            return View(symptom);
        }

        // GET: Symptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", symptom.UserId);
            //ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentID", "DoctorAndAppointmentDate", symptom.AppointmentId);
            return View(symptom);
        }

        // POST: Symptoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SymptomID,SymptomDescription,Detail,Severity,DateCreated,AppointmentId,UserId")] Symptom symptom)
        {
            if (id != symptom.SymptomID)
            {
                return NotFound();
            }

        ModelState.Remove("User");
        ModelState.Remove("UserId");

        if (ModelState.IsValid)
            {
                try
                {
                var user = await GetCurrentUserAsync();
                    symptom.UserId = user.Id;
                    _context.Update(symptom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SymptomExists(symptom.SymptomID))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", symptom.UserId);
           // ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentID", "DoctorAndAppointmentDate", symptom.AppointmentId);
            return View(symptom);
        }
        
        
         // GET: Symptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptom = await _context.Symptoms
                .Include(s => s.User)
                //.Include(s => s.appointment)
                .FirstOrDefaultAsync(m => m.SymptomID == id);
            if (symptom == null)
            {
                return NotFound();
            }

            return View(symptom);
        }

      
        // POST: Symptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var appointmentSymptom = await _context.AppointmentSymptoms
            .Where(AS => AS.SymptomID == id).ToListAsync();

            foreach (AppointmentSymptom AS in appointmentSymptom)
            {
                _context.AppointmentSymptoms.Remove(AS);
            }
               var symptom = await _context.Symptoms.FindAsync(id);
               _context.Symptoms.Remove(symptom);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
        }

        private bool SymptomExists(int id)
        {
            return _context.Symptoms.Any(e => e.SymptomID == id);
        }
    }
}
