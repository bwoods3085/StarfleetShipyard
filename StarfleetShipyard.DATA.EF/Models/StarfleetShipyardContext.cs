using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StarfleetShipyard.DATA.EF.Models
{
    public partial class StarfleetShipyardContext : DbContext
    {
        public StarfleetShipyardContext()
        {
        }

        public StarfleetShipyardContext(DbContextOptions<StarfleetShipyardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderShip> OrderShips { get; set; } = null!;
        public virtual DbSet<Ship> Ships { get; set; } = null!;
        public virtual DbSet<ShipClass> ShipClasses { get; set; } = null!;
        public virtual DbSet<ShipStatus> ShipStatuses { get; set; } = null!;
        public virtual DbSet<ShipType> ShipTypes { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress01;Database=StarfleetShipyard;Trusted_Connection = true;MultipleActiveResultSets = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(128)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Planet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quadrant)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shipyard)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(128)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_CustomerDetails");
            });

            modelBuilder.Entity<OrderShip>(entity =>
            {
                entity.HasKey(e => e.OrderShipsId);

                entity.Property(e => e.OrderShipsId).HasColumnName("OrderShipsID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ShipId).HasColumnName("ShipID");

                entity.Property(e => e.ShipPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderShips)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderShips_Orders");

                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.OrderShips)
                    .HasForeignKey(d => d.ShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderShips_Ships");
            });

            modelBuilder.Entity<Ship>(entity =>
            {
                entity.Property(e => e.ShipId).HasColumnName("ShipID");

                entity.Property(e => e.ShipClassesId).HasColumnName("ShipClassesID");

                entity.Property(e => e.ShipDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ShipImage)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.ShipName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ShipPrice).HasColumnType("money");

                entity.Property(e => e.ShipStatusId).HasColumnName("ShipStatusID");

                entity.Property(e => e.ShipTypesId).HasColumnName("ShipTypesID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.ShipClasses)
                    .WithMany(p => p.Ships)
                    .HasForeignKey(d => d.ShipClassesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ships_ShipClasses");

                entity.HasOne(d => d.ShipStatus)
                    .WithMany(p => p.Ships)
                    .HasForeignKey(d => d.ShipStatusId)
                    .HasConstraintName("FK_Ships_ShipStatus");

                entity.HasOne(d => d.ShipTypes)
                    .WithMany(p => p.Ships)
                    .HasForeignKey(d => d.ShipTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ships_ShipTypes");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Ships)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ships_Suppliers");
            });

            modelBuilder.Entity<ShipClass>(entity =>
            {
                entity.HasKey(e => e.ShipClassesId);

                entity.Property(e => e.ShipClassesId).HasColumnName("ShipClassesID");

                entity.Property(e => e.ShipClassesDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ShipClassesName)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShipStatus>(entity =>
            {
                entity.ToTable("ShipStatus");

                entity.Property(e => e.ShipStatusId).HasColumnName("ShipStatusID");

                entity.Property(e => e.ShipStatusName)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShipType>(entity =>
            {
                entity.HasKey(e => e.ShipTypesId);

                entity.Property(e => e.ShipTypesId).HasColumnName("ShipTypesID");

                entity.Property(e => e.ShipTypesDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTypesName)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Planet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quadrant)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierContact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
