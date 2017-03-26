--use SmartMe
--go

drop procedure spSavePasswordSafe
drop table PasswordSafe
go

/*********************************************************************************************/
create table PasswordSafe
(
	PasswordSafeId int identity(1,1) primary key,
	ServiceName varchar(255) not null,
	ServiceType varchar(100) null,
	Username varchar(100) not null,
	[Password] varchar(100) not null,
	SQ1 varchar(255) null,
	SA1 varchar(255) null,
	SQ2 varchar(255) null,
	SA2 varchar(255) null,
	SQ3 varchar(255) null,
	SA3 varchar(255) null,
	Created datetime default getdate()
)
go

alter table PasswordSafe
add IntegratedAuth varchar(100)
go

alter table PasswordSafe
add ValidPassword bit default 1
go

alter table PasswordSafe
add Active bit default 1
go

alter table PasswordSafe
add Modified datetime default getdate()
go

alter table PasswordSafe
add Notes varchar(max) 
go

create table ServiceType
(
	ServiceTypeId int primary key identity(1,1),
	Name varchar(255) not null,
	Protected bit default 0,
	Active bit default 1,
	Created datetime default getdate()
)
go

create table IntegratedAuthProvider
(
	IntegratedAuthProviderId int primary key identity(1,1),
	ProviderName varchar(255) not null,
)
go

/*********************************************************************************************/
ALTER procedure spSavePasswordSafe
(
	@passwordSafeId int = null,
	@serviceName varchar(255),
	@username varchar(100),
	@password varchar(50),
	@serviceType varchar(255) = null,
	@sq1 varchar(500) = null,
	@sa1 varchar(500) = null,
	@sq2 varchar(500) = null,
	@sa2 varchar(500) = null,
	@sq3 varchar(500) = null,
	@sa3 varchar(500) = null,
	@newPasswordSafeId int = null out
)
as
begin
	if(@passwordSafeId is null or @passwordSafeId = 0)
		begin
			insert into PasswordSafe (ServiceName, Username, [Password], ServiceType, SQ1, SA1, SQ2, SA2, SQ3, SA3)
			values(@serviceName, @username, @password, @serviceType, @sq1, @sa1, @sq2, @sa2, @sq3, @sa3)

			set @newPasswordSafeId = SCOPE_IDENTITY()
		end
	else
		begin 
			update PasswordSafe set 
				ServiceName = @serviceName,
				Username = @username,
				[Password] = @password,
				ServiceType = @serviceType,
				SQ1 = @sq1,
				SA1 = sa1,
				SQ2 = @sq2,
				SA2 = sa2,
				SQ3 = SQ3,
				SA3 = sa3
			where PasswordSafeId = @passwordSafeId
		end
end
go


