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

insert into ROLES (Nombre)
select 'Administrador' UNION
select 'Telefonista' UNION
select 'Supervisor'
GO

insert into ESTADOS (Nombre)
select 'Abierto' UNION
select 'En análisis' UNION
select 'Cerrado' UNION
select 'Reabierto' UNION
select 'Asignado' UNION
select 'Resuelto' 
GO

insert into PRIORIDADES (Nombre)
select 'Urgente' UNION
select 'Alta' UNION
select 'Media' UNION
select 'Baja' 
GO

insert into TIPOSINCIDENTE (Nombre)
select 'Producto dañado' UNION
select 'Problema en el cobro' UNION
select 'Entrega fallida' UNION
select 'Otro' 
GO

insert into USUARIOS (IDRol, Nombre, Apellido, Nick, Dni, Telefono, Email, Pass)
select 1, 'Admin', 'Admin', 'admin', '12345678', '12345678', 'admin@admin.com', 'admin'
GO

insert into PAISES (Nombre)
select 'Argentina' UNION
select 'Bolivia' UNION
select 'Chile' UNION
select 'Colombia' UNION
select 'Ecuador' UNION
select 'Paraguay' UNION
select 'Perú' UNION
select 'Uruguay' UNION
select 'Venezuela'
GO

insert into PROVINCIAS (IDPais, Nombre)
select 1, 'Buenos Aires' UNION
select 1, 'Capital Federal' UNION
select 1, 'Catamarca' UNION
select 1, 'Chaco' UNION
select 1, 'Chubut' UNION
select 1, 'Córdoba' UNION
select 1, 'Corrientes' UNION
select 1, 'Entre Ríos' UNION
select 1, 'Formosa' UNION
select 1, 'Jujuy' UNION
select 1, 'La Pampa' UNION
select 1, 'La Rioja' UNION
select 1, 'Mendoza' UNION
select 1, 'Misiones' UNION
select 1, 'Neuquén' UNION
select 1, 'Río Negro' UNION
select 1, 'Salta' UNION
select 1, 'San Juan' UNION
select 1, 'San Luis' UNION
select 1, 'Santa Cruz' UNION
select 1, 'Santa Fe' UNION
select 1, 'Santiago del Estero' UNION
select 1, 'Tierra del Fuego' UNION
select 1, 'Tucumán'
GO

insert into LOCALIDADES (IDProvincia, Nombre, CodigoPostal)
select 2, 'Capital Federal', '1084' UNION
select 1, 'Mar del Plata', '7600'
GO

insert into DOMICILIOS (IDLocalidad, Calle, Numero, Piso, Departamento) 
select 1, 'Pichincha', '410', '4', 'E' UNION
select 2, 'Libres del Sud', '523', null, null UNION
select 2, 'Moreno', '3730', null, null
GO

insert into CLIENTES (IDDomicilio, Nombre, Apellido, Dni, Telefono, Email, FechaNacimiento, FechaCreacion)
select 1, 'Franco', 'Cataldo', '37719580', '223-4374184', 'francocataldo7@gmail.com', '1992-10-12', '2024-06-08' UNION
select 2, 'Florencia', 'Cataldo', '1111111', '223-6332691', 'florenciacataldo@gmail.com', '1994-07-03', '2024-06-08' UNION
select 3, 'Nilda', 'Cataldo', '22222222', '223-5046121', 'nildacataldo@gmail.com', '1956-07-04', '2024-06-08'
GO

