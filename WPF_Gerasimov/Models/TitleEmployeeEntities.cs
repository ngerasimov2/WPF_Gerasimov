using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPF_Gerasimov.Models;

public partial class TitleEmployeeEntities : DbContext
{
    public TitleEmployeeEntities()
    {
    }

    public TitleEmployeeEntities(DbContextOptions<TitleEmployeeEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=C:\\Users\\Nikita\\Documents\\TitleEmployee.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2775072ECF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Telephone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TitleId).HasColumnName("TitleID");

            entity.HasOne(d => d.Title).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_ToTitle");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Titles__3214EC279EC1763F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title1)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("Title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
