use db_SMS
go
if object_Id('proc_insertUser') is not null
drop proc proc_insertUser
go
create proc proc_insertUser
(
@UserName varchar (20),
@UserPwd varchar (20),
@UserRight char (10)
)
as
if exists(select * from tb_User where UserName=@UserName)
	begin
	    return 100
	end
else
	begin
	    insert into tb_User(UserName,UserPwd,UserRight) 
	       values(@UserName,@UserPwd,@UserRight)
	end
go