Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports GestionProductos

Namespace Controllers
    Public Class ProductosController
        Inherits System.Web.Mvc.Controller
        ReadOnly coneccion As New SqlConnection(ConfigurationManager.ConnectionStrings("FidelityTools").ConnectionString)


        Private db As New FidelityToolsEntities

        ' GET: Productos
        Function Index() As ActionResult
            Dim productos = db.Productos.Include(Function(p) p.Categorias)
            Return View(productos.ToList())
        End Function

        ' GET: Productos/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim productos As Productos = db.Productos.Find(id)
            If IsNothing(productos) Then
                Return HttpNotFound()
            End If
            Return View(productos)
        End Function

        ' GET: Productos/Create
        Function Create() As ActionResult
            ViewBag.idCategoria = New SelectList(db.Categorias, "id", "nombre")
            Return View()
        End Function

        ' POST: Productos/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,nombre,stock,precio,idCategoria")> ByVal productos As Productos) As ActionResult
            Dim Sentencia As String = "Insert into Productos values (@NomProducto, @Stock, @Precio, @IdCat)"
            Dim buscar As String = "Select * from Productos where nombre=@NomProducto"
            Dim comando As New SqlCommand
            Dim nomProducto As String = productos.nombre
            Dim Stock As String = productos.stock
            Dim Precio As Decimal = productos.precio
            Dim idCat As Integer = productos.idCategoria


            Try
                coneccion.Open()
                comando.Connection = coneccion
                comando.CommandType = CommandType.Text
                comando.CommandText = buscar
                comando.Parameters.AddWithValue("@NomProducto", nomProducto)
                Dim Resultado As String = comando.ExecuteScalar()

                If Not IsNothing(Resultado) Then
                    Return Content("<script language='javascript' type='text/javascript'>
                                    alert('No se puede agregar: El producto ya existe en la base de datos!');
                                   </script>")
                Else
                    comando.Parameters.Clear()
                    comando.Connection = coneccion
                    comando.CommandType = CommandType.Text
                    comando.CommandText = Sentencia
                    comando.Parameters.AddWithValue("@NomProducto", nomProducto)
                    comando.Parameters.AddWithValue("@stock", Stock)
                    comando.Parameters.AddWithValue("@Precio", Precio)
                    comando.Parameters.AddWithValue("@IdCat", idCat)
                    comando.ExecuteNonQuery()
                End If
                coneccion.Close()
            Catch ex As Exception
            End Try
            ViewBag.idCategoria = New SelectList(db.Categorias, "id", "nombre", productos.idCategoria)
            Return RedirectToAction("Index")
        End Function

        ' GET: Productos/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim productos As Productos = db.Productos.Find(id)
            If IsNothing(productos) Then
                Return HttpNotFound()
            End If
            ViewBag.idCategoria = New SelectList(db.Categorias, "id", "nombre", productos.idCategoria)
            Return View(productos)
        End Function

        ' POST: Productos/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,nombre,stock,precio,idCategoria")> ByVal productos As Productos) As ActionResult
            If ModelState.IsValid Then
                db.Entry(productos).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.idCategoria = New SelectList(db.Categorias, "id", "nombre", productos.idCategoria)
            Return View(productos)
        End Function

        ' GET: Productos/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim productos As Productos = db.Productos.Find(id)
            If IsNothing(productos) Then
                Return HttpNotFound()
            End If
            Return View(productos)
        End Function

        ' POST: Productos/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim productos As Productos = db.Productos.Find(id)
            db.Productos.Remove(productos)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
