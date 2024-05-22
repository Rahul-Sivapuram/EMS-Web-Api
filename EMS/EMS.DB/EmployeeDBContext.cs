using System;
using System.Collections.Generic;
using System.Linq;
using EMS.DB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace EMS.DB
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Mode> Modes { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     var config=new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //     var configsection = config.GetSection("ConnectionStrings");

        //     optionsBuilder.UseSqlServer(configsection["DefaultConnection"] ?? null);
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07E1001716");

                entity.ToTable("Department");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "UIUX" },
                new Department { Id = 2, Name = "PRODUCT ENGINEERING" },
                new Department { Id = 3, Name = "QUALITY ANALYST" },
                new Department { Id = 4, Name = "IT" }
            );


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07BBAA243F");

                entity.ToTable("Employee");

                entity.HasIndex(e => e.MobileNumber, "UQ__Employee__250375B14E91F0D3").IsUnique();

                entity.HasIndex(e => e.EmailId, "UQ__Employee__7ED91ACE0A1D5596").IsUnique();

                entity.HasIndex(e => e.Uid, "UQ__Employee__C5B69A4B5FD4F6C6").IsUnique();

                entity.Property(e => e.Dob).HasColumnName("DOB");
                entity.Property(e => e.EmailId)
                    .HasMaxLength(256)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName).IsUnicode(false);
                entity.Property(e => e.LastName).IsUnicode(false);
                entity.Property(e => e.Uid)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__02FC7413");

                entity.HasOne(d => d.Location).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Employee__Locati__01142BA1");

                entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Employee__Manage__00200768");

                entity.HasOne(d => d.Project).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Employee__Projec__03F0984C");

                entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employee__RoleId__02084FDA");

                entity.HasIndex(e => e.Password).IsUnique();
               entity.Property(e => e.IsActive).HasDefaultValue(false);

                entity.HasOne(d => d.Modes).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ModeId)
                .HasConstraintName("FK__Employee__Modes");
            });

            modelBuilder.Entity<Mode>(entity =>
           {
               entity.HasKey(e => e.Id).HasName("PK__Mode");

               entity.ToTable("Modes");

               entity.Property(e => e.Name)
                   .HasMaxLength(70)
                   .IsUnicode(false);
           });
            modelBuilder.Entity<Mode>().HasData(
                new Mode { Id = 1, Name = "Active" },
                new Mode { Id = 2, Name = "Do Not Disturb" },
                new Mode { Id = 3, Name = "Sleep" }
            );

            modelBuilder.Entity<EmployeeDetail>().ToView(nameof(EmployeeDetails));

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Location__3214EC079248A117");

                entity.ToTable("Location");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Hyderabad" },
                new Location { Id = 2, Name = "Mumbai" },
                new Location { Id = 3, Name = "Bangalore" },
                new Location { Id = 4, Name = "Delhi" }
            );

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07C8DC1C01");

                entity.ToTable("Project");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Project>().HasData(
               new Project { Id = 1, Name = "AMAZON" },
               new Project { Id = 2, Name = "MYNTRA" },
               new Project { Id = 3, Name = "CISCO" }
           );


            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Role__3214EC076D0FF33F");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department).WithMany(p => p.Roles)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Role__Department__403A8C7D");

                entity.HasOne(d => d.Location).WithMany(p => p.Roles)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Role__Location");

                entity.Property(e => e.Description)
                   .HasMaxLength(1000);

                entity.HasOne(d => d.Employee).WithMany(p => p.Roles)
                   .HasForeignKey(d => d.EmployeeId)
                   .HasConstraintName("FK__Role__Employee");
            });
            modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "UIUX DESIGNER", DepartmentId = 1, Description = "uiux designer", EmployeeId = null, LocationId = null },
            new Role { Id = 2, Name = "FULL STACK DEVELOPER", DepartmentId = 2, Description = null, EmployeeId = null, LocationId = null },
            new Role { Id = 3, Name = "BACKEND DEVELOPER", DepartmentId = 4, Description = "backend developer", EmployeeId = null, LocationId = null },
            new Role { Id = 4, Name = "ASSISTANT BACKEND DEVELOPER", DepartmentId = 4, Description = null, EmployeeId = null, LocationId = null },
            new Role { Id = 5, Name = "FRONT END DEVELOPER", DepartmentId = 1, Description = null, EmployeeId = null, LocationId = null },
            new Role { Id = 6, Name = "CUSTOMER SERVICE MANAGER", DepartmentId = 4, Description = null, EmployeeId = null, LocationId = null },
            new Role { Id = 7, Name = "CUSTOMER SUPPORT", DepartmentId = 4, Description = null, EmployeeId = null, LocationId = null },
            new Role { Id = 8, Name = "SOLUTION ARCHITECT", DepartmentId = 4, Description = null, EmployeeId = null, LocationId = null },
            new Role { Id = 9, Name = "DOT NET DEVELOPER", DepartmentId = 4, Description = null, EmployeeId = null, LocationId = null }
        );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}