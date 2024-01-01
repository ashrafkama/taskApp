using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Task_Application.Models;

namespace Task_Application.Data
{
    public partial class taskappdbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public taskappdbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public virtual DbSet<Assignee> Assignees { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Models.Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
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

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Models.Task>(entity =>
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
