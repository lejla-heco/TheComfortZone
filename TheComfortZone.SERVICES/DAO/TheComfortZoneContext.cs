using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.DAO
{
    public partial class TheComfortZoneContext : DbContext
    {
        public TheComfortZoneContext()
        {
        }

        public TheComfortZoneContext(DbContextOptions<TheComfortZoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<Designer> Designers { get; set; } = null!;
        public virtual DbSet<Favourite> Favourites { get; set; } = null!;
        public virtual DbSet<FurnitureColor> FurnitureColors { get; set; } = null!;
        public virtual DbSet<FurnitureItem> FurnitureItems { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<MetricUnit> MetricUnits { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Space> Spaces { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local)\\mssqlserver_olap;Initial Catalog=TheComfortZone;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");

                entity.Property(e => e.DesignerId).HasColumnName("DesignerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AppointmentType)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppointmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_18");

                entity.HasOne(d => d.Designer)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DesignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_17");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AppointmentEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_REFERENCE_22");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppointmentUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_16");
            });

            modelBuilder.Entity<AppointmentType>(entity =>
            {
                entity.ToTable("AppointmentType");

                entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpaceId).HasColumnName("SpaceID");

                entity.HasOne(d => d.Space)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.SpaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_2");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("Collection");

                entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.DesignerId).HasColumnName("DesignerID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Designer)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.DesignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_3");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("Coupon");

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Coupons)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_15");
            });

            modelBuilder.Entity<Designer>(entity =>
            {
                entity.ToTable("Designer");

                entity.Property(e => e.DesignerId).HasColumnName("DesignerID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.ToTable("Favourite");

                entity.Property(e => e.FavouriteId).HasColumnName("FavouriteID");

                entity.Property(e => e.FurnitureItemId).HasColumnName("FurnitureItemID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FurnitureItem)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.FurnitureItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_13");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_14");
            });

            modelBuilder.Entity<FurnitureColor>(entity =>
            {
                entity.ToTable("FurnitureColor");

                entity.Property(e => e.FurnitureColorId).HasColumnName("FurnitureColorID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.FurnitureItemId).HasColumnName("FurnitureItemID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.FurnitureColors)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_6");

                entity.HasOne(d => d.FurnitureItem)
                    .WithMany(p => p.FurnitureColors)
                    .HasForeignKey(d => d.FurnitureItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_7");
            });

            modelBuilder.Entity<FurnitureItem>(entity =>
            {
                entity.ToTable("FurnitureItem");

                entity.Property(e => e.FurnitureItemId).HasColumnName("FurnitureItemID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.MetricUnitId).HasColumnName("MetricUnitID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Width)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FurnitureItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_1");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.FurnitureItems)
                    .HasForeignKey(d => d.CollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_4");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.FurnitureItems)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_5");

                entity.HasOne(d => d.MetricUnit)
                    .WithMany(p => p.FurnitureItems)
                    .HasForeignKey(d => d.MetricUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_19");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MetricUnit>(entity =>
            {
                entity.ToTable("MetricUnit");

                entity.Property(e => e.MetricUnitId).HasColumnName("MetricUnitID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Noip).HasColumnName("NOIP");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OrderEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_REFERENCE_21");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_10");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FurnitureItemId).HasColumnName("FurnitureItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.FurnitureItem)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.FurnitureItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_11");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_12");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Space>(entity =>
            {
                entity.ToTable("Space");

                entity.Property(e => e.SpaceId).HasColumnName("SpaceID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_20");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
