using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web_Final.Models.Account;
using Web_Final.Models.Process;
using Web_Final.Models.WareHouse;
using Web_Final.Models.Process;
using Web_Final.Models.WareHouse;

namespace Web_Final.Data;

public partial class StockDbContext : DbContext
{
    public StockDbContext()
    {
    }

    public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<T1Account> T1Accounts { get; set; }

    public virtual DbSet<T1CreateLot> T1CreateLots { get; set; }

    public virtual DbSet<T1Department> T1Departments { get; set; }

    public virtual DbSet<T1Equipment> T1Equipments { get; set; }

    public virtual DbSet<T1Factory> T1Factories { get; set; }

    public virtual DbSet<T1InBound> T1InBounds { get; set; }

    public virtual DbSet<T1Item> T1Items { get; set; }

    public virtual DbSet<T1LotHi> T1LotHis { get; set; }

    public virtual DbSet<T1Mprocess> T1Mprocesses { get; set; }

    public virtual DbSet<T1OutBound> T1OutBounds { get; set; }

    public virtual DbSet<T1WareHouse> T1WareHouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1; Database=LTDB; uid=user0706; pwd=1234; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T1Account>(entity =>
        {
            entity.ToTable("T1_Acount");

            entity.HasIndex(e => e.DepartmentId, "IX_T1_Acount_DepartmentId");

            entity.HasIndex(e => e.UserId, "IX_T1_Acount_UserId").IsUnique();

            entity.HasOne(d => d.Department).WithMany(p => p.T1Acounts).HasForeignKey(d => d.DepartmentId);
        });

        modelBuilder.Entity<T1CreateLot>(entity =>
        {
            entity.ToTable("T1_CreateLot");

            entity.HasIndex(e => e.Code, "IX_T1_CreateLot_Code").IsUnique();

            entity.HasIndex(e => e.ItemId, "IX_T1_CreateLot_ItemId");

            entity.HasIndex(e => e.ProcessId, "IX_T1_CreateLot_ProcessId");

            entity.HasOne(d => d.Item).WithMany(p => p.T1CreateLots).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.Process).WithMany(p => p.T1CreateLots).HasForeignKey(d => d.ProcessId);
        });

        modelBuilder.Entity<T1Department>(entity =>
        {
            entity.ToTable("T1_Department");
        });

        modelBuilder.Entity<T1Equipment>(entity =>
        {
            entity.ToTable("T1_Equipment");

            entity.HasIndex(e => e.Code, "IX_T1_Equipment_Code").IsUnique();
        });

        modelBuilder.Entity<T1Factory>(entity =>
        {
            entity.ToTable("T1_Factory");

            entity.HasIndex(e => e.Code, "IX_T1_Factory_Code").IsUnique();
        });

        modelBuilder.Entity<T1InBound>(entity =>
        {
            entity.ToTable("T1_InBound");

            entity.HasIndex(e => e.WareHouseId, "IX_T1_InBound_WareHouseId");

            entity.HasOne(d => d.WareHouse).WithMany(p => p.T1InBounds).HasForeignKey(d => d.WareHouseId);
        });

        modelBuilder.Entity<T1Item>(entity =>
        {
            entity.ToTable("T1_Item");

            entity.HasIndex(e => e.Code, "IX_T1_Item_Code").IsUnique();
        });

        modelBuilder.Entity<T1LotHi>(entity =>
        {
            entity.ToTable("T1_LotHis");

            entity.HasIndex(e => e.CreateLotId, "IX_T1_LotHis_CreateLotId");

            entity.HasOne(d => d.CreateLot).WithMany(p => p.T1LotHis).HasForeignKey(d => d.CreateLotId);
        });

        modelBuilder.Entity<T1Mprocess>(entity =>
        {
            entity.ToTable("T1_MProcess");

            entity.HasIndex(e => e.Code, "IX_T1_MProcess_Code").IsUnique();

            entity.HasIndex(e => e.EquipmentId, "IX_T1_MProcess_EquipmentId");

            entity.HasIndex(e => e.FactoriesId, "IX_T1_MProcess_FactoriesId");

            entity.HasOne(d => d.Equipment).WithMany(p => p.T1Mprocesses).HasForeignKey(d => d.EquipmentId);

            entity.HasOne(d => d.Factories).WithMany(p => p.T1Mprocesses).HasForeignKey(d => d.FactoriesId);
        });

        modelBuilder.Entity<T1OutBound>(entity =>
        {
            entity.ToTable("T1_OutBound");

            entity.HasIndex(e => e.MprocessId, "IX_T1_OutBound_MProcessId");

            entity.HasIndex(e => e.WareHouseId, "IX_T1_OutBound_WareHouseId");

            entity.Property(e => e.MprocessId).HasColumnName("MProcessId");

            entity.HasOne(d => d.Mprocess).WithMany(p => p.T1OutBounds).HasForeignKey(d => d.MprocessId);

            entity.HasOne(d => d.WareHouse).WithMany(p => p.T1OutBounds).HasForeignKey(d => d.WareHouseId);
        });

        modelBuilder.Entity<T1WareHouse>(entity =>
        {
            entity.ToTable("T1_WareHouse");

            entity.HasIndex(e => e.Product, "IX_T1_WareHouse_Product").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
