@Code
    ViewData("Title") = "Activate/Deactivate Student Account"
End Code

@ModelType StudentsAssessment.StudentData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

@*<link rel="stylesheet" media="screen" href="@Urls.Content("~/Content/Superfish/src/css/superfish.css")">
    <link href="@Url.Content("~/Content/Superfish/css/superfish-vertical.css")" rel="stylesheet" />
    <script src="@Url.Content("~/Content/Superfish/js/jquery.js")"></script>
    <script src="@Url.Content("~/Content/Superfish/js/superfish.js")"></script>
    <script src="@Url.Content("~/Content/Superfish/js/hoverIntent.js")"></script>*@

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="~/Content/MaskedInput/jquery.maskedinput.min.js"></script>

<link href="~/Content/jQuery_datepicker/css/jquery.datepick.css" rel="stylesheet" />
<script src="~/Content/jQuery_datepicker/js/jquery.plugin.min.js"></script>
<script src="~/Content/jQuery_datepicker/js/jquery.datepick.min.js"></script>

<script type="text/javascript">
    jQuery(function ($) {
        var serviceURL = '/Accounts/GetStudentAcctData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedStudent').val(); //mere $(this).val() does not seem to work
        if (iSel > 0) {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iStudentID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
            });
        }
        else
            $("#divStatusMessage").text("No teachers are available in system.  Please inform your administrator")


    });

    function LoadStudentActiveStatus() {
        $("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Accounts/GetStudentAcctData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedStudent').val(); //mere $(this).val() does not seem to work
        if (iSel > 0) {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iStudentID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
            });
        }
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        //$('#StartDate').val(data.Joindate);
        $("#isActive").prop("checked", data.isActive);
        if (data.isActive == true)
            $("#btnSubmit").val("DE-ACTIVATE STUDENT");
        else
            $("#btnSubmit").val("ACTIVATE STUDENT");
    }

    function errorFunc() {
        alert('Problem while loading account info for this teacher.  Please inform administrator.');
    }
</script>

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
            @<h3>ACTIVATE/DEACTIVATE STUDENT ACCOUNT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>

                <tr>
                    <td>
                        @Html.Label("SELECT A STUDENT:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})

                        @*@Html.LabelFor(Function(model) model.ClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedStudent, Model.StudentsList, New With {.onchange = "LoadStudentActiveStatus();"})
                        @Html.ValidationMessageFor(Function(model) model.StudentsList, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    @*<td>
                        @Html.LabelFor(Function(model) model.isActive, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>*@
                    <td colspan="2">
                        <label for="isActive" class="control-label col-md-2" style="width:50%;">Is Account Active?</label>&nbsp;
                        @Html.CheckBoxFor(Function(model) model.isActive, New With {.htmlAttributes = New With {.class = "form-control"}})<br />
                        @Html.ValidationMessageFor(Function(model) model.isActive, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <input id="btnSubmit" type="submit" value="ACTIVATE/DEACTIVATE TEACHER" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
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
    @If ViewBag.Script IsNot Nothing Then
        @Html.Raw(ViewBag.Script)
    End If