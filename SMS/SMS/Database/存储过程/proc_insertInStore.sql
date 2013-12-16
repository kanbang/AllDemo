use db_SMS
go
if object_Id('proc_insertInStore') is not null
drop proc proc_insertInStore
go
create proc proc_insertInStore
(
@GoodsID bigint,
@GoodsName varchar(50),
@PrName varchar (100),
@StoreName varchar (100),
@GoodsSpec varchar (50),
@GoodsUnit char (8),
@GoodsNum bigint,
@GoodsPrice money,
@HandlePeople varchar (20),
@ISRemark varchar (1000)
)
as
if exists(select * from tb_InStore where GoodsID=@GoodsID)
	begin
	 if exists(select * from tb_InStore where GoodsName=@GoodsName and GoodsSpec=@GoodsSpec)
	   begin
              insert into tb_InStore(GoodsID,GoodsName,PrName,StoreName,
                 GoodsSpec,GoodsUnit,GoodsNum,GoodsPrice,HandlePeople,ISRemark) 
              values(@GoodsID,@GoodsName,@PrName,@StoreName,@GoodsSpec,@GoodsUnit,@GoodsNum,
                 @GoodsPrice,@HandlePeople,@ISRemark)
	   end
	else
	  begin
             return 100
	  end
	end
else
 begin 
    	if exists(select * from tb_InStore where GoodsName=@GoodsName and GoodsSpec=@GoodsSpec)
		begin
                   return 200
		end
	else
		begin
                  insert into tb_InStore(GoodsID,GoodsName,PrName,StoreName,
                    GoodsSpec,GoodsUnit,GoodsNum,GoodsPrice,HandlePeople,ISRemark) 
                  values(@GoodsID,@GoodsName,@PrName,@StoreName,@GoodsSpec,@GoodsUnit,@GoodsNum,
                    @GoodsPrice,@HandlePeople,@ISRemark)
		end
 end
go 