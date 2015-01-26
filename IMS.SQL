/*
Created: 21-Jan-15
Modified: 27-Jan-15
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
  id Int NOT NULL,
  kode_item Varchar(32) NOT NULL,
  nama_item Varchar(128) NOT NULL,
  quantity Int NOT NULL,
  item_type Varchar(32) NOT NULL,
  item_status Varchar(32) NOT NULL,
  satuan Varchar(5),
  gudang_id Int NOT NULL,
  category_id Int NOT NULL,
  default_price Bigint NOT NULL,
  default_diskon Bigint,
  supplier_id Int NOT NULL,
  created_by Int,
  created_on Datetime,
  updated_on Datetime,
  updated_by Int
)
;

ALTER TABLE Items ADD PRIMARY KEY (id)
;

ALTER TABLE Items ADD UNIQUE kode_item (kode_item)
;

CREATE INDEX idx_items ON Items (kode_item,nama_item,gudang_id,category_id,supplier_id)
;

-- Table Gudang

CREATE TABLE Gudang
(
  id Int NOT NULL,
  kode_gudang Varchar(32) NOT NULL,
  nama_gudang Varchar(64) NOT NULL,
  address Varchar(500),
  person_in_charge Varchar(32),
  created_by Varchar(32),
  created_on Datetime,
  updated_by Varchar(32),
  updated_on Datetime
)
;

ALTER TABLE Gudang ADD PRIMARY KEY (id)
;

CREATE INDEX idx_gudang ON Gudang (kode_gudang,nama_gudang)
;

-- Table Items_Category

CREATE TABLE Items_Category
(
  id Int NOT NULL,
  kode_category Varchar(32) NOT NULL,
  nama_kategori Varchar(128) NOT NULL,
  created_on Datetime,
  created_by Varchar(32),
  updated_on Datetime,
  updated_by Varchar(32)
)
;

ALTER TABLE Items_Category ADD PRIMARY KEY (id)
;

ALTER TABLE Items_Category ADD UNIQUE kode_category (kode_category)
;

CREATE INDEX items_category_idx ON Items_Category (nama_kategori,kode_category)
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
