@Code
    ViewData("Title") = "Create Student Account"
    'Layout = Nothing
End Code

@ModelType StudentsAssessment.StudentData
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

<script type="text/javascript">
    jQuery(function ($) {
        //$("#Firstname").watermark({ watermarkText: "Type your first name" });
        //$("#Lastname").watermark({ watermarkText: "Type your last name" });
        //$("#Firstname").focus();
        $('#StartDate').datepick();
        //$('#EndDate').datepick();
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
            @<h3>CREATE A NEW STUDENT ACCOUNT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Firstname, htmlAttributes:=New With {.class = "control-label col-md-10"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Firstname, New With {.htmlAttributes = New With {.class = "form-control"}, .width = "200px", .height = "100px", .maxlength = "25"})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Firstname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        @Html.LabelFor(Function(model) model.Lastname, htmlAttributes:=New With {.class = "control-label col-md-10"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Lastname, New With {.htmlAttributes = New With {.class = "form-control"}, .maxlength = "25"})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Lastname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Joindate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Joindate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .id = "StartDate"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Joindate, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        @Html.Label("Username: Auto-assigned by system", htmlAttributes:=New With {.class = "control-label col-md-10", .style = "width:  100%;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Password:", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    </td>
                    <td>
                        <div style="font-weight:bold;">
                            @Html.Label("student", New With {.htmlAttributes = New With {.class = "form-control"}})
                        </div>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        @Html.Label("SELECT YOUR GRADE LEVEL:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:200px;"})
                        @Html.DropDownListFor(Function(model) model.SelectedGradeLevel, Model.GradeLevelsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedGradeLevel, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @Html.Label("SELECT YOUR SCHOOL:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:200px;"})
                        @Html.DropDownListFor(Function(model) model.SelectedSchool, Model.SchoolsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedSchool, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="CREATE ACCOUNT" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                            @<div class="field-validation-error">
                                @Model.Errormessage
                            </div>
                        Else
                            @<div class="field-validation-error">
                                @Html.Raw(Model.Successmessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>
