Create Database TPC
Go
Use TPC
Go
Create Table Clientes(
	ID bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Dni varchar(15) not null unique,
	Telefono varchar(30) null,
	Email varchar(50) not null unique,
	FechaNacimiento date null,
	FechaCreacion date not null
)
Go
Create Table Roles(
    ID int not null primary key identity (1, 1),
    Nombre varchar(100) not null
)
Go
Create Table Usuarios(
	ID bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nick varchar(100) not null,
	Dni varchar(15) not null unique,
	Telefono varchar(30) null,
	Email varchar(50) not null unique,
	Pass varchar(100) not null,
	IDRol int not null foreign key references Roles(ID),
)
Go
Create Table Paises (
	ID smallint not null primary key identity (1, 1),
	Nombre varchar(100) not null
)
Go
Create Table Localidades(
	ID smallint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	IDPais smallint not null foreign key references Paises(ID),
)
Go
Create Table Domicilios(
    ID bigint not null primary key foreign key references Clientes(ID),
    Calle varchar(50) not null,
	Numero smallint not null,
	Piso tinyint not null,
	Departamento tinyint not null,
	Observaciones varchar(200) not null,
	IDLocalidad smallint not null foreign key references Localidades(ID),
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
Create Table TiposIncidentes(
    ID smallint not null primary key identity (1, 1),
    Nombre varchar(100) not null
)
Go
Create Table Incidentes(
	ID bigint not null primary key identity (1, 1),
    IDTipo smallint not null foreign key references TiposIncidentes(ID),
    IDPrioridad smallint not null foreign key references Prioridades(ID),
	IDEstado smallint not null foreign key references Estados(ID),
	Detalle varchar (200) not null,
	UsuarioAsignado bigint not null foreign key references Usuarios(ID),
	UsuarioCreador bigint not null foreign key references Usuarios(ID),
)
GO