@ModelType GestionProductos.Productos
@Code
    ViewData("Title") = "FidelityTools-Detalle de Productos"
    ViewData("Encabezado") = "Productos"
End Code

<h2>Detalles del Producto</h2>

<div>
    <h4>Productos</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.stock)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.stock)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.precio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.precio)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Categorias.nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Categorias.nombre)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
