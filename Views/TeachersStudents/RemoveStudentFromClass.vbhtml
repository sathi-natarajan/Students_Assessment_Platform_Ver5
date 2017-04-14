@Code
    ViewData("Title") = "RemoveStudentFromClass"
End Code

@ModelType StudentsAssessment.StudentData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        FetchStudentsTakingCourse();
    });

    function FetchStudentsTakingCourse() {
        var serviceURL = '/TeachersStudents/GetStudentsTakingCourse'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedCourse').val(); //mere $(this).val() does not seem to work
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iCourseID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    }

    function successFunc(data, status) {
      
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        if (data.length > 0) {

            $('#SelectedStudent').empty();
            $.each(data, function (i, item) {
                $('#SelectedStudent').append($('<option>', {
                    value: item.StudentID,
                    text: item.Firstname+' '+item.Lastname
                }));
            });
        }
        else
            alert("The students list is empty");
    }

    function errorFunc() {
        alert('A problem occured while fetching list of students taking course');
    }
</script>

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
        @<h3>REMOVE STUDENTS FROM YOUR COURSES</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                @if Model.lstCoursesTaughtByTeacher.Count > 0 Then
                    @<tr id="trClasses">
                        <td>
                            @Html.Label("SELECT A COURSE TO REMOVE A STUDENT FROM", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedCourse, Model.lstCoursesTaughtByTeacher, New With {.onchange = "FetchStudentsTakingCourse();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                        </td>
                    </tr>

                    @<tr>
                        <td>
                            @Html.Label("SELECT STUDENT TO REMOVE FROM ABOVE COURSE:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedStudent, Model.StudentsList, New With {.onchange = "FillStudentData();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedStudent, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="REMOVE STUDENT" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                        </td>
                    </tr>
                Else
                    @<tr>
                        <td colspan="2">
                            You are not currently teaching any courses. Nothing to show for removal
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
    </div>
</div>


