USE [master]
GO
create database PaymentGateway;
use PaymentGateway;

create table Cryptocurrencies(
Id int identity(1,1) primary key ,
CryptoName varchar (50) not null,
DescriptionCrypto varchar (100),
price decimal(5,2) not null,
Amount int not null
);

create table CryptoOrder(
 Id int identity(1,1) primary key,
 DateOrder date not null,
 Headline varchar (30) not null,
 Subtotal int not null,
 total int not null,
 );

 create table CryptocurrencyOrder(
 Id int identity(1,1) primary key,
 IdCryptocurrencies int,
 IdPurchaseOrder int
 );