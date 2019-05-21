@ModelType IEnumerable(Of GestionProductos.Categorias)
@Code
    ViewData("Title") = "FidelityTools-Detalles de categorias"
    ViewData("Encabezado") = "Categorias"


End Code
    
<h2>Listado de Categorias</h2>


<table class="table">
    <tr>
        <th>
            @Html.Label("Nombre")
        </th>
         <th>
            @Html.Label("Accion")
        </th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.nombre)
        </td>
        <td>
            @Html.ActionLink("Editar", "Edit", New With {.id = item.id}) |         
            @Html.ActionLink("Eliminar", "Delete", New With {.id = item.id})
        </td>
    </tr>
Next

</table>
