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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

           

            // Restrict deletion of related order when OrderProducts entry is removed


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

            modelBuilder.Entity<Appointment>().HasData(
            new Appointment()
            {
                AppointmentID = 1,
                UserId = user.Id,
                DoctorName = "Dr Dodge",
                Address = "123 street Franklin TN",
                Phone= "111-337-222",
                AppointmentDate = DateTime.Parse("2019-09-01"),
                AppointmentReason = "Head Aches",
                DoctorsInstructions = "Take Medicine",
                Visited = false
            });

            modelBuilder.Entity<Symptom>().HasData(
            new Symptom()
            {
                SymptomID = 1,
                UserId = user.Id,
                SymptomDescription = "Feeling Fatique and dizzy",
                Detail = "In the morning when i woke up was feeling very low in energy and had an head ache",
                Severity = 6,
                AppointmentId =1
             });
           

            /*modelBuilder.Entity<Symptom>().HasData(
            new Symptom()
            {
                SymptomID = 1,
                UserId = user.Id,
                SymptomDescription = "Feeling Fatique and dizzy",
                Detail = "In the morning when i woke up was feeling very low in energy and had an head ache",
                Severity = 6,
                AppointmentId = 1
            });

            modelBuilder.Entity<Appointment>().HasData(
           new Appointment()
           {
               AppointmentID = 1,
               UserId = user.Id,
               DoctorName = "Dr Dodge",
               Address = "123 street Franklin TN",
               Phone = "111-337-222",
               AppointmentDate = DateTime.Parse("2019-09-01"),
               AppointmentReason = "Head Aches",
               DoctorsInstructions = "Take Medicine",
               Visited = false
           });*/
        }
    }



}
   

       

        

        
        