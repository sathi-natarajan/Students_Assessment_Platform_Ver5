@Code
    ViewData("Title") = "Update an assessment"
End Code

@ModelType StudentsAssessment.AssessmentData

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
        @<h3>UPDATE SELECTED ASSESSMENT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="5" cellspacing="5">
                <colgroup>
                    <col width="250" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td colspan="2">
                        TO MODIFY THE ASSESSMENT NAME, TYPE OVER THE BELOW TEXT
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @Html.TextBoxFor(Function(model) model.Assessmentname, htmlAttributes:=New With {.class = "control-label col-md-2", .maxlength = 50, .style = "width:100%;height:50px;"})
                        @Html.ValidationMessageFor(Function(model) model.Assessmentname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        TYPE OVER THE BELOW TEXT TO MODIFY THE DESCRIPTION OF THE
                        ASSESSMENT (Max no. of chars : 250)
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @Html.TextBoxFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2", .maxlength = 100, .style = "width:100%;height:50px;"})
                        @Html.ValidationMessageFor(Function(model) model.Assessmentname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
            </table>

            @<table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="UPDATE ASSESSMENT" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("NewList", "QuestionBank")'" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @If String.IsNullOrEmpty(TempData("StatusMessage")) = False Then
                            @<div class="field-validation-error">
                                @TempData("StatusMessage")
                            </div>
                        Else
                            @<div class="field-validation-error">
                                @Html.Raw(TempData("StatusMessage"))
                            </div>
                        End If
                    </td>
                </tr>
            </table>
       End Using
    </div>
</div>
