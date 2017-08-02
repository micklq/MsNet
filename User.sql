USE [hzdb]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](300) NULL,
	[Pid] [bigint] NOT NULL,
	[Sort] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Types] [varchar](50) NOT NULL,
	[Values] [varchar](300) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](300) NULL,
	[RoleType] [int] NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[PermissionId] [bigint] NOT NULL,
 CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SignedUpInfo]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SignedUpInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PassportId] [bigint] NOT NULL,
	[SignedUpTime] [datetime] NULL,
	[SignedUpIP] [varchar](256) NULL,
	[UtmSource] [varchar](128) NULL,
	[HttpUserAgent] [varchar](max) NULL,
	[RefererDomain] [varchar](128) NULL,
	[HttpReferer] [varchar](256) NULL,
	[InviteCode] [varchar](64) NULL,
 CONSTRAINT [PK_SignedUpInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserPassport]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserPassport](
	[PassportId] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserName] [nvarchar](500) NULL,
	[Email] [varchar](500) NULL,
	[Mobile] [varchar](500) NULL,
	[PassportStatus] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_UserPassport] PRIMARY KEY CLUSTERED 
(
	[PassportId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[PassportId] [bigint] NOT NULL,
	[NickName] [nvarchar](500) NULL,
	[RealName] [nvarchar](500) NULL,
	[Gender] [int] NULL,
	[Avatar] [varchar](500) NULL,
	[Mobile] [varchar](100) NULL,
	[CreatedTime] [datetime] NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[PassportId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PassportId] [bigint] NOT NULL,
	[Roles] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSecurity]    Script Date: 2017/2/17 18:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[UserSecurity](
	[PassportId] [bigint] NOT NULL,
	[Password] [varchar](128) NULL,
	[HashAlgorithm] [varchar](64) NULL,
	[PasswordSalt] [varchar](64) NULL,
	[LastPasswordChangedTime] [datetime] NULL,
	[IsLocked] [bit] NULL,
	[LastLockedTime] [datetime] NULL,
	[FailedPasswordAttemptCount] [int] NULL,
 CONSTRAINT [PK_UserSecurity] PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
