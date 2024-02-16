using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;

namespace UserRegistration2.Data;

public partial class UserRegistrationDbContext : DbContext
{
    public UserRegistrationDbContext()
    {
    }

    public UserRegistrationDbContext(DbContextOptions<UserRegistrationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=UserRegistrationDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserRegistration");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RepeatedPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
