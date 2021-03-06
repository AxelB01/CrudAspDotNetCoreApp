USE [ISW_311_1]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 3/9/2022 9:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Categoria] [varchar](100) NOT NULL,
	[PrecioCompra] [decimal](18, 2) NOT NULL,
	[PrecioVenta] [decimal](18, 2) NOT NULL,
	[Comentario] [varchar](500) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Categoria], [PrecioCompra], [PrecioVenta], [Comentario]) VALUES (2, N'Producto 1', N'Categoria 1', CAST(100.50 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Categoria], [PrecioCompra], [PrecioVenta], [Comentario]) VALUES (3, N'Producto 2', N'Categoria 1', CAST(120.00 AS Decimal(18, 2)), CAST(125.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Categoria], [PrecioCompra], [PrecioVenta], [Comentario]) VALUES (4, N'Producto 3', N'Categoria 1', CAST(150.00 AS Decimal(18, 2)), CAST(160.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Categoria], [PrecioCompra], [PrecioVenta], [Comentario]) VALUES (5, N'Producto 4', N'Categoria 2', CAST(75.00 AS Decimal(18, 2)), CAST(95.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Categoria], [PrecioCompra], [PrecioVenta], [Comentario]) VALUES (6, N'Producto 5', N'Categoria 2', CAST(200.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Categoria], [PrecioCompra], [PrecioVenta], [Comentario]) VALUES (7, N'Producto 6', N'Categoria 3', CAST(190.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Categoria], [PrecioCompra], [PrecioVenta], [Comentario]) VALUES (10, N'Producto 20', N'Categoria 10', CAST(150.25 AS Decimal(18, 2)), CAST(202.50 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateProducto]    Script Date: 3/9/2022 9:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CreateProducto]
@nombre VARCHAR(100),
@categoria VARCHAR(100),
@pCompra DECIMAL(18, 2),
@pVenta DECIMAL(18, 2),
@comentario VARCHAR(500)
AS
BEGIN
	INSERT INTO Productos (Nombre, Categoria, PrecioCompra, PrecioVenta, Comentario)
	VALUES(@nombre, @categoria, @pCompra, @pVenta, @comentario)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductoById]    Script Date: 3/9/2022 9:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteProductoById]
@idProducto INT
AS
BEGIN
	DELETE FROM Productos WHERE IdProducto = @idProducto
END	
GO
/****** Object:  StoredProcedure [dbo].[GetProductoById]    Script Date: 3/9/2022 9:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetProductoById]
@idProducto INT
AS
BEGIN
	SELECT pr.* FROM Productos pr WHERE pr.IdProducto = @idProducto
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductos]    Script Date: 3/9/2022 9:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductos]
AS
BEGIN
	SELECT *FROM Productos
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductoById]    Script Date: 3/9/2022 9:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UpdateProductoById]
@idProducto INT,
@nombre VARCHAR(100),
@categoria VARCHAR(100),
@pCompra DECIMAL(18, 2),
@pVenta DECIMAL(18, 2),
@comentario VARCHAR(500)
AS
BEGIN
	UPDATE Productos SET
	Nombre = @nombre,
	Categoria = @categoria,
	PrecioCompra = @pCompra,
	PrecioVenta = @pVenta,
	Comentario = @comentario
	WHERE IdProducto = @idProducto
END
GO
