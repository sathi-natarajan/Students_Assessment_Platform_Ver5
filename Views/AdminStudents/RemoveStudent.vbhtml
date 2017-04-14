@Code
    ViewData("Title") = "RemoveStudent"
End Code

@ModelType StudentsAssessment.StudentData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

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
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>REMOVE A STUDENT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table id="" border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="250" />
                </colgroup>

                <tr id="trClasses">
                    <td>
                        @Html.Label("SELECT STUDENT TO REMOVE:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        @*@Html.LabelFor(Function(model) model.StudentsList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedStudent, Model.StudentsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedStudent, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="REMOVE" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />

                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        @If String.IsNullOrEmpty(ViewBag.StatusMessage) = True Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @ViewBag.StatusMessage
                            </div>
                        Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Html.Raw(ViewBag.StatusMessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>