@Code
    ViewData("Title") = "Welcome page"
End Code

@ModelType IEnumerable(Of StudentsAssessment.QuestionData)

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="~/Scripts/jquery-1.12.4.min.js"></script>
<script src="~/Content/Scrollbar/jquery.nicescroll.min.js"></script>

<script>
$(document).ready(
function() {
$("html").niceScroll();
});
</script>
<div class="row" style="padding-top:100px;">
    <div class="col-lg-9">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>QUESTION BANK</h3>
            @<table cellpadding = "5" cellspacing="5">
                <colgroup>
                    <col />
                    <col width = "450" />
                </colgroup>
                <tr>
                    <td>
                        <div style = "float:right;" >
                            <a class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("CreateQuestionPanel", "QuestionBank")'">CREATE A QUESTION</a>
                            <a Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("FilterQuestionListPanel", "QuestionBank")'">FILTER LIST</a>
                            <a Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("BulkUploadQAs", "QuestionBank")'">BULK-LOAD QUESTIONS/ANSWERS</a>
                        </div>
                    </td>
                </tr>
            </table>
            @<hr style = "background-color:cadetblue;height:2px;" />
        dim i As Integer = 0
                @For each item In Model
                    i += 1
                    @Html.Partial("QuestionBox", New StudentsAssessment.QuestionData With
                                                                                          {
                                                              .QuestionID = item.QuestionID,
                                                              .QuestionIDStr = String.Format("{0}) {1}", i, item.QuestionIDStr),
                                                                  .QuestionStem = item.QuestionStem,
                                                          .Standard = item.Standard})
                    @<br/>@<br/>
                Next
                @For j = 1 To (Integer.Parse(Session("TotalQuestionsCnt")) / 5) + 1
                    @<input type="submit" value="@j" class="btn btn-success clsbutton-round" style="background:cadetblue;" name="button" />
                Next
                @<br/>                @<br />                @<br />
                @<p>
                    <input type="button"  value="BACK" class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />
                </p>
            @If String.IsNullOrEmpty(ViewBag.StatusMessage) = True Then
                @<div id="divStatusMessage" class="field-validation-error">
                    @ViewBag.StatusMessage
                </div>
            Else
                @<div id="divStatusMessage" class="field-validation-error">
                    @Html.Raw(ViewBag.StatusMessage)
                </div>
            End If
    End Using
    </div>
    <div class="col-lg-3" style="padding-top:50px;">
        @If Session("CreateQuestionShowPanel") IsNot Nothing AndAlso Session("CreateQuestionShowPanel") = True Then
            @<div  style="border:2px solid cadetblue;">
                 @If Session("QuestionsData") IsNot Nothing AndAlso TypeOf Session("QuestionsData") Is StudentsAssessment.QuestionData Then
                     Dim objquestionData As StudentsAssessment.QuestionData = CType(Session("QuestionsData"), StudentsAssessment.QuestionData)
                 @Html.Partial("CreateQuestionList", objquestionData)
                 End If
            </div>

        ElseIf Session("FilterListPanel") IsNot Nothing AndAlso Session("FilterListPanel") = True Then
            @<div style="border:2px solid cadetblue;">
                @If Session("FilterData") IsNot Nothing AndAlso TypeOf Session("FilterData") Is StudentsAssessment.FilterData Then
                    Dim objFilterData As StudentsAssessment.FilterData = CType(Session("FilterData"), StudentsAssessment.FilterData)
                    @Html.Partial("FilterQuestionsList", objFilterData)
                End If
            </div>
        End If    
      </div>  
</div>
