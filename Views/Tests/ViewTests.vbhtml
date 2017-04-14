﻿@ModelType IEnumerable(Of StudentsAssessment.TestData)
@Code
    ViewData("Title") = "View Tests created by teacher"
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
        <h3>LIST OF ALL TESTS ADMINISTERED BY YOU</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.TestID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Testname)
                </th>
                <th>
                    Assessments
                </th>
            </tr>

            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.TestID)
                        </td>
                        <td>
                            @*@Html.DisplayFor(Function(modelItem) item.Classname)*@
                            @Html.ActionLink(item.Testname, "ViewStudentsTaking", New With {.id = item.TestID})
                        </td>
                        @*<td>
                            @Html.DisplayFor(Function(modelItem) item.Subjects.Subjectname)
                        </td>*@
                        <td>
                            @If item.ListofAssessments IsNot Nothing AndAlso item.ListofAssessments.Count > 0 Then
                                For Each objAssessment In item.ListofAssessments
                                    @objAssessment.Assessmentname@<br />
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