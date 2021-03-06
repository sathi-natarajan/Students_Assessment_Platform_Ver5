﻿@ModelType IEnumerable(Of StudentsAssessment.CourseData)
@Code
    ViewData("Title") = "View courses taught by teacher"
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
        <h3>LIST OF COURSES TAUGHT BY YOU</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.CourseID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Classname)
                </th>
                <th>
                    Taught Subject
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
                            @Html.ActionLink(item.Classname, "ViewCourseStudents", New With {.id = item.CourseID})
                        </td>
                        @*<td>
                            @Html.DisplayFor(Function(modelItem) item.Subjects.Subjectname)
                        </td>*@
                        <td>
                            @If item.lstTaughtSubjects IsNot Nothing AndAlso item.lstTaughtSubjects.Count > 0 Then
                                For Each objsubjectsData In item.lstTaughtSubjects
                                    @objsubjectsData.Subjectname@<br />
                                Next
                            Else
                                @Html.Display("None")
                            End If
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
                    <td colspan="6">You do not currently teach any courses</td>
                </tr>
            End If


        </table>
    </div>
</div>