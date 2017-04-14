@Code
    ViewData("Title") = "Welcome page"
End Code

@ModelType StudentsAssessment.ProfileData

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="~/Scripts/jquery-1.12.4.min.js"></script>
<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        @If Model.Status = "TEACHER" Then
            @<h3>TEACHER TASKS</h3>
        Else
            @<h3>STUDENT TASKS</h3>
        End If
        
        <hr style = "background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        <h3>YOUR PROFILE</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <table cellspacing="2" cellpadding="2">
            <colgroup>
                <col width="250" />
                <col width="250" />
            </colgroup>
            <tr>
                <td>FIRSTNAME:</td>
                <td>@Model.Firstname</td>
            </tr>
            @If Model.Status = "TEACHER" Then
                 @<tr>
                <td>MIDDLENAME :         </td>
                <td>@Model.Middlename</td>
            </tr>
            End If
           
            <tr>
                <td>LASTNAME :  </td>
                <td>@Model.Lastname</td>
            </tr>

            <tr>
                <td>EMAIL ADDRESS:</td>
                <td>@Model.Emailaddress</td>
            </tr>
            <tr>
                <td>CURRENT STATUS:</td>
                <td>@Model.Status</td>
            </tr>
            @If Model.Status = "TEACHER" Then
                @<tr>
                    <td>CURRENT CLASS:</td>
                    <td>@ViewBag.CurrentClass</td>
                </tr>
                @<tr>
                    <td>CURRENT SUBJECT:</td>
                    <td>@ViewBag.CurrentSubject</td>
                </tr>
                @<tr>
                    <td>CURRENT SCHOOL:</td>
                    <td>@ViewBag.School</td>
                </tr>
                @<tr> 
                    <td>SCHOOLINFORMATION:</td>
                    <td>
                        @ViewBag.SchoolDistrict - @ViewBag.City,@ViewBag.State
                </td>
                </tr>
                @<tr>
                    <td>CURRENT TEACHING GRADE LEVEL:</td>
                    <td>@Model.GradeLevelname1</td>
                </tr>
                @<tr>
                    <td colspan="2">
                        <strong>CLASSES YOU ARE CURRENTLY TEACHING</strong>
                    </td>
                </tr>
                @<tr>
                    <td colspan="2">
                        @if Model.TeachingCoursesList1 IsNot Nothing AndAlso
Model.TeachingCoursesList1.Count > 0 Then
                            @<ul>
                                @for each objClass In Model.TeachingCoursesList1
                                    @<li>@objClass.Classname</li>
                                Next
                            </ul>
                        Else
                            @Html.Label("NONE", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;font-weight:normal;"})
                        End If
                    </td>
                </tr>
            ElseIf Model.Status = "STUDENT" Then
                @<tr>
                    <td>CURRENT SCHOOL:</td>
                    <td>@ViewBag.School</td>
                </tr>
                @<tr>
                    <td>CURRENT GRADE LEVEL:</td>
                    <td>@Model.GradeLevelname1</td>
                </tr>
                @<tr>
                    <td colspan="2">
                        <strong>COURSES YOU ARE CURRENTLY ENROLLED IN</strong>
                    </td>
                </tr>
                @<tr>
                    <td colspan="2">
                        @if Model.EnrolledCoursesList IsNot Nothing AndAlso
Model.EnrolledCoursesList.Count > 0 Then
                            @<ul>
                                @for each objClass In Model.EnrolledCoursesList
                                    @<li>@objClass.Classname</li>
                                Next
                            </ul>
                        Else
                            @Html.Label("NONE", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;font-weight:normal;"})
                        End If
                    </td>
                </tr>
            End If

            @If Model.Status = "STUDENT" AndAlso Model.Teachermessages.MessagesList IsNot Nothing AndAlso TypeOf Model.Teachermessages.MessagesList Is List(Of StudentsAssessment.TeachermessageData) Then
                @<tr>
                    <td colspan="2">
                        @if CType(Model.Teachermessages.MessagesList, List(Of StudentsAssessment.TeachermessageData)).Count > 0 Then
                            @<div style="font-weight:bold;"> MESSAGES FROM YOUR TEACHERS</div>
                            @<ul>
                                @For Each objTeacherMessage In CType(Model.Teachermessages.MessagesList, List(Of StudentsAssessment.TeachermessageData))
                                    @<li>
                                        @objTeacherMessage.MessageText
                                    </li>
                                Next
                            </ul>
                            @*Else
                            @Html.Label("NONE", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;font-weight:normal;"})*@
                        End If
                    </td>
                </tr>
            End If
            @If Model.Status = "TEACHER" Then
                @<tr>
                    <td colspan="2">
                        <p>
                            @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                                @<div class="field-validation-error">
                                    @Model.Errormessage
                                </div>
                            Else
                                @<div class="field-validation-error">
                                    @Html.Raw(Model.Successmessage)
                                </div>
                            End If
                        </p>
                    </td>
                </tr>
                @<tr>
                    <td colspan="2">
                        <p>
                            @If TempData("StatusMessage") IsNot Nothing Then
                                @<div class="field-validation-error">
                                    @TempData("StatusMessage")
                                </div>
                            Else
                                @<div class="field-validation-error">
                                    @Html.Raw(TempData("StatusMessage"))
                                </div>
                            End If
                        </p>
                    </td>
                </tr>
            End If
        </table>

        <!-----------Popup--------------
    <div id="dialog" title="Alert" class="dialog">
        <p>This Is the Default dialog which Is useful For displaying information. The dialog window can be moved, resized And closed With the 'x' icon.</p>
    </div>-->
        @*@Html.Raw(ViewBag.Script)*@
        @*@Html.Raw(TempData("Script"))*@
    </div>
</div>