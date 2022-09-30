
Use BookStoreDB

Create Table AdminInfo(
AdminId int Identity Primary Key,
AdminName varchar(200) Not Null,
AdminEmail varchar(100) Unique Not Null,
AdminPassword varchar(100) Not Null,
AdminMobile bigint Not Null
)
Insert Into AdminInfo
Values ('Abhishek Jadhav', 'radigitaldistribution@gmail.com', 'abhi1999', 9307631362)

Select * From AdminInfo;

-------- Stored Procedure For Admin Login --------
Create Procedure spAdminLogin
(
@AdminEmail varchar(100),
@AdminPassword varchar(100)
)
As
Begin
	Select * From AdminInfo Where AdminEmail = @AdminEmail And AdminPassword = @AdminPassword;
End