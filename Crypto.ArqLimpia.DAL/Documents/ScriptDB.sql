USE [master]
GO
create database PaymentGateway;
use PaymentGateway;

create table Cryptocurrencies(
Id int identity(1,1) primary key ,
CryptoName varchar (50) not null,
DescriptionCrypto varchar (100),
price decimal(18,2) not null,
Amount int not null
);

create table CryptoOrder(
 Id int identity(1,1) primary key,
 DateOrder date not null,
 email varchar (90) not null ,
 product_id int not null references Cryptocurrencies(Id),
 Quantity decimal(24,2) not null,
 total decimal(24,2) not null
);

 create table CryptocurrencyOrder(
 Id int identity(1,1) primary key,
 IdCryptocurrencies int,
 IdPurchaseOrder int
 );