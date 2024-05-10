using System;
using System.Collections.Generic;
using ITMS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ITMS.Persistence.DBaseContext
{
    public partial class ItmsDbContext : DbContext
    {
        public ItmsDbContext()
        {
        }

        public ItmsDbContext(DbContextOptions<ItmsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BloodGroup> BloodGroups { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Designation> Designations { get; set; }

        public virtual DbSet<District> Districts { get; set; }

        public virtual DbSet<Division> Divisions { get; set; }

        public virtual DbSet<OrgDivision> OrgDivisions { get; set; }

        public virtual DbSet<Thana> Thanas { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserGroup> UserGroups { get; set; }

        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=.;Database=ITMSDB;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__BloodGro__3214EC0777EAB69B");

                entity.ToTable("BloodGroup");

                entity.Property(e => e.BloodGroupName).HasMaxLength(75);
                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC075F3CDEC5");

                entity.ToTable("Department");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DepartmentCode).HasMaxLength(20);
                entity.Property(e => e.DepartmentName).HasMaxLength(75);
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.OrgDivision).WithMany(p => p.Departments)
                    .HasForeignKey(d => d.OrgDivisionId)
                    .HasConstraintName("FK__Departmen__OrgDi__3C69FB99");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Designat__3214EC075F885B59");

                entity.ToTable("Designation");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DesignationCode).HasMaxLength(20);
                entity.Property(e => e.DesignationName).HasMaxLength(75);
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Department).WithMany(p => p.Designations)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Designati__Depar__4222D4EF");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__District__3214EC07636A12B2");

                entity.ToTable("District");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DistrictName).HasMaxLength(75);
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Division).WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__District__Divisi__5165187F");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Division__3214EC07FB4336A6");

                entity.ToTable("Division");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DivisionName).HasMaxLength(75);
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrgDivision>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrgDivis__3214EC07F004D0AA");

                entity.ToTable("OrgDivision");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(75);
            });

            modelBuilder.Entity<Thana>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Thana__3214EC07381BB79F");

                entity.ToTable("Thana");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
                entity.Property(e => e.ThanaName).HasMaxLength(75);

                entity.HasOne(d => d.District).WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__Thana__DistrictI__5812160E");

                entity.HasOne(d => d.Division).WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__Thana__DivisionI__571DF1D5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__User__3214EC076E9356B8");

                entity.ToTable("User");

                entity.HasIndex(e => e.UserEmail, "UQ__User__08638DF8BCEA897E").IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__User__C9F28456D7C25B24").IsUnique();

                entity.HasIndex(e => e.PhoneNo, "UQ__User__F3EE33E26BEEB7EE").IsUnique();

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.FirstName).HasMaxLength(75);
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
                entity.Property(e => e.LastName).HasMaxLength(75);
                entity.Property(e => e.Password).HasMaxLength(15);
                entity.Property(e => e.PhoneNo).HasMaxLength(15);
                entity.Property(e => e.UserEmail).HasMaxLength(50);
                entity.Property(e => e.UserName).HasMaxLength(75);

                entity.HasOne(d => d.Department).WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__User__Department__6D0D32F4");

                entity.HasOne(d => d.Designation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__User__Designatio__6E01572D");

                entity.HasOne(d => d.OrgDivision).WithMany(p => p.Users)
                    .HasForeignKey(d => d.OrgDivisionId)
                    .HasConstraintName("FK__User__OrgDivisio__6C190EBB");

                entity.HasOne(d => d.UserGroup).WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK__User__UserGroupI__6B24EA82");

                entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__User__UserTypeId__6A30C649");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__UserGrou__3214EC075FCF1B1A");

                entity.ToTable("UserGroup");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.GroupName).HasMaxLength(75);
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__UserType__3214EC078E75CE21");

                entity.ToTable("UserType");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.CreateDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");
                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
                entity.Property(e => e.TypeName).HasMaxLength(75);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}