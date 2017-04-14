@Code
    ViewData("Title") = "Welcome page"
End Code


@ModelType StudentsAssessment.LoginData

@*<link rel="stylesheet" media="screen" href="@Url.Content("~/Content/Superfish/src/css/superfish.css")">
    <link href="@Url.Content("~/Content/Superfish/css/superfish-vertical.css")" rel="stylesheet" />
    <script src="@Url.Content("~/Content/Superfish/js/jquery.js")"></script>
    <script src="@Url.Content("~/Content/Superfish/js/superfish.js")"></script>
    <script src="@Url.Content("~/Content/Superfish/js/hoverIntent.js")"></script>*@

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
            <h3>YOUR PROFILE</h3>
            <hr style="background-color:cadetblue;height:2px;" />
            <table cellspacing="2" cellpadding="2">
                <colgroup>
                    <col width="250" />
                    <col width="250" />
                </colgroup>
                <tr>
                    <td>FIRSTNAME:</td>
                    <td>@Model.Firstname</td>
                </tr>
                <tr>
                    <td>LASTNAME:</td>
                    <td>@Model.Lastname</td>
                </tr>
                <tr>
                    <td>CURRENT STATUS:</td>
                    <td>@Model.Status</td>
                </tr>
            </table>
        </div>
</div>
