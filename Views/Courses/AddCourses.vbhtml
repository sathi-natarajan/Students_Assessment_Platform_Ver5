@Code
    ViewData("Title") = "Add courses"
End Code

@ModelType StudentsAssessment.CourseData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="~/Content/MaskedInput/jquery.maskedinput.min.js"></script>

<link href="~/Content/jQuery_datepicker/css/jquery.datepick.css" rel="stylesheet" />
<script src="~/Content/jQuery_datepicker/js/jquery.plugin.min.js"></script>
<script src="~/Content/jQuery_datepicker/js/jquery.datepick.min.js"></script>

<link href="~/Content/jQuery_timepicker/bootstrap-datepicker.css" rel="stylesheet" />
<link href="~/Content/jQuery_timepicker/jquery.timepicker.css" rel="stylesheet" />
<script src="~/Content/jQuery_timepicker/bootstrap-datepicker.js"></script>
<script src="~/Content/jQuery_timepicker/jquery.timepicker.min.js"></script>

<script type="text/javascript">
        jQuery(function ($) {
            $("#NoCreditHours").mask("9.9");
            $("#NoCreditHours").width("50px");
            $('#StartDate').datepick();
            $('#EndDate').datepick();

            $('#Starttime,#Endtime').timepicker({
                'minTime': '2:00pm',
                'maxTime': '11:30pm',
                'showDuration': true
            });

            $("#Starttime").width("50px");
            $("#Endtime").width("50px");
        });
</script>

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
            @<h3>ADD COURSES PAGE FOR TEACHERS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="5" cellspacing="5">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("Name of the class:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Classname, New With {.maxlength = 25})
                        @Html.ValidationMessageFor(Function(model) model.Classname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Description of course:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextAreaFor(Function(model) model.CourseDescription, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "width:500px;height:100px;", .maxlength = "250"})
                        @Html.ValidationMessageFor(Function(model) model.CourseDescription, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Add a subject to be taught in course:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.Subjects.SelectedSubject, Model.Subjects.SubjectsList, "Select a subject")
                        @Html.ValidationMessageFor(Function(model) model.Subjects.SelectedSubject, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Select a class period for this course to be taught in:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.Period.SelectedPeriod, Model.Period.PeriodsList, "Select a class period")
                        @Html.ValidationMessageFor(Function(model) model.Period.SelectedPeriod, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Startdate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Startdate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .id = "StartDate"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Startdate, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Enddate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Enddate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .id = "EndDate"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Enddate, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Starttime, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Starttime, New With {.htmlAttributes = New With {.class = "form-control"}, .type = "text", .id = "Starttime"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Starttime, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Endtime, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Endtime, New With {.htmlAttributes = New With {.class = "form-control"}, .type = "text", .id = "Endtime"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Endtime, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.NoCreditHours, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.NoCreditHours, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text"})<br />
                        @Html.ValidationMessageFor(Function(model) model.NoCreditHours, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Set as default class:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.CheckBoxFor(Function(model) model.DefaultCourse, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.DefaultCourse, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Set as default subject:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.CheckBoxFor(Function(model) model.DefaultSubject, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.DefaultSubject, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="ADD COURSE" Class="btn btn-success  clsbutton" style="background:cadetblue;border-radius: 24px;" />
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton" style="background:cadetblue;border-radius: 24px;" onclick="location.href='@Url.Action("Index", "Home")'" />
                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Model.Errormessage
                            </div>
                        Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Model.Successmessage
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>
