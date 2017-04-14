@Code
    ViewData("Title") = "Edit Student Profile"
End Code

@ModelType StudentsAssessment.ProfileData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>


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

@*@Scripts.Render("~/bundles/jqueryui")
    @Styles.Render("~/Content/cssjqueryui")*@
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>

<link href="~/Content/jQuery_datepicker/css/jquery.datepick.css" rel="stylesheet" />
<script src="~/Content/jQuery_datepicker/js/jquery.plugin.min.js"></script>
<script src="~/Content/jQuery_datepicker/js/jquery.datepick.min.js"></script>

@*<script type="text/javascript">
    $(document).ready(function () {
        LoadSubjectsForClass();
    });

    function LoadSubjectsForClass()
    {
        //alert($("#CurrentClassID").val() + " selected
        var serviceURL = '/Teachers/GetSubjectsData'; //This should not be inside AJAX call itself
        var iSel = $('#CurrentClassID').val(); //mere $(this).val() does not seem to work
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
        if (data.length > 0) {
            $('#CurrentSubjectID').empty();
            $.each(data, function (i, item) {
                $('#CurrentSubjectID').append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });
            FillSubjectData();
        }
        else {
            $("#divStatusMessage").text("Your subject list is empty.  Please contact administrator.  Or,  choose another class.");
        }

    }

    function errorFunc() {
        alert('Problem while fetching class details');
    }
</script>*@

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
                    <td>@Html.Label("Last name:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})</td>
                    <td>@Model.Lastname</td>
                </tr>
                <tr>
                    <td>@Html.Label("Current Status:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})</td>
                    <td>@Model.Status</td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Select your school:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SchoolID, Model.SchoolsList)
                        @Html.ValidationMessageFor(Function(model) model.SchoolID, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Select your grade level:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.GradeLevelID, Model.GradeLevelsList)
                        @Html.ValidationMessageFor(Function(model) model.GradeLevelID, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                @If Model.Status = "TEACHER" Then
                    @<tr>
                        <td>
                            @Html.Label("Select CURRENT Class:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.CurrentClassID, Model.ClassesList, New With {.onchange = "LoadSubjectsForClass();"})
                            @Html.ValidationMessageFor(Function(model) model.ClassesList, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td>
                            @Html.Label("Select CURRENT Subject:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.CurrentSubjectID, Model.SubjectsList)
                            @Html.ValidationMessageFor(Function(model) model.SubjectsList, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                End If
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="UPDATE" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />
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