using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataAccess.Models;

public partial class BookingContext : DbContext
{
    public BookingContext()
    {
    }

    public BookingContext(DbContextOptions<BookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MstBookingCode> MstBookingCodes { get; set; }

    public virtual DbSet<MstLocation> MstLocations { get; set; }

    public virtual DbSet<MstMenu> MstMenus { get; set; }

    public virtual DbSet<MstMenuRole> MstMenuRoles { get; set; }

    public virtual DbSet<MstResource> MstResources { get; set; }

    public virtual DbSet<MstResourceCode> MstResourceCodes { get; set; }

    public virtual DbSet<MstRole> MstRoles { get; set; }

    public virtual DbSet<MstRoom> MstRooms { get; set; }

    public virtual DbSet<MstSetupMenu> MstSetupMenus { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    public virtual DbSet<ResourceRoom> ResourceRooms { get; set; }

    public virtual DbSet<TransResourceRoom> TransResourceRooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Booking;Username=postgres;Password=indocyber");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MstBookingCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstBookingCode_pkey");

            entity.ToTable("MstBookingCode");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.BookingCode).HasColumnType("character varying");
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);
        });

        modelBuilder.Entity<MstLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstLocation_pkey");

            entity.ToTable("MstLocation");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);
        });

        modelBuilder.Entity<MstMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstMenu_pkey");

            entity.ToTable("MstMenu");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.Function).HasMaxLength(200);
            entity.Property(e => e.MenuName).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);
        });

        modelBuilder.Entity<MstMenuRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pk_MstMenuRole");

            entity.ToTable("MstMenuRole");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);

            entity.HasOne(d => d.Menu).WithMany(p => p.MstMenuRoles)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("MenuId_Menu");

            entity.HasOne(d => d.Role).WithMany(p => p.MstMenuRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("RoleId_Role");
        });

        modelBuilder.Entity<MstResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstResource_pkey");

            entity.ToTable("MstResource");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.Icon).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);
        });

        modelBuilder.Entity<MstResourceCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ResourceCode_pkey");

            entity.ToTable("MstResourceCode");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.ResourceCode).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);

            entity.HasOne(d => d.Resource).WithMany(p => p.MstResourceCodes)
                .HasForeignKey(d => d.ResourceId)
                .HasConstraintName("ResourceId_Resource");
        });

        modelBuilder.Entity<MstRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("MstRole");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);
        });

        modelBuilder.Entity<MstRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstRoom_pkey");

            entity.ToTable("MstRoom");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);

            entity.HasOne(d => d.Location).WithMany(p => p.MstRooms)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("LocationRoom");
        });

        modelBuilder.Entity<MstSetupMenu>(entity =>
        {
            entity.HasKey(e => e.ParameterCode).HasName("MstSetupMenu_pkey");

            entity.ToTable("MstSetupMenu");

            entity.Property(e => e.ParameterCode).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.ParameterDescription).HasMaxLength(255);
            entity.Property(e => e.ParameterName).HasMaxLength(255);
            entity.Property(e => e.ParameterValue).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);
        });

        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("MstUser");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedDate).HasPrecision(6);
            entity.Property(e => e.DeletedDate).HasPrecision(6);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LoginName).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(8000);
            entity.Property(e => e.UpdatedDate).HasPrecision(6);

            entity.HasOne(d => d.Role).WithMany(p => p.MstUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserRole");
        });

        modelBuilder.Entity<ResourceRoom>(entity =>
        {
            entity.HasKey(e => new { e.RoomId, e.ResourceId }).HasName("ResourceRoom_pkey");

            entity.ToTable("ResourceRoom");

            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceRooms)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ResourceId_Resource");

            entity.HasOne(d => d.Room).WithMany(p => p.ResourceRooms)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoomId_Room");
        });

        modelBuilder.Entity<TransResourceRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pk_TransResourceRoom");

            entity.ToTable("TransResourceRoom");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName(" Id");

            entity.HasOne(d => d.ResourceCode).WithMany(p => p.TransResourceRooms)
                .HasForeignKey(d => d.ResourceCodeId)
                .HasConstraintName("Fk_TransResourceResourceCode");

            entity.HasOne(d => d.Room).WithMany(p => p.TransResourceRooms)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("Fk_TransResourceRoom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
