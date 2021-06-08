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

insert into [Types] values ('Десерт'), ('Напиток'), ('Пицца'), ('Соус')

create table Products (
id int Identity(1,1) primary key,
[name] varchar(30),
price decimal(5,2),
[type] int references [Types](id) on delete cascade,
size int references Sizes(id) on delete cascade,
)

create table Orders (
id int Identity(1,1) primary key,
[user_id] int references Users(id) on delete cascade,
[name] varchar(30),
[telephone] varchar(15),
[date] date
)

create table Payment (
id int Identity(1,1) primary key,
[order_id] int references Orders(id) on delete cascade,
[address] varchar(100),
isCard bit,
card_number varchar(16)
)

create table Order_Products(
id int Identity(1,1) primary key,
[order_id] int references Orders(id) on delete cascade,
[product_id] int references Products(id) on delete cascade,
)
select * from Payment 