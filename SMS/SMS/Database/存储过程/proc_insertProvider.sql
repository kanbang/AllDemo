use db_SMS
go
if object_Id('proc_insertProvider') is not null
drop proc proc_insertProvider
go
create proc proc_insertProvider
(
@PrName varchar (100),
@PrPeople varchar (20),
@PrPhone varchar (20),
@PrFax varchar (20),
@PrRemark varchar (1000)
)
as
if exists(select * from tb_Provider where PrName=@PrName)
	begin
	    return 100
	end
else
	begin
	    insert into tb_Provider(PrName,PrPeople,PrPhone,PrFax,PrRemark) 
	       values(@PrName,@PrPeople,@PrPhone,@PrFax,@PrRemark)
	end
go 