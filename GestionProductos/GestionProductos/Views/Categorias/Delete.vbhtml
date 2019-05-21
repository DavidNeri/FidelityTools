@ModelType GestionProductos.Categorias
@Code
    ViewData("Title") = "FidelityTools-Eliminar Categoria"
    ViewData("Encabezado") = "Categorias"

End Code

<h2>Eliminar</h2>

<h3>¿Desea eliminar la siguiente categoria?</h3>
<div>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.nombre)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
