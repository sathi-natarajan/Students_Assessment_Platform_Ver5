@Code
    ViewData("Title") = "Test completion and submission"
End Code

@imports System.Data
@ModelType StudentsAssessment.TestQAData
<div class="row">
    <div class="col-lg-8" style="padding:100px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>REVIEW AND SUBMISSION PAGE</h3>
            @<hr style="background-color:cadetblue;height:2px;" />

           @If ViewBag.Submitted Is Nothing Then
            @if ViewBag.Result IsNot Nothing Then
                @<div>@ViewBag.Result</div>
                @if Session("data") IsNot Nothing AndAlso TypeOf Session("data") Is DataTable Then
                    @<div>
                        Your answers you provided is given below for your review.  Please click on
                        'SUBMIT TEST' to finally submit them
                    </div>
                   Dim dtTestQAData As DataTable = CType(Session("data"), DataTable)
                    @<table border="1">
                        @for each dtTestQADatarow In dtTestQAData.Rows
                            @<tr>
                                <td>
                                    @dtTestQADatarow("PageNo").ToString
                                </td>
                                <td>
                                    @dtTestQADatarow("QuestionType").ToString
                                </td>
                                <td>
                                    @dtTestQADatarow("QuestionID").ToString
                                </td>
                                <td>
                                    @dtTestQADatarow("AnswerEntryID").ToString
                                </td>
                                @If dtTestQADatarow("AnswerText") IsNot Nothing Then
                                    @<td>
                                        @dtTestQADatarow("AnswerText")
                                    </td>
                                End If
                                <td>
                                    @dtTestQADatarow("IsSelected").ToString
                                </td>
                            </tr>
                        Next
                    </table>
                End If
            End If@<br />
            @<p>
                <input type="submit" name="button" value="SUBMIT TEST" Class="btn btn-success clsbutton" style="background:cadetblue;" />
            </p>
           Else
            @<p>
                Your test data has been successfully submitted.  We will let you know your score in a few days.
            </p>

           End If

End Using
    </div>
</div>