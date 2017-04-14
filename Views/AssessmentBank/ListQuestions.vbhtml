@ModelType IEnumerable(Of StudentsAssessment.QuestionData)
@Code
    ViewData("Title") = "List of assessnent questions"
End Code

@*<h2>ListQuestions</h2>

    <p>
        @Html.ActionLink("Create New", "Create")
    </p>*@
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>


<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        <h3>QUESTIONS IN ASSESSMENT '@ViewBag.Assessmentname'</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.QuestionID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.QuestionStem)
                </th>

            </tr>
            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.QuestionID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.QuestionStem)
                        </td>
                    </tr>
                Next

            Else
                @<tr>
                    <td colspan="2">
                        This assessment has no questions added to it yet.
                    </td>
                </tr>
            End If


        </table>
    </div>@* <div class="col-sm-9"*@
    <div class="col-sm-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Html.Partial("SideMenu")
    </div>
</div>