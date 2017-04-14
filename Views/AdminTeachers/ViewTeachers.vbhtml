@ModelType IEnumerable(Of StudentsAssessment.TeacherData)
@Code
    ViewData("Title") = "View all available teachers"
End Code

@*<h2>ViewTeachers</h2>

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
        <h3>LIST OF ALL TEACHERS AVAILABLE IN SYSTEM</h3>

        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.TeacherID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Firstname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Lastname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Joindate)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Username)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Password)
                </th>
            </tr>

            @If Model.Count() > 0 Then

                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.TeacherID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Firstname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Lastname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Joindate)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Username)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Password)
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
                    <td colspan="6">There are no teachers current available in the system</td>
                </tr>
            End If

        </table>
    </div>
</div>
