@Code
    ViewData("Title") = "AddClass"
End Code

@ModelType StudentsAssessment.ClassData  
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<script type="text/javascript">
    jQuery(function ($) {
        $("#Starttime").width("50px");
        $("#Endtime").width("50px");
    });
</script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        var serviceURL = '/Classes/GetClassData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedClass').val(); //mere $(this).val() does not seem to work
        if (iSel > 0)
        {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iClassID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
            });
        }
        else
            $("#divStatusMessage").text("No class information found.  Please inform your administrator")

    });

    function FillClassData() {
        $("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Classes/GetClassData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedClass').val(); //mere $(this).val() does not seem to work
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iClassID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        //$('#ClassDuration').val(data.ClassDuration);
        $('#NumCreditHrs').val(data.NumCreditHrs);
        $('#dtStart').text(data.StartDate);
        $('#dtEnd').text(data.EndDate);
        $('#Starttime').val(data.Starttime);
        $('#Endtime').val(data.Endtime);

    }

    function errorFunc() {
        alert('class fill error');
    }
</script>

@*<link rel="stylesheet" media="screen" href="@Url.Content("~/Content/Superfish/src/css/superfish.css")">
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

<script type="text/javascript">
        jQuery(function ($) {
            $("#NumCreditHrs").mask("9.9");
            $("#NumCreditHrs").width("50px");
            $("#ClassDuration").mask("999");
            $("#ClassDuration").width("50px");
            $('#StartDate').datepick();
            $('#EndDate').datepick();
        });
</script>
<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>ADD A CLASS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                @If Model.ClassesList.Count > 0 Then
                    @<tr>
                        <td>
                            @Html.LabelFor(Function(model) model.ClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedClass, Model.ClassesList, New With {.onchange = "FillClassData();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td>
                            @Html.LabelFor(Function(model) model.NumCreditHrs, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.NumCreditHrs, New With {.htmlAttributes = New With {.class = "form-control"}, .type = "text", .readonly = "true"})<br />
                            @Html.ValidationMessageFor(Function(model) model.NumCreditHrs, "", New With {.class = "text-danger"})
                        </td>
                    </tr>

                    @<tr>
                        <td>
                            @Html.LabelFor(Function(model) model.StartDate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @* @Html.DisplayFor(Function(model) model.StartDate, New With {.htmlAttributes = New With {.class = "form-control"}})*@
                            <div id="dtStart">@Model.StartDate</div>
                            @Html.ValidationMessageFor(Function(model) model.EndDate, "", New With {.class = "text-danger"})
                        </td>
                    </tr>

                    @<tr>
                        <td>
                            @Html.LabelFor(Function(model) model.EndDate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @*@Html.EditorFor(Function(model) model.dtEnd, New With {.htmlAttributes = New With {.class = "form-control"}})*@

                            <div id="dtEnd">@Model.EndDate</div>
                            @Html.ValidationMessageFor(Function(model) model.EndDate, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td>
                            @Html.LabelFor(Function(model) model.Starttime, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.Starttime, New With {.htmlAttributes = New With {.class = "form-control"}, .type = "text", .readonly = "true"})<br />
                            @Html.ValidationMessageFor(Function(model) model.Starttime, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td>
                            @Html.LabelFor(Function(model) model.Endtime, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.Endtime, New With {.htmlAttributes = New With {.class = "form-control"}, .type = "text", .readonly = "true"})<br />
                            @Html.ValidationMessageFor(Function(model) model.Endtime, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @*@<tr>
                        <td>
                            @Html.Label("CLASS DURATION IN MINUTES:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.ClassDuration, New With {.htmlAttributes = New With {.class = "form-control"}, .readonly = "true"})<br />
                            @Html.ValidationMessageFor(Function(model) model.ClassDuration, "", New With {.class = "text-danger"})
                        </td>
                    </tr>*@
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="ADD" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />

                        </td>
                    </tr>
                Else
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            No classes are available in the system yet. You must wait till the admin adds some.
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
    </div>@* <div class="col-sm-9"*@
    <div class="col-sm-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Html.Partial("SideMenu")
    </div>
</div>