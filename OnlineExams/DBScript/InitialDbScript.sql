Create Proc onlineExamDB

USE [onlineExamDB]

CREATE TABLE [dbo].[UserGroups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserGroup] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 26-01-2020 00:54:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[GroupID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[UserGroups] ON 

GO
INSERT [dbo].[UserGroups] ([ID], [UserGroup], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status]) VALUES (1, N'Admin', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserGroups] ([ID], [UserGroup], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status]) VALUES (2, N'SubAdmin', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserGroups] ([ID], [UserGroup], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status]) VALUES (3, N'Student', NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([UserID], [username], [Password], [GroupID], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status]) VALUES (1, N'superadmin@gmail.com', N'12345', 1, NULL, NULL, 1, CAST(N'2017-03-03 00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Users_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[UserGroups] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_UserGroups_Users_GroupID]
GO
/****** Object:  StoredProcedure [dbo].[UserLoginAuthentication]    Script Date: 26-01-2020 00:54:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[UserLoginAuthentication]
(
@UserName nvarchar(50),  
@Password nvarchar(50)
)
As
Begin
		SELECT UserGroup.UserGroup, Users.UserID,Users.username FROM Users Users INNER JOIN UserGroups UserGroup ON UserGroup.ID = Users.GroupID
		WHERE Users.username COLLATE Latin1_General_CS_AS = @UserName
		AND Users.[Password] COLLATE Latin1_General_CS_AS = @Password
		AND Users.Status =1
	
End
GO


