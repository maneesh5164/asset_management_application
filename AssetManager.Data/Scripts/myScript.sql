using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Data.Scripts
{
    class myScript
    {
    USE [EmployeeAssetDB]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetAssignments]') AND type in (N'U'))
ALTER TABLE [dbo].[AssetAssignments] DROP CONSTRAINT IF EXISTS [FK_AssetAssignments_Employees_EmployeeId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetAssignments]') AND type in (N'U'))
ALTER TABLE [dbo].[AssetAssignments] DROP CONSTRAINT IF EXISTS [FK_AssetAssignments_Assets_AssetId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT IF EXISTS [DF__Employees__IsAct__3C69FB99]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Assets]') AND type in (N'U'))
ALTER TABLE [dbo].[Assets] DROP CONSTRAINT IF EXISTS [DF__Assets__IsSpare__398D8EEE]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 03-10-2025 22:53:26 ******/
DROP TABLE IF EXISTS [dbo].[Employees]
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 03-10-2025 22:53:26 ******/
DROP TABLE IF EXISTS [dbo].[Assets]
GO
/****** Object:  Table [dbo].[AssetAssignments]    Script Date: 03-10-2025 22:53:26 ******/
DROP TABLE IF EXISTS [dbo].[AssetAssignments]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 03-10-2025 22:53:26 ******/
DROP TABLE IF EXISTS [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 03-10-2025 22:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetAssignments]    Script Date: 03-10-2025 22:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetAssignments](
	[AssetAssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[AssetId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[AssignedDate] [datetime2](7) NOT NULL,
	[ReturnedDate] [datetime2](7) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_AssetAssignments] PRIMARY KEY CLUSTERED 
(
	[AssetAssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 03-10-2025 22:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assets](
	[AssetId] [int] IDENTITY(1,1) NOT NULL,
	[AssetName] [nvarchar](200) NOT NULL,
	[AssetType] [nvarchar](100) NOT NULL,
	[MakeModel] [nvarchar](150) NOT NULL,
	[SerialNumber] [nvarchar](100) NOT NULL,
	[PurchaseDate] [datetime2](7) NOT NULL,
	[WarrantyExpiryDate] [datetime2](7) NOT NULL,
	[Condition] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[IsSpare] [bit] NOT NULL,
	[Specifications] [nvarchar](max) NULL,
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[AssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 03-10-2025 22:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Department] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Designation] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251002103348_InitialCreate', N'9.0.9')
GO
SET IDENTITY_INSERT [dbo].[AssetAssignments] ON 
GO
INSERT [dbo].[AssetAssignments] ([AssetAssignmentId], [AssetId], [EmployeeId], [AssignedDate], [ReturnedDate], [Notes]) VALUES (2, 1, 5, CAST(N'2025-10-03T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-03T00:00:00.0000000' AS DateTime2), N'AS')
GO
INSERT [dbo].[AssetAssignments] ([AssetAssignmentId], [AssetId], [EmployeeId], [AssignedDate], [ReturnedDate], [Notes]) VALUES (3, 1, 5, CAST(N'2025-10-17T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-25T00:00:00.0000000' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[AssetAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Assets] ON 
GO
INSERT [dbo].[Assets] ([AssetId], [AssetName], [AssetType], [MakeModel], [SerialNumber], [PurchaseDate], [WarrantyExpiryDate], [Condition], [Status], [IsSpare], [Specifications]) VALUES (1, N'Dell Laptop', N'Electronics', N'Dell Latitude 5420', N'DL12345', CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2027-01-01T00:00:00.0000000' AS DateTime2), N'New', N'Available', 0, N'i7, 16GB RAM, 512GB SSD')
GO
SET IDENTITY_INSERT [dbo].[Assets] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [Department], [Email], [PhoneNumber], [Designation], [IsActive]) VALUES (5, N'Maneesh', N'Tech', N'man@gmail.com', N'8953695838', N'SDE', 1)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
ALTER TABLE [dbo].[Assets] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsSpare]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[AssetAssignments]  WITH CHECK ADD  CONSTRAINT [FK_AssetAssignments_Assets_AssetId] FOREIGN KEY([AssetId])
REFERENCES [dbo].[Assets] ([AssetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssetAssignments] CHECK CONSTRAINT [FK_AssetAssignments_Assets_AssetId]
GO
ALTER TABLE [dbo].[AssetAssignments]  WITH CHECK ADD  CONSTRAINT [FK_AssetAssignments_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssetAssignments] CHECK CONSTRAINT [FK_AssetAssignments_Employees_EmployeeId]
GO
    }
}
