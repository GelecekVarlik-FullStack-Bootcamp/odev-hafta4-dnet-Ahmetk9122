using BMS.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Entity.Models
{
    public partial class BMSDatabaseContext : DbContext
    {
        //Yöntem 1
        IConfiguration configuration;
        public BMSDatabaseContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /*
        public BMSDatabaseContext(DbContextOptions<BMSDatabaseContext> options)
            : base(options)
        {
        }
       */

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Yöntem 1 
                //Bu yöntemle app settings deki her şeyi okuyabiliriz.
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));


                // optionsBuilder.UseSqlServer("Server=DESKTOP-BM5NO11;Database=BMSDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeAuth)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeMail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePass)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EmployeePhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSurname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeDepNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeDep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerAuth)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerMail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerPass)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ManagerPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerSurname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ManagerDepNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.ManagerDep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manager_Department");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MessageBody)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MessageTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FromManagerNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.FromManager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Manager");

                entity.HasOne(d => d.ToEmployeeNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ToEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Employee");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("Work");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.Property(e => e.ClosingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Closing date");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RequestBody)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RequestNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Work_Department");

                entity.HasOne(d => d.RequesterNavigation)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.Requester)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Work_Manager");

                entity.HasOne(d => d.WorkOwnerNavigation)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.WorkOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Work_Employee");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
