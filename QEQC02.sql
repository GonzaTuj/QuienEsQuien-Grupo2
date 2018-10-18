USE [master]
GO
/****** Object:  Database [QEQC02]    Script Date: 18/10/2018 13:19:46 ******/
CREATE DATABASE [QEQC02]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QEQC02', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QEQC02.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QEQC02_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QEQC02_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QEQC02] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QEQC02].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QEQC02] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QEQC02] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QEQC02] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QEQC02] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QEQC02] SET ARITHABORT OFF 
GO
ALTER DATABASE [QEQC02] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QEQC02] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QEQC02] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QEQC02] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QEQC02] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QEQC02] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QEQC02] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QEQC02] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QEQC02] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QEQC02] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QEQC02] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QEQC02] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QEQC02] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QEQC02] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QEQC02] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QEQC02] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QEQC02] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QEQC02] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QEQC02] SET  MULTI_USER 
GO
ALTER DATABASE [QEQC02] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QEQC02] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QEQC02] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QEQC02] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QEQC02] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QEQC02', N'ON'
GO
ALTER DATABASE [QEQC02] SET QUERY_STORE = OFF
GO
USE [QEQC02]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [QEQC02]
GO
/****** Object:  User [QEQC02]    Script Date: 18/10/2018 13:19:46 ******/
CREATE USER [QEQC02] FOR LOGIN [QEQC02] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [QEQC02]
GO
/****** Object:  Table [dbo].[Caracteristicas]    Script Date: 18/10/2018 13:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caracteristicas](
	[IdCaract] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Pregunta] [varchar](100) NOT NULL,
	[FkCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Caracteristicas] PRIMARY KEY CLUSTERED 
(
	[IdCaract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaracteristicasCategorias]    Script Date: 18/10/2018 13:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaracteristicasCategorias](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CaracteristicasCategorias] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonajeCaracteristica]    Script Date: 18/10/2018 13:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonajeCaracteristica](
	[fkCaracteristica] [int] NOT NULL,
	[fkPersonaje] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personajes]    Script Date: 18/10/2018 13:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personajes](
	[IdPers] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FkCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Personajes] PRIMARY KEY CLUSTERED 
(
	[IdPers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonajesCategorias]    Script Date: 18/10/2018 13:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonajesCategorias](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PersonajesCategorias] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ranking]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ranking](
	[ID] [int] NOT NULL,
	[fkUsuario] [varchar](50) NOT NULL,
	[InfoCoins] [int] NOT NULL,
 CONSTRAINT [PK_Ranking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[EsAdministrador] [bit] NOT NULL,
	[Monedas] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [EsAdministrador], [Monedas]) VALUES (2, N'binarycasper', N'ß.ú3_—bŒ£œŸïTi«<¸7', 0, 1000000)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
ALTER TABLE [dbo].[Caracteristicas]  WITH CHECK ADD  CONSTRAINT [FK_Caracteristicas_CaracteristicasCategorias] FOREIGN KEY([FkCategoria])
REFERENCES [dbo].[CaracteristicasCategorias] ([ID])
GO
ALTER TABLE [dbo].[Caracteristicas] CHECK CONSTRAINT [FK_Caracteristicas_CaracteristicasCategorias]
GO
ALTER TABLE [dbo].[PersonajeCaracteristica]  WITH CHECK ADD  CONSTRAINT [FK_Personaje-Caracteristica_Caracteristicas] FOREIGN KEY([fkCaracteristica])
REFERENCES [dbo].[Caracteristicas] ([IdCaract])
GO
ALTER TABLE [dbo].[PersonajeCaracteristica] CHECK CONSTRAINT [FK_Personaje-Caracteristica_Caracteristicas]
GO
ALTER TABLE [dbo].[PersonajeCaracteristica]  WITH CHECK ADD  CONSTRAINT [FK_Personaje-Caracteristica_Personajes] FOREIGN KEY([fkPersonaje])
REFERENCES [dbo].[Personajes] ([IdPers])
GO
ALTER TABLE [dbo].[PersonajeCaracteristica] CHECK CONSTRAINT [FK_Personaje-Caracteristica_Personajes]
GO
ALTER TABLE [dbo].[Personajes]  WITH CHECK ADD  CONSTRAINT [FK_Personajes_PersonajesCategorias] FOREIGN KEY([FkCategoria])
REFERENCES [dbo].[PersonajesCategorias] ([ID])
GO
ALTER TABLE [dbo].[Personajes] CHECK CONSTRAINT [FK_Personajes_PersonajesCategorias]
GO
ALTER TABLE [dbo].[Ranking]  WITH CHECK ADD  CONSTRAINT [FK_Ranking_Usuarios] FOREIGN KEY([ID])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Ranking] CHECK CONSTRAINT [FK_Ranking_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[EliminarCaracteristica]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarCaracteristica]
@idCaract int
	
AS
BEGIN
	
	delete from Caracteristicas 
	where IdCaract=@idCaract
    
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoriaP]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCategoriaP]
	-- Add the parameters for the stored procedure here
	@IDCat int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;			
			DELETE FROM PersonajesCategorias WHERE	PersonajesCategorias.ID = @IDcat
			--UPDATE Categorias SET Categorias.NombreCat = @NombreCat WHERE Categorias.IdCat = @IDcat;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarPersonaje]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarPersonaje]
	@id int
AS
BEGIN
 delete from Personajes where IdPers = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarUsuario]
	@id int
AS
BEGIN
	
delete from Usuarios
where id=@id

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarCaracteristica]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertarCaracteristica]
@idCaract int, @Nombre varchar(50), @Pregunta varchar(100), @fkCategoria int
	
AS
BEGIN
	
	insert into Caracteristicas (IdCaract, Nombre, Pregunta, FkCategoria) values (@idCaract, @Nombre, @Pregunta, @fkCategoria)
    
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarCategoriaP]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCategoriaP]
	-- Add the parameters for the stored procedure here
	@NombreCatPer varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			INSERT INTO PersonajesCategorias(PersonajeCategorias.Nombre) VALUES (@NombreCatPer)
			
			--DELETE FROM Categorias WHERE Categorias.IdCat = @IDcat
			--UPDATE Categorias SET Categorias.NombreCat = @NombreCat WHERE Categorias.IdCat = @IDcat;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarPersonaje]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPersonaje] 
@Nom varchar(50), @Cat int
AS
BEGIN
	insert into Personajes (Nombre, FkCategoria) values (@nom, @Cat);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertarUsuario]
@nombre varchar(50), @password varchar(50)
as
begin
	insert into Usuarios(Contraseña, Usuario, EsAdministrador, Monedas) values(HASHBYTES('SHA1', @password), @nombre, 0, 1000000)
end 
GO
/****** Object:  StoredProcedure [dbo].[ModificarCaracteristica]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarCaracteristica]

@idCaract int, @Nombre varchar(50), @Pregunta varchar(100), @fkCategoria int
AS
BEGIN
	
	update Caracteristicas 
	set  Nombre= @Nombre, Pregunta= @Pregunta, FkCategoria= @fkCategoria
	where IdCaract=@idCaract;
    
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarCategoriaP]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ModificarCategoriaP]
	-- Add the parameters for the stored procedure here
	@IDcatPer int, @NombreCatPer varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			--INSERT INTO PersonajesCategorias(PersonajeCategorias.Nombre) VALUES (@NombreCatPer)
			
			--DELETE FROM PersonajesCategorias WHERE PersonajesCategorias.ID = @IDcatPer
			UPDATE PersonajesCategorias SET PersonajesCategorias.Nombre = @NombreCatper WHERE PersonajesCategorias.Id = @IDcatPer;
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarPersonaje]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarPersonaje]
	@id int ,@Nom varchar(10)
AS
BEGIN
update Personajes set Nombre = @Nom where IdPers = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModificarUsuario]
	
	@id int, @Usuario varchar(50) , @contraseña varchar(50), @esAdministrador bit
AS
BEGIN
	
 UPDATE Usuarios
SET  Usuario = @Usuario, Contraseña=@contraseña, EsAdministrador= @esAdministrador
WHERE id=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCategoriaP]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ObtenerCategoriaP]
@id int
as
begin
	if (@id != null)
	begin
		select * from PersonajesCategorias where id = @id 
	end 
	else 
	begin 
		select * from PersonajesCategorias
	end
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPersonaje]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerPersonaje]
	@id int
AS
BEGIN
	select Nombre from Personajes where IdPers = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 18/10/2018 13:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ObtenerUsuario]
@nombre varchar(50), @password varchar(50) null, @accion varchar(50)
as
begin
	if (@accion = 'InicioSesion')
	begin
		select * from Usuarios 
		where Usuario = @nombre and Contraseña = HASHBYTES('SHA1', @password) 
	end 
	if (@accion = 'Registro')
	begin
		select * from Usuarios 
		where Usuario = @nombre
	end 
end
GO
USE [master]
GO
ALTER DATABASE [QEQC02] SET  READ_WRITE 
GO
