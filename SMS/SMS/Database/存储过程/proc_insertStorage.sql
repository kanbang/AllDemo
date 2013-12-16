use db_SMS
go
if object_Id('proc_insertStorage') is not null
drop proc proc_insertStorage
go
create proc proc_insertStorage
(
@StoreName varchar (100),
@StorePeople varchar (20),
@StorePhone varchar (20),
@StoreUnit varchar (100),
@StoreRemark varchar (1000)
)
as
if exists(select * from tb_Storage where StoreName=@StoreName)
	begin
	    return 100
	end
else
	begin
	    insert into tb_Storage(StoreName,StorePeople,StorePhone,StoreUnit,StoreRemark) 
	       values(@StoreName,@StorePeople,@StorePhone,@StoreUnit,@StoreRemark)
	end
go 