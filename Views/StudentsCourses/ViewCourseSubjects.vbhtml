@ModelType IEnumerable(Of StudentsAssessment.SubjectsData)
@Code
    ViewData("Title") = "View students taking selected course"
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
        <h3>STUDENT TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        <h3>SELECTED COURSE: @Session("Coursename").ToString </h3>
        <h4>List of subjects taught in this course</h4>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.SubjectID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Subjectname)
                </th>
            </tr>

            @If Model IsNot Nothing AndAlso Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.SubjectID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Subjectname)

                        </td>
                        @*<td>
                        @Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})
                                            </td>*@
                    </tr>
                Next
            Else
                @<tr>
                    <td colspan="3">No student is currently taking this course</td>
                </tr>
            End If
            <tr>
                <td colspan="3">
                    @for i = 1 To 10
                        @<p>&nbsp;</p>
                    Next
                    <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("ViewCourses", "Courses")'" />
                </td>
            </tr>

        </table>
    </div>
</div>
