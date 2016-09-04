--2016年1月28日 抛弃该方案
--Create trigger tri_insert_SetState
--On tb_SYS_Menu
--For insert
--As
--	declare @id nvarchar(64);
--	select @id=ParentID from inserted;
--	update tb_SYS_Menu set State = '2' where ID = @id and ID != '0';
--Go

--Create trigger tri_update_SetState
--On tb_SYS_Menu
--For update
--As
--	declare @id nvarchar(64);
--	select @id=ParentID from inserted;
--	update tb_SYS_Menu set State = '2' where ID = @id and ID != '0';
--Go

--Create trigger tri_delete_SetState
--On tb_SYS_Menu
--For delete
--As
--	declare @id nvarchar(64),@childNumber int;
--	select @id=ParentID from deleted;
--	select @childNumber = COUNT(ID) from tb_SYS_Menu where ParentID = @id;
--	update tb_SYS_Menu set State = '1' where (ID = @id) and (@childNumber = 0) and (ID != '0');
--Go

--2016年2月2日 创建
Use [DemoDB]
Go
Create trigger tri_update_ChangeMenuNO
On tb_SYS_Menu
For update
As
	declare @id nvarchar(64), @parentNO int;
	select @id=ID, @parentNO=CAST(MenuNO as int) from inserted;
	update tb_SYS_Menu set MenuNO = CAST(@parentNO+1 as nvarchar) where ParentID = @id;
Go