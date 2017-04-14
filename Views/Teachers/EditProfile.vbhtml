@Code
    ViewData("Title") = "Edit Teacher Profile"
End Code

@ModelType StudentsAssessment.ProfileData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="https://code.jquery.com/jquery-1.12.4.js"></script>

<link href="~/Content/jQuery_datepicker/css/jquery.datepick.css" rel="stylesheet" />
<script src="~/Content/jQuery_datepicker/js/jquery.plugin.min.js"></script>
<script src="~/Content/jQuery_datepicker/js/jquery.datepick.min.js"></script>

<script>
    $(document).ready(function () {
        LoadSubjectsForCourse();
    });

    function LoadSubjectsForCourse() {
        var serviceURL = '/Teachers/LoadSubjectsForCourse'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedCourse').val(); //mere $(this).val() does not seem to work
        if(iSel>0)
        {
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
        else
        {
            //No course loaded so subjects also cannot be loaded
            $(".divsubjects").hide();
        }
        
    }

    function successFunc(data, status) {

        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        if (data.length > 0) {
            $(".divsubjects").show();
            $('#SelectedSubject').empty();
            $.each(data, function (i, item) {
                $('#SelectedSubject').append($('<option>', {
                    value: item.SubjectID,
                    text: item.Subjectname+' ('+item.Classname+')'
                }));
            });
        }
        else
        {            
            alert("The subjects list is empty");
            $(".divsubjects").hide();
        }
    }

    function errorFunc() {
        alert('A problem occured while fetching list of subjects for course');
    }
</script>
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
            @<h3>EDIT YOUR PROFILE</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td>@Html.Label("First name:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})</td>
                    <td>@Model.Firstname</td>
                </tr>
                 <tr>
                     <td>@Html.Label("Middle name:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})</td>
                     <td>@Model.Middlename</td>
                 </tr>
                <tr>
                    <td>@Html.Label("Last name:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})</td>
                    <td>@Model.Lastname</td>
                </tr>
                 <tr>
                     <td>
                         @Html.Label("Email address:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                     </td>
                     <td>
                         @Html.TextBoxFor(Function(model) model.Emailaddress, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                         @Html.ValidationMessageFor(Function(model) model.Emailaddress, "", New With {.class = "text-danger"})
                     </td>
                 </tr>
                <tr>
                    <td>@Html.Label("Current Status:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})</td>
                    <td>@Model.Status</td>
                </tr>
                @If Model.Status = "TEACHER" Then
                    If Model.TeachingCoursesList.Count > 0 Then
                        @<tr>
                            <td>
                                @Html.Label("Your CURRENT Course:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                            </td>
                            <td>
                                @Html.DropDownListFor(Function(model) model.SelectedCourse, Model.TeachingCoursesList, New With {.onchange = "LoadSubjectsForCourse();"})
                                @Html.ValidationMessageFor(Function(model) model.TeachingCoursesList, "", New With {.class = "text-danger"})
                            </td>
                        </tr>
                    Else
                        @<tr colspan="2">
                            <td>
                                @Html.Label("You do not teach any courses currently", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                            </td>
                        </tr>
                    End If
                    @<tr>
                        <td>
                            <div class="divsubjects">
                                 @Html.Label("Your CURRENT Subject:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                            </div>
                           
                        </td>
                        <td>
                            <div class="divsubjects">
                                 @Html.DropDownListFor(Function(model) model.SelectedSubject, Model.TeachingSubjectsList1)
                                 @Html.ValidationMessageFor(Function(model) model.SelectedSubject, "", New With {.class = "text-danger"})
                            </div>
                        </td>
                    </tr>

                    @<tr>
                        <td>
                            @Html.Label("Your school:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SchoolID, Model.SchoolsList)
                            @Html.ValidationMessageFor(Function(model) model.SchoolID, "", New With {.class = "text-danger"})
                        </td>
                    </tr>

                    @<tr>
                        <td>
                            @Html.Label("Your CURRENT grade level:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.GradeLevelID, Model.GradeLevelsList)
                            @Html.ValidationMessageFor(Function(model) model.GradeLevelID, "", New With {.class = "text-danger"})
                        </td>
                    </tr>

                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="UPDATE" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />
                        </td>
                    </tr>
                    @<tr>
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
                End If
            </table>
        End Using
    </div>
</div>
