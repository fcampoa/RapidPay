create database [RapidPay]
go

use [RapidPay];
go

create table Card(
    Id int not null identity,
    CardNumber varchar(15) not null,
    Balance numeric(10,5) default 0,
    primary key(Id)
);
go

insert into [Card] (CardNumber, Balance) 
values
('415231361584123', 1000),
('123456789011121', 2000),
('581531361581793', 500),
('515231361586494', 450);
go

create table Payments(
    Id int not null identity,
    Fee numeric(10,5) default 0,
    CardId int not null,
    primary key(Id),
    foreign key (CardId) references Card(Id)
);
go