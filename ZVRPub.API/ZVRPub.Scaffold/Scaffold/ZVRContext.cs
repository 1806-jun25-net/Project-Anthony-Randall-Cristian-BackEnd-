using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZVRPub.Scaffold
{
    public partial class ZVRContext : DbContext
    {
        public ZVRContext()
        {
        }

        public ZVRContext(DbContextOptions<ZVRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryHasLocation> InventoryHasLocation { get; set; }
        public virtual DbSet<LocationOrderProcess> LocationOrderProcess { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MenuCustom> MenuCustom { get; set; }
        public virtual DbSet<MenuCustomHasIventory> MenuCustomHasIventory { get; set; }
        public virtual DbSet<MenuCustomHasOrders> MenuCustomHasOrders { get; set; }
        public virtual DbSet<MenuPreBuilt> MenuPreBuilt { get; set; }
        public virtual DbSet<MenuPreBuiltHasInventory> MenuPreBuiltHasInventory { get; set; }
        public virtual DbSet<MenuPrebuiltHasOrders> MenuPrebuiltHasOrders { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "ZRV_Pub");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IngredientType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<InventoryHasLocation>(entity =>
            {
                entity.ToTable("Inventory_Has_Location", "ZRV_Pub");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryHasLocation)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.InventoryHasLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_ID");
            });

            modelBuilder.Entity<LocationOrderProcess>(entity =>
            {
                entity.ToTable("Location_Order_Process", "ZRV_Pub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocationId).HasColumnName("locationId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationOrderProcess)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Order");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LocationOrderProcess)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Location");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("Locations", "ZRV_Pub");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("Postal_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.States)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasColumnName("Street_Address")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MenuCustom>(entity =>
            {
                entity.ToTable("MenuCustom", "ZRV_Pub");

                entity.Property(e => e.NameOfCustomMenu)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdOrdersNavigation)
                    .WithMany(p => p.MenuCustom)
                    .HasForeignKey(d => d.IdOrders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_ID");
            });

            modelBuilder.Entity<MenuCustomHasIventory>(entity =>
            {
                entity.ToTable("MenuCustom_Has_Iventory_", "ZRV_Pub");

                entity.HasOne(d => d.IdInventoryNavigation)
                    .WithMany(p => p.MenuCustomHasIventory)
                    .HasForeignKey(d => d.IdInventory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_ID_MenuCustom");

                entity.HasOne(d => d.IdMenuCustomNavigation)
                    .WithMany(p => p.MenuCustomHasIventory)
                    .HasForeignKey(d => d.IdMenuCustom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuCustom_ID");
            });

            modelBuilder.Entity<MenuCustomHasOrders>(entity =>
            {
                entity.ToTable("MenuCustom_Has_Orders", "ZRV_Pub");

                entity.Property(e => e.CustomPreBuildId).HasColumnName("CustomPreBuildID");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.MenuCustomHasOrders)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders2_ID");
            });

            modelBuilder.Entity<MenuPreBuilt>(entity =>
            {
                entity.Property(e => e.NameOfMenu)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<MenuPreBuiltHasInventory>(entity =>
            {
                entity.ToTable("MenuPreBuilt_Has_Inventory");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.MenuPreBuiltHasInventory)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_ID");

                entity.HasOne(d => d.MenuPreBuild)
                    .WithMany(p => p.MenuPreBuiltHasInventory)
                    .HasForeignKey(d => d.MenuPreBuildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuPreBuild_ID");
            });

            modelBuilder.Entity<MenuPrebuiltHasOrders>(entity =>
            {
                entity.ToTable("MenuPrebuilt_Has_Orders");

                entity.Property(e => e.MenuPreBuildId).HasColumnName("MenuPreBuildID");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.MenuPrebuiltHasOrders)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_ID");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Orders", "ZRV_Pub");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderTime).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Users", "ZRV_Pub");

                entity.HasIndex(e => e.Username)
                    .HasName("UC_username_unique")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserPic).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
