using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using lianshenginc_api.Models;

namespace lianshenginc_api.Data;

public partial class EfCoreContext : DbContext
{
    public EfCoreContext()
    {
    }

    public EfCoreContext(DbContextOptions<EfCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FactoryUser> FactoryUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-ORSLCSS\\SQLEXPRESS;database=lianshengfactory;uid=test;pwd=DcsRelease1!;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FactoryUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__FactoryU__1788CC4C23A63FBA");

            entity.ToTable("FactoryUser");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
