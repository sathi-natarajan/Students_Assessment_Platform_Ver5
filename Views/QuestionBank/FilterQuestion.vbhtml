@Code
    ViewData("Title") = "Question list filtering"
End Code

@ModelType StudentsAssessment.FilterData

<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        QuestionTypeSelected();
    });

    //This is beong used in "Create a Question" box
    function QuestionTypeSelected() {
        var iSel = $('#SelectedFilter').val(); //mere $(this).val() does not seem to work
        switch (iSel) {
            case "1": //Class
                //When hidden, this will leave a gap
                //$("#divYesNo").css("visibility", "visible");
                //$("#divShortAnswer").css("visibility", "hidden");
                //When hidden, this will NOT leave a 
                $("#divClass").show();
                $("#divSubject").hide();
                $("#divGradeLevel").hide();
                $("#divQType").hide();
                $("#divQID").hide();
                break;

            case "2": //Subject
                $("#divClass").hide();
                $("#divSubject").show();
                $("#divGradeLevel").hide();
                $("#divQType").hide();
                $("#divQID").hide();
                break;

            case "3": //Grade Level
                $("#divClass").hide();
                $("#divSubject").hide();
                $("#divGradeLevel").show();
                $("#divQType").hide();
                $("#divQID").hide();
                break;

            case "4": //Question Type
                $("#divClass").hide();
                $("#divSubject").hide();
                $("#divGradeLevel").hide();
                $("#divQType").show();
                $("#divQID").hide();
                break;

            case "5": //Question ID
                $("#divClass").hide();
                $("#divSubject").hide();
                $("#divGradeLevel").hide();
                $("#divQType").hide();
                $("#divQID").show();
                break;
            default:
                alert(iSel);
        }
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
            @<h3>FILTER QUESTION LIST</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="5" cellspacing="5">
                <colgroup>
                    <col width="250" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("SELECT FILTER TYPE TO APPLY", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedFilter, Model.FilterTypesList, New With {.onchange = "QuestionTypeSelected();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedFilter, "", New With {.class = "text-danger"})
                    </td>
                </tr>
            </table>

            @*divClass*@
            @<div id="divClass">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please select the class to filter the list by</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedClass, Model.ClassesList)
                            @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divClass*@

            @*divSubject*@
            @<div id="divSubject">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please select the subject to filter the list by</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedSubject, Model.SubjectsList)
                            @Html.ValidationMessageFor(Function(model) model.SelectedSubject, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divSubject*@

            @*divGradeLevel*@
            @<div id="divGradeLevel">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please select the grade level to filter the list by</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedGradelevel, Model.GradeLevelsList)
                            @Html.ValidationMessageFor(Function(model) model.SelectedGradelevel, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divGradeLevel*@

            @*divQType*@
            @<div id="divQType">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please select the question type to filter the list by</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedQType, Model.QuestionTypesList)
                            @Html.ValidationMessageFor(Function(model) model.SelectedQType, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divQType*@

            @*divQType*@
            @<div id="divQID">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please select the question id to filter the list by</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedQID, Model.QuestionIDsList)
                            @Html.ValidationMessageFor(Function(model) model.SelectedQID, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divQID*@


            @<table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="FILTER QUESTION LIST" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("NewList", "QuestionBank")'" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @If String.IsNullOrEmpty(ViewBag.StatusMessage) = False Then
                            @<div class="field-validation-error">
                                @ViewBag.StatusMessage
                            </div>
                        Else
                            @<div class="field-validation-error">
                                @Html.Raw(ViewBag.StatusMessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>


