@Code
    ViewData("Title") = "Edit a class"
    'Layout = Nothing
End Code

@ModelType StudentsAssessment.ClassData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

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
        $("#NumCreditHrs").mask("9.9");
        $("#NumCreditHrs").width("50px");
        //$("#ClassDuration").mask("999");
        //$("#ClassDuration").width("50px");
        $('#StartDate').datepick();
        $('#EndDate').datepick();
        $("#Starttime").mask("99.99");
        $("#Endtime").mask("99.99");
        $("#Starttime").width("50px");
        $("#Endtime").width("50px");
    });
</script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        var serviceURL = '/Classes/GetClassData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedClass').val(); //mere $(this).val() does not seem to work
        if (iSel > 0) {
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
            $("#divStatusMessage").text("Information on the selected class could not be loaded")

    });

    function LoadClassDetails() {
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
        $('#StartDate').val(data.StartDate);
        $('#EndDate').val(data.EndDate);
        $('#Starttime').val(data.Starttime);
        $('#Endtime').val(data.Endtime);
    }

    function errorFunc() {
        alert('Information on the selected class could not be loaded');
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
            @<h3>EDIT A CLASS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("SELECT A CLASS TO EDIT:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})

                        @*@Html.LabelFor(Function(model) model.ClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedClass, Model.ClassesList, New With {.onchange = "LoadClassDetails();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.NumCreditHrs, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.NumCreditHrs, New With {.htmlAttributes = New With {.class = "form-control"}, .type = "text"})<br />
                        @Html.ValidationMessageFor(Function(model) model.NumCreditHrs, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.StartDate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.StartDate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .id = "StartDate"})<br />
                        @Html.ValidationMessageFor(Function(model) model.StartDate, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.EndDate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.EndDate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text"})<br />
                        @Html.ValidationMessageFor(Function(model) model.EndDate, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td>
                        @Html.Label("Start time:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Starttime, New With {.htmlAttributes = New With {.class = "form-control"}})<br />
                        @Html.ValidationMessageFor(Function(model) model.Starttime, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("End time:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Endtime, New With {.htmlAttributes = New With {.class = "form-control"}})<br />
                        @Html.ValidationMessageFor(Function(model) model.Endtime, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                @*<tr>
                    <td>
                        @Html.Label("CLASS DURATION IN MINUTES:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.ClassDuration, New With {.htmlAttributes = New With {.class = "form-control"}})<br />
                        @Html.ValidationMessageFor(Function(model) model.ClassDuration, "", New With {.class = "text-danger"})
                    </td>
                </tr>*@
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="UPDATE CLASS INFO" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" id="BACK TO MAIN" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
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
