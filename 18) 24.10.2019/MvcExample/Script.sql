create database company2
go

use company2
go

create table Persons
(PersonID uniqueidentifier primary key,
PersonName varchar(40),
Email varchar(40),
Password varchar(40),
Age int,
DateOfJoining datetime,
Gender varchar(10),
IsRegistered bit,
State varchar(50))
go

create procedure usp_CreatePersons
(@PersonID uniqueidentifier,
@PersonName varchar(40),
@Email varchar(40),
@Password varchar(40),
@Age int,
@DateOfJoining datetime,
@Gender varchar(10),
@IsRegistered bit,
@State varchar(50))
as begin
	insert into Persons values(@PersonID, @PersonName, @Email, @Password, @Age,
	@DateOfJoining, @Gender, @IsRegistered, @State)
end
go

create procedure usp_UpdatePerson
(@PersonID uniqueidentifier,
@PersonName varchar(40),
@Email varchar(40),
@Age int,
@DateOfJoining datetime,
@Gender varchar(10),
@IsRegistered bit,
@State varchar(50))
as begin
	update Persons set PersonName=@PersonName, Email=@Email, Age=@Age,
	DateOfJoining=@DateOfJoining, Gender=@Gender, IsRegistered=@IsRegistered, State=@State
	where PersonID=@PersonID
end
go

create procedure usp_DeletePerson
(@PersonID uniqueidentifier)
as begin
	delete from Persons
	where PersonID=@PersonID
end
go

create procedure usp_GetPersons
as begin
	select * from Persons
end
go

create procedure usp_GetPersonByPersonID
(@PersonID uniqueidentifier)
as begin
	select * from Persons
	where PersonID=@PersonID
end
go


insert into Persons(PersonID, PersonName,
Email) values(
newid(), 'Scott', 'scott@gmail.com')
insert into Persons(PersonID, PersonName,
Email) values(
newid(), 'Allen', 'allen@gmail.com')
