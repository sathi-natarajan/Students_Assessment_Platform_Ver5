@Code
    ViewData("Title") = "Assign Test to students"
End Code

@ModelType StudentsAssessment.TestData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

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
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>ASSIGN A TEST TO A STUDENT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="500" />
                    <col width="300" />
                </colgroup>
                @If Model.TestsList.Count > 0 Then
                    @<tr>
                        <td>
                            @Html.Label("SELECT A TEST TO ASSIGN:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})

                            @*@Html.LabelFor(Function(model) model.ClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedTest, Model.TestsList)
                            @Html.ValidationMessageFor(Function(model) model.SelectedTest, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @If Model.StudentstoAssigntoList.Count > 0 Then
                        @<tr>
                            <td>
                                @Html.Label("SELECT A STUDENT TO ASSIGN TEST TO:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})

                                @*@Html.LabelFor(Function(model) model.ClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                            </td>
                            <td>
                                @Html.DropDownListFor(Function(model) model.SelectedStudent, Model.StudentstoAssigntoList)
                                @Html.ValidationMessageFor(Function(model) model.SelectedStudent, "", New With {.class = "text-danger"})
                            </td>
                        </tr>
                        @<tr>
                            <td colspan="2" style="text-align:center;">
                                <input type="submit" value="ASSIGN" Class="btn btn-success clsbutton" style="background:cadetblue;" />
                                <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                            </td>
                        </tr>
                    Else
                        @<tr>
                            <td colspan="2" style="text-align:center;">
                                There are no students available to assign selected to. Please create a student account first
                            </td>
                        </tr>
                        @<tr>
                            <td colspan="2" style="text-align:center;">
                                <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                            </td>
                        </tr>
                    End If


                Else
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            There are no tests available for this teacher. Please create a test first
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                        </td>
                    </tr>
                End If
                <tr>
                    <td colspan="2">
                        @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Model.Errormessage
                            </div>
                        Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Html.Raw(Model.Successmessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>
