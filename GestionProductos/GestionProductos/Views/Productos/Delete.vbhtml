@ModelType GestionProductos.Productos
@Code
    ViewData("Title") = "FidelityTools-Eliminar Producto"
    ViewData("Encabezado") = "Productos"


End Code

<h2>Eliminar</h2>

<h3>¿Desea eliminar el siguiente producto?</h3>
<div>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Eliminar" class="btn btn-default" /> | 
            @Html.ActionLink("Regresar", "Index")
        </div>
    End Using
</div>
