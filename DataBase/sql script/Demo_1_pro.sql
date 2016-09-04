Use [DemoDB]
Go

If(object_id('proc_delete_Menu', 'P') is not null)
Drop procedure proc_delete_Menu
Go

Create procedure proc_delete_Menu
(
	@id nvarchar(64),
	@result nvarchar(32) output
)
As
	declare @childNumber int;
	select @childNumber = COUNT(ID) from tb_SYS_Menu where ParentID = @id;
	delete from tb_SYS_Menu where ID = @id and @childNumber = 0;
	--@result == 0 : ɾ���ɹ�
	--@result > 0 : ɾ��ʧ�ܣ���ֵΪ��������
	select @result = CAST(@childNumber as nvarchar(32));
Go

If(object_id('proc_delete_Role', 'P') is not null)
Drop procedure proc_delete_Role
Go

Create procedure proc_delete_Role
(
	@id nvarchar(64),
	@result nvarchar(32) output
)
As
	declare @childNumber int;
	select @childNumber = COUNT(ID) from tb_SYS_Role where ParentID = @id;
	delete from tb_SYS_Role where ID = @id and @childNumber = 0;
	--@result == 0 : ɾ���ɹ�
	--@result > 0 : ɾ��ʧ�ܣ���ֵΪ��������
	select @result = CAST(@childNumber as nvarchar(32));
Go

Create procedure proc_IsNesting
(
	@location nvarchar(64),
	@materialNO nvarchar(64),
	@result int out
)
As
	--�ݹ��ѯ@location�����Ƚڵ�
	With CTE
	As
	(
		Select t1.ParentNO
		from tb_JC_BOMSub t1
		where t1.MaterialNO = @location
		union all
		select t1.ParentNO
		from tb_JC_BOMSub t1,CTE
		where t1.MaterialNO = CTE.ParentNO
	)
	--�ж��Ƿ����ֵΪ@materialNO�Ľڵ㣬��������򷵻�ֵΪ1��������Լ��ٲ���Ҫ���������ģ�
	select top 1 * 
	from CTE
	where CTE.ParentNO = @materialNO
	set @result = @@ROWCOUNT
Go
--BOM����
Create procedure [proc_search_BOM]
(
	@materialNO nvarchar(64)
)
As
begin
	--�ݹ����
	with CTE
	as
	(
		select MaterialNO,ParentNO,[Level]=1
		from tb_JC_BOMSub
		where ParentNO = @materialNO
		union all
		select	t.MaterialNO,t.ParentNO,[Level]=CTE.[Level]+1
		from tb_JC_BOMSub as t,CTE
		where t.ParentNO = CTE.MaterialNO
	)
	select *,t.MaterialName,t1.MaterialName as ParentName from CTE 
	left join tb_JC_Material_B as t on CTE.MaterialNO=t.MaterialNO 
	left join tb_JC_Material_B as t1 on CTE.ParentNO=t1.MaterialNO 
	order by [Level]
end
--BOM����
Create procedure proc_reverseSearch_BOM
(
	@reverseLevel int,--���鼶��
	@materialNO nvarchar(64) --��λ������
)
As
	--�����鼶��Ϊ0ʱ��Ĭ�Ϸ��ز���Ʒ�����
	if @reverseLevel = 0
	begin
		with CTE
			as
			(
				select t1.ParentNO
				from vw_JC_BOMSub t1
				where t1.MaterialNO = @materialNO
				union all
				select t1.ParentNO
				from vw_JC_BOMSub t1 join CTE
				on t1.MaterialNO = CTE.ParentNO
			)
		select distinct t1.*,t2.PropertyName
		from CTE
	 	inner join tb_JC_Material_B t1
		on t1.MaterialNO = CTE.ParentNO and t1.Property = 'A'
		left join tb_JC_MaterialProperty t2
		on t1.Property = t2.PropertyNO
	end
	else
	begin
		with CTE
			as
			(
				select t1.ParentNO,reverseLevel = 1
				from vw_JC_BOMSub t1
				where t1.MaterialNO = @materialNO
				union all
				select t1.ParentNO,reverseLevel = CTE.reverseLevel + 1
				from vw_JC_BOMSub t1 join CTE
				on t1.MaterialNO = CTE.ParentNO
			)
		select t1.*,t2.PropertyName
		from CTE,tb_JC_Material_B t1,tb_JC_MaterialProperty t2 
		where CTE.reverseLevel = @reverseLevel and t1.MaterialNO = CTE.ParentNO and t1.Property = t2.PropertyNO
	end
Go

--���ݿ��ҳ
Create procedure proc_dataPage_Common
(
	@tableName nvarchar(64),	--����
	@fields nvarchar(1024),	--�ֶ���
	@sqlWhere nvarchar(1024),	--�������
	@order nvarchar(1024),	--�����ֶ�(�ɶ��ֶ�����,����ƴ������ʽ)
	@pageSize int,	--ÿҳ�ļ�¼��
	@pageIndex int,	--��ǰҳ����,��0��ʼ
	@totalRecord bigint output	--�����ܼ�¼��
)
As
begin
	declare @sql nvarchar(max)
	declare @totalPage int

	--�����ܼ�¼��
	set @sql = N'select @totalRecord = count(*) from ' + @tableName + N' where ' + @sqlWhere
	exec sp_executesql @sql,N'@totalRecord bigint output',@totalRecord output

	--������ҳ��
	set @totalPage = CEILING((@totalRecord*1.0)/@PageSize) --CEILING:����ȡ��

	--����ҳ�볬����Χ���쳣
	if @pageIndex < 0
		set @pageIndex = 0
	if (@pageIndex > @totalPage)
		set @pageIndex = @totalPage

	--��ȡ��¼��ʹ��MSSQL2012���ṩ��OFFSET FETCH�﷨��
	declare @offset bigint
	set @offset = @pageIndex*@pageSize
	set @sql = N'select ' + @fields + N' from ' + @tableName + N' where ' + @sqlWhere
	set @sql = @sql + N' order by ' + @order + N' offset ' + convert(nvarchar(32),@offset) + N' rows fetch next ' + convert(nvarchar(32),@pageSize) + N' rows only'
	exec sp_executesql @sql
end
--��ȡĳ�������ڹ������ĵ�ʣ�������͵�λ����
Create procedure [dbo].[proc_getFreeCapacity_Hour]
(
	@materialNO nvarchar(64),			--���ϱ��
	@date datetime,						--����
	@workCenterNO nvarchar(64) output,	--�������ı��
	@freeCapacity decimal(18,2) output,	--��������
	@unitCapacity decimal(18,2) output	--�������ϵĵ�λ����
)
As
begin
	declare @tempNO nvarchar(64)
	declare @amount int

	select @tempNO = t.ProcessRouteNO from tb_JC_Material_P as t where t.MaterialNO = @materialNO
	select @amount = t.ProcedureAmount,@tempNO = t.ID from tb_JC_Routing as t where t.RoutingNO = @tempNO
	--�˴����蹤������1��ʼ��������BOM�������ϲ�����һ������·��
	select @tempNO = t.ProcedureNO from tb_JC_RoutingSub as t where t.RoutingID = @tempNO and t.ProcedureOrder = @amount
	--�˴����蹤���빤������Ϊһ��һ�Ĺ�ϵ
	select @tempNO = t.WorkCenterNO from tb_JC_Procedure as t where t.ProcedureNO = @tempNO
	select @freeCapacity = t.StandardCapacity from tb_JC_WorkCenter as t where t.WorkCenterNO = @tempNO
	select @unitCapacity = t.UnitCapacity from tb_JC_WorkCenterCapacity as t where t.WorkCenterNO = @tempNO and t.MaterialNO = @materialNO
	select @freeCapacity = (@freeCapacity - t.OccupiedCapacity) from tb_JC_WorkCenterLoad as t where t.WorkCenterNO = @tempNO and t.Date = @date

	if @@ROWCOUNT <= 0
	begin
		exec proc_insertCapacity @tempNO,@date,@materialNO
	end

	set @workCenterNO = @tempNO 
end
GO
--�´�MPS
Create procedure proc_down_MPS
(
	@ID nvarchar(64),		--�ƻ���Դ����ID
	@result int output		--���н��
)
As
begin
	declare @materialNO nvarchar(64)
	declare @planAmount decimal(18,2)
	declare @downAmount decimal(18,2)
	declare @planDate datetime
	declare @number int
	declare @billType nvarchar(1)

	select @planDate = t1.EndDate,@billType=BillType,@materialNO=t1.MaterialNO,@planAmount=t1.PlanAmount,@downAmount=t1.DownAmount from tb_JH_PlannedSource as t1 where t1.ID = @ID
	
	begin tran		--��������ʼ
	if(@billType = 'R')
	begin
		exec proc_dateMinus @planDate,0,@planDate output
		insert into tb_JH_MPS values(NEWID(),NULL,@ID,@materialNO,@planAmount,0.00,@planDate,'N')
		update tb_JH_PlannedSource set DownAmount = @planAmount,[Status] = 'B' where ID=@ID
	end
	else
	begin
		select @number = COUNT(*) from tb_JH_PlannedSource as t1 where t1.EndDate < @planDate and t1.[Status] = 'C'
		if(@number > 0)
		begin
			set @result = 1	--1�Ŵ���:�´ﵥ�ݵ���������֮ǰ������δ�´�ĵ���
		end
		else
		begin
			declare @totalAmount decimal(18,2)	--MPS������
			declare @down decimal(18,2)	--�´���
			declare @date datetime	--ʱ��ָ��

			set @totalAmount = @planAmount - @downAmount
			exec proc_dateMinus @planDate,0,@date output

			--MPSѭ��
			while(1 = 1)
			begin
				if @date <= GETDATE()
				begin
					set @result = 3	--3�Ŵ����޷���ɷֽ�
					break
				end
				declare @freeCapacity decimal(18,2),@unitCapacity decimal(18,2),@occupiedCapacity decimal(18,2)
				declare @workCenterNO nvarchar(64)
				--���㵱�칤�����Ŀ�������������
				exec proc_getFreeCapacity_Hour @materialNO,@date,@workCenterNO output,@freeCapacity output,@unitCapacity output
				set @down = @freeCapacity/@unitCapacity
				--�������Ϊ0,ʱ����ǰ����
				if(@down = 0.0)
				begin
					exec proc_dateMinus @date,1,@date output
					continue
				end
				--�����������ʣ��ļƻ���,�´���˳�ѭ��
				else if(@down >= @totalAmount)
				begin
					insert into tb_JH_MPS values(NEWID(),NULL,@ID,@materialNO,@totalAmount,0,@date,'N')
					set @occupiedCapacity = @unitCapacity*@totalAmount
					exec proc_updateCapacity @materialNO,@workCenterNO,@date,@occupiedCapacity,@date output
					break
				end
				else
				begin
					insert into tb_JH_MPS values(NEWID(),NULL,@ID,@materialNO,@down,0,@date,'N')
					set @occupiedCapacity = @unitCapacity*@down
					exec proc_updateCapacity @materialNO,@workCenterNO,@date,@occupiedCapacity,@date output
					set @totalAmount = @totalAmount - @down
				end
			end
			update tb_JH_PlannedSource set DownAmount = @planAmount,[Status] = 'B' where ID=@ID
		end
	end

	if @@ERROR > 0
	begin
		rollback tran	--�ع�����
		set @result = 2	--2�Ŵ��󣬳���δ֪����
	end
	else if @result = 3
	begin
		rollback tran
		set @result = 3	--3�Ŵ����޷���ɷֽ�
	end
	else
	begin
		commit tran		--�ύ����
		set @result = 0	--0����Ϣ���ɹ�
	end	
end
Go
--MRP�ֽ�
Create procedure [dbo].[proc_resolve_MRP]
(
	@ID nvarchar(64),
	@result int output
)
As
begin
	declare @materialNO nvarchar(64)
	declare @planAmount decimal(18,2)
	declare @needAmount decimal(18,2)
	declare @planDate datetime
	declare @rowsnumber int
	declare @row int
	declare @MRPID nvarchar(64)
	create table #tmpMRP
	(
		ID nvarchar(64) not null primary key,
		Mark nvarchar(max) not null
	)

	select @materialNO=t.MaterialNO,@planAmount=t.PlanAmount,@planDate=t.EndDate from tb_JH_MPS as t where t.ID = @ID and t.Status = 'N'
	if @@ROWCOUNT <= 0
	begin
		set @result = 1; --1�Ŵ���MPS���ݲ����ڻ򲻺Ϸ�
		return
	end

	select * from tb_JH_MPS as t where t.EndDate < @planDate and t.Status = 'N'
	if @@ROWCOUNT > 0
	begin
		set @result = 2; --2�Ŵ��󣬴���������ǰ��ȴδ�ֽ��MPS����
		return
	end

	begin tran		--��������ʼ

	--������ڵ�����
	exec proc_dateMinus @planDate,0,@planDate output
	set @needAmount = dbo.func_NeedQuantity(@planAmount,@materialNO,@planDate)
	set @MRPID = NEWID()
	insert into tb_JH_MRP values(@MRPID,NULL,@ID,@materialNO,@needAmount,@planDate,'N')
	insert into #tmpMRP values(@MRPID,@materialNO)
	exec proc_update_StockInformation @materialNO,@planDate,@needAmount;

	--BOM����
	with CTE
	As
	(
		select t.MaterialNO,t.MaterialType,t.ParentNO,t.Amount,[Level] = 1,t2.FixedLeadTime,t2.VariableLeadTime,t2.VariableBatch,t.LeadTimeOffset,Mark=cast(t.ParentNO as nvarchar(max))
		from tb_JC_BOMSub as t,tb_JC_Material_B as t2
		where t.ParentNO = @materialNO and t.ParentNO = t2.MaterialNO

		union all
		select t1.MaterialNO,t1.MaterialType,t1.ParentNO,t1.Amount,[Level] = CTE.[Level] + 1,t3.FixedLeadTime,t3.VariableLeadTime,t3.VariableBatch,t1.LeadTimeOffset,Mark=CTE.mark+cast(t1.ParentNO as nvarchar(max))
		from tb_JC_BOMSub as t1,CTE,tb_JC_Material_B as t3
		where t1.ParentNO = CTE.MaterialNO and t1.ParentNO = t3.MaterialNO
	)
	select CTE.* into #temp from CTE order by CTE.Mark
	set @rowsnumber = @@ROWCOUNT
	set @row = 1

	declare @material nvarchar(64),@parent nvarchar(64)
	declare @materialType nvarchar(1)
	declare @multiple decimal(18,2)
	declare @level int
	declare @fixedTime decimal(18,2),@variableTime decimal(18,2),@variableBatch decimal(18,2),@offsetTime decimal(18,2)
	declare @offsetDays decimal(18,2)
	declare @parentAmount decimal(18,2)
	declare @date datetime
	declare @mark nvarchar(max)
	declare @sql nvarchar(max)
	declare @planBillType nvarchar(1)
	
	select @planBillType=BillType from tb_JH_PlannedSource where ID = (select PlannedSourceID from tb_JH_MPS where ID = @ID)

	--MRP��ѭ��
	while(@row <= @rowsnumber)
	begin
		set @sql = N'select @material=MaterialNO,@materialType=MaterialType,@parent=ParentNO,'
					+ N'@multiple=Amount,@level=Level,@fixedTime=FixedLeadTime,@variableTime=VariableLeadTime,@variableBatch=VariableBatch,@offsetTime=LeadTimeOffset,@mark=Mark '
					+ N'from #temp order by [Level] offset ' + convert(nvarchar(32),(@row-1)) + N' rows fetch next 1 row only'

		exec sp_executesql @sql,N'@material nvarchar(64) output,@materialType nvarchar(1) output,@parent nvarchar(64) output,
								@multiple decimal(18,2) output,@level int output,@fixedTime decimal(18,2) output,
								@variableTime decimal(18,2) output,@variableBatch decimal(18,2) output,@offsetTime decimal(18,2) output,@mark nvarchar(max) output',
								@material output,@materialType output,@parent output,@multiple output,
								@level output,@fixedTime output,@variableTime output,@variableBatch output,@offsetTime output,@mark output
		--��ȡ����������������������
		select @parentAmount=NeedAmount,@date=��eedDate from tb_JH_MRP where ID = (select ID from #tmpMRP where Mark = @mark)

		--������������������
		if(@planBillType != 'R')
		begin
			--����ƫ������
			set @offsetDays = @fixedTime + @parentAmount / @variableBatch * @variableTime - @offsetTime
			exec proc_dateMinus @date,@offsetDays,@date output
		end
		
		--����������������
		set @needAmount = dbo.func_NeedQuantity(@parentAmount*@multiple,@material,@date)

		set @MRPID = NEWID()
		insert into tb_JH_MRP values(@MRPID,NULL,@ID,@material,@needAmount,@date,'N')
		insert into #tmpMRP values(@MRPID,@mark + @material)

		exec proc_update_StockInformation @material,@date,@needAmount

		set @row = @row + 1
	end
	update tb_JH_MPS set ResolveAmount = @planAmount,[Status] = 'Y' where ID=@ID
	select [Status] from tb_JH_MPS where PlannedSourceID = (select PlannedSourceID from tb_JH_MPS where ID=@ID) and [Status] = 'N'
	if @@ROWCOUNT = 0
		update tb_JH_PlannedSource set [Status] = 'R' where ID = (select PlannedSourceID from tb_JH_MPS where ID=@ID)

	if @@ERROR > 0
	begin
		rollback tran	--�ع�����
		set @result = 3		--3�Ŵ��󣬷ֽ�ʧ��
	end
	else
	begin
		commit tran		--�ύ����
		set @result = 0		--0������������ɹ�
	end
end

--���ɹ�������
Create procedure proc_generateCalendar
(
	@start datetime
)
As
begin
	declare @i int,@j int
	declare @end datetime

	set @end = DATEADD(yy,1,@start)
	set @j = DATEDIFF(day,@start,@end)
	set @i = 0

	--ɾ��ԭ��������
	truncate table tb_JC_WorkCalendar

	--����һ�������
	while(@i < @j)
	begin
		insert into tb_JC_WorkCalendar([Date]) values(@start+@i)
		set @i = @i + 1
	end

	--ɾ�����������
	declare @type nvarchar(1),@time nvarchar(16),@sql nvarchar(max)
	select @j = Count(*) from tb_JC_WorkCalendarRule
	set @i = 0
	while(@i < @j)
	begin
		set @sql = N'select @type=ExceptionType,@time=ExceptionTime from tb_JC_WorkCalendarRule order by ExceptionType offset ' + convert(nvarchar(32),@i) + N' rows fetch next 1 row only'
		exec sp_executesql @sql,N'@type nvarchar(1) output,@time nvarchar(16) output',@type output,@time output
		if(@type = 'M')
			delete from tb_JC_WorkCalendar where MONTH([Date]) = @time
		if(@type = 'D')
			delete from tb_JC_WorkCalendar where (convert(nvarchar(16),datepart(month,[Date])) + '-' + convert(nvarchar(16),datepart(day,[Date]))) = @time
		if(@type = 'W')
			delete from tb_JC_WorkCalendar where Datepart(weekday, [Date] + @@DateFirst - 1) = @time
		set @i = @i + 1
	end
end
--���㹤������
Create procedure [dbo].[proc_dateMinus]
(
	@date datetime,			--��������
	@number int,			--��ȥ������
	@result datetime output --������
)
As
begin
	declare @sql nvarchar(max)

	set @sql = N'select @result = [Date] from tb_JC_WorkCalendar where [Date]<=@date order by [Date] desc offset ' + CONVERT(nvarchar(32),@number)
				+ N' rows fetch next 1 row only'
	exec sp_executesql @sql,N'@result datetime output,@date datetime',@result output,@date
end
GO
Create procedure [dbo].[proc_dateAdd]
(
	@date datetime,			--��������
	@number int,			--���ӵ�����
	@result datetime output --������
)
As
begin
	declare @sql nvarchar(max)

	set @sql = N'select @result = [Date] from tb_JC_WorkCalendar where [Date]>=@date order by [Date] asc offset ' + CONVERT(nvarchar(32),@number)
				+ N' rows fetch next 1 row only'
	exec sp_executesql @sql,N'@result datetime output,@date datetime',@result output,@date
end
GO
--�����������ݣ���ʼ��Ϊ0
Create procedure [dbo].[proc_insertCapacity]
(
	@workCenterNO nvarchar(64),		--�������ı��
	@date datetime,					--����
	@materialNO nvarchar(64)		--���ϱ��
)
As
begin
	declare @operation nvarchar(1)
	declare @days int
	declare @i int

	--��ȡ�����ϵ������������
	set @days = dbo.func_TotalLeadTime(@materialNO,dbo.func_MaxCapacity_Amount(@materialNO))
	set @i = 1
	set @operation = '-'

	begin tran
		declare @groupID nvarchar(64)
		set @groupID = NEWID()
		--�Ȳ���һ�����ݣ�Ȼ������ǰ�ơ������ǰ�������������Ѵ��ڣ����ں��ơ��ܹ�����@days�����ݺ�����ù��̡�
		insert into tb_JC_WorkCenterLoad values(NEWID(),@workCenterNO,0.00,0.00,@date,@groupID);
		exec proc_dateMinus @date,1,@date output
		while(@i < @days)
		begin
			select * from tb_JC_WorkCenterLoad where WorkCenterNO=@workCenterNO and [Date] = @date
			if @@ROWCOUNT <= 0
			begin
				insert into tb_JC_WorkCenterLoad values(NEWID(),@workCenterNO,0.00,0.00,@date,@groupID)
				if @operation = '-'
					exec proc_dateMinus @date,1,@date output
				else
					exec proc_dateAdd @date,1,@date output
				set @i = @i + 1
			end
			else
			begin
				set @operation = '+'
				set @i = @i + 1
				exec proc_dateAdd @date,@i,@date output
				set @i = @i - 1
			end			
		end
	if @@error <> 0
		rollback tran
	else
		commit tran
end
Go
--������������
Create procedure proc_updateCapacity
(
	@materialNO nvarchar(64),			--���ϱ��
	@workCenterNO nvarchar(64),			--�������ı��
	@date datetime,						--����
	@occupiedCapacity decimal(18,2),	--ռ������
	@nextDate datetime output			--�����һ������
)
As
begin
	declare @tmp decimal(18,2)
	declare @standCapacity decimal(18,2)

	select @standCapacity=StandardCapacity from tb_JC_WorkCenter where WorkCenterNO = @workCenterNO

	select ID,[Date] into #tmp from tb_JC_WorkCenterLoad
	where WorkCenterNO = @workCenterNO and GroupID = 
	(select GroupID from tb_JC_WorkCenterLoad where WorkCenterNO = @workCenterNO and [Date] = @date)

	update tb_JC_WorkCenterLoad set OccupiedCapacity = OccupiedCapacity+@occupiedCapacity,[Load] = (OccupiedCapacity+@occupiedCapacity) / @standCapacity
	where ID in (select ID from #tmp)

	select @nextDate = [Date] from #tmp order by [Date] asc offset 0 row fetch next 1 row only
	exec proc_dateMinus @nextDate,1,@nextDate output
end
Go
--��ȡĳ������ĳһ��ľ�������
Create procedure proc_netAmount
(
	@materialNO nvarchar(64),
	@requireDate datetime,
	@grossAmount decimal(18,2),
	@netAmount decimal(18,2) output
)
As
begin
	--α������̣��д�����2016/05/21
	--��ȡ����е����п�������ʡ���˼������
	declare @existingAmount decimal(18,2)
	select @existingAmount = StockQuantity from tb_JH_StockInformation where MaterialNO=@materialNO and [Date] = @requireDate

	--���㾻����
	if @@ROWCOUNT <= 0
		set @netAmount = @grossAmount
	else
		set @netAmount = @grossAmount - @existingAmount
end
Create procedure proc_insert_MPS
(
	@ID nvarchar(64),
	@planNO nvarchar(64),
	@plannedSourceID nvarchar(64),
	@materialNO nvarchar(64),
	@planAmount decimal(18,2),
	@date datetime,
	@result int output
)
As
begin
	declare @workCenterNO nvarchar(64)
	declare @freeCapacity decimal(18,2)
	declare @unitCapacity decimal(18,2)
	declare @occupiedCapacity decimal(18,2)

	begin tran

	exec proc_getFreeCapacity_Hour @materialNO,@date,@workCenterNO output,@freeCapacity output,@unitCapacity output
	if (@freeCapacity/@unitCapacity) < @planAmount
	begin
		rollback tran
		set @result = 1		--1�Ŵ�����������
	end
	else
	begin
		declare @returnDate datetime
		set @occupiedCapacity = @unitCapacity * @planAmount
		exec proc_updateCapacity @materialNO,@workCenterNO,@date,@occupiedCapacity,@returnDate output
		if @returnDate < GETDATE()
		begin
			rollback tran
			set @result = 2		--2�Ŵ��󣬷ֽ�����
		end
		else
		begin
			insert into tb_JH_MPS values(@ID,@planNO,@plannedSourceID,@materialNO,@planAmount,0.00,@date,'N')
			declare @totalAmount decimal(18,2),@downAmount decimal(18,2)
			select @totalAmount = PlanAmount,@downAmount = DownAmount from tb_JH_PlannedSource where ID = @plannedSourceID
			if @totalAmount = @downAmount + @planAmount
				update tb_JH_PlannedSource set DownAmount = DownAmount + @planAmount,[Status] = 'Y' where ID = @plannedSourceID
			else
				update tb_JH_PlannedSource set DownAmount = DownAmount + @planAmount where ID = @plannedSourceID 
			commit tran
			set @result = 0		--0����Ϣ���ɹ�
		end
	end
end
Go

Create procedure proc_update_MPS
(
	@ID nvarchar(64),
	@planNO nvarchar(64)
)
As
begin
	update tb_JH_MPS set PlanNO = @planNO where ID = @ID
end
Go

Create procedure proc_decreaseCapacity
(
	@workCenterNO nvarchar(64),
	@materialNO nvarchar(64),
	@decreaseAmount decimal(18,2),
	@date datetime
)
As
begin
	declare @standCapacity decimal(18,2),@unitCapacity decimal(18,2)
	select @standCapacity = StandardCapacity from tb_JC_WorkCenter where WorkCenterNO = @workCenterNO
	select @unitCapacity = UnitCapacity from tb_JC_WorkCenterCapacity where WorkCenterNO = @workCenterNO and MaterialNO = @materialNO
	update tb_JC_WorkCenterLoad set OccupiedCapacity = OccupiedCapacity - @decreaseAmount*@unitCapacity,
									[Load] = (OccupiedCapacity - @decreaseAmount*@unitCapacity) / @standCapacity
	where WorkCenterNO = @workCenterNO and GroupID = 
	(select GroupID from tb_JC_WorkCenterLoad where WorkCenterNO=@workCenterNO and [Date] = @date)
end
Go

Create procedure proc_delete_MPS
(
	@ID nvarchar(64),
	@materialNO nvarchar(64)
)
As
begin
	begin tran
		declare @amount decimal(18,2),@date datetime
		declare @workCenterNO nvarchar(64),@tmp decimal(18,2),@plannedSourceID nvarchar(64)
		select @plannedSourceID=PlannedSourceID,@amount = PlanAmount,@date = EndDate from tb_JH_MPS where ID = @ID
		exec proc_getFreeCapacity_Hour @materialNO,@date,@workCenterNO output,@tmp output,@tmp output
		exec proc_decreaseCapacity @workCenterNO,@materialNO,@amount,@date
		update tb_JH_PlannedSource set DownAmount = DownAmount-@amount,[Status] = (case when(@amount = 0.00)then [Status] else 'N' end)
		where ID=@plannedSourceID
		delete from tb_JH_MPS where ID = @ID
	if @@ERROR <> 0
		rollback tran
	else
		commit tran
end
Go

Create procedure proc_update_StockInformation
(
	@materialNO nvarchar(64),
	@date datetime,
	@amount decimal(18,2)
)
As
begin
	declare @stockQuantity decimal(18,2)

	select @stockQuantity=StockQuantity from tb_JH_StockInformation where MaterialNO=@materialNO and [Date]=@date

	if @stockQuantity > @amount
		set @stockQuantity = @stockQuantity - @amount
	else
		set @stockQuantity = 0

	update tb_JH_StockInformation set StockQuantity = @stockQuantity where MaterialNO=@materialNO and [Date]=@date
end
Go

Create procedure [dbo].[proc_assignPlan]
(
	@SourceID nvarchar(64),
	@result int output
)
As
begin
	declare @MRPID nvarchar(64),@materialNO nvarchar(64),@amount decimal(18,2),@date datetime
	declare @count int,@i int,@sql nvarchar(max)
	select * into #tmp from tb_JH_MRP where MPSID in (select ID from tb_JH_MPS where PlannedSourceID = @SourceID)
	set @count = @@ROWCOUNT
	set @i = 0

	begin tran
		while(@i < @count)
		begin
			set @sql = N'select @MRPID=ID,@materialNO=MaterialNO,@amount=NeedAmount,@date=NeedDate from #tmp order by NeedDate offset '+convert(nvarchar(32),@i)+' rows fetch next 1 row only'
			exec sp_executesql @sql,N'@MRPID nvarchar(64) output,@materialNO nvarchar(64) output,@amount decimal(18,2) output,@date datetime output',
									@MRPID output,@materialNO output,@amount output,@date output
		
			declare @property nvarchar(1),@billType nvarchar(1),@totalLeadTime decimal(18,2)
			select @property=Property from tb_JC_Material_B where MaterialNO = @materialNO

			if(@property = 'P') set @billType = 'P'			--�ɹ���
			else if(@property = 'O') set @billType = 'O'	--ί�ⵥ
			else set @billType = 'A'						--������

			set @totalLeadTime = dbo.func_TotalLeadTime(@materialNO,@amount)
			exec proc_dateMinus @date,@totalLeadTime,@date output		--��ν������͵�����ת��Ϊ��������

			insert into tb_JH_Task values(NEWID(),@SourceID,@MRPID,@billType,NULL,@date,@amount,0.00,'N')
			update tb_JH_MRP set [Status] = 'Y' where ID = @MRPID

			set @i = @i + 1
		end
		update tb_JH_PlannedSource set [Status] = 'A' where ID = @SourceID
	if @@ERROR <> 0
	begin
		rollback tran
		set @result = 1		--1����Ϣ��δ֪����
	end
	else
	begin
		commit tran
		set @result = 0		--0����Ϣ���ɹ�
	end
end
GO
