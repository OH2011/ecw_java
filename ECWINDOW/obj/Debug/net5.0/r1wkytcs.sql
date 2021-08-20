IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [tm_brand] (
    [brand_cd] varchar(4) NOT NULL,
    [brand_name] varchar(20) NOT NULL DEFAULT (('')),
    [brand_name_kana] varchar(30) NULL,
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_brand] PRIMARY KEY ([brand_cd])
);
GO

CREATE TABLE [tm_item] (
    [item_cd] varchar(10) NOT NULL,
    [item_name1] varchar(30) NOT NULL DEFAULT (('')),
    [item_name2] varchar(30) NULL,
    [item_category1_cd] varchar(4) NULL,
    [item_category2_cd] varchar(4) NULL,
    [brand_cd] varchar(4) NULL,
    [model_number] varchar(40) NULL,
    [jan_cd] varchar(13) NULL,
    [item_image_ref_div] varchar(1) NOT NULL DEFAULT (('1')),
    [item_image1] varchar(100) NULL,
    [disp_flg] varchar(1) NOT NULL DEFAULT (('1')),
    [status_cd] varchar(2) NOT NULL DEFAULT (('00')),
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_item] PRIMARY KEY ([item_cd])
);
GO

CREATE TABLE [tm_item_category1] (
    [item_category1_cd] varchar(4) NOT NULL,
    [item_category1_name] varchar(30) NOT NULL DEFAULT (('')),
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_item_category1] PRIMARY KEY ([item_category1_cd])
);
GO

CREATE TABLE [tm_item_category2] (
    [item_category1_cd] varchar(4) NOT NULL,
    [item_category2_cd] varchar(4) NOT NULL,
    [item_category2_name] varchar(30) NOT NULL DEFAULT (('')),
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_item_category2] PRIMARY KEY ([item_category1_cd], [item_category2_cd])
);
GO

CREATE TABLE [tm_item_price] (
    [item_cd] varchar(20) NOT NULL,
    [no_tax_retail_price] numeric(19, 4) NOT NULL DEFAULT ((0)),
    [no_tax_wholesale_price] numeric(19, 4) NOT NULL DEFAULT ((0)),
    [tax_div_cd] varchar(2) NOT NULL DEFAULT (('00')),
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_item_price] PRIMARY KEY ([item_cd])
);
GO

CREATE TABLE [tm_item_status] (
    [status_cd] varchar(2) NOT NULL,
    [status_name] varchar(30) NOT NULL DEFAULT (('')),
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_item_status] PRIMARY KEY ([status_cd])
);
GO

CREATE TABLE [tm_item_stock] (
    [item_cd] varchar(20) NOT NULL,
    [stock_num] numeric(19, 4) NOT NULL,
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_item_stock] PRIMARY KEY ([item_cd])
);
GO

CREATE TABLE [tm_message] (
    [msg_cd] varchar(80) NOT NULL,
    [msg_val] varchar(200) NOT NULL DEFAULT (('')),
    [description] varchar(200) NULL,
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_message] PRIMARY KEY ([msg_cd])
);
GO

CREATE TABLE [tm_system_setting] (
    [ss_id] varchar(6) NOT NULL,
    [ss_cd] varchar(80) NOT NULL,
    [ss_name] varchar(80) NOT NULL,
    [ss_val] varchar(4000) NULL,
    [description] varchar(200) NULL,
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_system_setting] PRIMARY KEY ([ss_id])
);
GO

CREATE TABLE [tm_tax_div] (
    [tax_div_cd] varchar(2) NOT NULL,
    [tax_rate] numeric(19, 4) NOT NULL,
    [tax_name] varchar(20) NOT NULL DEFAULT (('')),
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tm_tax_div] PRIMARY KEY ([tax_div_cd])
);
GO

CREATE TABLE [tt_order_history] (
    [order_no] varchar(10) NOT NULL,
    [order_date] datetime NOT NULL,
    [record_no] int NOT NULL,
    [item_cd] varchar(20) NOT NULL DEFAULT (('')),
    [order_quantity] numeric(19, 4) NOT NULL,
    [update_by] varchar(20) NULL,
    [update_time] datetime NOT NULL DEFAULT ((getdate())),
    [insert_by] varchar(20) NULL,
    [insert_time] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tt_order_history] PRIMARY KEY ([order_no], [record_no])
);
GO

CREATE UNIQUE INDEX [UQ__tm_syste__A44515E4113160AE] ON [tm_system_setting] ([ss_cd]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210623063635_CreateTables', N'5.0.9');
GO

COMMIT;
GO

