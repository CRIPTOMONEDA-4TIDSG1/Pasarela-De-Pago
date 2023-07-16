USE [master]
GO
create database PaymentGateway;
use PaymentGateway;

create table Cryptocurrencies(
Id int identity(1,1) primary key ,
NameProduct varchar (50) not null,
DescriptionProdut varchar (100),
Tipe varchar (20) not null,
Amount int not null
);

create table PurchaseOrder (
 Id int identity(1,1) primary key,
 DateOrder date not null,
 Headline varchar (30) not null
 );

 create table CryptocurrencyPurchaseOrder(
 Id int identity(1,1) primary key,
 IdCryptocurrencies int,
 IdPurchaseOrder int
 );