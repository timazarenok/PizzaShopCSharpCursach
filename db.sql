create database Pizza

use Pizza;

create table Users(
id int Identity(1,1) primary key,
[login] varchar(30)
)

create table Sizes(
id int Identity(1,1) primary key,
[name] varchar(30),
[value] int
)

create table [Types] (
id int Identity(1,1) primary key,
[name] varchar(30)
)

create table Products (
id int Identity(1,1) primary key,
[name] varchar(30),
price decimal(5,2),
[type] int references [Types](id),
size int references Sizes(id),
)

create table Orders (
id int Identity(1,1) primary key,
[user_id] int references Users(id),
[date] date
)

create table Order_Products(
id int Identity(1,1) primary key,
[order_id] int references Orders(id),
[product_id] int references Products(id),
)
