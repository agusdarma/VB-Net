/*
Created: 21-Jan-15
Modified: 24-Jan-15
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
