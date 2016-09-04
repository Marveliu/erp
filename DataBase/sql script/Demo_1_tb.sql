Use [master]
IF exists(select name from sysdatabases where name='DemoDB')
Drop database [DemoDB]
GO

Create database [DemoDB] on primary
(
	name = N'DemoDB', 
	fileName = N'E:\毕设项目\Demo\DataBase\DemoDB.mdf', 
	size = 5MB, maxsize = unlimited, 
	filegrowth = 1MB
)
Log on
(
	name = N'DemoDB_log', 
	fileName = N'E:\毕设项目\Demo\DataBase\DemoDB_log.ldf', 
	size = 1MB, maxsize = 100MB, 
	filegrowth = 10%
)
GO

Use [DemoDB]
Go

--系统权限
Create table tb_SYS_Parameter
(
	ID nvarchar(64) not null primary key,
	ParameterNO nvarchar(32) not null,
	Value nvarchar(64) null,
	[Status] nvarchar(1) not null
)
Go
Create table tb_SYS_Role
(
     ID nvarchar(64) not null primary key,
     RoleNO nvarchar(64) null,
     RoleName nvarchar(64) not null,
	 ParentID nvarchar(64) null,
	 DefaultUrl nvarchar(255) null,
     State nvarchar(1) null,
     CreateID nvarchar(64) null,
     CreateTime datetime null,
     UpdateID Nvarchar(64) null,
     UpdateTime datetime null
)
Go
Create table tb_SYS_Account
(
     ID nvarchar(64) not null primary key,
     AccountName nvarchar(64) not null,
     Password nvarchar(64) not null,
     AccountType nvarchar(1) null,
     RoleID nvarchar(64) null,
     State nvarchar(1) null,
     CreateID nvarchar(64) null,
     CreateTime datetime null,
     UpdateID nvarchar(64) null,
     UpdateTime datetime null
)
Go
Create table tb_SYS_Menu
(
     ID nvarchar(64) not null primary key,
     MenuNO nvarchar(64) null,
     MenuName nvarchar(64) not null,
     ParentID nvarchar(64) null,
     MenuUrl nvarchar(255) null,
     ImageUrl nvarchar(255) null,
     State nvarchar(1) null,
     CreateID nvarchar(64) null,
     CreateTime datetime null,
     UpdateID nvarchar(64) null,
     UpdateTime datetime null
)
Go
Create table tb_SYS_RoleMenu
(
     ID nvarchar(64) not null primary key,
     MenuID nvarchar(64) not null,
     RoleID nvarchar(64) not null,
	 AuthorizationDelete nvarchar(1) null,
     AuthorizationUpdate nvarchar(1) null,
     AuthorizationInsert nvarchar(1) null,
     State nvarchar(1) null,
     CreateID nvarchar(64) null,
     CreateTime datetime null,
     UpdateID nvarchar(64) null,
     UpdateTime datetime null
)
Go
Create table tb_SYS_RoleXML
(
     ID nvarchar(64) not null primary key,
     RoleID nvarchar(64) not null,
     XML nvarchar(max) null,
     State nvarchar(1) null,
     CreateID nvarchar(64) null,
     CreateTime datetime null,
     UpdateID nvarchar(64) null,
     UpdateTime datetime null
)
Go

--基础数据
Create table tb_JC_Employee
(
	ID nvarchar(64) not null primary key,
	EmployeeNO nvarchar(64) null,
	EmployeeName nvarchar(64) null,
	Age int null,
	Sex nvarchar(1) null,
	EntryDate datetime null,
	LeaveDate datetime null,
	IDNumber nvarchar(64) null,
	DepartmentNO nvarchar(64) null,
	PositionNO nvarchar(64) null,
	NativePlace nvarchar(64) null,
	MobileNumber nvarchar(64) null,
	Email nvarchar(64) null,
	Nation nvarchar(64) null,
	PoliticalStatus nvarchar(1) null,
	MaritialStatus nvarchar(1) null,
	Status nvarchar(1) null
)
Go
Create table tb_JC_WorkCenter
(
     ID nvarchar(64) not null primary key,
     WorkCenterNO nvarchar(64) null,
     WorkCenterName nvarchar(64) null,
	 CapacityType nvarchar(1) null,
     StandardCapacity decimal(18,2) null,
     CapacityUnit nvarchar(64) null,
	 Status nvarchar(1) null
)
Go
Create table tb_JC_WorkCenterCapacity
(
     ID nvarchar(64) not null primary key,
     WorkCenterNO nvarchar(64) null,
     MaterialNO nvarchar(64) null,
	 CapacityType nvarchar(1) null,
     UnitCapacity decimal(18,2) null,
     CapacityUnit nvarchar(64) null,
)
Go
Create table [tb_JC_MaterialProperty]
(
	ID nvarchar(64) not null primary key,
	PropertyNO nvarchar(1) null,
	PropertyName nvarchar(64) null,
)
Go
Create table [tb_JC_Department]
(
	ID nvarchar(64) not null primary key,
	DepartmentNO nvarchar(64) null,
	DepartmentName nvarchar(64) null, 
	Status nvarchar(1) null
)
Go
Create table [tb_JC_Position]
(
	ID nvarchar(64) not null primary key,
	PositionNO nvarchar(64) null,
	PositionName nvarchar(64) null,
	DepartmentNO nvarchar(64) null,
	Status nvarchar(1) null
)
Go
Create table tb_JC_Routing
(
	ID nvarchar(64) not null primary key,
	RoutingNO nvarchar(64) null,
	RoutingName nvarchar(64) null,
	ProcedureAmount int null,
	Status nvarchar(1) null
)
Go

Create table tb_JC_RoutingSub 
(
	ID nvarchar(64) not null primary key,
	RoutingID nvarchar(64) null,
	ProcedureOrder int null,
	ProcedureNO nvarchar(64) null
)
Go

Create table tb_JC_Procedure
(
	ID nvarchar(64) not null primary key,
	ProcedureNO nvarchar(64) null,
	ProcedureName nvarchar(64) null,
	WorkCenterNO nvarchar(64) null,
	Status nvarchar(1) null
)
Go

Create table tb_JC_WorkCenterLoad
(
	ID nvarchar(64) not null primary key,
	WorkCenterNO nvarchar(64) null,
	OccupiedCapacity decimal(18,2) null,
	[Load] decimal(18,2) null,
	[Date] datetime null
)
Go

Create table tb_JC_WorkCalendarRule
(
	ID nvarchar(64) primary key not null,
	ExceptionType nvarchar(1) null,
	ExceptionTime nvarchar(16) null
)
Go

Create table tb_JC_WorkCalendar
(
	ID int identity(1,1) primary key not null,
	[Date] datetime null
)
Go
--生产计划
Create table tb_JH_PlannedSource
(
     ID nvarchar(64) not null primary key,
     BillNO nvarchar(64) null,
     BillType nvarchar(1) null,
	 MaterialNO nvarchar(64) null,
	 PlanAmount decimal(18,2) null,
     DownAmount decimal(18,2) null,
     EndDate datetime null,
	 Status nvarchar(1) null,
)
Go
Create table tb_JH_MPS
(
     ID nvarchar(64) not null primary key,
     PlanNO nvarchar(64) null,
     PlannedSourceID nvarchar(64) null,
     MaterialNO nvarchar(64) null,
     PlanAmount decimal(18,2) null,
     ResolveAmount decimal(18,2) null,
     EndDate datetime null,
     Status nvarchar(1) null,
)
Go
Create table tb_JH_MRP
(
     ID nvarchar(64) not null primary key,
     PlanNO nvarchar(64) null,
     MPSID nvarchar(64) null,
     MaterialNO nvarchar(64) null,
     NeedAmount decimal(18,2) null,
     NeedDate datetime null,
     Status nvarchar(1) null,
)
Go
Create table tb_JH_Task
(
	ID nvarchar(64) not null primary key,
	SourceID nvarchar(64) not null,
	MRPID nvarchar(64) not null,
	BillType nvarchar(1) not null,
	BillNO nvarchar(64) null,
	[Date] datetime null,
	Amount decimal(18,2) null,
	ExecutedAmount decimal(18,2) null,
	[Status] nvarchar(1) null
)
Go
