@Code
    ViewData("Title") = "Create a new class"
    'Layout = Nothing
End Code

@ModelType StudentsAssessment.ClassData
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
        $("#NumCreditHrs").mask("9.9");
        $("#NumCreditHrs").width("50px");
        $("#ClassDuration").mask("999");
        $("#ClassDuration").width("50px");
        $('#StartDate').datepick();
        $('#EndDate').datepick();
        $("#Starttime").mask("99.99");
        $("#Endtime").mask("99.99");
        $("#Starttime").width("50px");
        $("#Endtime").width("50px");
    });
</script>


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
            @<h3>CREATE A NEW CLASS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("CLASS NAME:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Classname, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Classname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.NumCreditHrs, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.NumCreditHrs, New With {.htmlAttributes = New With {.class = "form-control"}, .type = "text"})<br />
                        @Html.ValidationMessageFor(Function(model) model.NumCreditHrs, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.StartDate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.StartDate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .id = "StartDate"})<br />
                        @Html.ValidationMessageFor(Function(model) model.StartDate, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.EndDate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.EndDate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text"})<br />
                        @Html.ValidationMessageFor(Function(model) model.EndDate, "", New With {.class = "text-danger"})
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
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="CREATE NEW" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                    </td>
                </tr>
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