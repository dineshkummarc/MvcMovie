USE [Movie]
GO





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schema]') AND type in (N'U'))  Drop Table [Schema] 
CREATE TABLE [dbo].[Schema](
	[Id] [int] IDENTITY(1, 1) NOT NULL , 
	[Version] [bigint] NOT NULL,
	[UtcDate]  [datetime] DEFAULT (GETUTCDATE()),
	[BuildNumber] [nvarchar](100)  , 
	[Status] [nvarchar](50) NULL ,
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate())  
) ;
INSERT [Schema] ([Version] ) Values(1 )




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Log]') AND type in (N'U'))  Drop Table [Log] 
CREATE TABLE [dbo].[Log]
	(
	  [Id] [int] IDENTITY(1, 1) NOT NULL, 
	  [Description] [nvarchar](MAX) NULL,
	  [Summary] [nvarchar](100) NULL,
	  [Level] [nvarchar](16) NULL,
	  [Logger] [nvarchar](128) NULL,
	  [Status] [nvarchar](50) NULL,
	  [IpAddress] [nvarchar](100) NULL,
	  [Browser] [nvarchar](100) NULL,
	  [Server] [nvarchar](100) NULL,
	  [Session] [nvarchar](100) NULL,
	  [UserName] [nvarchar](100) NULL, 
	  [Application] [nvarchar](100) NULL,
	  [Type] [nvarchar](100) NULL,
	  [Tag] [nvarchar](100),   
	  [Layout] [nvarchar](MAX) NULL,
	  [UpdatedAt] [datetime]  not null default(getdate())  
) ; 



 
 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Config]')  AND type IN ( N'U' ) )  DROP TABLE [Config]
CREATE TABLE [dbo].[Config](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[Name] [nvarchar](50) NULL,  
	[Value] [nvarchar](50) NULL,
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate()) 
	) ON [PRIMARY]
GO
INSERT INTO  [Config] ( [Name], [Value] ) VALUES  
('BrainTree-MerchantId', 'BrainTree-MerchantId'  )  ,
('BrainTree-PublicKey', 'BrainTree-PublicKey'  )  ,
('BrainTree-PrivateKey', 'BrainTree-PrivateKey'  )  

 


IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Movies]')  AND type IN ( N'U' ) )  DROP TABLE [Movies]
CREATE TABLE [dbo].[Movies](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[Title] [nvarchar](50) NULL,  
	[Genre] [nvarchar](50) NULL, 
	[Price] [money] NULL, 
	[Rating] [nvarchar](5) NULL,  
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate()) 
	) ON [PRIMARY]
GO
INSERT INTO  [Movies] ([Title], [Genre], [Price], [Rating]) VALUES  
('The Lost Boys', 'Action', 3.99, 'G'  )  ,
('When Harry Met Sally', 'Romantic Comedy', 3.99, 'G'  ) ,
('Raiders of the lost arc', 'Action', 3.99, 'G'  ) ,
('Ghostbusters', 'Comedy', 4.99, 'G'  )  ,
('Ghostbusters 2', 'Comedy', 2.99, 'G'  ) ,
('Spaceballs', 'Comedy', 7.99, 'G'  )  							    
 

  

IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Customers]')  AND type IN ( N'U' ) )  DROP TABLE [Customers] 
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[FirstName] [nvarchar](55)  ,  
	[LastName] [nvarchar](55)  ,  
	[Email] [nvarchar](55)  ,  
	[Address] [nvarchar](55)  ,  
	[CreatedAt] [datetime] NULL default(getdate()),
	[UpdatedAt] [datetime] NULL default(getdate()) 
) ON [PRIMARY]
GO

INSERT INTO  [Customers] ([Email], [FirstName], [LastName] ) VALUES  
('cust1@test.com' , 'Joe', 'Smith'  ) 
,('Bart@test.com', 'Bart', 'Simpson'     ) 
,('Homer@test.com' , 'Homer', 'Simpson'    ) 
,('Barney@test.com' , 'Barney', 'Gumble'    ) 
   



IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Users]')  AND type IN ( N'U' ) )  DROP TABLE [Users] 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[Email] [nvarchar](255) NOT NULL,
	[HashedPassword] [nvarchar](50) NULL,
	[LastLogin] [datetime] NULL,
	[CreatedAt] [datetime] NULL default(getdate()),
	[UpdatedAt] [datetime] NULL default(getdate()),
	[Token] [nvarchar](255) NULL,
	[IsBanned] [bit] NOT NULL default(0)
) ON [PRIMARY]
GO
INSERT INTO  [Users] ([Email], [HashedPassword]) VALUES  
('test123@test.com', 'tttttttttt'  ) 
,('a@test.com', 'aaaaaaaaaaaa'  ) 
,('b@test.com', 'bbbbbbbbbbbb'  ) 
,('c@test.com', 'cccccccccccc'  ) 
   
