USE [master]
GO
/****** Object:  Database [BibliotecaPeliculas]    Script Date: 5/9/2022 9:00:45 PM ******/
CREATE DATABASE [BibliotecaPeliculas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BibliotecaPeliculas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BibliotecaPeliculas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BibliotecaPeliculas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BibliotecaPeliculas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BibliotecaPeliculas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BibliotecaPeliculas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BibliotecaPeliculas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET ARITHABORT OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BibliotecaPeliculas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BibliotecaPeliculas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BibliotecaPeliculas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BibliotecaPeliculas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BibliotecaPeliculas] SET  MULTI_USER 
GO
ALTER DATABASE [BibliotecaPeliculas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BibliotecaPeliculas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BibliotecaPeliculas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BibliotecaPeliculas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BibliotecaPeliculas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BibliotecaPeliculas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BibliotecaPeliculas] SET QUERY_STORE = OFF
GO
USE [BibliotecaPeliculas]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 5/9/2022 9:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[id_actor] [bigint] IDENTITY(1,1) NOT NULL,
	[actor_name] [varchar](20) NOT NULL,
	[actor_lastname] [varchar](20) NOT NULL,
	[actor_age] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_actor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 5/9/2022 9:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[id_director] [bigint] IDENTITY(1,1) NOT NULL,
	[director_name] [varchar](20) NOT NULL,
	[director_lastname] [varchar](20) NOT NULL,
	[director_age] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_director] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 5/9/2022 9:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[id_genre] [bigint] IDENTITY(1,1) NOT NULL,
	[genre_name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 5/9/2022 9:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[id_movie] [bigint] IDENTITY(1,1) NOT NULL,
	[id_director] [bigint] NOT NULL,
	[id_production] [bigint] NOT NULL,
	[movie_name] [varchar](50) NOT NULL,
	[movie_synopsis] [varchar](200) NOT NULL,
	[movie_year] [int] NOT NULL,
	[movie_cartel] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_movie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Actor]    Script Date: 5/9/2022 9:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Actor](
	[id_movie_actor] [bigint] IDENTITY(1,1) NOT NULL,
	[id_movie] [bigint] NOT NULL,
	[id_actor] [bigint] NOT NULL,
	[movie_role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Movie_Actor] PRIMARY KEY CLUSTERED 
(
	[id_movie_actor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Genre]    Script Date: 5/9/2022 9:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Genre](
	[id_movie_genre] [bigint] IDENTITY(1,1) NOT NULL,
	[id_movie] [bigint] NOT NULL,
	[id_genre] [bigint] NOT NULL,
 CONSTRAINT [PK_Movie_Genre] PRIMARY KEY CLUSTERED 
(
	[id_movie_genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Production]    Script Date: 5/9/2022 9:00:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Production](
	[id_production] [bigint] IDENTITY(1,1) NOT NULL,
	[production_name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_production] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_MovieProduction] FOREIGN KEY([id_production])
REFERENCES [dbo].[Production] ([id_production])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_MovieProduction]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_MvoieDirector] FOREIGN KEY([id_director])
REFERENCES [dbo].[Director] ([id_director])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_MvoieDirector]
GO
ALTER TABLE [dbo].[Movie_Actor]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie] FOREIGN KEY([id_actor])
REFERENCES [dbo].[Actor] ([id_actor])
GO
ALTER TABLE [dbo].[Movie_Actor] CHECK CONSTRAINT [FK_ActorMovie]
GO
ALTER TABLE [dbo].[Movie_Actor]  WITH CHECK ADD  CONSTRAINT [FK_MovieActor] FOREIGN KEY([id_movie])
REFERENCES [dbo].[Movie] ([id_movie])
GO
ALTER TABLE [dbo].[Movie_Actor] CHECK CONSTRAINT [FK_MovieActor]
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK_GenreMovie] FOREIGN KEY([id_genre])
REFERENCES [dbo].[Genre] ([id_genre])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK_GenreMovie]
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK_MovieGenre] FOREIGN KEY([id_movie])
REFERENCES [dbo].[Movie] ([id_movie])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK_MovieGenre]
GO
USE [master]
GO
ALTER DATABASE [BibliotecaPeliculas] SET  READ_WRITE 
GO
