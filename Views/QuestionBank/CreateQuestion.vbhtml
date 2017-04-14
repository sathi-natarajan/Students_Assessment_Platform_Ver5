@Code
    ViewData("Title") = "Create question"
End Code

@ModelType StudentsAssessment.QuestionData

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
        var iSel = $('#SelectedQType').val(); //mere $(this).val() does not seem to work
        switch (iSel) {
            case "1": //Yes/No
                //When hidden, this will leave a gap
                //$("#divYesNo").css("visibility", "visible");
                //$("#divShortAnswer").css("visibility", "hidden");
                //When hidden, this will NOT leave a gap
                $("#divYesNo").show();
                $("#divShortAnswer").hide();
                $("#divMultipleChoice").hide();
                $("#divMultiChoice").hide();
                break;

            case "2": //short Answer
                $("#divYesNo").hide();
                $("#divShortAnswer").show();
                $("#divMultipleChoice").hide();
                $("#divMultiChoice").hide();
                break;

            case "3": //short Answer
                $("#divYesNo").hide();
                $("#divShortAnswer").hide();
                $("#divMultipleChoice").show();
                $("#divMultiChoice").hide();
                break;

            case "4": //short Answer
                $("#divYesNo").hide();
                $("#divShortAnswer").hide();
                $("#divMultipleChoice").hide();
                $("#divMultiChoice").show();
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
            @<h3>CREATE A NEW QUESTION</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="5" cellspacing="5">
                <colgroup>
                    <col width="250" />
                    <col width="400" />
                </colgroup>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.StandardsList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedStandard, Model.StandardsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedStandard, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.QuestionTypesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedQType, Model.QuestionTypesList, New With {.onchange = "QuestionTypeSelected();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedQType, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                @*<tr>
                    <td>
                        @Html.Label("SELECT APPROPRIATE GRADE LEVEL FOR THIS QUESTION", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedGradeLevel, Model.GradeLevelsList, New With {.onchange = "QuestionTypeSelected();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedGradeLevel, "", New With {.class = "text-danger"})
                    </td>
                </tr>*@
                <tr>
                    <td colspan="2">
                        Please provide the <strong>question stem</strong> below (250 chars max.):
                    </td>
                </tr>
                <tr>
                    @*<td>
                        @Html.LabelFor(Function(model) model.QuestionStem, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>*@
                    <td colspan="2">
                        @Html.TextAreaFor(Function(model) model.QuestionStem, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "width:500px;height:100px;", .maxlength = "250"})
                        @Html.ValidationMessageFor(Function(model) model.QuestionStem, "", New With {.class = "text-danger"})
                    </td>
                </tr>
            </table>

            @*divShortAnswer*@
            @<div id="divShortAnswer">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please type in the correct <strong>SHORT ANSWER</strong>  to the question (50 chars max.)</td>
                        </tr>
                    </thead>
                    <tr>
                        @*<td>
                            @Html.LabelFor(Function(model) model.ShortAnswer, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        </td>*@
                        <td>
                            @Html.TextAreaFor(Function(model) model.ShortAnswer, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "width:500px;height:100px;", .maxlength = "50"})
                            @Html.ValidationMessageFor(Function(model) model.ShortAnswer, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divShortAnswer*@

            @*divYesNo*@
            @<div id="divYesNo">
                <table border="0" cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">Please select YES or NO as correct answer to the question</td>
                        </tr>
                    </thead>
                    <tr>
                        <td colspan="2">
                            @Html.RadioButtonFor(Function(model) model.YesNo, "1")
                            @Html.Label("Yes", New With {.htmlAttributes = New With {.class = "form-control"}})
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            @Html.RadioButtonFor(Function(model) model.YesNo, "0")
                            @Html.Label("No", New With {.htmlAttributes = New With {.class = "form-control"}})
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            @Html.ValidationMessageFor(Function(model) model.YesNo, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divYesNo*@

            @*divMultipleChoice*@
            @<div id="divMultipleChoice">
                <table border="0" cellpadding="2" cellspacing="2">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">
                                <div>
                                    Please type in the text for the choices in the spaces provided.  <br /><strong>Max. no of characters for each choice: 50.</strong>
                                    <br />Additionally, choose <u>one of the choices</u> as correct answer to the question.
                                </div>
                            </td>
                        </tr>
                    </thead>
                    <tr>
                        <td colspan="2">
                            <table border="0" cellspacing="3" cellpadding="3">
                                <colgroup>
                                    <col width="50" />
                                    <col width="450" />
                                </colgroup>
                                <tr>
                                    <td>
                                        @Html.RadioButtonFor(Function(model) model.SelectedChoice, 1)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice1Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        @Html.RadioButtonFor(Function(model) model.SelectedChoice, 2)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice2Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        @Html.RadioButtonFor(Function(model) model.SelectedChoice, 3)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice3Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        @Html.RadioButtonFor(Function(model) model.SelectedChoice, 4)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice4Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            @Html.ValidationMessageFor(Function(model) model.SelectedChoice, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divMultipleChoice*@

            @*divMultipleChoice*@
            @<div id="divMultiChoice">
                <table border="0" cellpadding="2" cellspacing="2">
                    <colgroup>
                        <col width="250" />
                        <col width="400" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">
                                <div>
                                    Please type in the text for the choices in the spaces provided.  <br /><strong>Max. no of characters for each choice: 50.</strong>
                                    <br />Additionally, choose <u>ONE or MORE of the choices</u> as correct answers to the question.
                                </div>
                            </td>
                        </tr>
                    </thead>
                    <tr>
                        <td colspan="2">
                            <table border="0" cellspacing="3" cellpadding="3">
                                <colgroup>
                                    <col width="50" />
                                    <col width="450" />
                                </colgroup>
                                <tr>
                                    <td>
                                        @Html.CheckBoxFor(Function(model) model.Choice1Checked, 1)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice1Text_MCH, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        @Html.CheckBoxFor(Function(model) model.Choice2Checked, 2)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice2Text_MCH, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        @Html.CheckBoxFor(Function(model) model.Choice3Checked, 3)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice3Text_MCH, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        @Html.CheckBoxFor(Function(model) model.Choice4Checked, 4)
                                    </td>
                                    <td>
                                        @Html.TextBoxFor(Function(model) model.Choice4Text_MCH, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            @Html.ValidationMessageFor(Function(model) model.Choice1Checked, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                </table>
            </div> @*divMultipleChoice*@


            @<table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="CREATE QUESTION" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
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

    
