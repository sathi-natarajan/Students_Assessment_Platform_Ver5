@Code
    ViewData("Title") = "Create Teacher Account"
    'Layout = Nothing
End Code

@ModelType StudentsAssessment.TeacherData
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

<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>CREATE A NEW TEACHER ACCOUNT</h3>
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
                        @Html.TextBoxFor(Function(model) model.Firstname, New With {.htmlAttributes = New With {.class = "form-control"}, .width = "200px", .height = "100px"})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Firstname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                 <tr>
                     <td>
                         @Html.LabelFor(Function(model) model.Middlename, htmlAttributes:=New With {.class = "control-label col-md-10"})
                     </td>
                     <td>
                         @Html.TextBoxFor(Function(model) model.Middlename, New With {.htmlAttributes = New With {.class = "form-control"}, .width = "200px", .height = "100px"})
                         <br />
                         @Html.ValidationMessageFor(Function(model) model.Middlename, "", New With {.class = "text-danger"})
                     </td>
                 </tr>
                 <tr>
                     <td valign="top">
                         @Html.LabelFor(Function(model) model.Lastname, htmlAttributes:=New With {.class = "control-label col-md-10"})
                     </td>
                     <td>
                         @Html.TextBoxFor(Function(model) model.Lastname, New With {.htmlAttributes = New With {.class = "form-control"}})
                         <br />
                         @Html.ValidationMessageFor(Function(model) model.Lastname, "", New With {.class = "text-danger"})
                     </td>
                 </tr>
                <tr>
                    <td valign="top">
                        @Html.LabelFor(Function(model) model.Emailaddress, htmlAttributes:=New With {.class = "control-label col-md-10"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Emailaddress, New With {.htmlAttributes = New With {.class = "form-control"}})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Emailaddress, "", New With {.class = "text-danger"})
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
                            @Html.Label("teacher", New With {.htmlAttributes = New With {.class = "form-control"}})
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
              </table>
              @<fieldset>
                <legend>SCHOOL INFORMATION:</legend>
                    <table border="1" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="400" />
                    <col width="400" />
                    <col width="300" />
                </colgroup>
                @If Model.StatesListDDL.Count > 0 Then
                    @<tr>
                        <td colspan="2">
                            @Html.Label("SELECT SCHOOL'S STATE:")
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedState, Model.StatesListDDL)
                            @Html.ValidationMessageFor(Function(model) model.SelectedState, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @If Model.CitiesListDDL.Count > 0 Then
                        @<tr>
                            <td colspan="2">
                                @Html.Label("SELECT SCHOOL'S CITY:")
                            </td>
                            <td>
                                @Html.DropDownListFor(Function(model) model.SelectedCity, Model.CitiesListDDL)
                                @Html.ValidationMessageFor(Function(model) model.SelectedCity, "", New With {.class = "text-danger"})
                            </td>
                        </tr>
                        @If Model.SchoolDistrictsListDDL.Count > 0 Then
                            @<tr>
                                <td colspan="2">
                                    @Html.Label("SELECT SCHOOL DISTRICT:")
                                </td>
                                <td>
                                    @Html.DropDownListFor(Function(model) model.SelectedSchoolDist, Model.SchoolDistrictsListDDL)
                                    @Html.ValidationMessageFor(Function(model) model.SelectedSchoolDist, "", New With {.class = "text-danger"})
                                </td>
                            </tr>
                            @If Model.Schools1ListDDL.Count > 0 Then
                                @<tr>
                                    <td colspan="2">
                                        @Html.Label("SELECT YOUR SCHOOL:")
                                    </td>
                                    <td>
                                        @Html.DropDownListFor(Function(model) model.SelectedSchool1, Model.Schools1ListDDL)
                                        @Html.ValidationMessageFor(Function(model) model.SelectedSchool1, "", New With {.class = "text-danger"})
                                    </td>
                                </tr>
                            Else
                                @<tr>
                                    <td colspan="2">
                                        @Html.Label("School information could not be loaded for selection")
                                    </td>
                                </tr>
                                @<tr>
                                    <td colspan="3" style="text-align:center;">
                                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                                    </td>
                                </tr>
                            End If
Else
                            @<tr>
                                <td colspan="2">
                                    @Html.Label("School District information could not be loaded  for selection")
                                </td>
                            </tr>
                            @<tr>
                                <td colspan="3" style="text-align:center;">
                                    <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                                </td>
                            </tr>
                        End If
Else
                        @<tr>
                            <td colspan="2">
                                @Html.Label("City information could not be loaded  for selection")
                            </td>
                        </tr>
                        @<tr>
                            <td colspan="3" style="text-align:center;">
                                <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                            </td>
                        </tr>
                    End If
Else
                    @<tr>
                        <td colspan="2">
                            @Html.Label("State information could not be loaded  for selection")
                        </td>
                    </tr>
                    @<tr>
                <td colspan = "3" style="text-align:center;">
                    <input type = "button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                </td>
            </tr>
                End If
            <tr>
                <td colspan = "3" style="text-align:center;">
                    <input type = "submit" value="@Session("buttoncaption").ToString" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                    <input type = "button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                </td>
            </tr>
            <tr>
                    <td colspan = "3" >
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
</fieldset>
        End Using
    </div>
</div>
