USE [master]
GO
/****** Object:  Database [nData]    Script Date: 2016/3/4 16:13:23 ******/
CREATE DATABASE [nData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'nData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\nData.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'nData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\nData_log.ldf' , SIZE = 13632KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [nData] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [nData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [nData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [nData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [nData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [nData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [nData] SET ARITHABORT OFF 
GO
ALTER DATABASE [nData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [nData] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [nData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [nData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [nData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [nData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [nData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [nData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [nData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [nData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [nData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [nData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [nData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [nData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [nData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [nData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [nData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [nData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [nData] SET RECOVERY FULL 
GO
ALTER DATABASE [nData] SET  MULTI_USER 
GO
ALTER DATABASE [nData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [nData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [nData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [nData] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [nData]
GO
/****** Object:  Table [dbo].[ActorWorks]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActorWorks](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[PlotType] [varchar](150) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[VedioUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[BrokerageId] [int] NOT NULL,
 CONSTRAINT [PK_ActorWorks] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArtBanner]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArtBanner](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[ArtId] [int] NOT NULL,
	[LinkUrl] [varchar](300) NULL,
 CONSTRAINT [PK_MovieBanner] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArtCenter]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArtCenter](
	[ArtId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[EnName] [varchar](150) NULL,
	[Author] [varchar](150) NULL,
	[EnAuthor] [varchar](150) NULL,
	[Size] [varchar](150) NULL,
	[Material] [varchar](150) NULL,
	[EnMaterial] [varchar](150) NULL,
	[PictureUrl] [varchar](150) NULL,
	[OutLink] [varchar](350) NULL,
	[Contents] [text] NULL,
	[CreatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ArtCenter] PRIMARY KEY CLUSTERED 
(
	[ArtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](50) NULL,
	[CategoryName] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[Depth] [int] NULL,
	[IsOuter] [int] NULL,
	[LinkUrl] [varchar](150) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedUser] [varchar](120) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[StrategyName] [varchar](50) NULL,
	[StrategyPhone] [varchar](50) NULL,
	[StrategyEmail] [varchar](150) NULL,
	[AdName] [varchar](50) NULL,
	[AdPhone] [varchar](50) NULL,
	[AdEmail] [varchar](150) NULL,
	[BusinessName] [varchar](50) NULL,
	[BusinessPhone] [varchar](50) NULL,
	[BusinessEmail] [varchar](150) NULL,
	[RentedName] [varchar](50) NULL,
	[RentedPhone] [varchar](50) NULL,
	[RentedEmail] [varchar](150) NULL,
	[InvestmentName] [varchar](50) NULL,
	[InvestmentPhone] [varchar](50) NULL,
	[InvestmentEmail] [varchar](150) NULL,
	[ServiceName] [varchar](50) NULL,
	[ServicePhone] [varchar](50) NULL,
	[ServiceEmail] [varchar](150) NULL,
	[QRCode1] [varchar](250) NULL,
	[QRCode2] [varchar](250) NULL,
	[QRCode3] [varchar](250) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DanceDesign]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DanceDesign](
	[DanceId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Title] [varchar](150) NULL,
	[Description] [varchar](max) NULL,
	[OutLink] [varchar](260) NULL,
	[StartTime] [varchar](50) NULL,
	[Address] [varchar](260) NULL,
	[Support] [varchar](260) NULL,
	[MailCity] [varchar](350) NULL,
	[DateEvent] [varchar](260) NULL,
	[Prices] [varchar](260) NULL,
	[StillsUrl] [varchar](150) NULL,
	[Renderings] [varchar](150) NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
 CONSTRAINT [PK_DanceDesign] PRIMARY KEY CLUSTERED 
(
	[DanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FilmAD]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FilmAD](
	[AdId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[AdTypeText] [varchar](50) NULL,
	[AdType] [int] NULL,
	[Description] [varchar](500) NULL,
	[DocxUrl] [varchar](240) NULL,
	[OutLink] [varchar](240) NULL,
	[PictureUrl] [varchar](240) NULL,
	[VedioUrl] [varchar](240) NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
 CONSTRAINT [PK_FilmAD] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HomeAtlas]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HomeAtlas](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[LinkUrl] [varchar](260) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_HomeAtlas] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Introduct]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Introduct](
	[IntorId] [int] NOT NULL,
	[Contents] [text] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_CooperationIntroduct] PRIMARY KEY CLUSTERED 
(
	[IntorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Phone] [varchar](30) NULL,
	[QQ] [varchar](50) NULL,
	[Contents] [text] NULL,
	[IsAudit] [int] NULL,
	[AuditUser] [varchar](50) NULL,
	[AuditTime] [datetime] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Title] [varchar](150) NULL,
	[ActorDescription] [varchar](150) NULL,
	[Director] [varchar](50) NULL,
	[Screenwriter] [varchar](50) NULL,
	[Starring] [varchar](500) NULL,
	[PlotType] [varchar](50) NULL,
	[ReleaseDate] [varchar](50) NULL,
	[Synopsis] [varchar](max) NULL,
	[ActorUrl] [varchar](150) NULL,
	[StillsUrl] [varchar](150) NULL,
	[BannerUrl] [varchar](150) NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedUser] [varchar](120) NULL,
	[IsRecommend] [int] NULL,
	[Weight] [int] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovieAtlas]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovieAtlas](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[VedioUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[MovieId] [int] NOT NULL,
 CONSTRAINT [PK_MovieAtlas] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Navigation]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Navigation](
	[NavId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[EnTitle] [varchar](150) NULL,
	[NavType] [int] NULL,
	[LinkUrl] [varchar](260) NULL,
	[ImageUrl] [varchar](260) NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_Navigation] PRIMARY KEY CLUSTERED 
(
	[NavId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[News]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Title] [varchar](150) NULL,
	[KeyWords] [varchar](150) NULL,
	[Contents] [text] NULL,
	[PictureUrl] [varchar](150) NULL,
	[IsTop] [int] NULL,
	[IsHot] [int] NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedUser] [varchar](120) NULL,
	[ShowIndex] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewsAtlas]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewsAtlas](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[VedioUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[NewsId] [int] NOT NULL,
 CONSTRAINT [PK_NewsAtlas] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewsBanner]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewsBanner](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[NewsId] [int] NULL,
	[LinkUrl] [varchar](300) NULL,
 CONSTRAINT [PK_ProjectBanner] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partners](
	[PartnersId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[SiteName] [varchar](50) NULL,
	[Domain] [varchar](150) NULL,
	[LogoUrl] [varchar](260) NULL,
	[Summary] [text] NULL,
	[Email] [varchar](150) NULL,
	[Status] [int] NULL,
	[Types] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_FriendlyLink] PRIMARY KEY CLUSTERED 
(
	[PartnersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PerformingBrokerage]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PerformingBrokerage](
	[BrokerageId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Name] [varchar](50) NULL,
	[Birth] [varchar](50) NULL,
	[Height] [varchar](30) NULL,
	[Weight] [varchar](50) NULL,
	[Constellation] [varchar](50) NULL,
	[Hometown] [varchar](150) NULL,
	[Specialty] [varchar](150) NULL,
	[Weibo] [varchar](150) NULL,
	[Summary] [varchar](450) NULL,
	[ActorUrl] [varchar](150) NULL,
	[BannerUrl] [varchar](150) NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
 CONSTRAINT [PK_PerformingBrokerage] PRIMARY KEY CLUSTERED 
(
	[BrokerageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PerformingProject]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PerformingProject](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Title] [varchar](150) NULL,
	[ActorDescription] [varchar](150) NULL,
	[Director] [varchar](50) NULL,
	[Screenwriter] [varchar](50) NULL,
	[Starring] [varchar](500) NULL,
	[PlotType] [varchar](50) NULL,
	[ReleaseDate] [varchar](50) NULL,
	[Synopsis] [varchar](500) NULL,
	[ActorUrl] [varchar](150) NULL,
	[StillsUrl] [varchar](150) NULL,
	[BannerUrl] [varchar](150) NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedUser] [varchar](120) NULL,
	[IsRecommend] [int] NULL,
	[Weight] [int] NULL,
 CONSTRAINT [PK_PerformingProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectAtlas]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectAtlas](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[VedioUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectAtlas] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectCooperation]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectCooperation](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](150) NULL,
	[DownloadUrl] [varchar](260) NULL,
	[PictureUrl] [varchar](260) NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_ProjectCooperation] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SceneAtlas]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SceneAtlas](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[VedioUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[DanceId] [int] NOT NULL,
 CONSTRAINT [PK_SceneAtlas] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroup](
	[GroupId] [uniqueidentifier] NOT NULL,
	[GroupName] [varchar](50) NOT NULL,
	[GroupPermission] [varchar](350) NOT NULL,
	[GroupStatus] [int] NOT NULL,
	[GroupCreatedTime] [datetime] NOT NULL,
	[GroupStopTime] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[PassportId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](128) NULL,
	[GroupId] [uniqueidentifier] NULL,
	[Status] [int] NULL,
	[UserStopTime] [datetime] NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[PassportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Works]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Works](
	[WorksId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Title] [varchar](150) NULL,
	[ActorDescription] [varchar](150) NULL,
	[Director] [varchar](50) NULL,
	[Screenwriter] [varchar](50) NULL,
	[Starring] [varchar](500) NULL,
	[PlotType] [varchar](50) NULL,
	[ReleaseDate] [varchar](50) NULL,
	[Synopsis] [varchar](500) NULL,
	[ActorUrl] [varchar](260) NULL,
	[StillsUrl] [varchar](260) NULL,
	[BannerUrl] [varchar](260) NULL,
	[IsTop] [int] NULL,
	[LastModifyTime] [datetime] NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedUser] [varchar](120) NULL,
 CONSTRAINT [PK_Works] PRIMARY KEY CLUSTERED 
(
	[WorksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WorksAtlas]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WorksAtlas](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[VedioUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[WorksId] [int] NOT NULL,
 CONSTRAINT [PK_WorksAtlas] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WorksBanner]    Script Date: 2016/3/4 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WorksBanner](
	[AtlasId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[AtlasUrl] [varchar](260) NULL,
	[AtlasType] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[WorksId] [int] NULL,
	[LinkUrl] [varchar](300) NULL,
 CONSTRAINT [PK_WorksBanner] PRIMARY KEY CLUSTERED 
(
	[AtlasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[FilmAD] ADD  CONSTRAINT [DF_FilmAD_AdType]  DEFAULT ((0)) FOR [AdType]
GO
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_IsRecommend]  DEFAULT ((0)) FOR [IsRecommend]
GO
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[Navigation] ADD  CONSTRAINT [DF_Navigation_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_IsTop]  DEFAULT ((0)) FOR [IsTop]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_IsHot]  DEFAULT ((0)) FOR [IsHot]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_ShowIndex]  DEFAULT ((0)) FOR [ShowIndex]
GO
ALTER TABLE [dbo].[PerformingProject] ADD  CONSTRAINT [DF_PerformingProject_IsRecommend]  DEFAULT ((0)) FOR [IsRecommend]
GO
ALTER TABLE [dbo].[PerformingProject] ADD  CONSTRAINT [DF_PerformingProject_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[Works] ADD  CONSTRAINT [DF_Works_IsTop]  DEFAULT ((0)) FOR [IsTop]
GO
USE [master]
GO
ALTER DATABASE [nData] SET  READ_WRITE 
GO
