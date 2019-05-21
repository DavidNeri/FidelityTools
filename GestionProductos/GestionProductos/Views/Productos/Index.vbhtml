@ModelType IEnumerable(Of GestionProductos.Productos)
@Code
    ViewData("Title") = "FidelityTools-Listado de Productos"
    ViewData("Encabezado") = "Productos"
End Code

<h2>Lista de productos</h2>


<table class="table">
    <tr>
        <th>
            @Html.Label("Nombre")
        </th>
        <th>
            @Html.Label("Stock")
        </th>
        <th>
            @Html.Label("Precio")
        </th>
        <th>
            @Html.Label("Categoria")
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
            @Html.DisplayFor(Function(modelItem) item.stock)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.precio)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Categorias.nombre)
        </td>
        <td>
            @Html.ActionLink("Editar", "Edit", New With {.id = item.id}) |
            @Html.ActionLink("Eliminar", "Delete", New With {.id = item.id})
        </td>
    </tr>
Next

</table>
