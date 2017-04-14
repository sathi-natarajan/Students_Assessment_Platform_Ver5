@Code
    ViewData("Title") = "Generate Test No for a test"
End Code

@ModelType StudentsAssessment.TestData
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
    @<h3>CREATE A TEST NUMBER FOR A TEST</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>
                @If Model.TestsList.Count > 0 Then
                    @<tr>
                        <td>
                            @Html.Label("SELECT TEST:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedTest, Model.TestsList)
                            @Html.ValidationMessageFor(Function(model) model.TestsList, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="GENERATE TEST NO." Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type="button" value="BACK" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                        </td>
                    </tr>
                Else
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            There are no tests available for this teacher. Please create a test first
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="button" value="BACK" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                        </td>
                    </tr>
                End If

                @If String.IsNullOrEmpty(Model.TestNo.TestNo) = False Then
                    @<tr>
                        <td colspan="2">
                            <strong>Test number assigned to this test is:</strong>
                            @Html.DisplayFor(Function(model) model.TestNo.TestNo, New With {.htmlAttributes = New With {.class = "form-control"}})
                        </td>
                    </tr>
                End If
                <tr>

                    <td colspan="2">
                        @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Model.Errormessage
                            </div>
                        Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Html.Raw(Model.Successmessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
   End Using
    </div>
</div>