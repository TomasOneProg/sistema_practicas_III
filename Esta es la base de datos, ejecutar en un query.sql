USE [master]
GO
/****** Object:  Database [KUVO_GSTM]    Script Date: 11/2/2024 13:03:38 ******/
CREATE DATABASE [KUVO_GSTM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KUVO_GSTM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KUVO_GSTM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KUVO_GSTM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KUVO_GSTM_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KUVO_GSTM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KUVO_GSTM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KUVO_GSTM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET ARITHABORT OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KUVO_GSTM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KUVO_GSTM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KUVO_GSTM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KUVO_GSTM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET RECOVERY FULL 
GO
ALTER DATABASE [KUVO_GSTM] SET  MULTI_USER 
GO
ALTER DATABASE [KUVO_GSTM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KUVO_GSTM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KUVO_GSTM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KUVO_GSTM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KUVO_GSTM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KUVO_GSTM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'KUVO_GSTM', N'ON'
GO
ALTER DATABASE [KUVO_GSTM] SET QUERY_STORE = OFF
GO
USE [KUVO_GSTM]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](50) NULL,
	[hora] [varchar](50) NULL,
	[idUsuario] [int] NULL,
	[usuario] [varchar](50) NULL,
	[evento] [varchar](50) NULL,
	[detalle] [varchar](max) NULL,
	[origen] [varchar](50) NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[idFacturacion] [int] IDENTITY(1,1) NOT NULL,
	[idMenu] [int] NOT NULL,
	[nombreDelCliente] [varchar](50) NULL,
	[cantidades] [int] NULL,
	[formaDePago] [varchar](50) NULL,
	[precioTotal] [float] NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[idFacturacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[idMenu] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](100) NULL,
	[region] [varchar](100) NULL,
	[categoria] [varchar](100) NULL,
	[popularidad] [int] NULL,
	[precio] [decimal](18, 0) NULL,
	[temporada] [varchar](100) NULL,
	[tipoDeEvento] [varchar](100) NULL,
	[tiempoPreparacionEstimado] [int] NULL,
	[descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_Platillo] PRIMARY KEY CLUSTERED 
(
	[idMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[idPermiso] [int] IDENTITY(1,1) NOT NULL,
	[funcionalidad] [nvarchar](100) NOT NULL,
	[descripcion] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[idPersonal] [int] IDENTITY(1,1) NOT NULL,
	[apellido] [nchar](50) NULL,
	[nombre] [nchar](50) NULL,
	[nroDoc] [nchar](50) NULL,
	[cuil] [nchar](50) NULL,
	[calle] [nchar](50) NULL,
	[nro] [int] NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[idPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[marca] [varchar](100) NULL,
	[categoria] [varchar](50) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[razonSocial] [varchar](100) NULL,
	[cuit] [varchar](100) NULL,
	[direccionDeEmail] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
	[certificadoAfip] [varchar](100) NULL,
	[categoria] [varchar](100) NULL,
	[producto] [varchar](100) NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolPermisos]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolPermisos](
	[idRolPermiso] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[idPermiso] [int] NOT NULL,
	[fechaBaja] [datetime] NULL,
	[altaProvisoria] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idRolPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[idStock] [int] IDENTITY(1,1) NOT NULL,
	[fechaDeVencimiento] [varchar](50) NULL,
	[numeroDeLote] [varchar](50) NULL,
	[idProveedor] [int] NULL,
	[idProducto] [int] NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[idStock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRoles]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRoles](
	[idUsuarioRol] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idRol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuarioRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/2/2024 13:03:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nchar](50) NULL,
	[password] [varchar](100) NULL,
	[idPersonal] [int] NULL,
	[FechaAlta] [int] NULL,
	[fechaBaja] [int] NULL,
	[cambiaCada] [int] NULL,
	[fechaUltimoCambio] [int] NULL,
	[usuarioDesactivado] [int] NULL,
	[facheDesactivacion] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RolPermisos]  WITH CHECK ADD FOREIGN KEY([idPermiso])
REFERENCES [dbo].[Permisos] ([idPermiso])
GO
ALTER TABLE [dbo].[RolPermisos]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD  CONSTRAINT [FK__UsuarioRo__usuar__5BE2A6F2] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[UsuarioRoles] CHECK CONSTRAINT [FK__UsuarioRo__usuar__5BE2A6F2]
GO
USE [master]
GO
ALTER DATABASE [KUVO_GSTM] SET  READ_WRITE 
GO
