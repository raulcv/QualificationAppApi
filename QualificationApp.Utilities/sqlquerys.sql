use master
go
drop database if exists QualificaionDB;
create database QualificaionDB
go
use QualificaionDB
go
create schema Auditoria authorization dbo;
go
create schema Maestro authorization dbo;
go
create schema Transaccion authorization dbo;
go

create table Maestro.CorrelativoGeneral(
IdProceso varchar(10) primary key,
IdTipoTabla char(2) not null,
Nombre varchar(100) not null,
Estado char(1) not null,
NombreAlterno varchar(100) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
)

create table Transaccion.Tabla(
IdTabla varchar(10) primary key,
IdTipoTabla char(2) not null,
Nombre varchar(100) not null,
Estado char(1) not null,
NombreAlterno varchar(100) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
)
create table Maestro.Pais(
IdPais int primary key identity(1,1),
Nombre varchar(200) not null,
Abreviado char(3) not null,
Gentilicio varchar(100) not null,
Estado char(1) not null,
UsuarioCreacion varchar(20) not null,
FechaCreacion datetime not null,
UsuarioEdicion varchar(20) not null,
FechaEdicion datetime not null
)
create table Maestro.Ocupacion(
IdOcupacion int identity(1,1) primary key,
Descripcion varchar(100) not null,
Estado char(1) not null,
UsuarioCreacion varchar(20) not null,
FechaCreacion datetime not null,
UsuarioEdicion varchar(20) not null,
FechaEdicion datetime not null
)
insert Maestro.Ocupacion values('Engineer','A','Raulcv',getdate(),'Raulcv',getdate())
create table Maestro.Area(
IdArea varchar(12) primary key,
Nombre varchar(100) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
)

create table Maestro.PersonaOcupacion (
IdPersona varchar(10) not null,
IdOcupacion varchar(12) not null,
Descripcion varchar(100) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
primary key(IdPersona, IdOcupacion)
)

create table Maestro.Persona (
IdPersona varchar(12) primary key,
Nombre varchar(50) not null,
ApellidoPaterno varchar(100) not null,
ApellidoMaterno varchar(100) not null,
Genero CHAR(1) not null,
IdOcupacion varchar(12) not null,
IdArea varchar(10) not null,
IdEstadoCivil varchar(10) not null,
IdPais varchar(10) not null,
FechaNacimiento date not null,
UserCreation datetime not null,
DateCreation datetime not null,
UserEdition datetime not null,
DateEdition datetime not null,
foreign key (IdOcupacion) references Maestro.Ocupacion,
foreign key (IdArea) references Maestro.Area,
foreign key (IdEstadoCivil) references Maestro.Tabla,
foreign key (IdPais) references Mestro.Pais
)

create table Maestro.Puntuacion(
IdPuntuacion varchar(10) primary key,
Descripcion varchar(50) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
)

create table Maestro.Competencias(
IdCompetencia varchar(10) primary key,
Nombre varchar(50) not null,
Descripcion varchar(200) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
)

create table Maestro.Preguntas(
IdPregunta varchar(10) primary key,
Descripcion varchar(2000) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
)

create table Maestro.Jerarquia(
IdJerarquia varchar(10) primary key,
Nombre varchar(50) not null,
Descripcion varchar(2000) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null
);

create table Transaccion.Encuesta(
IdEncuesta varchar(10) primary key,
IdProceso varchar(8) not null,
IdEvaluador varchar(12) not null,
IdEvaluado varchar(12) not null,
IdJerarquia varchar(10) not null,
Descripcion varchar(2000) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null,
foreign key (IdProceso) references Mestro.Tabla,
foreign key (IdEvaluador) references Mestro.Persona,
foreign key (IdEvaluado) references Mestro.Persona,
foreign key (IdJerarquia) references Mestro.Jerarquia
);

create table Transaccion.DetalleEncuesta(
IdEncuesta varchar(10) not null,
IdPregunta varchar(12) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null,
primary key (IdEncuesta, IdPregunta),
);

create table Transaccion.Respuesta(
IdRespuesta varchar(10) primary key,
IdEncuesta varchar(10) not null,
IdPregunta varchar(10) not null,
IdPuntuacion varchar(10) not null,
Observacion varchar(2000) not null,
Estado char(1) not null,
UsuarioCreation datetime not null,
FechaCreation datetime not null,
UsuarioEdition datetime not null,
FechaEdition datetime not null,
foreign key (IdEncuesta) references Transaccion.Tabla,
foreign key (IdPregunta) references Mestro.Pregunta,
foreign key (IdPuntuacion) references Mestro.Puntuacion,
);
create table Maestro.Usuario
(
IdUsuario	int primary key identity(1,1),
Nombre	varchar(255) not null,
Apellido	varchar(255)	not null,
Imagen	varchar(255),
NombreUsuario	varchar(100) not null unique,
Email	varchar(255)	not null,
Password	varchar(255)	not null,
Salt	varchar(250)	not null,
Estado	char(1)	not null,
UsuarioCreacion	varchar(20)	not null,
FechaCreacion	datetime	not null,
UsuarioEdicion	varchar(20)	not null,
FechaEdicion	datetime	not null
)

select * from Maestros.PersonaOcupacion

select * from DB_Calificacion.Maestro.Pais
INSERT INTO DB_Calificacion.Maestro.Pais(Nombre, Abreviado, Gentilicio, Estado, UsuarioCreacion, FechaCreacion, UsuarioEdicion, FechaEdicion)
select Nombre, CodIso3, Gentilicio, Estado, 'RVALERIANO', getdate(), 'RVALERIANO', getdate() from BD_COMERCIAL_DESA.Maestros.Pais WHERE Nombre<>'-' order by Nombre asc

Server=181.224.226.108;Initial Catalog=DB_Calificacion;User Id=rcvQualificationApi;Password=Ipassword;


create table Auditoria.ExceptionLog
(
Id int primary key identity(1,1),
Host varchar(100),
Url varchar(1500),
Mensaje varchar(max),
Usuario varchar(250),
Fecha datetime
)
go
/***********************************/
create proc [Auditoria].[usp_RegistrarAuditoria]
@Host varchar(100),
@Url varchar(1500),
@Mensaje varchar(max),
@Usuario varchar(250)
as  
begin  
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200), Retorno1 varchar(20))  
  insert into Auditoria.ExceptionLog (Host,Url,Mensaje,Usuario,Fecha)
  values(@Host, @Url, @Mensaje, @Usuario, getdate())
  select @@identity Id
end
go
/********************************* USUARIO *******************************/
create proc [Maestro].[usp_CrearUsuario]
@Nombre varchar(255),
@Apellido varchar(255),
@Imagen varchar(255),
@NombreUsuario varchar(100),
@Email varchar(255),
@Password varchar(255),
@Estado char(1),
@Salt varchar(250),
@Usuario varchar(20)  
as  
begin  
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200), Retorno1 varchar(20))  
  insert into Maestro.Usuario (Nombre,Apellido,Imagen,NombreUsuario, Email,Password,Salt,Estado,UsuarioCreacion,FechaCreacion,UsuarioEdicion,FechaEdicion)
  values(@Nombre, @Apellido, @Imagen, @NombreUsuario, @Email, @Password, @Salt, @Estado, @Usuario, getdate(), @Usuario, getdate())
  insert into @tbRespuesta values(1, 'Usuario created successfully!', convert(varchar(20),@@identity));  
  select Resultado, Mensaje, Retorno1 from @tbRespuesta  
end
go

create proc [Maestro].[usp_ModificarUsuario]
@IdUsuario int,
@Nombre varchar(255),
@Apellido varchar(255),
@Imagen varchar(255),
@Email varchar(255),
@Password varchar(255),
@Estado char(1),  
@Usuario varchar(20)  
as  
begin  
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200))  
  update Maestro.Usuario set Nombre=@Nombre, Apellido=@Apellido, Imagen=@Imagen, Estado=@Estado, UsuarioEdicion=@Usuario, FechaEdicion=getdate() where IdUsuario=@IdUsuario
  insert into @tbRespuesta values(1, 'Usuario modificado successfully!');  
  select Resultado, Mensaje from @tbRespuesta  
end
go

create proc [Maestro].[usp_EliminarUsuario]
@IdUsuario int
as  
begin  
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200))  
  delete Maestro.Usuario where IdUsuario=@IdUsuario
  insert into @tbRespuesta values(1, 'Usuario Eliminado successfully!');  
  select Resultado, Mensaje from @tbRespuesta  
end
go

create proc [Maestro].[usp_ListarUsuario]
@IdUsuario int = 0
as
begin
	select IdUsuario, Nombre, Apellido, Imagen, NombreUsuario, Email, [Password], Salt, Estado, UsuarioCreacion, FechaCreacion, UsuarioEdicion, FechaEdicion from Maestro.Usuario where IdUsuario = @IdUsuario or @IdUsuario = 0
end
go

create proc [Maestro].[usp_ObtenerUsuario]
@Usuario varchar(100)
as
begin
 select IdUsuario, Nombre, Apellido, Imagen, NombreUsuario, Email, Password, Salt, Estado, UsuarioCreacion, FechaCreacion, UsuarioEdicion, FechaEdicion from Maestro.Usuario where Email = @Usuario or NombreUsuario = @Usuario
end


/********************************* OCUPACION *******************************/
create proc [Maestro].[usp_CrearOcupacion]  
@Descripcion varchar(100),  
@Estado char(1),  
@Usuario varchar(20)  
as  
begin  
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200), Retorno1 varchar(20))  
  insert into Maestro.Ocupacion(Descripcion,Estado, UsuarioCreacion, FechaCreacion, UsuarioEdicion, FechaEdicion)  
  values(@Descripcion, @Estado, @Usuario, getdate(), @Usuario, getdate())  
  insert into @tbRespuesta values(1, 'Ocupacion created successfully!', convert(varchar(20), @@IDENTITY));  
  select Resultado, Mensaje, Retorno1 from @tbRespuesta  
end
go

create proc [Maestro].[usp_ModificarOcupacion]  
@IdOcupacion int,  
@Descripcion varchar(100),  
@Estado char(1),  
@Usuario varchar(20)  
as  
begin  
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200))  
  update Maestro.Ocupacion set Descripcion=@Descripcion, Estado=@Estado, UsuarioEdicion=@Usuario, FechaEdicion=getdate() where IdOcupacion=@IdOcupacion  
  insert into @tbRespuesta values(1, 'Ocupacion modificado successfully!');  
  select Resultado, Mensaje from @tbRespuesta  
end
go

create proc [Maestro].[usp_EliminarOcupacion]
@IdOcupacion int
as
begin
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200))
  delete Maestro.Ocupacion where IdOcupacion=@IdOcupacion
  insert into @tbRespuesta values(1, 'Ocupacion Eliminado successfully!');
  select Resultado, Mensaje from @tbRespuesta
end
go

create proc [Maestro].[usp_ListarOcupacion]  
@IdOcupacion int = 0  
as  
begin  
  select o.IdOcupacion, o.Descripcion, o.Estado, o.UsuarioCreacion, o.FechaCreacion, o.UsuarioEdicion, o.FechaEdicion  
  from Maestro.Ocupacion o where o.IdOcupacion = @IdOcupacion or @IdOcupacion = 0  
end
go

/********************************* PAIS *******************************/
create proc [Maestro].[usp_CrearPais]
@Nombre varchar(100),
@Abreviado varchar(100),
@Gentilicio varchar(50),
@Estado char(1),
@Usuario varchar(20)
as
begin
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200), Retorno1 varchar(20))
  insert into Maestro.Pais(Nombre, Abreviado, Gentilicio, Estado, UsuarioCreacion, FechaCreacion, UsuarioEdicion, FechaEdicion)
  values(@Nombre, @Abreviado, @Gentilicio, @Estado, @Usuario, getdate(), @Usuario, getdate())
  insert into @tbRespuesta values(1, 'Pais created successfully!', convert(varchar(20),@@identity));
  select Resultado, Mensaje, Retorno1 from @tbRespuesta
end
go

create proc [Maestro].[usp_ModificarPais]
@IdPais int,
@Nombre varchar(100),
@Abreviado varchar(100),
@Gentilicio varchar(50),
@Estado char(1),
@Usuario varchar(20)
as
begin
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200))
  update Maestro.Pais set Nombre = @Nombre, Abreviado=@Abreviado, Gentilicio=@Gentilicio, Estado=@Estado, UsuarioEdicion=@Usuario, FechaEdicion=getdate()
  where IdPais = @IdPais
  insert into @tbRespuesta values(1, 'Pais updated successfully!');
  select Resultado, Mensaje from @tbRespuesta
end
go

create proc [Maestro].[usp_EliminarPais]
@IdPais int
as
begin
  declare @tbRespuesta as table (Resultado int, Mensaje varchar(200))
  delete Maestro.Pais where IdPais = @IdPais
  insert into @tbRespuesta values(1, 'Pais updated successfully!');
  select Resultado, Mensaje from @tbRespuesta
end
go

create proc [Maestro].[usp_ListarPais]
@IdPais int = 0
as
begin
  select p.IdPais, p.Nombre, p.Abreviado, p.Gentilicio, p.Estado, p.UsuarioCreacion, p.FechaCreacion, p.UsuarioEdicion, p.FechaEdicion
  from Maestro.Pais p where p.IdPais = @IdPais or @IdPais = 0
end
/**************************************************************************************************************************/
/* personal notes
credentias are in local txt file
*/