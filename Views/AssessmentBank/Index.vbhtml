@Code
    ViewData("Title") = "Students Assessment Platform - Assessment Bank"
End Code

@ModelType IEnumerable(Of StudentsAssessment.AssessmentData)

<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<link href="~/Content/jQueriUI/themes/base/jquery-ui.min.css" rel="stylesheet" />
<script src="~/Scripts/jquery-1.12.4.min.js"></script>
<script src="~/Scripts/jquery-ui-1.12.1.min.js"></script>

<script>
    function FetchQuestionInfo(ID) {
        $("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/AssessmentBank/GetAssessmentInfo'; //This should not be inside AJAX call itself
        var iSel = ID;
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iQuestionID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        //$('#Endtime').val(data.Endtime);
        //var strQuestionInfo="<strong>Question ID:</strong>" + data.QuestionID+"<br/>";
        //strQuestionInfo += "<strong>Question:</strong>" + data.QuestionStem + "<br/>";
        //strQuestionInfo += "<strong>QuestionType:</strong>" + data.QuestionType;
        //alert(strQuestionInfo);
        $("#dlgQuestionInfo").html("<p>" + strQuestionInfo + "</p>")
        $("#dlgQuestionInfo").dialog({
            resizable: false,
            title: "Info. on selected assessment",
            height: "auto",
            width: 500,
            height: 300,
            modal: true,
            buttons: {
                "OK": function () {
                   // alert("You clicked OK");
                    $(this).dialog("close");
                },
                //Cancel: function () {
                //    //alert("You clicked Cancel");
                //    $(this).dialog("close");
                //}
            }
        });
    }

    function errorFunc() {
        // alert('An error occured when trying to fetch information on the selected test');
        $("#dlgQuestionInfo").html("<p>An error occured when trying to fetch information on the selected assessment</p>")
        $("#dlgQuestionInfo").dialog({
            resizable: false,
            title: "ERROR",
            height: "auto",
            width: 500,
            height: 300,
            modal: true,
            buttons: {
                "OK": function () {
                    // alert("You clicked OK");
                    $(this).dialog("close");
                },
                //Cancel: function () {
                //    //alert("You clicked Cancel");
                //    $(this).dialog("close");
                //}
            }
        });
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

                @<h3>Assessment Bank</h3>
               @<hr style="background-color:cadetblue;height:2px;" />

                @<table cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col />
                        <col width="475" />
                    </colgroup>
                    <tr>
                        <td>@Html.Label("Total # of assessments returned: ")@Model.Count</td>
                        <td>
                            <div style="float:right;">
                                <a class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("CreateAssessment", "AssessmentBank")'">CREATE AN ASSESSMENT</a>
                                <a class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("FetchAssessmentsList", "AssessmentBank")'">REFRESH LIST</a>
                                <a class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("FilterAssessments_notimp", "AssessmentBank")'">FILTER LIST</a>
                            </div>
                        </td>
                    </tr>
                </table>

            @<table cellpadding="15">
                <colgroup>
                    <col width="100" valign="top" />
                    <col width="200" valign="top" />
                </colgroup>
                <tr>
                    <td colspan="2">
                        <div id="divAssessmentList" style="height:400px;width:800px;
                        overflow-x:hidden;overflow-y:auto;border:2px solid cadetblue;
                        padding-top:20px;padding-left:20px;">
                            @if Model.Count > 0 Then
                                @For Each item In Model
                                    @<table border="1" class="table" style="width:600px;">
                                        @*<tr>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.QuestionID)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.QuestionStem)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.SelectedQType)
                                            </th>

                                        </tr>*@
                                        <colgroup>
                                            <col width="100" />
                                            <col width="500" />
                                            <col width="100" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                @Html.DisplayFor(Function(modelItem) item.AssessmentIDStr)
                                            </td>
                                            <td>
                                                @Html.DisplayFor(Function(modelItem) item.Assessmentname)
                                            </td>
                                            <td>
                                                @Html.DisplayFor(Function(modelItem) item.CreateDate)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("RemoveAssessments", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    Trash Assessment
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("DuplicateAssessment", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    Duplicate Assesment.
                                                </a>
                                                @*<a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("ViewData1", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    View Data
                                                </a>*@
                                                @*@Html.ActionLink("View Data", New With {.onclick = "ViewData(" + item.AssessmentID.ToString + ");"})*@
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("ListQuestions", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    List Questions
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("AssessmentInfo", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    Assessment Info
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("UpdateAssessment", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    Update Assessment
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("ListofStandardsinAssessment", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    List Standards
                                                </a>
                                            </td>
                                            @*<td>
                                            @Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                                                @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                                                @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})
                                                </td>*@
                                        </tr>

                                    </table>
                                Next
                            Else
                                @<div>There is Nothing to show here</div>
                            End If

                        </div>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @If String.IsNullOrEmpty(TempData("StatusMessage")) = False Then
                            @<div class="field-validation-error">
                                @TempData("StatusMessage")
                            </div>
                        Else
                            @<div class="field-validation-error">
                                @Html.Raw(TempData("StatusMessage"))
                            </div>
                        End If
                    </td>
                </tr>
            </table>

            @<div style="height:400px;width:800px; padding-top:20px;padding-left:20px;">
                @If Session("AssessmentData") IsNot Nothing Then
                    Dim objAssessmentData As StudentsAssessment.AssessmentData = CType(Session("AssessmentData"), StudentsAssessment.AssessmentData)
                    @<div style="margin-left:-150px;">
                        <h3>@objAssessmentData.Assessmentname</h3>
                        <hr style="background-color:cadetblue;height:2px;" />
                    </div>
                    @<a href="javascript:void(0);" Class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                        onclick="location.href='@Url.Action("ViewQuestions", "AssessmentBank", New With {.iAssessmentID = objAssessmentData.AssessmentID})'">
                        MASTERY BY STANDARD/QUESTION TYPE
                    </a>
                                @<a href="javascript:void(0);" Class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                    onclick="location.href='@Url.Action("ViewStudents", "AssessmentBank", New With {.iAssessmentID = objAssessmentData.AssessmentID})'">
                                    MASTERY BY INDIV. STU PERF
                                </a>
                                @<p>&nbsp;</p>

                                @If Session("QuestionsList") IsNot Nothing AndAlso CType(Session("QuestionsList"), List(Of StudentsAssessment.QuestionData)).Count > 0 Then
                        objAssessmentData = CType(Session("Assessmentname"), StudentsAssessment.AssessmentData)

                                    @*@<div id = "divQuestionsList" style="height:400px;width:800px;
                                    overflow-x:hidden;overflow-y:auto;border:2px solid cadetblue;
                                    padding-top:20px;margin-left:-25px;">*@

                                    @<table border="0" style="margin-left:-150px;width:500px;" cellpadding="5" cellspacing="5">
                                        <colgroup>
                                            <col width="100" valign="top" />
                                            <col width="300" valign="top" />
                                            <col width="100" valign="top" />
                                        </colgroup>
                                        @For Each objquestionData In CType(Session("QuestionsList"), List(Of StudentsAssessment.QuestionData))
                                            @<tr>
                                                <td>
                                                    <a href="javascript:void(0);"
                                                       onclick="location.href='@Url.Action("ViewAnswers", "AssessmentBank", New With {.iQuestionID = objquestionData.QuestionID})'">
                                                        @Html.Label("Select", New With {.style = "font-weight:normal;color:#000;text-decoration:underline;"})
                                                    </a>
                                                </td>
                                                <td>
                                                    @*<a href="javascript:void(0);"
                                                    onclick="location.href='@Url.Action("ViewAnswers", "AssessmentBank", New With {.iQuestionID = objquestionData.QuestionID})'">*@
                                                    @Html.Label(objquestionData.QuestionStem, New With {.style = "font-weight:normal;color:#000;"})
                                                    @*</a>*@
                                                </td>
                                                <td>
                                                    <div style="height:25px;width:25px;background:cadetblue;">
                                                        %
                                                    </div>

                                                </td>
                                            </tr>
                                        Next
                                    </table>
                                    '</div>
                                Else
                                    @*@<div>No questions in the selected assessment yet</div>*@
                                End If

                                @if Session("AnswersList") IsNot Nothing AndAlso CType(Session("AnswersList"), List(Of StudentsAssessment.AnswersData)).Count > 0 Then
                                    @<p>&nbsp;</p>
                                    @<div style="margin-left:-150px;">
                                        <h3>@Session("Questionstem")</h3>
                                        <hr style="background-color:cadetblue;height:2px;" />
                                    </div>
                                    @*@<div id = "divQuestionsList" style="height:400px;width:800px;
                                    overflow-x:hidden;overflow-y:auto;border:2px solid cadetblue;
                                    padding-top:20px;margin-left:-25px;">*@

                                    @<table style="margin-left:-150px;width:500px;" cellpadding="5" cellspacing="5">
                                        <colgroup>
                                            <col width="350" valign="top" />
                                            <col width="100" valign="top" />
                                        </colgroup>
                                        @code
                                dim iCtr=0
                                        End Code
                                        @For Each objAnswersData In CType(Session("AnswersList"), List(Of StudentsAssessment.AnswersData))
                                            iCtr += 1
                                            Select Case iCtr
                                                Case 1
                                                    @<tr>
                                                        <td>
                                                            @Html.Label(objAnswersData.Choice1Text, New With {.style = "font-weight:normal;color:#000;"})
                                                            @if objAnswersData.Choice1Correct Then
                                                                @<img src="~/Content/images/check.gif" />
                                                                @*Else
                                                                @<img src="~/Content/images/cross.gif" />*@
                                                            End If
                                                        </td>
                                                        <td>
                                                            <div style="height:25px;width:25px;background:cadetblue;">
                                                                %
                                                            </div>

                                                        </td>
                                                    </tr>
                                                Case 2
                                                    @<tr>
                                                        <td>
                                                            @Html.Label(objAnswersData.Choice2Text, New With {.style = "font-weight:normal;color:#000;"})
                                                            @if objAnswersData.Choice2Correct Then
                                                                @<img src="~/Content/images/check.gif" />
                                                                @*Else
                                                                @<img src="~/Content/images/cross.gif" />*@
                                                            End If
                                                        </td>
                                                        <td>
                                                            <div style="height:25px;width:25px;background:cadetblue;">
                                                                %
                                                            </div>

                                                        </td>
                                                    </tr>
                                                Case 3
                                                    @<tr>
                                                        <td>
                                                            @Html.Label(objAnswersData.Choice3Text, New With {.style = "font-weight:normal;color:#000;"})
                                                            @if objAnswersData.Choice3Correct Then
                                                                @<img src="~/Content/images/check.gif" />
                                                                @*Else
                                                                @<img src="~/Content/images/cross.gif" />*@
                                                            End If
                                                        </td>
                                                        <td>
                                                            <div style="height:25px;width:25px;background:cadetblue;">
                                                                %
                                                            </div>

                                                        </td>
                                                    </tr>
                                                Case 4
                                                    @<tr>
                                                        <td>
                                                            @Html.Label(objAnswersData.Choice4Text, New With {.style = "font-weight:normal;color:#000;"})
                                                            @if objAnswersData.Choice4Correct Then
                                                                @<img src="~/Content/images/check.gif" />
                                                                @*Else
                                                                @<img src="~/Content/images/cross.gif" />*@
                                                            End If
                                                        </td>
                                                        <td>
                                                            <div style="height:25px;width:25px;background:cadetblue;">
                                                                %
                                                            </div>

                                                        </td>
                                                    </tr>
                                            End Select
                                        Next
                                    </table>
                                            '</div>
                                            @<p>&nbsp;</p>
                                            @<p>&nbsp;</p>
                                            @<p>&nbsp;</p>
                                            @<p>&nbsp;</p>
                                            @<p>&nbsp;</p>
                                            @<p>&nbsp;</p>
                                            @*Else
                                            @<div>No answers/answers missing for the selected question</div>*@
                                End If

                                            @if Session("StudentsList") IsNot Nothing AndAlso CType(Session("StudentsList"), List(Of StudentsAssessment.StudentData)).Count > 0 Then
                                                @<table style="margin-left:-150px;width:500px;" cellpadding="5" cellspacing="5">
                                                    <colgroup>
                                                        <col width="100" valign="top" />
                                                        <col width="300" valign="top" />
                                                        <col width="100" valign="top" />
                                                    </colgroup>
                                                    @For Each objStudentData In CType(Session("StudentsList"), List(Of StudentsAssessment.StudentData))
                                                        @<tr>
                                                            <td>
                                                                <a href="javascript:void(0);"
                                                                   onclick="location.href='@Url.Action("ViewStudentAssessmentQAs", "AssessmentBank", New With {.iStudentID = objStudentData.StudentID})'">
                                                                    @Html.Label("Select", New With {.style = "font-weight:normal;color:#000;text-decoration:underline;"})
                                                                </a>
                                                            </td>
                                                            <td>
                                                                @Html.Label(objStudentData.Firstname, New With {.style = "font-weight:normal;color:#000;"})&nbsp;&nbsp;&nbsp;
                                                                @Html.Label(objStudentData.Lastname, New With {.style = "font-weight:normal;color:#000;"})
                                                            </td>
                                                            <td>
                                                                <div style="height:25px;width:25px;background:cadetblue;">
                                                                    %
                                                                </div>

                                                            </td>
                                                        </tr>
                                                    Next
                                                </table>
                                                @*Else
                                                @<div>No students have yet been assigned the selected assessment yet</div>*@
                                            End If
                                            End If
            </div>
                                            End Using
    </div>
</div>

<div style="margin-top:100px;">
    <div id="dialog" title="Assessment Information" class="dialog">
        <p>This Is the Default dialog which Is useful For displaying information. The dialog window can be moved, resized And closed With the 'x' icon.</p>
    </div>
    <div id="dialog1" title="List of Assessment questions" class="dialog">
        <p>This Is the Default dialog which Is useful For displaying information. The dialog window can be moved, resized And closed With the 'x' icon.</p>
    </div>
    <div id="dialog2" title="List of Standards in Assessment" class="dialog">
        <p>This Is the Default dialog which Is useful For displaying information. The dialog window can be moved, resized And closed With the 'x' icon.</p>
    </div>
</div>


@*@Html.Raw(ViewBag.Script)*@
@Html.Raw(TempData("Script"))

<div id="dlgQuestionInfo" title="QuestionInfo">
</div>
