----------------------------------------------------------------------------------------------------
-- ECWINDOW サンプルデータ登録
----------------------------------------------------------------------------------------------------

-- 商品分類1マスタ
TRUNCATE TABLE tm_item_category1;
with sign as (select 'ecwinit' as name)
insert into tm_item_category1 (item_category1_cd, item_category1_name, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('10',	'パソコン'			)
	,('20',	'家電'				)
	,('30',	'時計＆雑貨'		)
) as v(v1,v2), sign
;

-- 商品分類2マスタ
TRUNCATE TABLE tm_item_category2;
with sign as (select 'ecwinit' as name)
insert into tm_item_category2 (item_category1_cd, item_category2_cd, item_category2_name, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('10',	'10',	'ノートPC'			)
	,('10',	'20',	'デスクトップPC'	)
	,('10',	'30',	'PC周辺機器'		)
	,('20',	'10',	'テレビ'			)
	,('20',	'20',	'冷蔵庫'			)
	,('30',	'10',	'時計'				)
	,('30',	'20',	'雑貨'				)
) as v(v1,v2,v3), sign
;

-- ブランドマスタ
TRUNCATE TABLE tm_brand;
with sign as (select 'ecwinit' as name)
insert into tm_brand (brand_cd, brand_name, brand_name_kana, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0001',	'D**BRAND',			'D**ブランド'			)
	,('0002',	'E**BRAND',			'E**ブランド'			)
	,('0003',	'S**BRAND',			'S**ブランド'			)
	,('0004',	'P**BRAND',			'P**ブランド'			)
	,('0005',	'O**BRAND',			'O**ブランド'			)
	,('0006',	'CI**BRAND',		'CI**ブランド'			)
	,('0007',	'R**BRAND',			'R**ブランド'			)
	,('0008',	'CO**BRAND',		'CO**ブランド'			)
	,('0009',	'M**BRAND',			'M**ブランド'			)
) as v(v1,v2,v3), sign
;

-- 商品マスタ（ノートPC）
TRUNCATE TABLE tm_item;
with sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, item_name2, item_category1_cd, item_category2_cd, brand_cd, model_number, jan_cd, item_image1, disp_flg, status_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000001001',	'Inspire 17 910 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-17-910-ND',	'4900000101001',	'0100_pc01.png',	'1',	'01')
	,('0000001002',	'Inspire 15 910 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-15-910-ND',	'4900000101002',	'0100_pc01.png',	'1',	'01')
	,('0000001003',	'Inspire 17 900 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-17-900-ND',	'4900000101003',	'0100_pc01.png',	'1',	'00')
	,('0000001004',	'Inspire 15 900 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-15-900-ND',	'4900000101004',	'0100_pc01.png',	'1',	'00')
	,('0000001005',	'Inspire 17 710 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-17-710-ND',	'4900000101005',	'0100_pc01.png',	'1',	'00')
	,('0000001006',	'Inspire 15 710 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-15-710-ND',	'4900000101006',	'0100_pc01.png',	'1',	'00')
	,('0000001007',	'Inspire 17 700 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-17-700-ND',	'4900000101007',	'0100_pc01.png',	'1',	'00')
	,('0000001008',	'Inspire 15 700 New Dimension',		'Laptop',	'10',	'10',	'0001',	'DD-INSP-15-700-ND',	'4900000101008',	'0100_pc01.png',	'1',	'00')
	,('0000001009',	'Inspire 14 510 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-14-510-STD',	'4900000101009',	'0100_pc01.png',	'1',	'00')
	,('0000001010',	'Inspire 13 510 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-13-510-STD',	'4900000101010',	'0100_pc01.png',	'1',	'00')
	,('0000001011',	'Inspire 14 500 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-14-500-STD',	'4900000101011',	'0100_pc01.png',	'1',	'00')
	,('0000001012',	'Inspire 13 500 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-13-500-STD',	'4900000101012',	'0100_pc01.png',	'1',	'00')
	,('0000001013',	'Inspire 14 310 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-14-310-STD',	'4900000101013',	'0100_pc01.png',	'1',	'00')
	,('0000001014',	'Inspire 13 310 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-13-310-STD',	'4900000101014',	'0100_pc01.png',	'1',	'00')
	,('0000001015',	'Inspire 14 300 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-14-300-STD',	'4900000101015',	'0100_pc01.png',	'1',	'00')
	,('0000001016',	'Inspire 13 300 Standard',			'Laptop',	'10',	'10',	'0001',	'DD-INSP-13-300-STD',	'4900000101016',	'0100_pc01.png',	'1',	'00')
) as v(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11), sign
;

-- 商品マスタ（デスクトップPC）
with sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, item_name2, item_category1_cd, item_category2_cd, brand_cd, model_number, jan_cd, item_image1, disp_flg, status_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000002001',	'Vistro 910 New Frontier',		'Desktop',	'10',	'20',	'0001',	'DD-VIST-910-NF',	'4900000201001',	'0100_pc02.png',	'1',	'01')
	,('0000002002',	'Vistro 900 New Frontier',		'Desktop',	'10',	'20',	'0001',	'DD-VIST-900-NF',	'4900000201002',	'0100_pc02.png',	'1',	'00')
	,('0000002003',	'Vistro 710 New Frontier',		'Desktop',	'10',	'20',	'0001',	'DD-VIST-710-NF',	'4900000201003',	'0100_pc02.png',	'1',	'00')
	,('0000002004',	'Vistro 700 New Frontier',		'Desktop',	'10',	'20',	'0001',	'DD-VIST-700-NF',	'4900000201004',	'0100_pc02.png',	'1',	'00')
	,('0000002005',	'Vistro 510',					'Desktop',	'10',	'20',	'0001',	'DD-VIST-510',		'4900000201005',	'0100_pc02.png',	'1',	'00')
	,('0000002006',	'Vistro 500',					'Desktop',	'10',	'20',	'0001',	'DD-VIST-500',		'4900000201006',	'0100_pc02.png',	'1',	'99')
	,('0000002007',	'Vistro 310',					'Desktop',	'10',	'20',	'0001',	'DD-VIST-310',		'4900000201007',	'0100_pc02.png',	'1',	'99')
	,('0000002008',	'非表示商品☆Vistro 300',		'Desktop',	'10',	'20',	'0001',	'DD-VIST-300',		'4900000201008',	'0100_pc02.png',	'0',	'99')
	,('0000002009',	'Vistro R7',					'Desktop',	'10',	'20',	'0001',	'DD-VIST-R7',		'4900000201009',	'0100_pc02.png',	'1',	'00')
	,('0000002010',	'Vistro R5',					'Desktop',	'10',	'20',	'0001',	'DD-VIST-R5',		'4900000201010',	'0100_pc02.png',	'1',	'00')
	,('0000002011',	'Vistro R3',					'Desktop',	'10',	'20',	'0001',	'DD-VIST-R3',		'4900000201011',	'0100_pc02.png',	'1',	'00')
) as v(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11), sign
;

-- 商品マスタ（PC周辺機器）
with sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, item_name2, item_category1_cd, item_category2_cd, brand_cd, model_number, jan_cd, item_image1, disp_flg, status_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000003001',	'Colorin NP-54A3',				'プリンタ複合機',	'10',	'30',	'0002',	'CLRN-NP-54A3',		'4900000301001',	'0100_pc03.png',	'1',	'00')
	,('0000003002',	'Colorin NP-53A4',				'プリンタ複合機',	'10',	'30',	'0002',	'CLRN-NP-53A4',		'4900000301002',	'0100_pc03.png',	'1',	'00')
	,('0000003003',	'Colorin NP-44A3',				'プリンタ複合機',	'10',	'30',	'0002',	'CLRN-NP-44A3',		'4900000301003',	'0100_pc03.png',	'1',	'00')
	,('0000003004',	'Colorin NP-43A4',				'プリンタ複合機',	'10',	'30',	'0002',	'CLRN-NP-43A4',		'4900000301004',	'0100_pc03.png',	'1',	'00')
	,('0000003005',	'非表示商品☆Colorin NP-34A3',	'プリンタ複合機',	'10',	'30',	'0002',	'CLRN-NP-34A3',		'4900000301005',	'0100_pc03.png',	'0',	'00')
	,('0000003006',	'非表示商品☆Colorin NP-33A4',	'プリンタ複合機',	'10',	'30',	'0002',	'CLRN-NP-33A4',		'4900000301006',	'0100_pc03.png',	'0',	'00')
	,('0000003007',	'Colorin Q34',					'プリンタ',			'10',	'30',	'0002',	'CLRN-NP-Q34',		'4900000301007',	'0100_pc03.png',	'1',	'00')
	,('0000003008',	'Colorin Q33',					'プリンタ',			'10',	'30',	'0002',	'CLRN-NP-Q33',		'4900000301008',	'0100_pc03.png',	'1',	'00')
	,('0000003009',	'Colorin U24',					'プリンタ',			'10',	'30',	'0002',	'CLRN-NP-U24',		'4900000301009',	'0100_pc03.png',	'1',	'00')
	,('0000003010',	'Colorin U23',					'プリンタ',			'10',	'30',	'0002',	'CLRN-NP-U23',		'4900000301010',	'0100_pc03.png',	'1',	'00')
) as v(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11), sign
;

-- 商品マスタ（テレビ）
with sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, item_name2, item_category1_cd, item_category2_cd, brand_cd, model_number, jan_cd, item_image1, disp_flg, status_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000004001',	'BRAVINA 55V NU1150',	'4K液晶テレビ',				'20',	'10',	'0003',	'SN-BRV-55V-NU1150',	'4900000401001',	'0200_electronics01.png',	'1',	'00')
	,('0000004002',	'BRAVINA 43V NU1130',	'4K液晶テレビ',				'20',	'10',	'0003',	'SN-BRV-43V-NU1130',	'4900000401002',	'0200_electronics01.png',	'1',	'00')
	,('0000004003',	'BRAVINA 32V NU1100',	'ハイビジョン液晶テレビ',	'20',	'10',	'0003',	'SN-BRV-32V-NU1100',	'4900000401003',	'0200_electronics01.png',	'1',	'00')
	,('0000004004',	'BRAVINA 28V NN1050',	'ハイビジョン液晶テレビ',	'20',	'10',	'0003',	'SN-BRV-28V-NN1050',	'4900000401004',	'0200_electronics01.png',	'1',	'00')
	,('0000004005',	'BRAVINA 24V NN1030',	'ハイビジョン液晶テレビ',	'20',	'10',	'0003',	'SN-BRV-24V-NN1030',	'4900000401005',	'0200_electronics01.png',	'1',	'00')
	,('0000004006',	'LDC-45RC 45V',			'4K液晶テレビ',				'20',	'10',	'0009',	'MB-LDC-45V-RC',		'4900000401006',	'0200_electronics02.png',	'1',	'00')
	,('0000004007',	'LDC-39DY 39V',			'4K液晶テレビ',				'20',	'10',	'0009',	'MB-LDC-39V-DY',		'4900000401007',	'0200_electronics02.png',	'1',	'00')
	,('0000004008',	'LDC-33HA 33V',			'ハイビジョン液晶テレビ',	'20',	'10',	'0009',	'MB-LDC-33V-HA',		'4900000401008',	'0200_electronics02.png',	'1',	'00')
	,('0000004009',	'LDC-28UC 28V',			'ハイビジョン液晶テレビ',	'20',	'10',	'0009',	'MB-LDC-28V-UC',		'4900000401009',	'0200_electronics02.png',	'1',	'00')
) as v(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11), sign
;

-- 商品マスタ（冷蔵庫）
with sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, item_name2, item_category1_cd, item_category2_cd, brand_cd, model_number, jan_cd, item_image1, disp_flg, status_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000005001',	'DXR-EX401A-SU',		null,		'20',	'20',	'0004',	'DXR-EX401A-SU',	'4900000501001',	'0200_electronics03.png',	'1',	'00')
	,('0000005002',	'DXR-EX351A-DU',		null,		'20',	'20',	'0004',	'DXR-EX351A-DU',	'4900000501002',	'0200_electronics03.png',	'1',	'00')
	,('0000005003',	'GR-EX301A-LL',			null,		'20',	'20',	'0004',	'GR-EX301A-CR',		'4900000501003',	'0200_electronics03.png',	'1',	'00')
	,('0000005004',	'GR-EX251A-LS',			null,		'20',	'20',	'0004',	'GR-EX251A-LF',		'4900000501004',	'0200_electronics03.png',	'1',	'00')
	,('0000005005',	'GR-EX201A-SH',			null,		'20',	'20',	'0004',	'GR-EX251A-EOF',	'4900000501005',	'0200_electronics03.png',	'1',	'99')
) as v(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11), sign
;

-- 商品マスタ（時計）
with sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, item_name2, item_category1_cd, item_category2_cd, brand_cd, model_number, jan_cd, item_image1, disp_flg, status_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000006001',	'SEAMEISTER',			'',	'30',	'10',	'0005',	'',	'4900000601001',	'0300_watchesandgoods01.png',	'1',	'00')
	,('0000006002',	'ツインベル UX50',		'',	'30',	'10',	'0006',	'',	'4900000601002',	'0300_watchesandgoods02.png',	'1',	'00')
) as v(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11), sign
;

-- 商品マスタ（雑貨）
with sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, item_name2, item_category1_cd, item_category2_cd, brand_cd, model_number, jan_cd, item_image1, disp_flg, status_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000007001',	'カップ&ソーサー ペア',		'',		'30',	'20',	'0007',	'',	'4900000701001',	'0300_watchesandgoods03.png',	'1',	'00')
	,('0000007002',	'MOUNTAINSIDE LANTERN',		'',		'30',	'20',	'0008',	'',	'4900000701002',	'0300_watchesandgoods04.png',	'1',	'00')
) as v(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11), sign
;


-- システム設定マスタ
TRUNCATE TABLE tm_system_setting;
with sign as (select 'ecwinit' as name)
insert into tm_system_setting (ss_id, ss_cd, ss_name, ss_val, description, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('001000',	'system_name1',				'システム名1',					'ECWINDOW',									'システム名英語'									)
	,('001001',	'system_name2',				'システム名2',					'ECウインドウ',								'システム名日本語'									)
	,('001002',	'system_name_abbr',			'システム名略称',				'ECW',										'システム名略称'									)
	,('001003',	'item_image_url',			'Webサーバ商品画像参照URL',		'http://localhost:80/ecw/images/item/',		' Webサーバ（Apache）上の商品画像を参照する際のURL'	)
) as v(v1,v2,v3,v4,v5), sign
;

-- メッセージマスタ
TRUNCATE TABLE tm_message;
with sign as (select 'ecwinit' as name)
insert into tm_message (msg_cd, msg_val, description, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('item_search_no_result',	'検索条件に一致する商品はありませんでした。',	'[商品一覧]検索結果が0件だった時の文言'	)
) as v(v1,v2,v3), sign
;

-- 商品ステータスマスタ
TRUNCATE TABLE tm_item_status;
with sign as (select 'ecwinit' as name)
insert into tm_item_status (status_cd, status_name, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('00',	'販売中'		)
	,('01',	'予約受付中'	)
	,('99',	'取扱終了'		)
) as v(v1,v2), sign
;

-- 商品単価マスタ（ノートPC）
TRUNCATE TABLE tm_item_price;
with sign as (select 'ecwinit' as name)
insert into tm_item_price (item_cd, no_tax_retail_price, tax_div_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000001001',	111980,	'00')
	,('0000001002',	108980,	'00')
	,('0000001003',	105980,	'00')
	,('0000001004',	102980,	'00')
	,('0000001005',	99980,	'00')
	,('0000001006',	96980,	'00')
	,('0000001007',	93980,	'00')
	,('0000001008',	90980,	'00')
	,('0000001009',	87980,	'00')
	,('0000001010',	84980,	'00')
	,('0000001011',	81980,	'00')
	,('0000001012',	78980,	'00')
	,('0000001013',	75980,	'00')
	,('0000001014',	72980,	'00')
	,('0000001015',	69980,	'00')
	,('0000001016',	66980,	'00')
) as v(v1,v2,v3), sign
;

-- 商品単価マスタ（デスクトップPC）
with sign as (select 'ecwinit' as name)
insert into tm_item_price (item_cd, no_tax_retail_price, tax_div_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000002001',	103980,	'00')
	,('0000002002',	99980,	'00')
	,('0000002003',	95980,	'00')
	,('0000002004',	91980,	'00')
	,('0000002005',	87980,	'00')
	,('0000002006',	83980,	'00')
	,('0000002007',	79980,	'00')
	,('0000002008',	75980,	'00')
	,('0000002009',	71980,	'00')
	,('0000002010',	67980,	'00')
	,('0000002011',	63980,	'00')
) as v(v1,v2,v3), sign
;

-- 商品単価マスタ（PC周辺機器）
with sign as (select 'ecwinit' as name)
insert into tm_item_price (item_cd, no_tax_retail_price, tax_div_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000003001',	88980,	'00')
	,('0000003002',	65980,	'00')
	,('0000003003',	82980,	'00')
	,('0000003004',	59980,	'00')
	,('0000003005',	76980,	'00')
	,('0000003006',	53980,	'00')
	,('0000003007',	50980,	'00')
	,('0000003008',	47980,	'00')
	--,('0000003009',	44980,	'00')
	,('0000003010',	41980,	'00')
) as v(v1,v2,v3), sign
;

-- 商品単価マスタ（テレビ）
with sign as (select 'ecwinit' as name)
insert into tm_item_price (item_cd, no_tax_retail_price, tax_div_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000004001',	158000,	'00')
	,('0000004002',	98000,	'00')
	,('0000004003',	58000,	'00')
	,('0000004004',	38000,	'00')
	,('0000004005',	28000,	'00')
	,('0000004006',	128000,	'00')
	,('0000004007',	98000,	'00')
	,('0000004008',	55000,	'00')
	,('0000004009',	35000,	'00')
) as v(v1,v2,v3), sign
;

-- 商品単価マスタ（冷蔵庫）
with sign as (select 'ecwinit' as name)
insert into tm_item_price (item_cd, no_tax_retail_price, tax_div_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	 ('0000005001',	288000,	'00')
	,('0000005002',	228000,	'00')
	,('0000005003',	178000,	'00')
	,('0000005004',	138000,	'00')
	,('0000005005',	108000,	'00')
) as v(v1,v2,v3), sign
;

-- 商品単価マスタ（時計）
with sign as (select 'ecwinit' as name)
insert into tm_item_price (item_cd, no_tax_retail_price, tax_div_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	  ('0000006001',	446000,	'00')
	 ,('0000006002',	2400,	'00')
) as v(v1,v2,v3), sign
;

-- 商品単価マスタ（雑貨）
with sign as (select 'ecwinit' as name)
insert into tm_item_price (item_cd, no_tax_retail_price, tax_div_cd, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	  ('0000007001',	24000,	'00')
	 ,('0000007002',	20700,	'00')
) as v(v1,v2,v3), sign
;

-- 税抜下代単価を投入（税抜上代単価×0.9）
update tm_item_price set no_tax_wholesale_price = floor(no_tax_retail_price * 0.9);

-- 商品在庫マスタ、サンプルデータ投入（在庫数量0を3件以上含み、かつランダムな在庫数量）
TRUNCATE TABLE tm_item_stock;
with pre_stock_num_list as (
	select
		 item_cd
		,floor( power(rand(CHECKSUM(convert(varbinary, newid())))*8, 2) ) as stock_num
	from
		tm_item
)
, ascend as (
	select
		 row_number()over(order by stock_num asc) as row_num
		,stock_num
	from
		pre_stock_num_list
)
,sign as(select 'ecwinit' as name)
insert into tm_item_stock(item_cd, stock_num, update_by, insert_by)
select
	 item_cd
	,(case when (psnl.stock_num - third_from_bottom.stock_num) > 0 then  (psnl.stock_num - third_from_bottom.stock_num) else 0 end) stock_num
	,sign.name
	,sign.name
from
	 
	(select stock_num from ascend where row_num = 3) as third_from_bottom
	,pre_stock_num_list psnl
	,sign
;

-- 消費税率区分マスタ
TRUNCATE TABLE tm_tax_div;
with sign as (select 'ecwinit' as name)
insert into tm_tax_div (tax_div_cd, tax_rate, tax_name, update_by, insert_by)
select v.*, sign.name, sign.name
from
(values
	  ('01',	10,		'標準税率')
	 ,('02',	 8,		'軽減税率')
) as v(v1,v2,v3), sign
;


-- 商品マスタ（商品分類なしテスト商品データ5000件生成）
WITH serial AS ( 
  SELECT 0 AS N -- 開始値
  UNION ALL 
  SELECT N + 1 FROM serial 
  WHERE serial.N < 5000 -- 最大値
) ,
generate_item_cds as (
	select
		cast(N+9000000000 as varchar) as item_cd
	from
		serial
)
,test_item_values as (
	select
		 item_cd
		,'テスト商品' + item_cd as item_name1
	from
		generate_item_cds
)
,sign as (select 'ecwinit' as name)
insert into tm_item (item_cd, item_name1, update_by, insert_by)
select v.*, sign.name, sign.name
from test_item_values as v, sign
OPTION ( MAXRECURSION 0 )
;



-- 受注履歴トラン、データ投入（2000注文ランダム）
truncate table tt_order_history;
WITH serial1 AS ( 
  SELECT 0 AS N -- 開始値
  UNION ALL 
  SELECT N + 1 FROM serial1 
  WHERE serial1.N < 2000 -- 最大値
) ,
serial2 AS ( 
  SELECT 0 AS N -- 開始値
  UNION ALL 
  SELECT N + 1 FROM serial2 
  WHERE serial2.N < 5 -- 最大値
) ,
serial3 AS ( 
  SELECT 0 AS N -- 開始値
  UNION ALL 
  SELECT N + 1 FROM serial3
  WHERE serial3.N < 2000 -- 最大値
) ,
generate_order_nos as (
	select
		 1000000000+serial1.N as order_no
		,serial2.N as record_no
	from
	(	
			serial1
			cross join
			serial2
	)	
)
,order_seq as (
	
	select
		 row_number()over(order by gon.order_no asc) as order_seq_no
		,gon.order_no
	from
		generate_order_nos gon
	group by
		gon.order_no
)
,generate_max_record_no as (
	select
		 1000000000+N as order_no
		,floor( power( (rand(CHECKSUM(convert(varbinary, newid()))) + 0.5), 3 ) ) + 1 as max_record_no
	from
		serial3
)
,item_cds as (
	select
		 row_number() over(order by I.item_cd asc) as row_num
		,I.item_cd
	from
		tm_item I
	where
		exists (
			select 1
			from tm_item_price IP
			where IP.item_cd = I.item_cd
		)
	and
		I.disp_flg = '1'
	
)
,base_orders as (
	select
		TOP(10000)
		 gon.order_no
		,gon.record_no
		,floor(rand(CHECKSUM(convert(varbinary, newid()))) * (select count(1) from item_cds)) + 1 as choice_item_row_num
		,floor(rand(CHECKSUM(convert(varbinary, newid()))) * 5) + 1 as order_quantity
	from
		generate_order_nos gon
	left join
		generate_max_record_no gmrn
		on gon.order_no = gmrn.order_no
	where
		gon.record_no <= gmrn.max_record_no
	order by
		gon.order_no asc
)
,order_history_values as (
	select
		 BO.order_no
		,DATEADD(minute, OS.order_seq_no * 10, '2021-03-23') as order_date
		,BO.record_no
		,IC.item_cd
		,BO.order_quantity
	from
		base_orders BO
	left join
		item_cds IC
		on IC.row_num = BO.choice_item_row_num
	left join
		order_seq OS
		on OS.order_no = BO.order_no
)
,sign as (select 'ecwinit' as name)
insert into tt_order_history (order_no, order_date, record_no, item_cd, order_quantity, update_by, insert_by)
select v.*, sign.name, sign.name 
from order_history_values as v, sign
OPTION ( MAXRECURSION 0 )
; 

