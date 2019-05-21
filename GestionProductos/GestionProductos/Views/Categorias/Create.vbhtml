@ModelType GestionProductos.Categorias
@Code
    ViewData("Title") = "FidelityTools-Nueva Categoria"
    ViewData("Encabezado") = "Categorias"
End Code
<h2>Nueva Categoria</h2>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.Label("Nombre categoria", htmlAttributes:=New With {.class = "control-label col-md-2", .id = "LblCat"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.nombre, New With {.htmlAttributes = New With {.class = "form-control", .id = "TxtCat"}})
                @Html.ValidationMessageFor(Function(model) model.nombre, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Guardar" class="btn btn-default" OnClick="ValidarCategoria();" />
            </div>
        </div>
    </div>
End Using
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section

