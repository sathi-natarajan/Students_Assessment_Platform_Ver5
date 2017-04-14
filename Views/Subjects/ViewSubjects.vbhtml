@ModelType IEnumerable(Of StudentsAssessment.SubjectsData)
@Code
    ViewData("Title") = "View subjects taught by teacher"
End Code

@*<p>
        @Html.ActionLink("Create New", "Create")
    </p>*@

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        <h3>LIST OF SUBJECTS YOU TEACH IN YOUR CLASSES</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Classname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.GradeLevelname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Subjectname)
                </th>
                <th></th>
            </tr>
            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Classname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.GradeLevelname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Subjectname)
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
                     <td colspan="4">You currently do not teach any subjects in any of your classes</td>
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