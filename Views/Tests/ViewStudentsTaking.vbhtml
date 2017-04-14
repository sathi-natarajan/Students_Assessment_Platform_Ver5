@ModelType IEnumerable(Of StudentsAssessment.StudentData)
@Code
    ViewData("Title") = "View Students taking selected test"
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
        <h3>LIST OF STUDENTS ASSIGNED TO TAKE THIS TEST</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.StudentID)
                </th>
                <th>
                   Student name
                </th>
            </tr>

            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.StudentID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Firstname)
                            @Html.DisplayFor(Function(modelItem) item.Lastname)
                          
                        </td>
                    </tr>
                Next
                        Else
                @<tr>
                    <td colspan="6">The selected test has not been assigned to anyone yet.</td>
                </tr>
            End If


        </table>
    </div>
</div>
