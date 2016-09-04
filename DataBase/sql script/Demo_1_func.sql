Create function func_getBOM()
Returns table
As
Return
(
	with bom
	as
	(
		select t1.ID,t1.ParentNO,t1.MaterialNO,t1.MaterialType,t1.Amount,[Level]=1,Mark=cast(t1.MaterialNO as nvarchar(max)),t1.LeadTimeOffset,t1.BackFlush
		from tb_JC_BOMSub t1
		where t1.ParentNO in (select t1.MaterialNO from tb_JC_BOM t1 where t1.MaterialType = 'A')
		union all
		select t1.ID,t1.ParentNO,t1.MaterialNO,t1.MaterialType,t1.Amount,[Level]=bom.level+1,Mark=bom.mark+cast(t1.MaterialNO as nvarchar(max)),t1.LeadTimeOffset,t1.BackFlush
		from tb_JC_BOMSub t1,bom
		where t1.ParentNO = bom.MaterialNO
	)
	select * from bom
)
Go

--计算工作中心关于某物料的最大产量
Create function func_MaxCapacity_Amount
(
	@materialNO nvarchar(64)
)
Returns decimal(18,2)
begin
	declare @tmp nvarchar(64)
	declare @totalCapacity decimal(18,2)
	declare @unitCapacity decimal(18,2)
	declare @result decimal(18,2)

	select @tmp = ProcessRouteNO from tb_JC_Material_P where MaterialNO = @materialNO
	select @tmp = ID from tb_JC_Routing where RoutingNO = @tmp
	select top 1 @tmp = ProcedureNO from tb_JC_RoutingSub where RoutingID = @tmp order by ProcedureOrder desc
	select @tmp = WorkCenterNO from tb_JC_Procedure where ProcedureNO = @tmp
	select @totalCapacity = StandardCapacity from tb_JC_WorkCenter where WorkCenterNO = @tmp
	select @unitCapacity = UnitCapacity from tb_JC_WorkCenterCapacity where WorkCenterNO = @tmp and MaterialNO = @materialNO

	set @result = CEILING(@totalCapacity / @unitCapacity)		--设计基础数据时，应当保证该值为整数
	if @@ERROR <> 0
		set @result = -1
	return @result
end

--计算总提前期
Create function func_TotalLeadTime
(
	@materialNO nvarchar(64),
	@Amount decimal(18,2)
)
Returns decimal(18,2)
begin
	declare @fixedLeadTime decimal(18,2)
	declare @variableLeadTime decimal(18,2)
	declare @variableBatch decimal(18,2)
	declare @result decimal(18,2)

	select @fixedLeadTime=FixedLeadTime,@variableLeadTime=VariableLeadTime,@variableBatch=VariableBatch 
	from tb_JC_Material_B where MaterialNO = @materialNO

	if @@ROWCOUNT <= 0
		set @result = 0
	else
		set @result = @fixedLeadTime + @Amount / @variableBatch * @variableLeadTime

	return @result
end

--计算物料需求量
Create function func_NeedQuantity
(
	@Amount decimal(18,2),
	@materialNO nvarchar(64),
	@date datetime
)
Returns decimal(18,2)
Begin
	declare @stockQuantity decimal(18,2),@needQuantity decimal(18,2)
	select @stockQuantity=StockQuantity from tb_JH_StockInformation where MaterialNO=@materialNO and [Date]=@date
	if @@ROWCOUNT <= 0
		set @stockQuantity = 0.00
	if @Amount > @stockQuantity
		set @needQuantity = @Amount - @stockQuantity
	else
		set @needQuantity = 0
	
	return @needQuantity
End