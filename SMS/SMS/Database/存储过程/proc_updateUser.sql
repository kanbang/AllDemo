if object_Id('proc_updateUser') is not null
drop proc proc_updateUser
go
create proc proc_updateUser
(
@UserID bigint,
@UserPwd varchar (20),
@UserRight char (10)
)
as
update tb_User set UserPwd=@UserPwd,UserRight=@UserRight where UserID=@UserID
go
