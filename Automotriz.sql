USE [master]
GO
/****** Object:  Database [Automotriz]    Script Date: 9/6/2022 17:53:55 ******/
CREATE DATABASE [Automotriz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Automotriz', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVERATLAS\MSSQL\DATA\Automotriz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Automotriz_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVERATLAS\MSSQL\DATA\Automotriz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Automotriz] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Automotriz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Automotriz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Automotriz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Automotriz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Automotriz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Automotriz] SET ARITHABORT OFF 
GO
ALTER DATABASE [Automotriz] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Automotriz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Automotriz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Automotriz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Automotriz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Automotriz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Automotriz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Automotriz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Automotriz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Automotriz] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Automotriz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Automotriz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Automotriz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Automotriz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Automotriz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Automotriz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Automotriz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Automotriz] SET RECOVERY FULL 
GO
ALTER DATABASE [Automotriz] SET  MULTI_USER 
GO
ALTER DATABASE [Automotriz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Automotriz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Automotriz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Automotriz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Automotriz] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Automotriz', N'ON'
GO
ALTER DATABASE [Automotriz] SET QUERY_STORE = OFF
GO
USE [Automotriz]
GO
/****** Object:  Table [dbo].[asignacion]    Script Date: 9/6/2022 17:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacion](
	[asi_id_asigancion] [int] IDENTITY(1,1) NOT NULL,
	[cli_id_cliente] [int] NOT NULL,
	[pat_id_patio] [int] NOT NULL,
	[asi_fecha_asignacion] [datetime] NOT NULL,
 CONSTRAINT [PK_asignacion] PRIMARY KEY CLUSTERED 
(
	[asi_id_asigancion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 9/6/2022 17:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[cli_id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cli_identificacion] [nchar](10) NOT NULL,
	[cli_nombres] [nchar](100) NULL,
	[cli_apellidos] [nchar](100) NULL,
	[cli_edad] [int] NULL,
	[cli_fecha_nacimiento] [datetime] NULL,
	[cli_direccion] [nchar](200) NULL,
	[cli_telefono] [nchar](10) NULL,
	[cli_estado_civil] [nchar](10) NULL,
	[cli_identificacion_conyugue] [nchar](10) NULL,
	[cli_nombre_conyugue] [nchar](100) NULL,
	[cli_sujeto_credito] [bit] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[cli_id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[credito]    Script Date: 9/6/2022 17:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[credito](
	[cre_id_credito] [int] IDENTITY(1,1) NOT NULL,
	[cli_id_cliente] [int] NOT NULL,
	[eje_id_ejecutivo] [int] NOT NULL,
	[veh_id_vehiculo] [int] NOT NULL,
	[pat_id_patio] [int] NOT NULL,
	[cre_fecha_elaboracion] [datetime] NOT NULL,
	[cre_meses_plazo] [int] NOT NULL,
	[cre_cuotas] [money] NOT NULL,
	[cre_entrada] [money] NOT NULL,
	[cre_estado] [nchar](10) NOT NULL,
	[cre_observacion] [nchar](200) NOT NULL,
 CONSTRAINT [PK_credito] PRIMARY KEY CLUSTERED 
(
	[cre_id_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ejecutivo]    Script Date: 9/6/2022 17:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ejecutivo](
	[eje_id_ejecutivo] [int] IDENTITY(1,1) NOT NULL,
	[pat_id_patio] [int] NOT NULL,
	[eje_identificacion] [nchar](10) NOT NULL,
	[eje_nombres] [nchar](100) NOT NULL,
	[eje_apellidos] [nchar](100) NOT NULL,
	[eje_direccion] [nchar](200) NOT NULL,
	[eje_telefono_convencional] [nchar](10) NOT NULL,
	[eje_celular] [nchar](10) NOT NULL,
	[eje_edad] [int] NOT NULL,
 CONSTRAINT [PK_ejecutivo] PRIMARY KEY CLUSTERED 
(
	[eje_id_ejecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 9/6/2022 17:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[mar_id_marca] [int] IDENTITY(1,1) NOT NULL,
	[mar_nombre] [nchar](100) NOT NULL,
 CONSTRAINT [PK_marca] PRIMARY KEY CLUSTERED 
(
	[mar_id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patio]    Script Date: 9/6/2022 17:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patio](
	[pat_id_patio] [int] IDENTITY(1,1) NOT NULL,
	[pat_nombre] [nchar](100) NOT NULL,
	[pat_direccion] [nchar](200) NOT NULL,
	[pat_telefono] [nchar](10) NOT NULL,
	[pat_punto_vente] [int] NOT NULL,
 CONSTRAINT [PK_patio] PRIMARY KEY CLUSTERED 
(
	[pat_id_patio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 9/6/2022 17:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[veh_id_vehiculo] [int] IDENTITY(1,1) NOT NULL,
	[veh_placa] [nchar](10) NOT NULL,
	[mar_id_marca] [int] NOT NULL,
	[veh_modelo] [nchar](10) NOT NULL,
	[veh_numero_chasis] [nchar](10) NOT NULL,
	[veh_tipo] [nchar](10) NULL,
	[veh_cilindraje] [nchar](10) NOT NULL,
	[veh_avaluo] [money] NOT NULL,
 CONSTRAINT [PK_vehiculo] PRIMARY KEY CLUSTERED 
(
	[veh_id_vehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[asignacion]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_cliente] FOREIGN KEY([cli_id_cliente])
REFERENCES [dbo].[cliente] ([cli_id_cliente])
GO
ALTER TABLE [dbo].[asignacion] CHECK CONSTRAINT [FK_asignacion_cliente]
GO
ALTER TABLE [dbo].[asignacion]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_patio] FOREIGN KEY([pat_id_patio])
REFERENCES [dbo].[patio] ([pat_id_patio])
GO
ALTER TABLE [dbo].[asignacion] CHECK CONSTRAINT [FK_asignacion_patio]
GO
ALTER TABLE [dbo].[credito]  WITH CHECK ADD  CONSTRAINT [FK_credito_cliente] FOREIGN KEY([cli_id_cliente])
REFERENCES [dbo].[cliente] ([cli_id_cliente])
GO
ALTER TABLE [dbo].[credito] CHECK CONSTRAINT [FK_credito_cliente]
GO
ALTER TABLE [dbo].[credito]  WITH CHECK ADD  CONSTRAINT [FK_credito_ejecutivo] FOREIGN KEY([eje_id_ejecutivo])
REFERENCES [dbo].[ejecutivo] ([eje_id_ejecutivo])
GO
ALTER TABLE [dbo].[credito] CHECK CONSTRAINT [FK_credito_ejecutivo]
GO
ALTER TABLE [dbo].[credito]  WITH CHECK ADD  CONSTRAINT [FK_credito_vehiculo] FOREIGN KEY([veh_id_vehiculo])
REFERENCES [dbo].[vehiculo] ([veh_id_vehiculo])
GO
ALTER TABLE [dbo].[credito]  WITH CHECK ADD  CONSTRAINT [FK_credito_patio] FOREIGN KEY([pat_id_patio])
REFERENCES [dbo].[patio] ([pat_id_patio])
GO
ALTER TABLE [dbo].[credito] CHECK CONSTRAINT [FK_credito_vehiculo]
GO
ALTER TABLE [dbo].[ejecutivo]  WITH CHECK ADD  CONSTRAINT [FK_ejecutivo_patio] FOREIGN KEY([pat_id_patio])
REFERENCES [dbo].[patio] ([pat_id_patio])
GO
ALTER TABLE [dbo].[ejecutivo] CHECK CONSTRAINT [FK_ejecutivo_patio]
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_vehiculo_marca] FOREIGN KEY([mar_id_marca])
REFERENCES [dbo].[marca] ([mar_id_marca])
GO
ALTER TABLE [dbo].[vehiculo] CHECK CONSTRAINT [FK_vehiculo_marca]
GO
USE [master]
GO
ALTER DATABASE [Automotriz] SET  READ_WRITE 
GO
