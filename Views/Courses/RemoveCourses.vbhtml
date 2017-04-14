@Code
    ViewData("Title") = "Remove a course"
End Code

@ModelType StudentsAssessment.CourseData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>REMOVE A COURSE</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                @if Model.lstTaughtCoursesForDDL.Count()>0
                    @<tr>
                        <td colspan="2">
                            @Html.Label("You are teaching these courses currently, please select the one you want to remove", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2">
                            @Html.DropDownListFor(Function(model) model.SelectedCourse, Model.lstTaughtCoursesForDDL, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedCourse, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="REMOVE COURSE" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />

                        </td>
                    </tr>
                Else
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            Your list of courses to teach is empty. Nothing to show for removal
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            @* <input type="submit" value="REMOVE CLASS" Class="btn btn-success clsbutton" style="background:cadetblue;" />*@
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                        </td>
                    </tr>
                End If


                <tr>
                    <td colspan="2">
                        @If String.IsNullOrEmpty(ViewBag.StatusMessage) = True Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @ViewBag.StatusMessage
                            </div>
                        Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Html.Raw(ViewBag.StatusMessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>

