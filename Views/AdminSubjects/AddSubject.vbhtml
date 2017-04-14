@Code
    ViewData("Title") = "AddSubjects"
End Code

@ModelType StudentsAssessment.SubjectsData
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
            @<h3>CREATE A NEW SUBJECT AND ADD TO A CLASS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="250" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("SUBJECT NAME:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Subjectname, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text"})
                        @Html.ValidationMessageFor(Function(model) model.Subjectname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @Html.Label("IN WHICH CLASS IS THIS SUBJECT TO BE TAUGHT?", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        @Html.DropDownListFor(Function(model) model.SelectedClass, Model.ClassesTobeTaughtInList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="CREATE SUBJECT" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
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
