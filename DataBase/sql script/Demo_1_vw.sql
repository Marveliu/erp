Use [DemoDB]
Go

--系统
Create view vw_SYS_Menu
As
Select t1.*,t2.MenuNO as ParentNO,t2.MenuName as ParentName
From tb_SYS_Menu t1 left join tb_SYS_Menu t2
On t1.ParentID = t2.ID
Go

Create view vw_SYS_Role
As
Select t1.*,t2.RoleName as ParentName
From tb_SYS_Role t1 left join tb_SYS_Role t2
On t1.ParentID = t2.ID
Go

Create view [dbo].[vw_SYS_RoleMenu]
As
	select t1.MenuID,t1.RoleID,t2.MenuNO,t2.MenuName,t2.MenuUrl,t3.MenuName as ParentName
	from tb_SYS_RoleMenu t1,tb_SYS_Menu t2,tb_SYS_Menu t3
	where t1.MenuID = t2.ID and t2.ParentID = t3.ID
Go

Create view vw_SYS_Account
As
	select t1.ID,t1.AccountName,t1.[Password],t1.AccountType,t1.RoleID,t2.RoleName,t1.[State],t2.DefaultUrl
	from tb_SYS_Account t1,tb_SYS_Role t2
	where t1.RoleID = t2.ID
Go

--基础数据
Create view vw_JC_BOM
As
(
	select t1.*,t2.MaterialName as ParentName,t3.MaterialName as MaterialName,t3.Unit as Unit
	from func_getBOM() t1,tb_JC_Material_B t2,tb_JC_Material_B t3
	where t2.MaterialNO=t1.ParentNO and t3.MaterialNO=t1.MaterialNO
)
Go

Create view [dbo].[vw_JC_BOMParent]
As
(
	select t1.*,t2.MaterialName as MaterialName,t2.Specification as Specification,t2.Model as Model,t2.Unit as Unit,
				t3.EmployeeName as CheckName,t4.PropertyName as PropertyName
	from tb_JC_BOM t1 left join tb_JC_Material_B t2
	on t1.MaterialNO = t2.MaterialNO
	left join tb_JC_Employee t3
	on t1.CheckNO = t3.EmployeeNO
	left join tb_JC_MaterialProperty t4
	on t1.MaterialType = t4.PropertyNO
)

Create view vw_JC_BOMSub
As
(
	select t1.*,t2.MaterialName as MaterialName,t2.Specification as Specification,t2.Model as Model,
				t2.Unit as Unit,t3.MaterialName as ParentName,t4.PropertyName as PropertyName
	from tb_JC_BOMSub t1
	left join tb_JC_Material_B t2
	on t1.MaterialNO = t2.MaterialNO
	left join tb_JC_Material_B t3
	on t1.ParentNO = t3.MaterialNO
	left join tb_JC_MaterialProperty t4
	on t1.MaterialType = t4.PropertyNO
)
GO

Create view [vw_JC_Employee]
As
(
	select t1.*,t2.DepartmentName as DepartmentName,t3.PositionName as PositionName
	from tb_JC_Employee t1 left join tb_JC_Department t2
	on t1.DepartmentNO = t2.DepartmentNO
	left join tb_JC_Position t3
	on t1.PositionNO = t3.PositionNO
)
Go

Create view vw_JC_Material
As
	select t1.*,t2.ProcessRouteNO,t2.ProductionVolume,t2.IncreaseAmount,t2.UnitStandardTime
	from tb_JC_Material_B as t1
	left join tb_JC_Material_P as t2
	on t1.MaterialNO = t2.MaterialNO
GO

Create view vw_JC_Procedure
As
	select t1.*,t2.WorkCenterName
	from tb_JC_Procedure t1
	left join tb_JC_WorkCenter t2
	on t1.WorkCenterNO = t2.WorkCenterNO
GO

Create view vw_JH_PlannedSource
As
	select t1.*,t2.MaterialName,t2.Property,t2.Unit,t3.PropertyName
	from tb_JH_PlannedSource as t1
	left join tb_JC_Material_B as t2
	on t1.MaterialNO = t2.MaterialNO
	left join tb_JC_MaterialProperty as t3
	on t2.Property = t3.PropertyNO
Go

Create view vw_JH_MPS
As
	select t1.*,t2.MaterialName,t2.Unit,t3.BillNO as PlannedSourceNO
	from tb_JH_MPS as t1
	left join tb_JC_Material_B as t2
	on t1.MaterialNO = t2.MaterialNO
	left join tb_JH_PlannedSource as t3
	on t1.PlannedSourceID = t3.ID
Go

Create view vw_JH_MRP
As
	select t1.*,t2.MaterialName,t2.Unit,t3.PlanNO as MPSNO,t4.PropertyName
	from tb_JH_MRP as t1
	left join tb_JC_Material_B as t2
	on t1.MaterialNO = t2.MaterialNO
	left join tb_JH_MPS as t3
	on t1.MPSID = t3.ID
	left join tb_JC_MaterialProperty as t4
	on t2.Property = t4.PropertyNO
Go

Create view vw_JC_RoutingSub
As
(
	select t1.ID,t1.ProcedureNO,t1.ProcedureOrder,t1.RoutingID,t2.ProcedureName,t2.WorkCenterNO,t2.WorkCenterName,t3.RoutingNO
	from tb_JC_RoutingSub as t1
	left join vw_JC_Procedure as t2
	on t1.ProcedureNO = t2.ProcedureNO
	left join tb_JC_Routing as t3
	on t1.RoutingID = t3.ID
)
Go
Create view vw_JH_Task
As
(
	select t1.*,t2.BillNO as SourceNO,t3.MaterialNO,t4.MaterialName,t4.Unit
	from tb_JH_Task as t1
	left join tb_JH_PlannedSource as t2
	on t1.SourceID = t2.ID
	left join tb_JH_MRP as t3
	on t1.MRPID = t3.ID
	left join tb_JC_Material_B as t4
	on t3.MaterialNO = t4.MaterialNO
)