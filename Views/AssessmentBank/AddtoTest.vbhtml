@Code
    ViewData("Title") = "Student Assessment Platform - Add assessment to test"
End Code

@ModelType StudentsAssessment.TestData
<h2>AddtoAssessment</h2>

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
            @<h3>ADD THIS ASSESSMENT TO SELECTED TEST</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="250" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("ASSESSMENT ID", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.Label(Session("AssessmentID").ToString, htmlAttributes:=New With {.Class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("SELECTED ASSESSMENT", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.Label(ViewBag.AssessmentName.ToString, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;font-weight:normal;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @*@Html.LabelFor(Function(model) model.TestsList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                        @Html.Label("SELECT TEST TO ADD TO", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedTest, Model.TestsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedTest, "", New With {.class = "text-danger"})
                    </td>
                </tr>
            </table>
            @<table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="ADD TO TEST" Class="btn btn-success clsbutton-round" style="background:cadetblue;"/>
                        <input type="button" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "AssessmentBank")'" />
                    </td>
                </tr>
                 <tr>
                     <td colspan="2">
                         <p>
                             @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                                 @<div class="field-validation-error">
                                     @Model.Errormessage
                                 </div>
                             Else
                                 @<div class="field-validation-error">
                                      @Model.Successmessage
                                 </div>
                             End If
                         </p>
                     </td>
                 </tr>   
            </table>
End Using
    </div>
    <div class="col-sm-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Html.Partial("SideMenu")
    </div>
</div>
