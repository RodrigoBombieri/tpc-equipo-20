Create Database Ticketera
Go
Use Ticketera
Go
Create Table Paises (
	ID smallint not null primary key identity (1, 1),
	Nombre varchar(100) not null
)
Go
Create Table Provincias (
	ID smallint not null primary key identity (1, 1),
	IDPais smallint not null foreign key references Paises(ID),
	Nombre varchar(100) not null
)
Go
Create Table Localidades(
	ID smallint not null primary key identity (1, 1),
	IDProvincia smallint not null foreign key references Provincias(ID),
	Nombre varchar(100) not null,
	CodigoPostal varchar(50) not null
)
Go
Create Table Domicilios(
    ID bigint not null primary key identity (1,1),
    IDLocalidad smallint not null foreign key references Localidades(ID),
    Calle varchar(100) not null,
	Numero varchar(50) not null,
	Piso varchar(50) null,
	Departamento varchar(50) null,
	Observaciones varchar(200) null
)
Go
Create Table Clientes(
	ID bigint not null primary key identity (1, 1),
	IDDomicilio bigint not null foreign key references Domicilios(ID),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Dni varchar(15) not null unique,
	Telefono varchar(30) null,
	Email varchar(50) not null unique,
	FechaNacimiento date not null,
	FechaCreacion date not null
)
Go
Create Table Roles(
    ID smallint not null primary key identity (1, 1),
    Nombre varchar(100) not null
)
Go
Create Table Usuarios(
	ID bigint not null primary key identity (1, 1),
	IDRol smallint not null foreign key references Roles(ID),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nick varchar(100) not null,
	Dni varchar(15) not null unique,
	Telefono varchar(30) null,
	Email varchar(50) not null unique,
	Pass varchar(100) not null,
	urlImagenPerfil varchar(500) null
)
Go
Create Table Estados(
    ID smallint not null primary key identity (1, 1),
    Nombre varchar(100) not null
)
Go
Create Table Prioridades(
    ID smallint not null primary key identity (1, 1),
    Nombre varchar(100) not null
)
Go
Create Table TiposIncidente(
    ID smallint not null primary key identity (1, 1),
    Nombre varchar(100) not null
)
Go
Create Table Incidentes(
	ID bigint not null primary key identity (1, 1),
    IDTipo smallint not null foreign key references TiposIncidente(ID),
    IDPrioridad smallint not null foreign key references Prioridades(ID),
	IDEstado smallint not null foreign key references Estados(ID),
	UsuarioAsignado bigint not null foreign key references Usuarios(ID),
	UsuarioCreador bigint not null foreign key references Usuarios(ID),
	Detalle varchar (200) not null,
	FechaCreacion date not null,
	FechaCierre date not null    
)
GO
Create Table Eventos(
    ID bigint not null primary key identity (1, 1),
	IDIncidente bigint not null foreign key references Incidentes(ID),
	FechaCreacion date not null,   
    Detalle varchar(200) not null
)
GO

insert into ROLES values ('Administrador'), ('Telefonista'), ('Supervisor')
insert into ESTADOS values ('Abierto'), ('En análisis'), ('Cerrado'), ('Reabierto'), ('Asignado'), ('Resuelto')
insert into PRIORIDADES values ('Urgente'), ('Alta'), ('Media'), ('Baja')
insert into TIPOSINCIDENTE values ('Producto dañado'), ('Problema en el cobro'), ('Entrega fallida'), ('Otro')
insert into USUARIOS values (1, 'Admin', 'Admin', 'admin', '12345678', '12345678', 'admin@admin.com', 'admin', null)