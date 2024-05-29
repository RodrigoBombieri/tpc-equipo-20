Create Database TPC
Go
Use TPC
Go
Create Table Clientes(
	ID bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Dni tinyint not null,
	Telefono tinyint null,
	Email varchar(50) null,
	FechaNacimiento date null,
	FechaCreacion date not null
)
Go
Create Table Usuarios(
	ID bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nick varchar(100) not null,
	Dni tinyint not null,
	Telefono tinyint null,
	Email varchar(50) null,
	Pass varchar(100) not null,
)
Go
Create Table Domicilios(
    ID bigint not null primary key identity (1, 1),
    Calle varchar(50) not null,
	Numero smallint not null,
	Piso tinyint not null,
	Departamento tinyint not null,
	Observaciones varchar(200) not null,
	Localidad smallint not null,
	Provincia smallint not null,
	Pais smallint not null,
	CodigoPostal varchar(50) null
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
Create Table Roles(
    ID int not null primary key identity (1, 1),
    Nombre varchar(100) not null
)
Go
Create Table Incidentes(
	ID bigint not null primary key identity (1, 1),
    Tipo smallint not null foreign key references TiposIncidentes(ID),
    Prioridad smallint not null foreign key references Prioridades(ID),
	Estado smallint not null foreign key references Estados(ID),
	Detalle varchar (200) not null,
	UsuarioAsignado bigint not null foreign key references Usuarios(ID),
	UsuarioCreador bigint not null foreign key references Usuarios(ID),
)