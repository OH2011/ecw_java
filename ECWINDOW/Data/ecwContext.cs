using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ecw.Models;

namespace ecw.Data
{
    public partial class ecwContext : DbContext
    {
        public ecwContext()
        {
        }

        public ecwContext(DbContextOptions<ecwContext> options)
            : base(options)
        {
        }

        //　データベースのテーブルにあたるDBSetクラス、クラス名は複数形にするのが一般的
        public virtual DbSet<TmBrand> TmBrands { get; set; }
        public virtual DbSet<TmItem> TmItems { get; set; }
        public virtual DbSet<TmItemCategory1> TmItemCategory1s { get; set; }
        public virtual DbSet<TmItemCategory2> TmItemCategory2s { get; set; }
        public virtual DbSet<TmItemPrice> TmItemPrices { get; set; }
        public virtual DbSet<TmItemStatus> TmItemStatuses { get; set; }
        public virtual DbSet<TmItemStock> TmItemStocks { get; set; }
        public virtual DbSet<TmMessage> TmMessages { get; set; }
        public virtual DbSet<TmSystemSetting> TmSystemSettings { get; set; }
        public virtual DbSet<TmTaxDiv> TmTaxDivs { get; set; }
        public virtual DbSet<TtOrderHistory> TtOrderHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ecw;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Japanese_CI_AS");

            modelBuilder.Entity<TmBrand>(entity =>
            {
                entity.HasKey(e => e.BrandCd);

                entity.ToTable("tm_brand");

                entity.Property(e => e.BrandCd)
                    .HasColumnName("brand_cd")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("brand_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BrandNameKana)
                    .HasColumnName("brand_name_kana")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmItem>(entity =>
            {
                entity.HasKey(e => e.ItemCd);

                entity.ToTable("tm_item");

                entity.Property(e => e.ItemCd)
                    .HasColumnName("item_cd")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandCd)
                    .HasColumnName("brand_cd")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DispFlg)
                    .IsRequired()
                    .HasColumnName("disp_flg")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemCategory1Cd)
                    .HasColumnName("item_category1_cd")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCategory2Cd)
                    .HasColumnName("item_category2_cd")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ItemImage1)
                    .HasColumnName("item_image1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemImageRefDiv)
                    .IsRequired()
                    .HasColumnName("item_image_ref_div")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ItemName1)
                    .IsRequired()
                    .HasColumnName("item_name1")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemName2)
                    .HasColumnName("item_name2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JanCd)
                    .HasColumnName("jan_cd")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.ModelNumber)
                    .HasColumnName("model_number")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StatusCd)
                    .IsRequired()
                    .HasColumnName("status_cd")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('00')");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmItemCategory1>(entity =>
            {
                entity.HasKey(e => e.ItemCategory1Cd);

                entity.ToTable("tm_item_category1");

                entity.Property(e => e.ItemCategory1Cd)
                    .HasColumnName("item_category1_cd")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemCategory1Name)
                    .IsRequired()
                    .HasColumnName("item_category1_name")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
   
            modelBuilder.Entity<TmItemCategory2>(entity =>
            {
                entity.HasKey(e => new { e.ItemCategory1Cd, e.ItemCategory2Cd });

                entity.ToTable("tm_item_category2");

                entity.Property(e => e.ItemCategory1Cd)
                    .HasColumnName("item_category1_cd")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCategory2Cd)
                    .HasColumnName("item_category2_cd")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemCategory2Name)
                    .IsRequired()
                    .HasColumnName("item_category2_name")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmItemPrice>(entity =>
            {
                entity.HasKey(e => e.ItemCd);

                entity.ToTable("tm_item_price");

                entity.Property(e => e.ItemCd)
                    .HasColumnName("item_cd")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoTaxRetailPrice)
                    .HasColumnName("no_tax_retail_price")
                    .HasColumnType("numeric(19, 4)")
                    .HasDefaultValue(0);

                entity.Property(e => e.NoTaxWholesalePrice)
                    .HasColumnName("no_tax_wholesale_price")
                    .HasColumnType("numeric(19, 4)")
                    .HasDefaultValue(0);

                entity.Property(e => e.TaxDivCd)
                    .IsRequired()
                    .HasColumnName("tax_div_cd")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('00')");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmItemStatus>(entity =>
            {
                entity.HasKey(e => e.StatusCd);

                entity.ToTable("tm_item_status");

                entity.Property(e => e.StatusCd)
                    .HasColumnName("status_cd")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmItemStock>(entity =>
            {
                entity.HasKey(e => e.ItemCd);

                entity.ToTable("tm_item_stock");

                entity.Property(e => e.ItemCd)
                    .HasColumnName("item_cd")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockNum)
                    .HasColumnName("stock_num")
                    .HasColumnType("numeric(19, 4)");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmMessage>(entity =>
            {
                entity.HasKey(e => e.MsgCd);

                entity.ToTable("tm_message");

                entity.Property(e => e.MsgCd)
                    .HasColumnName("msg_cd")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MsgVal)
                    .IsRequired()
                    .HasColumnName("msg_val")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmSystemSetting>(entity =>
            {
                entity.HasKey(e => e.SsId);

                entity.ToTable("tm_system_setting");

                entity.HasIndex(e => e.SsCd)
                    .HasName("UQ__tm_syste__A44515E4113160AE")
                    .IsUnique();

                entity.Property(e => e.SsId)
                    .HasColumnName("ss_id")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsCd)
                    .IsRequired()
                    .HasColumnName("ss_cd")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SsName)
                    .IsRequired()
                    .HasColumnName("ss_name")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SsVal)
                    .HasColumnName("ss_val")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TmTaxDiv>(entity =>
            {
                entity.HasKey(e => e.TaxDivCd);

                entity.ToTable("tm_tax_div");

                entity.Property(e => e.TaxDivCd)
                    .HasColumnName("tax_div_cd")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TaxName)
                    .IsRequired()
                    .HasColumnName("tax_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasColumnType("numeric(19, 4)");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TtOrderHistory>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.RecordNo });

                entity.ToTable("tt_order_history");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecordNo).HasColumnName("record_no");

                entity.Property(e => e.InsertBy)
                    .HasColumnName("insert_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insert_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemCd)
                    .IsRequired()
                    .HasColumnName("item_cd")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderQuantity)
                    .HasColumnName("order_quantity")
                    .HasColumnType("numeric(19, 4)")
                    .HasDefaultValue(0);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            //modelBuilder.Seed();
        }
    }
}
