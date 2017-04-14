@Code
    ViewData("Title") = "Student Assessment Platform - Add question to assessment"
End Code
@ModelType StudentsAssessment.QuestionData
<h2>AddtoAssessment</h2>

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
            @<h3>ADD THIS QUESTION TO AN ASSESSMENT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="250" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("QUESTION ID", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.Label(Session("QuestionID").ToString, htmlAttributes:=New With {.Class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("SELECTED QUESTION", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.Label(ViewBag.Question.ToString, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;font-weight:normal;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.AssessmentsList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedAssessment, Model.AssessmentsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedAssessment, "", New With {.class = "text-danger"})
                    </td>
                </tr>
            </table>
            @<table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="ADD TO ASSESSMENT" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("New_AddtoAssessment", "QuestionBank", New With {.QuestionID = 2})'" />
                        <input type="button" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("NewList", "QuestionBank")'" />
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>

