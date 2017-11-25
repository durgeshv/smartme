--use SmartMe
--go

drop procedure spSavePasswordSafe
drop procedure spSaveAccount
drop table PasswordSafe
drop table Account
drop table AccountType

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

create table AccountType
(
	AccountTypeId int identity(1,1) not null,
	Name varchar(255) not null,
	constraint PK_AccountType_AccountTypeId primary key(AccountTypeId)
)
go

create table Account
(
	AccountId int identity(1,1) not null,
	AccountName varchar(500) not null,
	AccountNumber varchar(100) not null,
	AccountTypeId int not null,
	RoutingNumberPaperElectronic varchar(50) null,
	RoutingNumberWires varchar(50) null,
	CVV varchar(5),
	PIN varchar(10),
	Email varchar(255),
	[Address] varchar(1000),
	Phone1 varchar(15),
	Phone2 varchar(15),
	constraint PK_Account_AccountId primary key(AccountId),
	constraint FK_Account_AccountTypeId foreign key(AccountTypeId) references AccountType(AccountTypeId)
)
go


/*********************************************************************************************/
create procedure spSavePasswordSafe
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

create procedure spSaveAccount
(
	@accountId int = null,
	@accountName varchar(500),
	@accountNumber varchar(100),
	@accountTypeId int,
	@routingNumberPaperElectronic varchar(50) = null,
	@routingNumberWires varchar(50) = null,
	@cvv varchar(5) = null,
	@pin varchar(10) = null,
	@email varchar(255) = null,
	@address varchar(1000) = null,
	@phone1 varchar(15) = null,
	@phone2 varchar(15) = null,
	@newAccountId int = null out
)
as
	if(@accountId is null)
		begin
			insert into Account(AccountName, AccountNumber, AccountTypeId, RoutingNumberPaperElectronic, RoutingNumberWires, CVV, PIN, Email, [Address], Phone1, Phone2)
			values (@accountName, @accountNumber, @accountTypeId, @routingNumberPaperElectronic, @routingNumberWires, @cvv, @pin, @email, @address, @phone1, @phone2)

			set @newAccountId = SCOPE_IDENTITY()
		end
	else
		begin
			update Account set 
				AccountName = @accountName,
				AccountNumber = @accountNumber,
				AccountTypeId = @accountTypeId,
				RoutingNumberPaperElectronic = @routingNumberPaperElectronic,
				RoutingNumberWires = @routingNumberWires,
				CVV = @cvv,
				PIN = @pin,
				Email = @email,
				[Address] = @address,
				Phone1 = @phone1,
				Phone2 = @phone2
			where AccountId = @accountId
		end
go

