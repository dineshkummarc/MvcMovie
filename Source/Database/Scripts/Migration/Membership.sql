﻿use Movie



-- Altairis Web Security Toolkit - database creation script for "Table*Provider" classes
-- Copyright  Michal A. Valasek - Altairis, 2006-2011 | www.altairis.cz | www.rider.cz
-- Licensed under terms of Microsoft Shared Source Permissive License (MS-PL)
 
   
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[RoleMemberships]')  AND type IN ( N'U' ) )  DROP TABLE [RoleMemberships] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Roles]')  AND type IN ( N'U' ) )  DROP TABLE [Roles]  
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Users]')  AND type IN ( N'U' ) )  DROP TABLE [Users] 
CREATE TABLE dbo.Users (
	[ID] [int] IDENTITY(1, 1) NOT NULL , 
	UserName				nvarchar(100)		NOT NULL,
	PasswordHash			binary(64)			NOT NULL,
	PasswordSalt			binary(128)			NOT NULL,
	Email					nvarchar(max)		NOT NULL,
	Comment					nvarchar(max)		NULL,
	IsApproved				bit					NOT NULL,
	DateCreated				datetime			NOT NULL,
	DateLastLogin			datetime			NULL,
	DateLastActivity		datetime			NULL,
	DateLastPasswordChange	datetime			NOT NULL,
	-- You may add other columns needed by your application, as
	-- long as they are either nullable or have defaults assigned
	LastIpAddress			nvarchar(50)		NULL,
	LastSessionId			nvarchar(50)		NULL,
	CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (UserName)
)
INSERT INTO [Users]([UserName],[PasswordHash],[PasswordSalt],[Email],IsApproved,DateCreated,DateLastPasswordChange ) VALUES 
('a',0x41F2AFBF15FAD3B4255F7F60C12690CAB28172AC4782E8B773FB745B97EF37D7E2DDA258E7AAC4FEF0AB9997DDEE7EAF929AB53CD0712BA53245659952F34707,0xC641F94B847D2F7FABEB576F2676ED371B72D7B2359BA3FE5C62AB6BD1DD8E43E4A03FFCD840D00029DD9F2EC9AC1884F8CCB6423A21345013BA4FA503355619DF69C227EA134EA85D164B73AD1CAC4A8898EBAD645C5E6200A6B990EEE074D4C1A3109BF091E88A464E80A617BA6992D65FC807822376DA24E57F8075B5E8CD,'a@a.com',1,'1/1/2000','1/1/2000' ),
('b',0x41F2AFBF15FAD3B4255F7F60C12690CAB28172AC4782E8B773FB745B97EF37D7E2DDA258E7AAC4FEF0AB9997DDEE7EAF929AB53CD0712BA53245659952F34707,0xC641F94B847D2F7FABEB576F2676ED371B72D7B2359BA3FE5C62AB6BD1DD8E43E4A03FFCD840D00029DD9F2EC9AC1884F8CCB6423A21345013BA4FA503355619DF69C227EA134EA85D164B73AD1CAC4A8898EBAD645C5E6200A6B990EEE074D4C1A3109BF091E88A464E80A617BA6992D65FC807822376DA24E57F8075B5E8CD,'b@b.com',1,'1/1/2010','1/1/2010' ),
('c',0x41F2AFBF15FAD3B4255F7F60C12690CAB28172AC4782E8B773FB745B97EF37D7E2DDA258E7AAC4FEF0AB9997DDEE7EAF929AB53CD0712BA53245659952F34707,0xC641F94B847D2F7FABEB576F2676ED371B72D7B2359BA3FE5C62AB6BD1DD8E43E4A03FFCD840D00029DD9F2EC9AC1884F8CCB6423A21345013BA4FA503355619DF69C227EA134EA85D164B73AD1CAC4A8898EBAD645C5E6200A6B990EEE074D4C1A3109BF091E88A464E80A617BA6992D65FC807822376DA24E57F8075B5E8CD,'c@c.com',1,'1/1/2010','1/1/2010' ),
('Config'		,0x41F2AFBF15FAD3B4255F7F60C12690CAB28172AC4782E8B773FB745B97EF37D7E2DDA258E7AAC4FEF0AB9997DDEE7EAF929AB53CD0712BA53245659952F34707,0xC641F94B847D2F7FABEB576F2676ED371B72D7B2359BA3FE5C62AB6BD1DD8E43E4A03FFCD840D00029DD9F2EC9AC1884F8CCB6423A21345013BA4FA503355619DF69C227EA134EA85D164B73AD1CAC4A8898EBAD645C5E6200A6B990EEE074D4C1A3109BF091E88A464E80A617BA6992D65FC807822376DA24E57F8075B5E8CD,'Config@c.com',1,'1/1/2010','1/1/2010' ),
('ConfigEdit'	,0x41F2AFBF15FAD3B4255F7F60C12690CAB28172AC4782E8B773FB745B97EF37D7E2DDA258E7AAC4FEF0AB9997DDEE7EAF929AB53CD0712BA53245659952F34707,0xC641F94B847D2F7FABEB576F2676ED371B72D7B2359BA3FE5C62AB6BD1DD8E43E4A03FFCD840D00029DD9F2EC9AC1884F8CCB6423A21345013BA4FA503355619DF69C227EA134EA85D164B73AD1CAC4A8898EBAD645C5E6200A6B990EEE074D4C1A3109BF091E88A464E80A617BA6992D65FC807822376DA24E57F8075B5E8CD,'ConfigEdit@c.com',1,'1/1/2010','1/1/2010' ),
('User'			,0x41F2AFBF15FAD3B4255F7F60C12690CAB28172AC4782E8B773FB745B97EF37D7E2DDA258E7AAC4FEF0AB9997DDEE7EAF929AB53CD0712BA53245659952F34707,0xC641F94B847D2F7FABEB576F2676ED371B72D7B2359BA3FE5C62AB6BD1DD8E43E4A03FFCD840D00029DD9F2EC9AC1884F8CCB6423A21345013BA4FA503355619DF69C227EA134EA85D164B73AD1CAC4A8898EBAD645C5E6200A6B990EEE074D4C1A3109BF091E88A464E80A617BA6992D65FC807822376DA24E57F8075B5E8CD,'User@c.com',1,'1/1/2010','1/1/2010' ),
('UserRoleEdit'	,0x41F2AFBF15FAD3B4255F7F60C12690CAB28172AC4782E8B773FB745B97EF37D7E2DDA258E7AAC4FEF0AB9997DDEE7EAF929AB53CD0712BA53245659952F34707,0xC641F94B847D2F7FABEB576F2676ED371B72D7B2359BA3FE5C62AB6BD1DD8E43E4A03FFCD840D00029DD9F2EC9AC1884F8CCB6423A21345013BA4FA503355619DF69C227EA134EA85D164B73AD1CAC4A8898EBAD645C5E6200A6B990EEE074D4C1A3109BF091E88A464E80A617BA6992D65FC807822376DA24E57F8075B5E8CD,'UserRoleEdit@c.com',1,'1/1/2010','1/1/2010' )
 
GO









CREATE TABLE dbo.Roles (
	[ID] [int] IDENTITY(1, 1) NOT NULL , 
	RoleName				nvarchar(100)		NOT NULL,
	CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (RoleName)
)
INSERT INTO [Roles] ([RoleName]) VALUES ('Administrator'),   ('Dev'),('User'),('UserRoleEdit'),('Log'),('Audit'), ('Config'), ('ConfigEdit')
GO




CREATE TABLE dbo.RoleMemberships (
	[ID] [int] IDENTITY(1, 1) NOT NULL , 
	UserName				nvarchar(100)		NOT NULL,
	RoleName				nvarchar(100)		NOT NULL,
	CONSTRAINT PK_RoleMemberships PRIMARY KEY CLUSTERED (UserName, RoleName),
	CONSTRAINT FK_RoleMemberships_Roles FOREIGN KEY (RoleName) REFERENCES dbo.Roles (RoleName) ON UPDATE CASCADE ON DELETE CASCADE,
) 
-- When using both these providers together, you may want to add the foreign key
ALTER TABLE dbo.RoleMemberships ADD CONSTRAINT FK_RoleMemberships_Users FOREIGN KEY (UserName) REFERENCES dbo.Users (UserName) ON UPDATE CASCADE ON DELETE CASCADE
GO
INSERT INTO [RoleMemberships] ([UserName],[RoleName]) VALUES 
('a','Administrator'),
('a','Dev'), 
('a','Log'),
('a','Audit'),
('a','Config'), 
('b','Dev') , 
('c','Config') , 
('c','ConfigEdit') ,
('Config','Config') , 
('ConfigEdit','Config') ,
('ConfigEdit','ConfigEdit') ,
('UserRoleEdit','UserRoleEdit') ,  
('UserRoleEdit','User') ,  
('User','User')   
GO



IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Logins]')  AND type IN ( N'U' ) )  DROP TABLE [Logins]  

CREATE TABLE dbo.Logins (
	[ID] [int] IDENTITY(1, 1) NOT NULL , 
	UserName				nvarchar(100)		NOT NULL, 
	Email					nvarchar(max)		NOT NULL,
	Comment					nvarchar(max)		NULL,
	FailedAttempts			INT					NULL,
	DateCreated				datetime			NOT NULL , 
	IpAddress				nvarchar(50)		NULL,
	SessionId				nvarchar(50)		NULL 
)  
GO
