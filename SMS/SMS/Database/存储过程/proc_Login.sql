use db_SMS
go
if object_id('proc_Login') is not null
drop proc proc_Login
go
create proc proc_Login
(
@UserName varchar (20),
@UserPwd varchar (20)
)
as
if exists(select * from tb_User where UserName=@UserName and UserPwd=@UserPwd)
   return 100	
else
   return -100
go