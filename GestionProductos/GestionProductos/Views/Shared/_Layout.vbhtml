<!DOCTYPE html>
<html>
<head>   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title </title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <!--Encabezado-->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <h1 class="navbar-header">@ViewBag.Encabezado</h1>
    </div>
    <!-- Menu -->
    <div class="sidebar">
        <a class="active" href="~/home/index">Home</a>
        <a class="active" href="">Productos</a>
        <a href="~/productos/index">Ver productos</a>
        <a href="~/productos/create">Altas</a>
        <a class="active" href="">Categorias</a>
        <a href="~/categorias/index">Ver Categorias</a>
        <a href="~/categorias/create">Altas</a>
    </div>
    <!-- Contenido -->
    <div class="content">
        @RenderBody()
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
