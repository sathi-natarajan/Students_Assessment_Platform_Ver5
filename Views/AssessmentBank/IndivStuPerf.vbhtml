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

            @<div style="margin-left:-140px;">
                <h3>Assessment Bank</h3>
                <hr style="background-color:cadetblue;height:2px;" />

                <table cellpadding="5" cellspacing="5">
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
                                <a class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("FilterAssessments", "AssessmentBank")'">FILTER LIST</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>


            @<table style="margin-left:-150px;" cellpadding="15">
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
                                                   onclick="location.href='@Url.Action("DuplicateAssessments", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    Duplicate Assesment.
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("ViewQuestions", "AssessmentBank", New With {.iAssessmentID = item.AssessmentID})'">
                                                    View Data
                                                </a>
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
            @if Session("QuestionsList") IsNot Nothing AndAlso CType(Session("QuestionsList"), List(Of StudentsAssessment.QuestionData)).Count > 0 Then
                @<table id="tblAssessmentname" style="margin-left:150px;border:2px solid cadetblue;" cellpadding="15">
                    <tr>
                        <td>
                            @Html.Label(Session("Assessmentname"))
                        </td>
                    </tr>
                </table>
                @<div style="margin-left:-150px;">
                    @Html.Label("Total # of questions:")
                    @Html.Label(CType(Session("QuestionsList"), List(Of StudentsAssessment.QuestionData)).Count)
                </div>
                @*@<div id = "divQuestionsList" style="height:400px;width:800px;
                overflow-x:hidden;overflow-y:auto;border:2px solid cadetblue;
                padding-top:20px;margin-left:-25px;">*@

                @<table border="1" style="margin-left:-150px;border:2px solid cadetblue;width:500px;" cellpadding="15">
                    <colgroup>
                        <col width="100" valign="top" />
                        <col width="200" valign="top" />
                    </colgroup>
                    @For Each objquestionData In CType(Session("QuestionsList"), List(Of StudentsAssessment.QuestionData))
                        @<tr>
                            <td>
                                @Html.Label(objquestionData.QuestionStem)<br />
                                <a href="javascript:void(0);" Class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                   onclick="location.href='@Url.Action("ViewAnswers", "AssessmentBank", New With {.iQuestionID = objquestionData.QuestionID})'">
                                    View Answers
                                </a>
                            </td>
                        </tr>
                    Next
                </table>
                '</div>
            End If

            @if Session("AnswersList") IsNot Nothing AndAlso CType(Session("AnswersList"), List(Of String)).Count > 0 Then
                @<p>&nbsp;</p>
                @<table id="tblAssessmentname" style="margin-left:150px;border:2px solid cadetblue;" cellpadding="15">
                    <tr>
                        <td>
                            @Html.Label(Session("Questionstem"))
                        </td>
                    </tr>
                </table>
                @<div style="margin-left:-150px;">
                    @Html.Label("Total # of questions:")
                    @Html.Label(CType(Session("AnswersList"), List(Of String)).Count)
                </div>
                @*@<div id = "divQuestionsList" style="height:400px;width:800px;
                overflow-x:hidden;overflow-y:auto;border:2px solid cadetblue;
                padding-top:20px;margin-left:-25px;">*@

                @<table style="margin-left:-150px;border:2px solid cadetblue;width:500px;" cellpadding="15">
                    <colgroup>
                        <col width="100" valign="top" />
                        <col width="200" valign="top" />
                    </colgroup>
                    @For Each strAnswer In CType(Session("AnswersList"), List(Of String))
                        @<tr>
                            <td>
                                @Html.Label(strAnswer)<br />
                                @*<a href="javascript:void(0);" Class="btn btn-success clsbutton-round" style="background:cadetblue;height:25px;"
                                   onclick="location.href='@Url.Action("ViewAnswers", "AssessmentBank", New With {.iQuestionID = objquestionData.QuestionID})'">
                                    View Answers
                                </a>*@
                            </td>
                        </tr>
                    Next
                </table>
                '</div>
            End If

        End Using
    </div>
</div>




