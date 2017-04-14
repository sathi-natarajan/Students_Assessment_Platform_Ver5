@Code
    ViewData("Title") = "Enrollment"
End Code

@ModelType StudentsAssessment.StudentData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

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
        <h3>STUDENT TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>ENROLL IN A CLASS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("SELECT A CLASS TO ENROLL IN:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedCourse, Model.AvailableCoursesListDDL)
                        @Html.ValidationMessageFor(Function(model) model.SelectedCourse, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="REGISTER COURSE" Class="btn btn-success  clsbutton-round" style="background:cadetblue;" />
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />
                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        @If String.IsNullOrEmpty(ViewBag.Statusmessage) = False Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @ViewBag.Statusmessage
                            </div>
                            @*Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Model.Successmessage
                            </div>*@
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>

