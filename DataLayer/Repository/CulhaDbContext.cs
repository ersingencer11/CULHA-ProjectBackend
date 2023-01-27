using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataLayer.Repository.Models;

namespace DataLayer.Repository
{
    public partial class CulhaDbContext : DbContext
    {
        public CulhaDbContext()
        {
        }

        public CulhaDbContext(DbContextOptions<CulhaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Academician> Academicians { get; set; } = null!;
        public virtual DbSet<AcademicianConstraint> AcademicianConstraints { get; set; } = null!;
        public virtual DbSet<Campus> Campuses { get; set; } = null!;
        public virtual DbSet<ClassSchedule> ClassSchedules { get; set; } = null!;
        public virtual DbSet<ClassSchedule2> ClassSchedule2s { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<ClassroomConstraint> ClassroomConstraints { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseConstraint> CourseConstraints { get; set; } = null!;
        public virtual DbSet<CourseOffered> CourseOffereds { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EducationArea> EducationAreas { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamSchedule> ExamSchedules { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<TimeSlot> TimeSlots { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.35.0.104;User ID=imeuser;Password=35imedbtest!*;Database=culha-dev-db;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicianConstraint>(entity =>
            {
                entity.HasOne(d => d.Academician)
                    .WithMany(p => p.AcademicianConstraints)
                    .HasForeignKey(d => d.AcademicianId)
                    .HasConstraintName("FK_5cd4323154e33af3f69969af1d1");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.AcademicianConstraints)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_9a98eb6e1b268ce7ca2d63f10eb");
            });

            modelBuilder.Entity<ClassSchedule>(entity =>
            {
                entity.HasOne(d => d.ClassroomCodeNavigation)
                    .WithMany(p => p.ClassSchedules)
                    .HasForeignKey(d => d.ClassroomCode)
                    .HasConstraintName("FK_de913b1c1f1e6ab8bfaa50fea9c");

                entity.HasOne(d => d.CourseOffered)
                    .WithMany(p => p.ClassSchedules)
                    .HasForeignKey(d => d.CourseOfferedId)
                    .HasConstraintName("FK_baed38ea6efd0288ea32370bb97");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.ClassSchedules)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_c3911409c478702241d403c3a58");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => e.ClassroomCode)
                    .HasName("PK_68820b55e8a9a1a01f8038f7ec2");

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Classrooms)
                    .HasForeignKey(d => d.CampusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_9d732ac01d2457fcae4fa37fbc4");
            });

            modelBuilder.Entity<ClassroomConstraint>(entity =>
            {
                entity.HasOne(d => d.ClassroomCodeNavigation)
                    .WithMany(p => p.ClassroomConstraints)
                    .HasForeignKey(d => d.ClassroomCode)
                    .HasConstraintName("FK_52f9fb53f1664d66ae990841925");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.ClassroomConstraints)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_6bd29c56282f06a7063b0d24082");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseCode)
                    .HasName("PK_36d4d52ade632d96825a976331b");

                entity.Property(e => e.CourseType).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CourseConstraint>(entity =>
            {
                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.CourseConstraints)
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK_f52709f6128abe243ea5aebc97e");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.CourseConstraints)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_0ebf561875b0bee5a2849a654d5");
            });

            modelBuilder.Entity<CourseOffered>(entity =>
            {
                entity.Property(e => e.IsAssigned).HasDefaultValueSql("((1))");

                entity.Property(e => e.Section).IsFixedLength();

                entity.HasOne(d => d.Academician)
                    .WithMany(p => p.CourseOffereds)
                    .HasForeignKey(d => d.AcademicianId)
                    .HasConstraintName("FK_a55fe101defa546ac312c196219");

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.CourseOffereds)
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK_73688d3a4e4219a8fc535a4743b");

                entity.HasOne(d => d.DepartmentCodeNavigation)
                    .WithMany(p => p.CourseOffereds)
                    .HasForeignKey(d => d.DepartmentCode)
                    .HasConstraintName("FK_4c9931b095f223f6385c70530fd");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentCode)
                    .HasName("PK_000b9dffd073202a65a6b79f6ec");

                entity.HasIndex(e => e.DepartmentChair, "REL_7ca6ea9999356bb65820e8ca6b")
                    .IsUnique()
                    .HasFilter("([DepartmentChair] IS NOT NULL)");

                entity.HasOne(d => d.DepartmentChairNavigation)
                    .WithOne(p => p.Department)
                    .HasForeignKey<Department>(d => d.DepartmentChair)
                    .HasConstraintName("FK_7ca6ea9999356bb65820e8ca6bc");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_1fa854e32f77e385cf9571f4f8e");

                entity.HasMany(d => d.CourseCodes)
                    .WithMany(p => p.DepartmentCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepartmentCourse",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("CourseCode").HasConstraintName("FK_141e8cda4be3e4fd0229559893e"),
                        r => r.HasOne<Department>().WithMany().HasForeignKey("DepartmentCode").HasConstraintName("FK_42ec445aa0b5f545328b3aa9ede"),
                        j =>
                        {
                            j.HasKey("DepartmentCode", "CourseCode").HasName("PK_f7fd41e11c877e77d261249bd41");

                            j.ToTable("Department_Courses");

                            j.HasIndex(new[] { "CourseCode" }, "IDX_141e8cda4be3e4fd0229559893");

                            j.HasIndex(new[] { "DepartmentCode" }, "IDX_42ec445aa0b5f545328b3aa9ed");

                            j.IndexerProperty<string>("DepartmentCode").HasMaxLength(8);

                            j.IndexerProperty<string>("CourseCode").HasMaxLength(15);
                        });
            });

            modelBuilder.Entity<EducationArea>(entity =>
            {
                entity.HasOne(d => d.ClassroomCodeNavigation)
                    .WithMany(p => p.EducationAreas)
                    .HasForeignKey(d => d.ClassroomCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationArea_Classroom");

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.EducationAreas)
                    .HasForeignKey(d => d.CourseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationArea_Course");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CourseCode })
                    .HasName("PK_25143dbc0f88937227553fe9c1a");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.CourseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_7282c3a7412364227a8361553f8");
            });

            modelBuilder.Entity<ExamSchedule>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ItemNo })
                    .HasName("PK_dc42d329a1e9ca685c8b8075867");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Section).IsFixedLength();

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.ExamSchedules)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_2e4a20bf15821bcc4be2255430c");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
