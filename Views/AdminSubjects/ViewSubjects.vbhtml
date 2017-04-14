@ModelType IEnumerable(Of StudentsAssessment.SubjectsData)
@Code
    ViewData("Title") = "View all available subjects"
End Code

@*<h2>ViewSubjects</h2>

    <p>
        @Html.ActionLink("Create New", "Create")
    </p>*@

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        <h3>ADMIN TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        <h3>LIST OF ALL SUBJECTS AVAILABLE IN SYSTEM</h3>
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.SubjectID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Subjectname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Classname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.GradeLevelname)
                </th>
            </tr>
            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.SubjectID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Subjectname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Classname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.GradeLevelname)
                        </td>
                        <td>
                            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
                        </td>
                    </tr>
                Next
    Else
                @<tr>
                    <td colspan="4">There are no subjects available in the system for any classes yet</td>
                </tr>
            End If

        </table>
    </div>
</div>