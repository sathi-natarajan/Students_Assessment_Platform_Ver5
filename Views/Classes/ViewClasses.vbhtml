@ModelType IEnumerable(Of StudentsAssessment.ClassData)
@Code
    ViewData("Title") = "View classes taught by teacher"
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
        <h3>LIST OF CLASSES TAUGHT BY YOU</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.ClassID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Classname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.NumCreditHrs)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.StartDate)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.EndDate)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.ClassDuration)
                </th>
            </tr>
            
            @If Model.Count > 0 Then
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.ClassID)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Classname)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.NumCreditHrs)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.StartDate)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.EndDate)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.ClassDuration)
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
                     <td colspan="6">You do not currently teach any class</td>
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