using System;
using System.Collections.Generic;
using System.Text;
using iCare.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iCare.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<AppointmentSymptom> AppointmentSymptoms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);



            // Restrict deletion of related order when OrderProducts entry is removed

            // Restrict deletion of related order when AppointmentSymptom entry is removed
            modelBuilder.Entity<Appointment>()
                .HasMany(o => o.appointmentSymptoms)
                .WithOne(l => l.appointment)
                .OnDelete(DeleteBehavior.Restrict);



            // Restrict deletion of related product when AppointmentSymptom entry is removed
            modelBuilder.Entity<Symptom>()
                .HasMany(o => o.appointmentSymptoms)
                .WithOne(l => l.symptom)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Symptom>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "2b43d80c-25d9-4820-a424-b53a44531427"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);
////////////////////////////   AppointmentDB ///////////////////////////////////////////////
///
            modelBuilder.Entity<Appointment>().HasData(
            new Appointment()
            {
                AppointmentID = 1,
                UserId = user.Id,
                DoctorName = "Dr Dodge",
                Address = "123 street Franklin TN",
                Phone= "111-337-222",
                AppointmentDate = DateTime.Parse("2019-09-01"),
                DoctorsInstructions = "Take Medicine",
                Visited = false
            },
            new Appointment()
            {
                AppointmentID = 2,
                UserId = user.Id,
                DoctorName = "Dr Felch",
                Address = "abc street Franklin TN",
                Phone = "111-222-222",
                AppointmentDate = DateTime.Parse("2019-05-20"),
                DoctorsInstructions = "Put refresh tears eye drops in every hour",
                Visited = false
            },
            new Appointment()
            {
                AppointmentID = 3,
                UserId = user.Id,
                DoctorName = "Dr Diana",
                Address = "xyz street Nahville TN",
                Phone = "222-337-222",
                AppointmentDate = DateTime.Parse("2019-08-01"),
                DoctorsInstructions = "Advice excersise and walk for 30 min 5 times a week",
                Visited = false
            }
            );
           

            
/////////////////////////////  Symptomdb  ///////////////////////////////////////////


            modelBuilder.Entity<Symptom>().HasData(
            new Symptom()
            {
                SymptomID = 1,
                UserId = user.Id,
                SymptomDescription = "Feeling Fatique and dizzy",
                Detail = "In the morning when i woke up was feeling very low in energy and had an head ache",
                Severity = 6,
                
             },
            new Symptom()
            {
                SymptomID = 2,
                UserId = user.Id,
                SymptomDescription = "Head ache",
                Detail = "Having a head ache which goes mild to medium during day time",
                Severity = 5,

            },
             new Symptom()
             {
                 SymptomID = 3,
                 UserId = user.Id,
                 SymptomDescription = "Black lines infront of eyes",
                 Detail = "having black in lines infront of my vision all day since few months",
                 Severity = 8,

             });

           

            ////////////////////////////////  AppointmentSymptom ////////////////////////////////
            modelBuilder.Entity<AppointmentSymptom>().HasData(
            new AppointmentSymptom()
            {
                AppointmentSymptomID = 1,
                
                SymptomID = 2,
                AppointmentID = 2,
                UserId = user.Id


            },
            new AppointmentSymptom()
            {
                AppointmentSymptomID = 2,
               
                SymptomID = 3,
                AppointmentID = 3,
                UserId = user.Id


            },
            new AppointmentSymptom()
            {
                AppointmentSymptomID = 3,
                
                SymptomID = 1,
                AppointmentID = 1,
                UserId = user.Id

            });




        }
    }



}
   

       

        

        
        