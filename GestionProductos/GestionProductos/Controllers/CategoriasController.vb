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
    Public Class CategoriasController
        Inherits System.Web.Mvc.Controller
        ReadOnly coneccion As New SqlConnection(ConfigurationManager.ConnectionStrings("FidelityTools").ConnectionString)
        Private db As New FidelityToolsEntities
        ' GET: Categorias
        Function Index() As ActionResult
            Return View(db.Categorias.ToList())
        End Function

        ' GET: Categorias/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim categorias As Categorias = db.Categorias.Find(id)
            If IsNothing(categorias) Then
                Return HttpNotFound()
            End If
            Return View(categorias)
        End Function

        ' GET: Categorias/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Categorias/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id, nombre")> ByVal categorias As Categorias) As ActionResult
            Dim Sentencia As String = "Insert into Categorias values (@Categoria)"
            Dim Buscar As String = "Select * from categorias where nombre=@Nombre"
            Dim NomCat As String = categorias.nombre
            Dim comando As New SqlCommand
            Try
                coneccion.Open()
                comando.Parameters.Clear()
                comando.Connection = coneccion
                comando.CommandType = CommandType.Text
                comando.CommandText = Buscar
                comando.Parameters.AddWithValue("@nombre", NomCat)
                Dim resultado As String = comando.ExecuteScalar()
                If Not IsNothing(resultado) Then
                    Return Content("<script language='javascript' type='text/javascript'>
                                    alert('No se puede agregar: La categoria ya existe en la base de datos!');
                                   </script>")
                Else
                    comando.Parameters.Clear()
                    comando.Connection = coneccion
                    comando.CommandType = CommandType.Text
                    comando.CommandText = Sentencia
                    comando.Parameters.AddWithValue("@Categoria", NomCat)
                    comando.ExecuteNonQuery()
                End If
                coneccion.Close()
            Catch ex As Exception
                ex.Message("Error al cargar la categoria").ToString()

            End Try
            Return RedirectToAction("Index")
        End Function


        ' GET: Categorias/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim categorias As Categorias = db.Categorias.Find(id)
            If IsNothing(categorias) Then
                Return HttpNotFound()
            End If
            Return View(categorias)
        End Function

        ' POST: Categorias/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,nombre")> ByVal categorias As Categorias) As ActionResult
            If ModelState.IsValid Then
                db.Entry(categorias).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(categorias)
        End Function

        ' GET: Categorias/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim categorias As Categorias = db.Categorias.Find(id)
            If IsNothing(categorias) Then
                Return HttpNotFound()
            End If
            Return View(categorias)
        End Function

        ' POST: Categorias/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim categorias As Categorias = db.Categorias.Find(id)
            Dim Id_Cat As Integer = id
            Dim buscar As String = "Select * from Productos where idCategoria=@Id_Cat"
            Dim comando As New SqlCommand

            Try
                coneccion.Open()
                comando.Connection = coneccion
                comando.CommandType = CommandType.Text
                comando.CommandText = buscar
                comando.Parameters.AddWithValue("@Id_Cat", Id_Cat)
                Dim Resultado As String = comando.ExecuteScalar()
                coneccion.Close()

                If IsNothing(Resultado) Then
                    db.Categorias.Remove(categorias)
                    db.SaveChanges()
                Else
                    Return Content("<script language='javascript' type='text/javascript'>
                                    alert('No se puede agregar: La categoria Tiene productos asociados');
                                   </script>")
                End If
            Catch ex As Exception
                ex.Message("Error en la conexion, no se pudo eliminar la categoria").ToString()
            End Try
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
