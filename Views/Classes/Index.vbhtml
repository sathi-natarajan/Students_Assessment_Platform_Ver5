@Code
    ViewData("Title") = "Students Assessment Platform - Class Management"
    'Layout = Nothing
End Code


<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>CLASS MANAGEMENT SECTION FOR TEACHERS</h3>
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
    <div class="col-sm-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div style="padding-left:75px;">
            @Html.Partial("SideMenu")
        </div>
    </div>
</div>
