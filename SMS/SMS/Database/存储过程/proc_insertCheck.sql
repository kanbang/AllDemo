use db_SMS
go
if object_Id('proc_insertCheck') is not null
drop proc proc_insertCheck
go
create proc proc_insertCheck
(
@GoodsID bigint,
@StoreName varchar(100),
@GoodsName varchar (50),
@GoodsUnit char (8),
@CheckNum bigint,
@PALNum bigint,
@CheckPeople varchar (20),
@CheckRemark varchar (1000)
)
as
if exists(select * from tb_Check where GoodsID=@GoodsID)
	begin
           return 100
	end
else
	begin
           insert into tb_Check(GoodsID,StoreName,GoodsName,GoodsUnit,CheckNum,PALNum,CheckPeople,CheckRemark) 
             values(@GoodsID,@StoreName,@GoodsName,@GoodsUnit,@CheckNum,@PALNum,@CheckPeople,@CheckRemark)
	end
go