
@Code
    ViewData("Title") = "RemoveSubjectFromClass"
End Code

@ModelType StudentsAssessment.SubjectsData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        //$("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Teachers/GetTaughtSubjectsData'; //This should not be inside AJAX call itself
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
        {

            $("#divStatusMessage").text("This teacher does not teach any subjects in any classes yet.  Please add some subjects to classes first")
            $('#trClassesList').css("visibility", "hidden");
            $('#trSubjectsList').css("visibility", "hidden");
            //$('#trSubjectDetails').css("visibility", "hidden");
        }

    });

    function FillSubjectData() {
        //$("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Teachers/GetSubjectData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedSubject').val(); //mere $(this).val() does not seem to work
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iSubjectID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc1,
            error: errorFunc1
        });
    }
    function FillSubjectsData() {
        //$("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Teachers/GetTaughtSubjectsData'; //This should not be inside AJAX call itself
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
        FillSubjectData();
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        //$('#SelectedSubject').append($('<option>', {
        //    value: data.Value,
        //    text: data.Text
        //})).append($('<option>', {
        //    value: data.Value,
        //    text: data.Text
        //}))

        if (data.length > 0) {
            $('#trSubjectsList').css("visibility", "visible");
            //$('#trSubjectDetails').css("visibility", "visible");
            $('#SelectedSubject').empty();
            $.each(data, function (i, item) {
                $('#SelectedSubject').append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });
            FillSubjectData();
        }
        else
        {
            $("#divStatusMessage").text("Your subject list is empty.  Please contact administrator.  Or,  choose another class.");
            $('#trSubjectsList').css("visibility", "hidden");
            //$('#trSubjectDetails').css("visibility", "hidden");
        }
    }


    function errorFunc() {
        alert('class fill error');
    }

    function successFunc1(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        $('#GradeLevel').val(data.GradeLevel);
    }
    function errorFunc1() {
        alert('subjects fill error');
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

<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>REMOVE SUBJECT FROM A CLASS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2" >
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                <tr id="trClassesList">
                    <td>
                        @*@Html.LabelFor(Function(model) model.TaughtClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                        @Html.Label("SELECT CLASS BEING TAUGHT BY TEACHER", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedClass, Model.TaughtClassesList, New With {.onchange = "FillSubjectsData();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr id="trSubjectsList">
                    <td>
                        @*@Html.LabelFor(Function(model) model.SubjectsList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                        @Html.Label("SELECT SUBJECT BEING TAUGHT IN CLASS", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedSubject, Model.SubjectsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedSubject, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="REMOVE" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
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
    </div>@* <div class="col-sm-9"*@
    <div class="col-sm-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Html.Partial("SideMenu")
    </div>
</div>