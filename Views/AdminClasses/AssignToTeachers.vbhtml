@Code
    ViewData("Title") = "Assign classes to teachers"
End Code

@ModelType StudentsAssessment.ClassData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        var serviceURL = '/Teachers/GetClassData'; //This should not be inside AJAX call itself
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
            $("#divStatusMessage").text("No class information found.  Please inform your administrator")

    });

    function LoadClassDetails() {
        $("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Teachers/GetClassData'; //This should not be inside AJAX call itself
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
        $('#ClassDuration').val(data.ClassDuration);
        $('#NumCreditHrs').val(data.NumCreditHrs);
        $('#StartDate').val(data.StartDate);
        $('#EndDate').val(data.EndDate);
    }

    function errorFunc() {
        alert('class fill error');
    }
</script>

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
            @<h3>ASSIGN A CLASS TO A TEACHER</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="500" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("SELECT A CLASS TO ASSIGN:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})

                        @*@Html.LabelFor(Function(model) model.ClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedClass, Model.ClassesList, New With {.onchange = "LoadClassDetails();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td>
                        @*@Html.Label("SELECT A CLASS TO ASSIGN:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@

                        @Html.LabelFor(Function(model) model.TeacherstoAssigntoList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedTeacher, Model.TeacherstoAssigntoList, New With {.onchange = "LoadClassDetails();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedTeacher, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="ASSIGN CLASS TO TEACHER" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        @* <input type="button" id="btnAddtoTeacher" name="btnAddtoTeacher" value="ASSIGN TO TEACHERS" Class="btn btn-success" onclick="location.href='@Url.Action("Index", "Home")'" /><br/><br />*@
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
