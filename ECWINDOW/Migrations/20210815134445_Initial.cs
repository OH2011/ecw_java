using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECWINDOW.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tm_brand",
                columns: table => new
                {
                    brand_cd = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    brand_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValueSql: "('')"),
                    brand_name_kana = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_brand", x => x.brand_cd);
                });

            migrationBuilder.CreateTable(
                name: "tm_item",
                columns: table => new
                {
                    item_cd = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    item_name1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, defaultValueSql: "('')"),
                    item_name2 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    item_category1_cd = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    item_category2_cd = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    brand_cd = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    model_number = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    jan_cd = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    item_image_ref_div = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('1')"),
                    item_image1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    disp_flg = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('1')"),
                    status_cd = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false, defaultValueSql: "('00')"),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_item", x => x.item_cd);
                });

            migrationBuilder.CreateTable(
                name: "tm_item_category1",
                columns: table => new
                {
                    item_category1_cd = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    item_category1_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, defaultValueSql: "('')"),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_item_category1", x => x.item_category1_cd);
                });

            migrationBuilder.CreateTable(
                name: "tm_item_category2",
                columns: table => new
                {
                    item_category1_cd = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    item_category2_cd = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    item_category2_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, defaultValueSql: "('')"),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_item_category2", x => new { x.item_category1_cd, x.item_category2_cd });
                });

            migrationBuilder.CreateTable(
                name: "tm_item_price",
                columns: table => new
                {
                    item_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    no_tax_retail_price = table.Column<decimal>(type: "numeric(19,4)", nullable: false, defaultValue: 0m),
                    no_tax_wholesale_price = table.Column<decimal>(type: "numeric(19,4)", nullable: false, defaultValue: 0m),
                    tax_div_cd = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false, defaultValueSql: "('00')"),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_item_price", x => x.item_cd);
                });

            migrationBuilder.CreateTable(
                name: "tm_item_status",
                columns: table => new
                {
                    status_cd = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    status_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, defaultValueSql: "('')"),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_item_status", x => x.status_cd);
                });

            migrationBuilder.CreateTable(
                name: "tm_item_stock",
                columns: table => new
                {
                    item_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    stock_num = table.Column<decimal>(type: "numeric(19,4)", nullable: false),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_item_stock", x => x.item_cd);
                });

            migrationBuilder.CreateTable(
                name: "tm_message",
                columns: table => new
                {
                    msg_cd = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    msg_val = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValueSql: "('')"),
                    description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_message", x => x.msg_cd);
                });

            migrationBuilder.CreateTable(
                name: "tm_system_setting",
                columns: table => new
                {
                    ss_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    ss_cd = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    ss_name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    ss_val = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true),
                    description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_system_setting", x => x.ss_id);
                });

            migrationBuilder.CreateTable(
                name: "tm_tax_div",
                columns: table => new
                {
                    tax_div_cd = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    tax_rate = table.Column<decimal>(type: "numeric(19,4)", nullable: false),
                    tax_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValueSql: "('')"),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tm_tax_div", x => x.tax_div_cd);
                });

            migrationBuilder.CreateTable(
                name: "tt_order_history",
                columns: table => new
                {
                    order_no = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    record_no = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    item_cd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValueSql: "('')"),
                    order_quantity = table.Column<decimal>(type: "numeric(19,4)", nullable: false, defaultValue: 0m),
                    update_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    insert_by = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    insert_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tt_order_history", x => new { x.order_no, x.record_no });
                });

            migrationBuilder.CreateIndex(
                name: "UQ__tm_syste__A44515E4113160AE",
                table: "tm_system_setting",
                column: "ss_cd",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tm_brand");

            migrationBuilder.DropTable(
                name: "tm_item");

            migrationBuilder.DropTable(
                name: "tm_item_category1");

            migrationBuilder.DropTable(
                name: "tm_item_category2");

            migrationBuilder.DropTable(
                name: "tm_item_price");

            migrationBuilder.DropTable(
                name: "tm_item_status");

            migrationBuilder.DropTable(
                name: "tm_item_stock");

            migrationBuilder.DropTable(
                name: "tm_message");

            migrationBuilder.DropTable(
                name: "tm_system_setting");

            migrationBuilder.DropTable(
                name: "tm_tax_div");

            migrationBuilder.DropTable(
                name: "tt_order_history");
        }
    }
}
