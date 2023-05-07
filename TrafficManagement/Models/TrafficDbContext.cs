using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrafficManagement.Models;

public partial class TrafficDbContext : DbContext
{
    public TrafficDbContext()
    {
    }

    public TrafficDbContext(DbContextOptions<TrafficDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<General> Generals { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=TrafficDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<General>(entity =>
        {
            entity.ToTable("General");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direction).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
