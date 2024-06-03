﻿// <auto-generated />
using System;
using EMS.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMS.DB.Migrations
{
    [DbContext(typeof(EmployeeDBContext))]
    partial class EmployeeDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EMS.DB.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Departme__3214EC07E1001716");

                    b.ToTable("Department", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "UIUX"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PRODUCT ENGINEERING"
                        },
                        new
                        {
                            Id = 3,
                            Name = "QUALITY ANALYST"
                        },
                        new
                        {
                            Id = 4,
                            Name = "IT"
                        });
                });

            modelBuilder.Entity("EMS.DB.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsManager")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("JoiningDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<long?>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("ModeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProfilePic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.HasKey("Id")
                        .HasName("PK__Employee__3214EC07BBAA243F");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ModeId");

                    b.HasIndex("Password")
                        .IsUnique()
                        .HasFilter("[Password] IS NOT NULL");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "MobileNumber" }, "UQ__Employee__250375B14E91F0D3")
                        .IsUnique()
                        .HasFilter("[MobileNumber] IS NOT NULL");

                    b.HasIndex(new[] { "EmailId" }, "UQ__Employee__7ED91ACE0A1D5596")
                        .IsUnique();

                    b.HasIndex(new[] { "Uid" }, "UQ__Employee__C5B69A4B5FD4F6C6")
                        .IsUnique();

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("EMS.DB.Models.EmployeeDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JoiningDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("ModelStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Project")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToView("EmployeeDetails", (string)null);
                });

            modelBuilder.Entity("EMS.DB.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Location__3214EC079248A117");

                    b.ToTable("Location", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hyderabad"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mumbai"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bangalore"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delhi"
                        });
                });

            modelBuilder.Entity("EMS.DB.Models.Mode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id")
                        .HasName("PK__Mode");

                    b.ToTable("Modes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Active"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Do Not Disturb"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sleep"
                        });
                });

            modelBuilder.Entity("EMS.DB.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Project__3214EC07C8DC1C01");

                    b.ToTable("Project", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AMAZON"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MYNTRA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CISCO"
                        });
                });

            modelBuilder.Entity("EMS.DB.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Role__3214EC076D0FF33F");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LocationId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Description = "uiux designer",
                            Name = "UIUX DESIGNER"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            Name = "FULL STACK DEVELOPER"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 4,
                            Description = "backend developer",
                            Name = "BACKEND DEVELOPER"
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 4,
                            Name = "ASSISTANT BACKEND DEVELOPER"
                        },
                        new
                        {
                            Id = 5,
                            DepartmentId = 1,
                            Name = "FRONT END DEVELOPER"
                        },
                        new
                        {
                            Id = 6,
                            DepartmentId = 4,
                            Name = "CUSTOMER SERVICE MANAGER"
                        },
                        new
                        {
                            Id = 7,
                            DepartmentId = 4,
                            Name = "CUSTOMER SUPPORT"
                        },
                        new
                        {
                            Id = 8,
                            DepartmentId = 4,
                            Name = "SOLUTION ARCHITECT"
                        },
                        new
                        {
                            Id = 9,
                            DepartmentId = 4,
                            Name = "DOT NET DEVELOPER"
                        });
                });

            modelBuilder.Entity("EMS.DB.Models.Employee", b =>
                {
                    b.HasOne("EMS.DB.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Employee__Depart__02FC7413");

                    b.HasOne("EMS.DB.Models.Location", "Location")
                        .WithMany("Employees")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK__Employee__Locati__01142BA1");

                    b.HasOne("EMS.DB.Models.Employee", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__Employee__Manage__00200768");

                    b.HasOne("EMS.DB.Models.Mode", "Modes")
                        .WithMany("Employees")
                        .HasForeignKey("ModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Employee__Modes");

                    b.HasOne("EMS.DB.Models.Project", "Project")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK__Employee__Projec__03F0984C");

                    b.HasOne("EMS.DB.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Employee__RoleId__02084FDA");

                    b.Navigation("Department");

                    b.Navigation("Location");

                    b.Navigation("Manager");

                    b.Navigation("Modes");

                    b.Navigation("Project");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EMS.DB.Models.Role", b =>
                {
                    b.HasOne("EMS.DB.Models.Department", "Department")
                        .WithMany("Roles")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Role__Department__403A8C7D");

                    b.HasOne("EMS.DB.Models.Employee", "Employee")
                        .WithMany("Roles")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Role__Employee");

                    b.HasOne("EMS.DB.Models.Location", "Location")
                        .WithMany("Roles")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK__Role__Location");

                    b.Navigation("Department");

                    b.Navigation("Employee");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("EMS.DB.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EMS.DB.Models.Employee", b =>
                {
                    b.Navigation("InverseManager");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EMS.DB.Models.Location", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EMS.DB.Models.Mode", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EMS.DB.Models.Project", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EMS.DB.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
