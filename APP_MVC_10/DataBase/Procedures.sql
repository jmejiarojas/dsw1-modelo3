use negocios2017
go

-- Listar
Create Proc usp_Producto_Listar
As
Begin 
    Select IdProducto,NomProducto,IdCategoria,IdProveedor,
	CantxUnidad,PrecioUnidad,UnidadesEnExistencia
	from Compras.productos
End
go



Create Proc usp_Producto_Insertar
@IdProducto int,
@NombreProducto varchar(50), @IdProveedor int, 
@IdCategoria int, @umedida varchar(50), @PrecioUnidad decimal,
@Stock int
As
Begin
    Insert Compras.productos(IdProducto,NomProducto,IdProveedor,IdCategoria,
	CantxUnidad,PrecioUnidad,UnidadesEnExistencia,UnidadesEnPedido)
	Values(@IdProducto,@NombreProducto,@IdProveedor,@IdCategoria,@umedida,
	@PrecioUnidad,@Stock,100)
End
go

Create Proc usp_ProductoActualizar
@IdProducto int,@NombreProducto varchar(50), @IdProveedor int, 
@IdCategoria int, @umedida varchar(50), @PrecioUnidad decimal,
@Stock int
As
Begin
   Update Compras.productos Set NomProducto=@NombreProducto,
   IdProveedor=@IdProveedor,IdCategoria=@IdCategoria,
   CantxUnidad=@umedida,PrecioUnidad=@PrecioUnidad,
   UnidadesEnExistencia=@Stock
   Where IdProducto=@IdProducto
End
go

Create Proc usp_Producto_Eliminar
@IdProducto int
As
Begin
   Delete Compras.productos Where IdProducto=@IdProducto
End
go

Create Proc usp_Producto_Datos
@IdProducto int
As
Begin
   Select IdProducto,NomProducto,IdCategoria,IdProveedor,
   CantxUnidad,PrecioUnidad,UnidadesEnExistencia
   from Compras.productos Where IdProducto=@IdProducto
End
go

Create Proc usp_Categoria_Listar
As
Begin
   Select IdCategoria,NombreCategoria
   from Compras.categorias
End