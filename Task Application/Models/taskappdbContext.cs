using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task_Application.Models
{
    public partial class taskappdbContext : DbContext
    {
        public taskappdbContext()
        {
        }

        public taskappdbContext(DbContextOptions<taskappdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignee> Assignees { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=taskappdb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignee>(entity =>
            {
                entity.ToTable("Assignee");

                entity.Property(e => e.Assignee1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Assignee");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Status1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.AssigneeNoNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.AssigneeNo)
                    .HasConstraintName("FK_Task_Assignee");

                entity.HasOne(d => d.StatusNoNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusNo)
                    .HasConstraintName("FK_Task_Status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
