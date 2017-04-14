@Code
    ViewData("Title") = "Students Administration"
    'Layout = Nothing
End Code


<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        <h3>ADMIN TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>SCHOOLS ADMINISTRATION SECTION FOR ADMINISTRATORS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<p>Please use the menu appearing on your left</p>
            @If String.IsNullOrEmpty(ViewBag.StatusMessage) = True Then
                @<div id="divStatusMessage" class="field-validation-error">
                    @ViewBag.StatusMessage
                </div>
            Else
                @<div id="divStatusMessage" class="field-validation-error">
                    @Html.Raw(ViewBag.StatusMessage)
                </div>
            End If
        End Using
    </div>
</div>
