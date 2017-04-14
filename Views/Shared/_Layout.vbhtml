<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Content/sitemenu/jquery.slidereveal.js"></script>
    <link href="~/Content/sitemenu/index.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $('#slider').slideReveal({
                trigger: $("#trigger")
            });
        });
    </script>
</head>
<body>
    @*navbar-inverse class,if included here, will show a black line just below the top banner*@
    <div class="navbar navbar-fixed-top" style="background-color:aquamarine;">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @*@Html.ActionLink("Application name", "Index", "Home", New With { .area = "" }, New With { .class = "navbar-brand" })*@
            </div>
            <div class="navbar-collapse collapse" >
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Home", "Index", "Home", New With {.style = "color:#000000;"})</li>
                    <li>@Html.ActionLink("About", "About", "Home", New With {.style = "color:#000000;"})</li>
                    <li>@Html.ActionLink("Feedback and Comments", "Contact", "Home", New With {.style = "color:#000000;"})</li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content" style="padding:50px;">
        <div id='slider' style="position: fixed; width: 250px; 
        transition: all 300ms ease; height: 100%; top: 0px; left: -270px;
        background-color:aquamarine;">
            <div style="text-align:center;margin-top:75px;">
                <h3>TEACHER TASKS</h3>
                <ul>
                    <li>Task 1</li>
                    <li>Task 2</li>
                    <li>Task 3</li>
                </ul>
            </div>
        </div>
        <div style="margin-left:-54px;margin-top:-49px;">
            <button id='trigger' style="background-color:aquamarine;">Trigger</button>@*@slider*@
        </div>
        
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @*The sitemenu (jQuery-based) is not working if  we enable this...*@
    @*@Scripts.Render("~/bundles/jquery")*@ 
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
