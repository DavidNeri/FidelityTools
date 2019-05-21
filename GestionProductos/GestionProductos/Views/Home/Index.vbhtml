@Code
    ViewData("Title") = "FidelityTools-Gestion de Productos"
    ViewData("Encabezado") = "Home"

End Code
<!--Encabezado-->
<div class="navbar navbar-inverse navbar-fixed-top">
    <h1 class="navbar-header">@ViewBag.Encabezado</h1>
</div>

<div class="img-comp-container">
    <div class="img-comp-img">
        <img src="~/Content/Imagenes/1.png" width="538" height="463">
    </div>
    <div class="img-comp-img img-comp-overlay">
        <img src="~/Content/Imagenes/2.png" width="538" height="463">
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jquerySlide")
    <script>
            initComparisons();    
    </script>
End Section

