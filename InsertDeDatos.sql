USE GestionDeposito
GO 
SET DATEFORMAT DMY
GO


-- INSERTS TIPOS DE MOVIMIENTO
INSERT INTO TiposMovimiento (NombreTipoMovimiento_Valor, EsIncremento) 
			VALUES ('Venta', 0),
				('Devolución', 1),
				('Compra', 1)



-- INSERTS ARTICULO
/*PROMPT: puedes crear 80 registros con similares propiedades para una papeleria: 
	INSERT INTO Articulos (Nombre_Valor, Descripcion_Valor, CodigoArticulo_Valor, Precio_Valor, Stock_Valor)
					VALUES('Lapicera BIC', 'Caja lapicera azul de uso general', 0000000000001, 876,  20)*/

INSERT INTO Articulos (Nombre_Valor, Descripcion_Valor, CodigoArticulo_Valor, Precio_Valor, Stock_Valor, ParametroId)
VALUES
    ('Lapicera BIC', 'Caja lapicera azul de uso general', 0000000000001, 876, 100, 1),
    ('Cuaderno Norma', 'Cuaderno universitario de 100 hojas', 0000000000002, 234, 100, 2),
    ('Resaltador Faber-Castell', 'Resaltador color amarillo', 0000000000003, 123, 100, 3),
    ('Borrador Pelikan', 'Borrador para lápiz y tinta', 0000000000004, 45, 100, 4),
    ('Tijeras Maped', 'Tijeras escolares 13 cm', 0000000000005, 321, 100, 5),
    ('Pegamento Pritt', 'Pegamento en barra 22g', 0000000000006, 98, 100, 6),
    ('Marcador Sharpie', 'Marcador permanente negro', 0000000000007, 65, 100, 7),
    ('Carpeta A4', 'Carpeta tamaño A4 color rojo', 0000000000008, 189, 100, 8),
    ('Regla Staedtler', 'Regla de 30 cm transparente', 0000000000009, 37, 100, 9),
    ('Corrector Paper Mate', 'Corrector líquido 20ml', 0000000000010, 56, 100, 10),
    ('Calculadora Casio', 'Calculadora científica FX-82', 0000000000011, 1290, 100, 11),
    ('Agenda Moleskine', 'Agenda diaria 2024', 0000000000012, 654, 100, 12),
    ('Pluma Parker', 'Pluma estilográfica negra', 0000000000013, 8765, 100, 13),
    ('Cuaderno Scribe', 'Cuaderno profesional 200 hojas', 0000000000014, 320, 100, 14),
    ('Goma Eva', 'Lámina de goma eva color verde', 0000000000015, 15, 100, 15),
    ('Cartulina', 'Cartulina blanca tamaño carta', 0000000000016, 5, 100, 16),
    ('Lápiz de color Prismacolor', 'Caja de 24 lápices de colores', 0000000000017, 789, 100, 17),
    ('Libro de colorear', 'Libro para colorear infantil', 0000000000018, 120, 100, 18),
    ('Bolsa para regalo', 'Bolsa de regalo tamaño mediano', 0000000000019, 45, 100, 19),
    ('Papel crepé', 'Rollo de papel crepé azul', 0000000000020, 12, 100, 20),
    ('Bolígrafo Pilot', 'Bolígrafo de gel negro', 0000000000021, 34, 100, 21),
    ('Rotulador Bic', 'Rotulador de pizarra blanca', 0000000000022, 65, 100, 22),
    ('Estuche Kimmidoll', 'Estuche escolar con diseño', 0000000000023, 210, 100, 23),
    ('Compás Staedtler', 'Compás escolar metálico', 0000000000024, 98, 100, 24),
    ('Lápiz mecánico Pentel', 'Lápiz mecánico 0.5 mm', 0000000000025, 76, 100, 25),
    ('Papel fotocopia', 'Resma de papel A4 500 hojas', 0000000000026, 250, 100, 26),
    ('Tijeras Titanium', 'Tijeras de acero inoxidable 20 cm', 0000000000027, 180, 100, 27),
    ('Cuaderno de dibujo', 'Cuaderno de dibujo espiralado', 0000000000028, 150, 100, 28),
    ('Pegamento UHU', 'Pegamento líquido 33ml', 0000000000029, 110, 100, 29),
    ('Regla metálica', 'Regla de acero inoxidable 50 cm', 0000000000030, 75, 100, 30),
    ('Portaminas Faber-Castell', 'Portaminas con goma', 0000000000031, 80, 100, 31),
    ('Plastilina', 'Caja de plastilina 12 colores', 0000000000032, 70, 100, 32),
    ('Papel Kraft', 'Rollo de papel kraft 1m', 0000000000033, 45, 100, 33),
    ('Cuaderno cuadriculado', 'Cuaderno cuadriculado 100 hojas', 0000000000034, 190, 100, 34),
    ('Sacapuntas metálico', 'Sacapuntas doble uso', 0000000000035, 23, 100, 35),
    ('Tinta Epson', 'Botella de tinta negra 100ml', 0000000000036, 140, 100, 36),
    ('Block de notas', 'Block de notas adhesivas', 0000000000037, 65, 100, 37),
    ('Cuadro de corcho', 'Tablero de corcho 60x90 cm', 0000000000038, 450, 100, 38),
    ('Carpeta de anillas', 'Carpeta de anillas A4 azul', 0000000000039, 170, 100, 39),
    ('Cinta adhesiva', 'Rollo de cinta adhesiva 50m', 0000000000040, 30, 100, 40),
    ('Perforadora', 'Perforadora de 2 agujeros', 0000000000041, 120, 100, 41),
    ('Grapas', 'Caja de grapas N° 10', 0000000000042, 20, 100, 42),
    ('Portafolios', 'Portafolios de plástico A4', 0000000000043, 80, 100, 43),
    ('Papel de regalo', 'Rollo de papel de regalo', 0000000000044, 35, 100, 44),
    ('Marcador de pizarra', 'Marcador borrable negro', 0000000000045, 55, 100, 45),
    ('Cinta correctora', 'Cinta correctora de 10m', 0000000000046, 45, 100, 46),
    ('Pinceles', 'Set de 5 pinceles variados', 0000000000047, 150, 100, 47),
    ('Hojas para álbum', 'Hojas transparentes A4', 0000000000048, 45, 100, 48),
    ('Caja organizadora', 'Caja plástica organizadora', 0000000000049, 90, 100, 49),
    ('Rotulador permanente', 'Rotulador permanente azul', 0000000000050, 65, 100, 50),
    ('Cuaderno de notas', 'Cuaderno de notas A5', 0000000000051, 110, 100, 51),
    ('Borrador de pizarra', 'Borrador para pizarra blanca', 0000000000052, 55, 100, 52),
    ('Rotulador borrable', 'Rotulador de pizarra blanca', 0000000000053, 60, 100, 53),
    ('Lápiz de grafito', 'Lápiz de grafito HB', 0000000000054, 15, 100, 54),
    ('Cinta doble cara', 'Cinta adhesiva doble cara', 0000000000055, 35, 100, 55),
    ('Papel milimetrado', 'Block de papel milimetrado', 0000000000056, 120, 100, 56),
    ('Set de geometría', 'Set de regla, escuadra y transportador', 0000000000057, 75, 100, 57),
    ('Archivador', 'Archivador metálico A4', 0000000000058, 300, 100, 58),
    ('Papel bond', 'Resma de papel bond A4', 0000000000059, 200, 100, 59),
    ('Lapicera gel', 'Lapicera gel azul', 0000000000060, 30, 70, 60),
    ('Cuaderno de tapa dura', 'Cuaderno tapa dura 150 hojas', 0000000000061, 250, 100, 61),
    ('Pegamento blanco', 'Botella de pegamento blanco 120ml', 0000000000062, 60, 100, 62),
    ('Notas adhesivas', 'Paquete de notas adhesivas', 0000000000063, 55, 100, 63),
    ('Lápices acuarelables', 'Set de 24 lápices acuarelables', 0000000000064, 450, 100, 64),
    ('Papel glasé', 'Paquete de papel glasé colores', 0000000000065, 50, 100, 65),
    ('Portadocumentos', 'Portadocumentos A4 con cierre', 0000000000066, 80, 100, 66),
    ('Láminas de dibujo', 'Paquete de láminas A3', 0000000000067, 90, 100, 67),
    ('Rotulador textil', 'Rotulador para tela negro', 0000000000068, 45, 100, 68),
    ('Carpeta colgante', 'Carpeta colgante verde', 0000000000069, 65, 100, 69),
    ('Marcador fluorescente', 'Marcador fluorescente rosa', 0000000000070, 30, 100, 70),
    ('Notas autoadhesivas', 'Notas autoadhesivas 76x76 mm', 0000000000071, 35, 100, 71),
    ('Tablero magnético', 'Tablero magnético 45x60 cm', 0000000000072, 320, 100, 72),
    ('Goma moldeable', 'Goma moldeable blanca', 0000000000073, 80, 100, 73),
    ('Rotulador de punta fina', 'Rotulador punta fina azul', 0000000000074, 25, 100, 74),
    ('Carpeta escolar', 'Carpeta escolar tamaño oficio', 0000000000075, 70, 100, 75),
    ('Portaminas Pentel', 'Portaminas 0.7 mm', 0000000000076, 65, 100, 76),
    ('Papel adhesivo', 'Rollo de papel adhesivo', 0000000000077, 50, 100, 77),
    ('Bolígrafo bic', 'Bolígrafo azul de punta fina', 0000000000078, 15, 100, 78),
    ('Papel fotográfico', 'Paquete de papel fotográfico A4', 0000000000079, 300, 100, 79),
    ('Caja archivadora', 'Caja archivadora de cartón', 0000000000080, 100, 100, 80);


-- INSERTS PARAMETRO DE ARTICULOS
/*
PROMP: Puedes generar 80 registros con el siguiente formato: INSERT INTO ParametroArticulos (ArticuloId, TopeMovimiento_Valor)
			VALUES(1, 5)
El ArticuloId debe ir del 1 al 80 y el TopeMovimiento_valor debe variar entre 1 y 20
*/

INSERT INTO Parametros(Nombre, Valor_Valor) 
VALUES
    ('Producto1', 4),
    ('Producto2', 8),
    ('Producto3', 7),
    ('Producto4', 12),
    ('Producto5', 2),
    ('Producto6', 15),
    ('Producto7', 5),
    ('Producto8', 12),
    ('Producto9', 15),
    ('Producto10', 13),
    ('Producto11', 4),
    ('Producto12', 19),
    ('Producto13', 18),
    ('Producto14', 12),
    ('Producto15', 4),
    ('Producto16', 4),
    ('Producto17', 12),
    ('Producto18', 15),
    ('Producto19', 5),
    ('Producto20', 1),
    ('Producto21', 10),
    ('Producto22', 18),
    ('Producto23', 15),
    ('Producto24', 15),
    ('Producto25', 2),
    ('Producto26', 19),
    ('Producto27', 2),
    ('Producto28', 11),
    ('Producto29', 4),
    ('Producto30', 14),
    ('Producto31', 16),
    ('Producto32', 7),
    ('Producto33', 9),
    ('Producto34', 3),
    ('Producto35', 9),
    ('Producto36', 17),
    ('Producto37', 3),
    ('Producto38', 18),
    ('Producto39', 17),
    ('Producto40', 18),
    ('Producto41', 8),
    ('Producto42', 5),
    ('Producto43', 12),
    ('Producto44', 13),
    ('Producto45', 1),
    ('Producto46', 20),
    ('Producto47', 3),
    ('Producto48', 20),
    ('Producto49', 13),
    ('Producto50', 7),
    ('Producto51', 12),
    ('Producto52', 8),
    ('Producto53', 7),
    ('Producto54', 20),
    ('Producto55', 7),
    ('Producto56', 9),
    ('Producto57', 13),
    ('Producto58', 6),
    ('Producto59', 16),
    ('Producto60', 16),
    ('Producto61', 16),
    ('Producto62', 14),
    ('Producto63', 15),
    ('Producto64', 8),
    ('Producto65', 15),
    ('Producto66', 4),
    ('Producto67', 12),
    ('Producto68', 6),
    ('Producto69', 20),
    ('Producto70', 8),
    ('Producto71', 16),
    ('Producto72', 6),
    ('Producto73', 6),
    ('Producto74', 11),
    ('Producto75', 12),
    ('Producto76', 2),
    ('Producto77', 8),
    ('Producto78', 19),
    ('Producto79', 4),
    ('Producto80', 4);

-- INSERTS USUARIOS
/*PROMPT: Podrias crear 10 inserts diferentes con  propiedades similares a el siguiente: INSERT INTO Usuarios (Email_Valor, Nombre_Valor, Apellido_Valor, Contrasenia_Valor, TipoUsuario, ContraseniaEncriptada)
		VALUES('admin@algo.com', 'Juan', 'Rodriguez', '12345', 'EncargadoDeposito', '$2b$12$vMjRSEZxC1H6NJ3DfJndA.nJwnnktM/19SKayBCEQfBUW6C7pUkbm' )
		Necesito que me encriptes 10 veces la contraseña "Password01!" con ByCript para agregarsela a esos usuarios*/
INSERT INTO Usuarios (Email_Valor, Nombre_Valor, Apellido_Valor, Contrasenia_Valor, TipoUsuario, ContraseniaEncriptada)
		VALUES ('usuario@algo.com', 'Juan', 'Rodriguez', 'Passsword01!', 'EncargadoDeposito', '$2b$12$vMjRSEZxC1H6NJ3DfJndA.nJwnnktM/19SKayBCEQfBUW6C7pUkbm'),
			   ('usuario1@algo.com', 'Pedro', 'González', 'Passsword01!', 'EncargadoDeposito', '$2b$12$B81CPHmxm/lFPgXYjKLrJO/zJnBbkLaCgKDY8XYBNx9PDI1RMFO.K'),
			   ('usuario2@algo.com', 'María', 'López', 'Passsword01!', 'EncargadoDeposito', '$2b$12$sKjBdEg2Ptx4qIBr4DTUt.wskJDHZq0UOigQoWJ0naDErVv4NvCGm'),
			   ('usuario3@algo.com', 'Juana', 'Garcia', 'Passsword01!', 'EncargadoDeposito', '$2b$12$sKjBdEg2Ptx4qIBr4DTUt.wskJDHZq0UOigQoWJ0naDErVv4NvCGm'),
			   ('usuario4@algo.com', 'Jesus', 'Martinez', 'Passsword01!', 'EncargadoDeposito', '$2b$12$sKjBdEg2Ptx4qIBr4DTUt.wskJDHZq0UOigQoWJ0naDErVv4NvCGm'),
			   ('admin@algo.com', 'Carlos', 'Martínez', 'Passsword01!', 'Administrador', '$2b$12$YpOeiFVrB9qt3Spz2tqyRunaV2mZIdPDCYynpNG.TAnd0uuik4LU.'),
			   ('admin1@algo.com', 'Laura', 'Fernández', 'Passsword01!', 'Administrador', '$2b$12$e0GWbrWyGm4ZKF2k7oVnnuq185KCZNcu0Lx2S/PJPf5ry9t.Wx6Xm'),
			   ('admin2@algo.com', 'Ana', 'Sánchez', 'Passsword01!', 'Administrador', '$2b$12$qGaCSEMBBrnyi8xM62JjtOsXi95VFUjGGHLCxGQ5YNG4KLT5pLEk6'),
			   ('admi3@algo.com', 'Javier', 'Gutierrez', 'Passsword01!', 'Administrador', '$2b$12$e0GWbrWyGm4ZKF2k7oVnnuq185KCZNcu0Lx2S/PJPf5ry9t.Wx6Xm'),
			   ('admin4@algo.com', 'Roberto', 'Mendez', 'Passsword01!', 'Administrador', '$2b$12$qGaCSEMBBrnyi8xM62JjtOsXi95VFUjGGHLCxGQ5YNG4KLT5pLEk6');


-- INSERTS MovimientoStock
/*PROMPT: Puedes generarme 40 registros similares al siguiente: INSERT INTO MovimientosStock (Cantidad_Valor, UsuarioId, ArticuloId, Fecha, TipoMovimientoId)
			VALUES(4, 4, 1, '11-06-2024', 1004). Teniendo en cuenta que el UsuarioId debe estar entre 4 y6. Ademas los ArticulosId deben estar entre 1 y 81. La fecha maximia debes tomar el dia de hoy y los tipos de movimiento son los siguientes: INSERT INTO TiposMovimiento (NombreTipoMovimiento_Valor, EsIncremento) 
			VALUES ('VENTA', 0),
			('DEVOLUCION', 1),
			('COMPRA', 1). Todos los articulos tienen un stock de 100 y un tope por movimiento: INSERT INTO ParametroArticulos (ArticuloId, TopeMovimiento_Valor) 
                                VALUES	(1, 4),....
					(79, 4),
					(80, 4); 
INSERT INTO TiposMovimiento (NombreTipoMovimiento_Valor, EsIncremento) 
			VALUES ('VENTA', 0),
			('DEVOLUCION', 1),
			('COMPRA', 1) */
INSERT INTO MovimientosStock (Cantidad_Valor, UsuarioEmail, ArticuloId, Fecha, TipoMovimientoId)
        VALUES  (4, 'usuario@algo.com', 1, '2024-06-01', 1),
				(8, 'usuario@algo.com', 2, '2024-06-02', 2),
				(7, 'usuario@algo.com', 3, '2024-06-03', 3),
				(12, 'usuario@algo.com', 4, '2024-06-04', 1),
				(2, 'usuario@algo.com', 5, '2024-06-05', 2),
				(15, 'usuario@algo.com', 6, '2024-06-06', 3),
				(5, 'usuario@algo.com', 7, '2024-06-07', 1),
				(12, 'usuario@algo.com', 8, '2024-06-08', 2),
				(15, 'usuario@algo.com', 9, '2024-06-09', 3),
				(13, 'usuario@algo.com', 10, '2024-06-10', 1),
				(4, 'usuario@algo.com', 11, '2024-06-11', 2),
				(19, 'usuario@algo.com', 12, '2024-06-01', 3),
				(18, 'usuario@algo.com', 13, '2024-06-02', 1),
				(12, 'usuario@algo.com', 14, '2024-06-03', 2),
				(4, 'usuario@algo.com', 15, '2024-06-04', 3),
				(4, 'usuario@algo.com', 16, '2024-06-05', 1),
				(12, 'usuario1@algo.com', 17, '2024-06-06', 2),
				(15, 'usuario1@algo.com', 18, '2024-06-07', 3),
				(5, 'usuario1@algo.com', 19, '2024-06-08', 1),
				(1, 'usuario1@algo.com', 20, '2024-06-09', 2),
				(10, 'usuario1@algo.com', 21, '2024-06-10', 3),
				(18, 'usuario1@algo.com', 22, '2024-06-11', 1),
				(15, 'usuario1@algo.com', 23, '2024-06-01', 2),
				(15, 'usuario1@algo.com', 24, '2024-06-02', 3),
				(2, 'usuario1@algo.com', 25, '2024-06-03', 1),
				(19, 'usuario1@algo.com', 26, '2024-06-04', 2),
				(2, 'usuario1@algo.com', 27, '2024-06-05', 3),
				(11, 'usuario1@algo.com', 28, '2024-06-06', 1),
				(4, 'usuario1@algo.com', 29, '2024-06-07', 2),
				(14, 'usuario1@algo.com', 30, '2024-06-08', 3),
				(16, 'usuario2@algo.com', 31, '2024-06-09', 1),
				(7, 'usuario2@algo.com', 32, '2024-06-10', 2),
				(9, 'usuario2@algo.com', 33, '2024-06-11', 3),
				(3, 'usuario2@algo.com', 34, '2024-06-01', 1),
				(9, 'usuario2@algo.com', 35, '2024-06-02', 2),
				(17, 'usuario2@algo.com', 36, '2024-06-03', 3),
				(3, 'usuario2@algo.com', 37, '2024-06-04', 1),
				(18, 'usuario2@algo.com', 38, '2024-06-05', 2),
				(17, 'usuario2@algo.com', 39, '2024-06-06', 3),
				(18, 'usuario2@algo.com', 40, '2024-06-07', 1);

--Parametro para paginacion
INSERT INTO Parametros VALUES('Paginacion', 2)