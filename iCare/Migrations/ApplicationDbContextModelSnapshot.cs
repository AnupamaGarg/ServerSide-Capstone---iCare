﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iCare.Data;

namespace iCare.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("iCare.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "e58fdf97-1576-4228-b621-67a023036252",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5c6c429c-a0d5-4072-b966-696d8bc04574",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGpMEEWaYWQeuuiTvrPw9vQunPlPIUTXfeSGDgV1bGCIt7uMpqWwgvSR0qz70iswyQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2b43d80c-25d9-4820-a424-b53a44531427",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("iCare.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<DateTime>("AppointmentDate");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("DoctorsInstructions")
                        .HasMaxLength(100);

                    b.Property<string>("Phone");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<bool>("Visited");

                    b.HasKey("AppointmentID");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentID = 1,
                            Address = "123 street Franklin TN",
                            AppointmentDate = new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Dr Dodge",
                            DoctorsInstructions = "Take Medicine",
                            Phone = "111-337-222",
                            UserId = "e58fdf97-1576-4228-b621-67a023036252",
                            Visited = false
                        },
                        new
                        {
                            AppointmentID = 2,
                            Address = "abc street Franklin TN",
                            AppointmentDate = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Dr Felch",
                            DoctorsInstructions = "Put refresh tears eye drops in every hour",
                            Phone = "111-222-222",
                            UserId = "e58fdf97-1576-4228-b621-67a023036252",
                            Visited = false
                        },
                        new
                        {
                            AppointmentID = 3,
                            Address = "xyz street Nahville TN",
                            AppointmentDate = new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Dr Diana",
                            DoctorsInstructions = "Advice excersise and walk for 30 min 5 times a week",
                            Phone = "222-337-222",
                            UserId = "e58fdf97-1576-4228-b621-67a023036252",
                            Visited = false
                        });
                });

            modelBuilder.Entity("iCare.Models.AppointmentSymptom", b =>
                {
                    b.Property<int>("AppointmentSymptomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentID");

                    b.Property<int>("SymptomID");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("AppointmentSymptomID");

                    b.HasIndex("AppointmentID");

                    b.HasIndex("SymptomID");

                    b.HasIndex("UserId");

                    b.ToTable("AppointmentSymptoms");

                    b.HasData(
                        new
                        {
                            AppointmentSymptomID = 1,
                            AppointmentID = 2,
                            SymptomID = 2,
                            UserId = "e58fdf97-1576-4228-b621-67a023036252"
                        },
                        new
                        {
                            AppointmentSymptomID = 2,
                            AppointmentID = 3,
                            SymptomID = 3,
                            UserId = "e58fdf97-1576-4228-b621-67a023036252"
                        },
                        new
                        {
                            AppointmentSymptomID = 3,
                            AppointmentID = 1,
                            SymptomID = 1,
                            UserId = "e58fdf97-1576-4228-b621-67a023036252"
                        });
                });

            modelBuilder.Entity("iCare.Models.Symptom", b =>
                {
                    b.Property<int>("SymptomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Detail")
                        .HasMaxLength(500);

                    b.Property<int>("Severity");

                    b.Property<string>("SymptomDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("SymptomID");

                    b.HasIndex("UserId");

                    b.ToTable("Symptoms");

                    b.HasData(
                        new
                        {
                            SymptomID = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "In the morning when i woke up was feeling very low in energy and had an head ache",
                            Severity = 6,
                            SymptomDescription = "Feeling Fatique and dizzy",
                            UserId = "e58fdf97-1576-4228-b621-67a023036252"
                        },
                        new
                        {
                            SymptomID = 2,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Having a head ache which goes mild to medium during day time",
                            Severity = 5,
                            SymptomDescription = "Head ache",
                            UserId = "e58fdf97-1576-4228-b621-67a023036252"
                        },
                        new
                        {
                            SymptomID = 3,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "having black in lines infront of my vision all day since few months",
                            Severity = 8,
                            SymptomDescription = "Black lines infront of eyes",
                            UserId = "e58fdf97-1576-4228-b621-67a023036252"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("iCare.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("iCare.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iCare.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("iCare.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iCare.Models.Appointment", b =>
                {
                    b.HasOne("iCare.Models.ApplicationUser", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iCare.Models.AppointmentSymptom", b =>
                {
                    b.HasOne("iCare.Models.Appointment", "appointment")
                        .WithMany("appointmentSymptoms")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iCare.Models.Symptom", "symptom")
                        .WithMany("appointmentSymptoms")
                        .HasForeignKey("SymptomID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iCare.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iCare.Models.Symptom", b =>
                {
                    b.HasOne("iCare.Models.ApplicationUser", "User")
                        .WithMany("Symptoms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
