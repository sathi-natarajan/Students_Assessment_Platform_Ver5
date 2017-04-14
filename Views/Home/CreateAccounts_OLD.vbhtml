@ModelType StudentsAssessment.CreateAccountData
@Code
    ViewData("Title") = "CreateAccounts"
End Code

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script language="javascript" type="text/javascript">
    function RadioButtonSelected(data)
    {
        switch (data) {
            case 'student':
                $("#divPassword").text("student");
                $("#spnAccountType").text("STUDENT");
                break;
            case 'teacher':
                $("#divPassword").text("teacher");
                $("#spnAccountType").text("TEACHER");
                break;
        }
    }
</script>
<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <h3>CREATE ACCOUNTS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Using (Html.BeginForm("DoCreateAccount", "Home"))
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td valign="top">
                        @Html.LabelFor(Function(model) model.TypeofAccount, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td valign="top">
                        <div Class="col-md-10" style="border:2px solid lightgray;width:250px;">
                            @If Session("AcctType") IsNot Nothing AndAlso Session("AcctType").ToString.ToLower = "teacher" Then
                                @Html.RadioButton("TypeofAccount", "teacher", New With {.onchange = "RadioButtonSelected('teacher');", .checked = "checked"})
                            Else
                                @Html.RadioButton("TypeofAccount", "teacher", New With {.onchange = "RadioButtonSelected('teacher');"})
                            End If
                            TEACHER ACCOUNT
                            <br />
                            @If Session("AcctType") IsNot Nothing AndAlso Session("AcctType").ToString.ToLower = "student" Then
                                @Html.RadioButton("TypeofAccount", "student", New With {.onchange = "RadioButtonSelected('student');", .checked = "checked"})
                            Else
                                @Html.RadioButton("TypeofAccount", "student", New With {.onchange = "RadioButtonSelected('student');"})
                            End If
                            STUDENT ACCOUNT
                            @Html.ValidationMessageFor(Function(model) model.TypeofAccount, "", New With {.class = "text-danger"})
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h3 style="text-align:center;">
                            @If Session("AcctType") IsNot Nothing AndAlso Session("AcctType").ToString.ToLower = "teacher" Then
                                @<span id="spnAccountType">TEACHER </span>
                            ElseIf Session("AcctType") IsNot Nothing AndAlso Session("AcctType").ToString.ToLower = "student" Then
                                @<span id="spnAccountType">STUDENT </span>
                            Else
                                @<span id="spnAccountType"></span>
                            End If
                            ACCOUNT DETAILS
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        @Html.LabelFor(Function(model) model.Firstname, htmlAttributes:=New With {.class = "control-label col-md-10"})
                    </td>
                    <td valign="top">
                        @Html.EditorFor(Function(model) model.Firstname, New With {.htmlAttributes = New With {.class = "form-control"}})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Firstname, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        @Html.LabelFor(Function(model) model.Lastname, htmlAttributes:=New With {.class = "control-label col-md-10"})
                    </td>
                    <td valign="top">
                        @Html.EditorFor(Function(model) model.Lastname, New With {.htmlAttributes = New With {.class = "form-control"}})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Lastname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @Html.Label("Username: Auto-assigned by system", htmlAttributes:=New With {.class = "control-label col-md-10", .style = "width:  100%;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Password:", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    </td>
                    <td valign="top">
                        <div id="divPassword" style="font-weight:bold;">
                            @If Session("AcctType") IsNot Nothing AndAlso Session("AcctType").ToString.ToLower = "teacher" Then
                                @Html.Label("teacher", New With {.htmlAttributes = New With {.class = "form-control"}})
                            ElseIf Session("AcctType") IsNot Nothing AndAlso Session("AcctType").ToString.ToLower = "student" Then
                                @Html.Label("student", New With {.htmlAttributes = New With {.class = "form-control"}})
                            Else
                                @Html.Label("", New With {.htmlAttributes = New With {.class = "form-control"}})
                            End If

                        </div>
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        @Html.Label("SCHOOL:", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    </td>
                    <td valign="top">
                        @Html.EditorFor(Function(model) model.SelectedSchool, New With {.htmlAttributes = New With {.class = "form-control"}})
                    </td>
                </tr>

            </table>
            @<br />
            @<div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="CREATE THIS ACCOUNT" class="btn btn-success" style="background:cadetblue;" />
                    <input type="button" value="BACK TO MAIN" class="btn btn-success" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                    @If String.IsNullOrEmpty(ViewBag.StatusMessage) = False Then
                        @<div class="field-validation-error">
                            @ViewBag.StatusMessage
                        </div>
                    Else
                        @<div class="field-validation-error">
                            @Html.Raw(ViewBag.StatusMessage)
                        </div>
                    End If
                </div>
            </div>
        End Using
    </div>
    @*<div class="col-sm-3" style="margin-top:-50px;margin-left:60%;margin-top:50px;position:absolute;">
            @If Session("LoggedinAdminID") IsNot Nothing AndAlso IsNumeric(Session("LoggedinAdminID")) AndAlso Integer.Parse(Session("LoggedinAdminID")) > 0 Then
        @<strong>ACCOUNT TASKS</strong>@<br />@<br />
        @<ul id="AccountTasks" Class="sf-menu sf-vertical" style="width:200px;">
            <li style="background-color:#bbd775;">
                <a href="@Url.Action(" ActivateAccounts", " Home")">ACTIVATE ACCOUNTS</a>
            </li>
            <li style="background-color:#bbd775;">
                <a href="@Url.Action(" ActivateAccounts", " Home")">ADD MULTIPLE ACCOUNTS</a>
            </li>
        </ul>
            End If

        </div>*@

    <div Class="col-sm-3" style="padding-top:20px;padding-left:100px;">
        @Html.Partial("SideMenu")
</div>
</div>