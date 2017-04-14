@ModelType StudentsAssessment.FilterData
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
                $("#divStandard").hide();
                break;

            case "2": //Subject
                $("#divClass").hide();
                $("#divSubject").show();
                $("#divGradeLevel").hide();
                $("#divQType").hide();
                $("#divQID").hide();
                $("#divStandard").hide();
                break;

            case "3": //Grade Level
                $("#divClass").hide();
                $("#divSubject").hide();
                $("#divGradeLevel").show();
                $("#divQType").hide();
                $("#divQID").hide();
                $("#divStandard").hide();
                break;

            case "4": //Question Type
                $("#divClass").hide();
                $("#divSubject").hide();
                $("#divGradeLevel").hide();
                $("#divQType").show();
                $("#divQID").hide();
                $("#divStandard").hide();
                break;

            case "5": //Question ID
                $("#divClass").hide();
                $("#divSubject").hide();
                $("#divGradeLevel").hide();
                $("#divQType").hide();
                $("#divQID").show();
                $("#divStandard").hide();
                break;

            case "6": //Standard
                $("#divClass").hide();
                $("#divSubject").hide();
                $("#divGradeLevel").hide();
                $("#divQType").hide();
                $("#divQID").hide();
                $("#divStandard").show();
                break;
            default:
                alert(iSel);
        }
    }
</script>

        @Using (Html.BeginForm("FilterQuestion", "QuestionBank"))
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>FILTER QUESTIONS</h3>
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

            @*divStandard*@
            @<div id="divStandard">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please select the Standard to filter the list by</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedStandard, Model.StandardsList)
                            @Html.ValidationMessageFor(Function(model) model.SelectedStandard, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divQID*@


            @<table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="FILTER QUESTION LIST" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" value="UNDO" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "QuestionBank")'" />
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