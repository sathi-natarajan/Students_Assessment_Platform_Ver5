@ModelType IEnumerable(Of StudentsAssessment.CourseData)
@Code
    ViewData("Title") = "View Student Enrollments"
End Code

<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

@*<h2>ViewEnrollments</h2>*@

@*<p>
        @Html.ActionLink("Create New", "Create")
    </p>*@

<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        <h3>STUDENT TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        <h3>LIST OF COURSES YOU ARE ENROLLED IN</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.CourseID)
                <th>
                    @Html.DisplayNameFor(Function(model) model.Classname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Startdate)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Enddate)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Starttime)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Endtime)
                </th>
            </tr>
            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.CourseID)
                        </td>
                        <td>
                            @*@Html.DisplayFor(Function(modelItem) item.Classname)*@
                            @Html.ActionLink(item.Classname, "ViewCourseSubjects", New With {.id = item.CourseID})
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Startdate)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Enddate)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Starttime)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Endtime)
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
                    <td colspan="5">You do not currently take any class</td>
                </tr>
            End If

        </table>

    </div>
</div>

