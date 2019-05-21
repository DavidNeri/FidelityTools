@ModelType GestionProductos.Categorias
@Code
    ViewData("Title") = "FidelityTools-Detalles de Categoria"
    ViewData("Encabezado") = "Categorias"

End Code

<h2>Details</h2>

<div>
    <h4>Categorias</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.nombre)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
