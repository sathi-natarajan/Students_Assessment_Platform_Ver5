@Code
    ViewData("Title") = "AddStudenttoClass"
End Code

@ModelType StudentsAssessment.StudentData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

@*<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        var serviceURL = '/Teachers/GetStudentsData'; //This should not be inside AJAX call itself
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
        else {
            $("#divStatusMessage").text("Your class list is empty.  Please add some classes to your list first");
            $("#trClasses").css("visibility", "hidden");
            $("#trStudents").css("visibility", "hidden");
            $("#trDetails").css("visibility", "hidden");

        }

    });

    function FillStudentData() {
        var serviceURL = '/Teachers/GetStudentData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedStudent').val(); //mere $(this).val() does not seem to work
        if (iSel > 0) {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iStudentID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc1,
                error: errorFunc1
            });
        }
        else {
            $("#divStatusMessage").text("Your students list is empty.  Please contact administrator.  Or,  choose another class.");
            //$("#trClasses").css("visibility", "hidden");
            $("#trStudents").css("visibility", "hidden");
            $("#trDetails").css("visibility", "hidden");
        }
    }
    function FillStudentsData() {
        var serviceURL = '/Teachers/GetStudentsData'; //This should not be inside AJAX call itself
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
        //$('#SelectedSubject').append($('<option>', {
        //    value: data.Value,
        //    text: data.Text
        //})).append($('<option>', {
        //    value: data.Value,
        //    text: data.Text
        //}))

        $("#trClasses").css("visibility", "visible");
        $("#trStudents").css("visibility", "visible");
        $("#trDetails").css("visibility", "visible");

        if (data.length > 0) {
            $('#SelectedStudent').empty();
            $.each(data, function (i, item) {
                $('#SelectedStudent').append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });
            FillStudentData();
        }
        else {
            $("#divStatusMessage").text("Your students list is empty.  Please contact administrator.  Or,  choose another class.");
            //$("#trClasses").css("visibility", "hidden");
            $("#trStudents").css("visibility", "hidden");
            $("#trDetails").css("visibility", "hidden");
        }

    }

    function errorFunc() {
        alert('class fill error');
    }

    function successFunc1(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        $("#trStudents").css("visibility", "visible");
        $("#trDetails").css("visibility", "visible");
        $('#Joindate').val(data.Joindate);
    }
    function errorFunc1() {
        alert('students fill error');
    }
</script>*@

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
        @<h3>ADD STUDENTS FROM YOUR SCHOOL TO YOUR COURSES</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                @If Model.lstCoursesTaughtByTeacher.Count > 0 Then
                    @<tr>
                        <td>
                        @Html.Label("SELECT A COURSE TO ADD STUDENT TO", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                        @Html.DropDownListFor(Function(model) model.SelectedCourse, Model.lstCoursesTaughtByTeacher, New With {.onchange = "FillStudentsData();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedCourse, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan = "2" >
                            @*@Html.LabelFor(Function(model) model.StudentsList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                            @Html.Label("SELECT A STUDENT TO ADD TO ABOVE COURSE", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                            @Html.DropDownListFor(Function(model) model.SelectedStudent, Model.StudentsList, New With {.onchange = "FillStudentData();"})
                            @Html.ValidationMessageFor(Function(model) model.StudentsList, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan = "2" style="text-align:center;">
                            <input type = "submit" value="ADD" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type = "button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />
                        </td>
                    </tr>
                Else
                    @<tr>
                        <td colspan="2">You are not teaching any courses currently.</td>
                    </tr>
                    @<tr>
                        <td colspan="2">
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />
                        </td>
                    </tr>
                End If
               
                @*<tr id="trStudents">
                    <td colspan="2"></td>
                </tr>
                <tr id="trDetails">
                    <td>
                        @Html.LabelFor(Function(model) model.Joindate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Joindate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:100%;"}, .readonly = "true"})
                        @Html.ValidationMessageFor(Function(model) model.Joindate, "", New With {.class = "text-danger"})
                    </td>
                </tr>*@
                
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