/*
Created: 21-Jan-15
Modified: 12-Feb-15
Model: IMS
Database: MySQL 5.1
*/



-- Create tables section -------------------------------------------------

-- Table User

CREATE TABLE User
(
  id Int NOT NULL AUTO_INCREMENT,
  user_code Varchar(32) NOT NULL,
  user_name Varchar(64) NOT NULL,
  password Varchar(32) NOT NULL,
  group_id Int NOT NULL,
  last_login_on Datetime,
  created_by Varchar(32),
  created_on Datetime,
  updated_by Varchar(32),
  updated_on Datetime,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

ALTER TABLE User ADD UNIQUE user_code (user_code)
;

CREATE INDEX idx_User ON User (user_code,user_name,password,group_id,updated_on)
;

-- Table Groups

CREATE TABLE Groups
(
  id Int NOT NULL AUTO_INCREMENT,
  group_code Varchar(32) NOT NULL,
  group_name Varchar(64) NOT NULL,
  updated_on Datetime,
  updated_by Varchar(32),
  created_on Datetime,
  created_by Varchar(32),
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

ALTER TABLE Groups ADD UNIQUE group_code (group_code)
;

CREATE INDEX idx_group ON Groups (group_code,group_name,updated_on)
;

-- Table Supplier

CREATE TABLE Supplier
(
  id Int NOT NULL AUTO_INCREMENT,
  kode_supplier Varchar(32) NOT NULL,
  name_supplier Varchar(64) NOT NULL,
  contact_person Varchar(32) NOT NULL,
  address1 Varchar(256),
  address2 Varchar(256),
  city Varchar(32),
  phone Varchar(32),
  hp Varchar(32),
  fax Varchar(32),
  email Varchar(32),
  website Varchar(32),
  diskon Bigint,
  credit_term Bigint,
  npwp Varchar(64),
  updated_on Datetime,
  updated_by Varchar(32),
  created_by Varchar(32),
  created_on Datetime,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

ALTER TABLE Supplier ADD UNIQUE kode_supplier (kode_supplier)
;

CREATE INDEX idx_supplier ON Supplier (kode_supplier,name_supplier)
;

-- Table Customer

CREATE TABLE Customer
(
  id Int NOT NULL AUTO_INCREMENT,
  kode_customer Varchar(32) NOT NULL,
  name_customer Varchar(64) NOT NULL,
  contact_person Varchar(32) NOT NULL,
  address1 Varchar(256),
  address2 Varchar(256),
  city Varchar(32),
  phone Varchar(32),
  hp Varchar(32),
  fax Varchar(32),
  email Varchar(32),
  website Varchar(32),
  diskon Bigint,
  credit_term Bigint,
  npwp Varchar(64),
  territory_key Varchar(32),
  credit_limit Bigint,
  class_key Varchar(32),
  updated_on Datetime,
  updated_by Varchar(32),
  created_by Varchar(32),
  created_on Datetime,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

ALTER TABLE Customer ADD UNIQUE kode_supplier (kode_customer)
;

CREATE INDEX idxCustomer ON Customer (name_customer,kode_customer)
;

-- Table Items

CREATE TABLE Items
(
  id Int NOT NULL AUTO_INCREMENT,
  kode_item Varchar(32) NOT NULL,
  nama_item Varchar(128) NOT NULL,
  quantity Int NOT NULL,
  item_type Varchar(32) NOT NULL,
  item_status Varchar(32) NOT NULL,
  satuan Varchar(5),
  gudang_id Int NOT NULL,
  category_id Int NOT NULL,
  supplier_id Int NOT NULL,
  default_price Bigint NOT NULL,
  default_diskon Bigint,
  total_cost Bigint,
  cost Bigint,
  created_by Varchar(32),
  created_on Datetime,
  updated_on Datetime,
  updated_by Varchar(32),
 PRIMARY KEY (id)
)
;

ALTER TABLE Items ADD UNIQUE kode_item (kode_item)
;

CREATE INDEX idx_items ON Items (kode_item,nama_item,gudang_id,category_id,supplier_id)
;

-- Table Gudang

CREATE TABLE Gudang
(
  id Int NOT NULL AUTO_INCREMENT,
  kode_gudang Varchar(32) NOT NULL,
  nama_gudang Varchar(64) NOT NULL,
  address Varchar(500),
  person_in_charge Varchar(32),
  created_by Varchar(32),
  created_on Datetime,
  updated_by Varchar(32),
  updated_on Datetime,
 PRIMARY KEY (id)
)
;

CREATE INDEX idx_gudang ON Gudang (kode_gudang,nama_gudang)
;

-- Table Items_Category

CREATE TABLE Items_Category
(
  id Int NOT NULL AUTO_INCREMENT,
  kode_category Varchar(32) NOT NULL,
  nama_kategori Varchar(128) NOT NULL,
  created_on Datetime,
  created_by Varchar(32),
  updated_on Datetime,
  updated_by Varchar(32),
 PRIMARY KEY (id)
)
;

ALTER TABLE Items_Category ADD UNIQUE kode_category (kode_category)
;

CREATE INDEX items_category_idx ON Items_Category (nama_kategori,kode_category)
;

-- Table purchase_order_header

CREATE TABLE purchase_order_header
(
  id Bigint NOT NULL AUTO_INCREMENT,
  kode_supplier Varchar(32) NOT NULL,
  nama_supplier Varchar(64) NOT NULL,
  alamat_supplier Varchar(256),
  ship_to Varchar(256),
  supplier_taxable Int,
  inclusive_tax Int,
  po_no Varchar(64),
  po_date Datetime,
  expected_date Datetime,
  fob Varchar(32),
  terms Varchar(32),
  ship_via Varchar(32),
  notes Varchar(256),
  available_dp Bigint,
  used_dp Bigint,
  sub_total Bigint,
  diskon Bigint,
  diskon_pct Int,
  tax_value Bigint,
  cost_ship Bigint,
  total_order Bigint,
  status_po Int,
  created_by Varchar(32),
 PRIMARY KEY (id)
)
;

ALTER TABLE purchase_order_header ADD UNIQUE po_no (po_no)
;

CREATE INDEX po_header_idx ON purchase_order_header (kode_supplier,nama_supplier,po_no,po_date)
;

-- Table sales_order_header

CREATE TABLE sales_order_header
(
  id Bigint NOT NULL AUTO_INCREMENT,
  kode_customer Varchar(32) NOT NULL,
  nama_customer Varchar(64) NOT NULL,
  bill_to Varchar(256),
  ship_to Varchar(256),
  cust_taxable Int,
  inclusive_tax Int,
  po_no Varchar(64),
  so_no Varchar(64),
  so_date Datetime,
  ship_date Datetime,
  notes Varchar(256),
  sub_total Bigint,
  diskon Bigint,
  diskon_pct Int,
  tax_value Bigint,
  cost_ship Bigint,
  total_order Bigint,
  status_so Int,
  created_by Varchar(32),
 PRIMARY KEY (id)
)
;

ALTER TABLE sales_order_header ADD UNIQUE po_no (so_no)
;

CREATE INDEX so_header_idx ON sales_order_header (kode_customer,nama_customer,so_no,so_date)
;

-- Table purchase_order_detail

CREATE TABLE purchase_order_detail
(
  id Bigint NOT NULL AUTO_INCREMENT,
  po_header_id Bigint,
  kode_item Varchar(32),
  nama_item Varchar(32),
  qty Bigint,
  satuan Varchar(32),
  price_per_unit Bigint,
  diskon Bigint,
  price_total Bigint,
 PRIMARY KEY (id)
)
;

CREATE INDEX po_detail_idx ON purchase_order_detail (po_header_id,kode_item,nama_item)
;

-- Table sales_order_detail

CREATE TABLE sales_order_detail
(
  id Bigint NOT NULL AUTO_INCREMENT,
  so_header_id Bigint,
  kode_item Varchar(32),
  nama_item Varchar(32),
  qty Bigint,
  satuan Varchar(32),
  price_per_unit Bigint,
  diskon Bigint,
  price_total Bigint,
 PRIMARY KEY (id)
)
;

CREATE INDEX so_detail_idx ON sales_order_detail (so_header_id,kode_item,nama_item)
;

-- Table receive_item_header

CREATE TABLE receive_item_header
(
  id Bigint NOT NULL AUTO_INCREMENT,
  kode_supplier Varchar(32) NOT NULL,
  nama_supplier Varchar(32) NOT NULL,
  alamat_supplier Varchar(256),
  form_no Varchar(32),
  receipt_no Varchar(32),
  receive_date Datetime,
  ship_date Datetime,
  notes Varchar(256),
  status_receive_item Int,
  created_by Varchar(32),
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

ALTER TABLE receive_item_header ADD UNIQUE form_no (form_no)
;

-- Table delivery_order_header

CREATE TABLE delivery_order_header
(
  id Bigint NOT NULL AUTO_INCREMENT,
  kode_customer Varchar(32) NOT NULL,
  nama_customer Varchar(32) NOT NULL,
  bill_to Varchar(256),
  ship_to Varchar(256),
  po_no Varchar(32),
  do_no Varchar(32),
  delivery_date Datetime,
  notes Varchar(256),
  status_delivery_order Int,
  created_by Varchar(32),
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

ALTER TABLE delivery_order_header ADD UNIQUE do_no (do_no)
;

CREATE INDEX IndexDeliveryHeader ON delivery_order_header (kode_customer,nama_customer,status_delivery_order,created_by)
;

-- Table receive_item_detail

CREATE TABLE receive_item_detail
(
  id Bigint NOT NULL AUTO_INCREMENT,
  receive_header_id Bigint,
  kode_item Varchar(32),
  nama_item Varchar(64),
  qty Bigint,
  satuan Varchar(5),
  kode_gudang Varchar(64),
  po_no Varchar(64),
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table delivery_order_detail

CREATE TABLE delivery_order_detail
(
  id Bigint NOT NULL AUTO_INCREMENT,
  delivery_header_id Bigint,
  kode_item Varchar(32),
  nama_item Varchar(64),
  qty Bigint,
  satuan Varchar(5),
  so_no Varchar(64),
  kode_gudang Varchar(64),
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

CREATE INDEX IndexDelivery_detail ON delivery_order_detail (delivery_header_id,so_no)
;

-- Table items_gudang

CREATE TABLE items_gudang
(
  gudang_id Bigint NOT NULL,
  kode_item Varchar(32) NOT NULL,
  qty Bigint
)
;

ALTER TABLE items_gudang ADD PRIMARY KEY (gudang_id,kode_item)
;

-- Table purchase_invoice_header

CREATE TABLE purchase_invoice_header
(
  id Bigint NOT NULL AUTO_INCREMENT,
  kode_supplier Varchar(32),
  nama_supplier Varchar(32),
  form_no Varchar(32),
  invoice_no Varchar(32),
  invoice_date Datetime,
  ship_date Datetime,
  notes Varchar(256),
  supplier_taxable Int,
  inclusive_tax Int,
  sub_total Bigint,
  diskon_pct Int,
  diskon Bigint,
  tax_value Bigint,
  total_order Bigint,
  status_invoice Int
  COMMENT '1= baru dibuat invoice',
  created_by Varchar(32),
 PRIMARY KEY (id)
)
;

ALTER TABLE purchase_invoice_header ADD UNIQUE form_no (form_no)
;

CREATE INDEX PurchaseInvoiceIdx ON purchase_invoice_header (kode_supplier,form_no,invoice_no)
;

-- Table sales_invoice_header

CREATE TABLE sales_invoice_header
(
  id Bigint NOT NULL AUTO_INCREMENT,
  kode_customer Varchar(32),
  nama_customer Varchar(32),
  bill_to Varchar(256),
  ship_to Varchar(256),
  form_no Varchar(32),
  sales_invoice_no Varchar(32),
  sales_invoice_date Datetime,
  ship_date Datetime,
  notes Varchar(256),
  customer_taxable Int,
  inclusive_tax Int,
  sub_total Bigint,
  diskon_pct Int,
  diskon Bigint,
  tax_value Bigint,
  total_order Bigint,
  status_sales_invoice Int
  COMMENT '1= baru dibuat invoice',
  created_by Varchar(32),
 PRIMARY KEY (id)
)
;

ALTER TABLE sales_invoice_header ADD UNIQUE form_no (form_no)
;

CREATE INDEX SalesInvoiceIdx ON sales_invoice_header (kode_customer,form_no,sales_invoice_no)
;

-- Table purchase_invoice_detail

CREATE TABLE purchase_invoice_detail
(
  id Bigint NOT NULL AUTO_INCREMENT,
  purchase_header_id Bigint,
  kode_item Varchar(32),
  nama_item Varchar(64),
  qty Bigint,
  satuan Varchar(5),
  price_per_unit Bigint,
  diskon Bigint,
  price_total Bigint,
  kode_gudang Varchar(32),
  po_no Varchar(32),
  receive_no Varchar(32),
 PRIMARY KEY (id)
)
;

CREATE INDEX purchase_inv_detail ON purchase_invoice_detail (purchase_header_id,po_no,receive_no)
;

-- Table sales_invoice_detail

CREATE TABLE sales_invoice_detail
(
  id Bigint NOT NULL AUTO_INCREMENT,
  sales_invoice_header_id Bigint,
  kode_item Varchar(32),
  nama_item Varchar(64),
  qty Bigint,
  satuan Varchar(5),
  price_per_unit Bigint,
  diskon Bigint,
  price_total Bigint,
  kode_gudang Varchar(32),
  so_no Varchar(32),
  do_no Varchar(32),
 PRIMARY KEY (id)
)
;

CREATE INDEX sales_inv_detail ON sales_invoice_detail (sales_invoice_header_id,so_no,do_no)
;

-- Table purchase_payment

CREATE TABLE purchase_payment
(
  id Bigint NOT NULL AUTO_INCREMENT,
  kode_supplier Varchar(32),
  nama_supplier Varchar(256),
  alamat_supplier Varchar(256),
  invoice_no Varchar(32),
  form_no_invoice Varchar(32),
  invoice_date Datetime,
  payment_date Datetime,
  form_no Varchar(32),
  total_order Bigint,
  owing Bigint,
  payment_amount Bigint,
  notes Varchar(256),
  is_history Int,
 PRIMARY KEY (id)
)
;



INSERT INTO user
(user_code,user_name,password,group_id,last_login_on,created_by,created_on,updated_by,updated_on)
VALUES
('admin','admin','123456',1,null,null,null,null,null);

INSERT INTO groups(
   group_code
  ,group_name
  ,updated_on
  ,updated_by
  ,created_on
  ,created_by
) VALUES (
   '0001'
  ,'Administrator'
  ,null
  ,null
  ,null
  ,null
)

INSERT INTO groups(
   group_code
  ,group_name
  ,updated_on
  ,updated_by
  ,created_on
  ,created_by
) VALUES (
   '0002'
  ,'Data Entry'
  ,null
  ,null
  ,null
  ,null
)
