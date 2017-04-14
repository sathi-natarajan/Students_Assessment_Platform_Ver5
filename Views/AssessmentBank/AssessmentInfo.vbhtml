@Code
    ViewData("Title") = "Assessment Information"
End Code

@ModelType StudentsAssessment.AssessmentData

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
            @<h3>INFORMATION ON SELECTED ASSESSMENT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />

            @If Model.ErrorMessage IsNot Nothing AndAlso String.IsNullOrEmpty(Model.ErrorMessage) = True Then
                @<table border="0" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>
                            @Html.DisplayNameFor(Function(model) model.AssessmentID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(model) model.AssessmentID)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            @Html.DisplayNameFor(Function(model) model.Assessmentname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(model) model.Assessmentname)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            @Html.DisplayNameFor(Function(model) model.Description)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(model) model.Description)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            @Html.DisplayNameFor(Function(model) model.NoQuestions)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(model) model.NoQuestions)
                        </td>
                    </tr>
                   
                   
                    <tr>
                        <td>
                            @Html.DisplayNameFor(Function(model) model.CreateDate)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(model) model.CreateDate)
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <input type="button" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "AssessmentBank")'" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            @If String.IsNullOrEmpty(ViewBag.StatusMessage) = False Then
                                @<div class="field-validation-error">
                                    @ViewBag.StatusMessage
                                </div>
                            Else
                                @<div class="field-validation-error">
                                    @Html.Raw(ViewBag.StatusMessage)
                                </div>
                            End If
                        </td>
                    </tr>
                </table>
            Else
                @<div>Problem loading the assessment information</div>
            End If

        End Using
    </div>
    <div class="col-sm-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Html.Partial("SideMenu")
    </div>
</div>
