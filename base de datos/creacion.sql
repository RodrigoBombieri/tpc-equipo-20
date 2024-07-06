Create Database Ticketera
Go
Use Ticketera
Go
Create Table Provincias (
	ID smallint not null primary key identity (1, 1),
	Nombre varchar(100) not null
)
Go
Create Table Domicilios(
    	ID bigint not null primary key identity (1,1),
    	IDProvincia smallint not null foreign key references Provincias(ID),
    	Calle varchar(100) not null,
	Numero varchar(50) not null,
	Piso varchar(50) null,
	Departamento varchar(50) null,
    	Localidad varchar(100) not null,
	CodigoPostal varchar(50) not null,
	Observaciones varchar(200) null
)
Go
Create Table Clientes(
	ID bigint not null primary key identity (1, 1),
	IDDomicilio bigint not null foreign key references Domicilios(ID),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Dni varchar(15) not null unique,
	Telefono1 varchar(30) null,
	Telefono2 varchar(30) null,
	Email varchar(50) not null unique,
	FechaNacimiento date not null,
	FechaCreacion datetime not null
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
    Nombre varchar(100) not null,
	Vigencia smallint not null
)
Go
Create Table TiposIncidentes(
    ID smallint not null primary key identity (1, 1),
    Nombre varchar(100) not null,
	IDPrioridad smallint not null 
)
Go
Create Table TiposAcciones(
    ID smallint not null primary key identity (1, 1),
    Nombre varchar(100) not null,
	Automatico bit not null
)
Go
Create Table Incidentes(
	ID bigint not null primary key identity (1, 1),
    IDTipo smallint not null foreign key references TiposIncidentes(ID),
    IDPrioridad smallint not null foreign key references Prioridades(ID),
	IDEstado smallint not null foreign key references Estados(ID),
	IDCliente bigint not null foreign key references Clientes(ID),
	IDUsuario bigint not null foreign key references Usuarios(ID),
	Detalle varchar (200) null,
	FechaCreacion datetime not null,
	FechaCierre datetime null    
)
GO
Create Table Acciones(
    ID bigint not null primary key identity (1, 1),
	IDIncidente bigint not null foreign key references Incidentes(ID),
	IDUsuario bigint not null foreign key references Usuarios(ID),
	Fecha datetime not null,
    Detalle varchar(200) null,
	IDTipo smallint not null foreign key references TiposAcciones(ID),
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

insert into PRIORIDADES (Nombre,Vigencia)
select '',0 UNION
select 'Urgente',2 UNION
select 'Alta',4 UNION
select 'Media',6 UNION
select 'Baja',8 
GO

insert into TIPOSINCIDENTES (Nombre,IDPrioridad)
select '',1 UNION
select 'Producto dañado',3 UNION
select 'Problema en el cobro',4 UNION
select 'Entrega ok',5 UNION
select 'Garantia',2 UNION
select 'Entrega fallida',2 UNION
select 'Otro',5 
GO

insert into USUARIOS (IDRol, Nombre, Apellido, Nick, Dni, Telefono, Email, Pass) VALUES
(1, 'Admin', 'Admin', 'admin', '12345678', '12345678', 'admin@admin.com', 'admin'),
(3, 'Lucas', 'Saputo', 'lucasNick', '31146239', '123456789', 'tel@tel.com', 'admin'),
(2, 'María', 'Gómez', 'mariaG', '22222222', '223-5555555', 'maria@gmail.com', 'password'),
(2, 'Juan', 'López', 'juanL', '33333333', '223-6666666', 'juan@gmail.com', 'password'),
(3, 'Carlos', 'Rodríguez', 'carlosR', '44444444', '223-7777777', 'carlos@gmail.com', 'password'),
(2, 'Laura', 'Martínez', 'lauraM', '55555555', '223-8888888', 'laura@gmail.com', 'password'),
(2, 'Pedro', 'Sánchez', 'pedroS', '66666666', '223-9999999', 'pedro@gmail.com', 'password'),
(2, 'Ana', 'Gutiérrez', 'anaG', '77777777', '223-10101010', 'ana@gmail.com', 'password'),
(2, 'Sofía', 'Díaz', 'sofiaD', '88888888', '223-11111111', 'sofia@gmail.com', 'password'),
(3, 'Jorge', 'Hernández', 'jorgeH', '99999999', '223-12121212', 'jorge@gmail.com', 'password'),
(2, 'Gabriela', 'Pérez', 'gabrielaP', '10101010', '223-13131313', 'gabriela@gmail.com', 'password'),
(2, 'Martín', 'Torres', 'martinT', '11111111', '223-14141414', 'martin@gmail.com', 'password');
GO

insert into PROVINCIAS (Nombre)
select 'Buenos Aires' UNION
select 'Capital Federal' UNION
select 'Catamarca' UNION
select 'Chaco' UNION
select 'Chubut' UNION
select 'Córdoba' UNION
select 'Corrientes' UNION
select 'Entre Ríos' UNION
select 'Formosa' UNION
select 'Jujuy' UNION
select 'La Pampa' UNION
select 'La Rioja' UNION
select 'Mendoza' UNION
select 'Misiones' UNION
select 'Neuquén' UNION
select 'Río Negro' UNION
select 'Salta' UNION
select 'San Juan' UNION
select 'San Luis' UNION
select 'Santa Cruz' UNION
select 'Santa Fe' UNION
select 'Santiago del Estero' UNION
select 'Tierra del Fuego' UNION
select 'Tucumán'
GO

insert into DOMICILIOS (IDProvincia, Calle, Numero, Piso, Departamento, Localidad, CodigoPostal) VALUES
(2, 'Pichincha', '410', '4', 'E', 'CABA', '1082'),
(1, 'Libres del Sud', '523', null, null, 'Mar del Plata', '7600'),
(1, 'Moreno', '3730', null, null, 'Mar del Plata', '7600'),
(3, 'Belgrano', '123', '1', 'A', 'Resistencia', '3500'),
(4, 'San Martín', '456', null, null, 'Sáenz Peña', '3700'),
(5, 'Roca', '789', '2', 'B', 'Comodoro Rivadavia', '9000'),
(6, 'Rivadavia', '1011', null, null, 'Córdoba', '5000'),
(7, 'San Juan', '1213', null, null, 'Corrientes', '3400'),
(8, 'San Martín', '1415', null, null, 'Paraná', '3100'),
(9, 'San Juan', '1617', '3', 'C', 'Formosa', '3600'),
(10, '9 de Julio', '1819', null, null, 'San Salvador de Jujuy', '4600'),
(11, 'Mitre', '2021', null, null, 'Santa Rosa', '6300'),
(12, 'Moreno', '2223', '4', 'D', 'La Rioja', '5300'),
(13, 'Belgrano', '2425', null, null, 'Mendoza', '5500'),
(14, 'San Martín', '2627', null, null, 'Posadas', '3300'),
(15, 'Roca', '2829', '5', 'E', 'Neuquén', '8300'),
(16, 'Rivadavia', '3031', null, null, 'Viedma', '8500'),
(17, 'San Juan', '3233', null, null, 'Salta', '4400'),
(18, 'San Martín', '3435', '6', 'F', 'San Juan', '5400'),
(19, 'San Juan', '3637', null, null, 'San Luis', '5700'),
(20, '9 de Julio', '3839', null, null, 'Río Gallegos', '9400');
GO

insert into CLIENTES (IDDomicilio, Nombre, Apellido, Dni, Telefono1, Email, FechaNacimiento, FechaCreacion) VALUES
(1, 'Franco', 'Cataldo', '37719580', '223-4374184', 'francocataldo7@gmail.com', '1992-10-12', '2024-06-08 21:13:30.007'),
(2, 'Florencia', 'Cataldo', '1111111', '223-6332691', 'florenciacataldo@gmail.com', '1994-07-03', '2024-06-08 21:13:30.007'),
(3, 'Nilda', 'Cataldo', '22222222', '223-5046121', 'nildacataldo@gmail.com', '1956-07-04', '2024-06-08 21:13:30.007'),
(4, 'Marcelo', 'López', '12345678', '223-5555555', 'marcelo@gmail.com', '1980-03-15', '2024-06-08 21:13:30.007'),
(5, 'Lucía', 'Gómez', '23456789', '223-6666666', 'lucia@gmail.com', '1995-04-20', '2024-06-08 21:13:30.007'),
(6, 'Martina', 'Rodríguez', '34567890', '223-7777777', 'martina@gmail.com', '1992-12-30', '2024-06-08 21:13:30.007'),
(7, 'Mariano', 'Martínez', '45678901', '223-8888888', 'mariano@gmail.com', '1988-08-08', '2024-06-08 21:13:30.007'),
(8, 'Micaela', 'Sánchez', '56789012', '223-9999999', 'micaela@gmail.com', '1999-09-09', '2024-06-08 21:13:30.007'),
(9, 'Manuel', 'Gutiérrez', '67890123', '223-10101010', 'manuel@gmail.com', '1985-05-25', '2024-06-08 21:13:30.007'),
(10, 'Miranda', 'Díaz', '78901234', '223-11111111', 'miranda@gmail.com', '1976-07-07', '2024-06-08 21:13:30.007'),
(11, 'Maximiliano', 'Hernández', '89012345', '223-12121212', 'maximiliano@gmail.com', '1990-01-01', '2024-06-08 21:13:30.007'),
(12, 'Mariana', 'Pérez', '90123456', '223-13131313', 'mariana@gmail.com', '1982-02-14', '2024-06-08 21:13:30.007'),
(13, 'Miguel', 'Torres', '01234567', '223-14141414', 'miguel@gmail.com', '1987-11-11', '2024-06-08 21:13:30.007');
GO


insert into Incidentes (IDTipo, IDPrioridad, IDEstado, IDCliente, IDUsuario, Detalle, FechaCreacion)
values
(1, 2, 3, 1, 1, 'Producto defectuoso recibido', '2024-07-02 17:07:14.733'),
(3, 1, 2, 2, 1, 'Error en el cobro de la factura electrónica', '2024-07-03 10:15:20.000'),
(4, 3, 1, 3, 1, 'Problema con la entrega a domicilio', '2024-07-04 12:30:45.000'),
(5, 2, 3, 1, 1, 'Problema con la garantía del producto', '2024-07-05 14:45:55.000'),
(1, 4, 4, 2, 1, 'Devolución de producto defectuoso', '2024-07-06 16:00:00.000'),
(2, 4, 5, 5, 2, 'Producto recibido dañado nuevamente', '2024-07-06 17:00:00.000'),
(3, 3, 2, 6, 3, 'Problema en cobro de factura de servicio adicional', '2024-07-06 18:00:00.000'),
(4, 2, 3, 7, 4, 'Entrega realizada correctamente pero con retraso', '2024-07-06 19:00:00.000'),
(5, 1, 4, 8, 5, 'Garantía vencida extendida', '2024-07-06 20:00:00.000'),
(6, 2, 1, 9, 6, 'Entrega fallida por ausencia no notificada', '2024-07-06 21:00:00.000'),
(2, 3, 5, 10, 7, 'Producto defectuoso con problemas graves', '2024-07-06 22:00:00.000'),
(3, 2, 2, 11, 8, 'Error en el monto cobrado por desajuste', '2024-07-06 23:00:00.000'),
(4, 1, 3, 12, 9, 'Entrega ok, pero con incidente menor', '2024-07-06 10:00:00.000'),
(5, 4, 4, 13, 10, 'Garantía extendida por solicitud especial', '2024-07-06 11:00:00.000'),
(1, 2, 1, 4, 1, 'Producto dañado al recibirlo inicialmente', '2024-07-06 12:00:00.000');

GO

insert into TiposAcciones (Nombre, Automatico)
values
('',0),
('Alta de incidente',1),
('Cierre de incidente',1),
('Resolución de incidente',1),
('Reapertura de incidente',1),
('Reasignación de usuario',0),
('Contacto del cliente',0),
('Contacto del telefonista',0),
('Cambio de instrumento de cobro',0),
('Seguimiento',0),
('Visita del servicio técnico',0),
('Cambio de prioridad/tipo',1),
('Otro',0)
GO