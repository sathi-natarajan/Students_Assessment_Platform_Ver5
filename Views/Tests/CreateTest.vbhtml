@Code
    ViewData("Title") = "Create a test"
End Code

@ModelType StudentsAssessment.TestData
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
        //$("#Starttime").mask("99.99");
        //$("#Endtime").mask("99.99");
        $("#Starttime").width("50px");
        $("#Endtime").width("50px");
        $('#StartDate').datepick();

        $('#Starttime,#Endtime').timepicker({
            'minTime': '2:00pm',
            'maxTime': '11:30pm',
            'showDuration': true
        });
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
            @<h3>CREATE A NEW TEST</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("TEST NAME:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Testname, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .maxlength = "50"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Testname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("DESCRIPTION OF TEST:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextAreaFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:500px;height:100px;", .maxlength = "150"}})<br />
                        @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("TEST DATE:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Testdate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .id = "StartDate"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Testdate, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Start time:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Starttime, New With {.htmlAttributes = New With {.class = "form-control"}})<br />
                        @Html.ValidationMessageFor(Function(model) model.Starttime, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("End time:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Endtime, New With {.htmlAttributes = New With {.class = "form-control"}})<br />
                        @Html.ValidationMessageFor(Function(model) model.Endtime, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("SELECT ASSESSMENT TO ASSOCIATE WITH TEST:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedAssessment, Model.ListofAssessmentsDDL)
                        @Html.ValidationMessageFor(Function(model) model.ListofAssessmentsDDL, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="CREATE TEST" class="btn btn-success clsbutton" style="background:cadetblue;" />
                        <input type="button" value="BACK" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                    </td>
                </tr>
                @If String.IsNullOrEmpty(Model.TestNo.TestNo) = False Then
                    @<tr>
                        <td colspan="2">
                            <strong>Test number assigned to this test is:</strong>
                            @Html.DisplayFor(Function(model) model.TestNo.TestNo, New With {.htmlAttributes = New With {.class = "form-control"}})
                        </td>
                    </tr>
                End If
                <tr>

                    <td colspan="2">
                        @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Model.Errormessage
                            </div>
                        Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Html.Raw(Model.Successmessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>
