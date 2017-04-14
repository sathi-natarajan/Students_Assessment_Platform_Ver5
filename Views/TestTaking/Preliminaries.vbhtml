@Code
    ViewData("Title") = "Testing Preliminaries"
End Code

@ModelType StudentsAssessment.TestQAData

<div class="row">
    <div class="col-lg-8" style="padding:100px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>TESTS ASSIGNED TO YOU</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7" style="width:800px;">
                <colgroup>
                    <col width="250" />
                    <col width="550" />
                </colgroup>
        @If Model.TestsList.Count > 0 Then
            @<tr>
                <td valign="top">
                    @Html.Label("SELECT A TEST TO TAKE", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                </td>
                <td>
                    @Html.DropDownListFor(Function(model) model.SelectedTest, Model.TestsList, New With {.onchange = "FillClassData();"})
                    @Html.ValidationMessageFor(Function(model) model.SelectedTest, "", New With {.class = "text-danger"})
                </td>
            </tr>
            @If Model.SelectedTest = 0 AndAlso Model.SelectedAssessment = 0 Then
                @<tr>
                    <td colspan="2">
                        <input type="submit" value="SELECT TEST" Class="btn btn-success clsbutton" style="background:cadetblue;" />
                    </td>
                </tr>
            End If

             @If Model.SelectedTest > 0 Then
               @*You have selected a test at this point*@
                @<tr>
                    <td colspan="2">
                        <h3>VERIFICATION OF TEST CODE FOR SELECTED TEST</h3>
                        <hr style="background-color:cadetblue;height:2px;" /><br />
                        @Html.Label("Enter the 9-digit test code that you are assigned for this test:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        @Html.TextBoxFor(Function(model) model.TestNoEntered.TestNo, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                </tr>
                @<tr>
                    <td>
                        @*Once a test number is entered, you no longer show this button*@
                        @If String.IsNullOrEmpty(Model.TestNoEntered.TestNo) Then
                            @<input type="submit" value="VERIFY TEST CODE" Class="btn btn-success clsbutton" style="background:cadetblue;" />
                        End If   
                    </td>
                </tr>
                @If String.IsNullOrEmpty(Model.TestNoEntered.TestNo) = False Then
                    @*TestNo has been entered*@
                If Model.TestNoValid Then
                        @If Model.SelectedTest > 0 AndAlso Model.AssessmentsList.Count > 0 AndAlso Model.TestNoValid Then
                            @<tr>
                                <td colspan="2">
                                    <h3>ASSESSMENTS IN SELECTED TEST</h3>
                                    <hr style="background-color:cadetblue;height:2px;" />
                                </td>
                            </tr>
                            @<tr>
                                <td valign="top">
                                    @Html.Label("SELECT AN ASSESSMENT TO TAKE", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                                </td>
                                <td>
                                    @Html.DropDownListFor(Function(model) model.SelectedAssessment, Model.AssessmentsList)
                                    @Html.ValidationMessageFor(Function(model) model.SelectedAssessment, "", New With {.class = "text-danger"})
                                </td>
                            </tr>
                            @<tr>
                                <td colspan="2">
                                    <input type="submit" value="SELECT ASSESSMENT" Class="btn btn-success clsbutton" style="background:cadetblue;" />
                                </td>
                            </tr>        
                        End If
                Else
                    @*TestNo entered is invalid*@
                    @<tr>

                    <td colspan = "2" >
                        @If String.IsNullOrEmpty(ViewBag.StatusMessage) = False Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @ViewBag.StatusMessage
                            </div>
Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @ViewBag.StatusMessage
                            </div>
End If
                    </td>
                </tr>
    End If
Else
                                    @*TestNo has not yet been entered*@
End If
             End If
            @<tr>
                <td>
                    <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                </td>
            </tr>
        Else
            @<tr>
                <td valign="top" colspan="2">
                    You are not currently assigned any tests.  Please check back frequently.
                </td>
            </tr>
            @<tr>
                <td colspan="2" style="text-align:center;">
                    <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                </td>
            </tr>
        End If      
    </table>

        End Using
    </div>
</div>

