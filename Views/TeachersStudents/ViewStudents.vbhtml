@ModelType IEnumerable(Of StudentsAssessment.StudentData)
@Code
    ViewData("Title") = "View students"
End Code

@*<p>
        @Html.ActionLink("Create New", "Create")
    </p>*@

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
        <h3>LIST OF STUDENTS IN ALL YOUR COURSES</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.StudentID)
                </th>
                <th>
                    Student name
                </th>
                <th>
                    Course
                </th>
                <th>
                   Class
                </th>
                <th>
                    Subject
                </th>
            </tr>

            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.StudentID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Firstname)&nbsp;
                            @Html.DisplayFor(Function(modelItem) item.Lastname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.CourseName)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.ClassName)
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
                    <td colspan="6">There are currently no students in any of the courses you teach/plan to teach</td>
                </tr>
            End If
        </table>
    </div>
</div>