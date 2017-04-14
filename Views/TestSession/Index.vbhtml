@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

@ModelType StudentsAssessment.TestQAData

<style>
.numberCircle {
    border-radius: 50%;
    behavior: url(PIE.htc); /* remove if you don't care about IE8 */

    width: 50px;
    height: 50px;
    padding: 5px;
    
    background-color:cadetblue;
    border: 2px solid cadetblue;
    color: #666;
    text-align: center;
    
    font: 32px Arial, sans-serif;
}    
</style>

<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        @*<h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>*@
    </div>
    <div class="col-lg-9">
       @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

        @*=====================*@
        @<table border="1" cellpadding="5" cellspacing="5" style="width:600px;height:300px;">
            <colgroup>
                <col width="600" />
            </colgroup>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <div class="numberCircle">@Model.SeqNo</div>
                            </td>
                            <td>
                                @If Model.QuestionStem IsNot Nothing Then
                                    @<div id="divQuestion" style="height:100px;overflow-x:hidden;overflow-y:auto;">
                                        @Model.QuestionStem
                                    </div>
                                Else
                                    @<div id="divQuestion">
                                        QUESTION STEM WILL SHOW UP HERE
                                    </div>
                            end if
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divAnswers">
                        @*Depending on question type, different controls are used to get
                            the answers*@
                        @select Case Model.QuestionType
                            Case 1 'Yes/No
                                @<div>
                                    <strong>PLEASE SELECT YES OR NO</strong><br />
                                    @Html.RadioButtonFor(Function(model) model.ProvidedAnswer.YesNo, "1")
                                    Yes<br />
                                    @Html.RadioButtonFor(Function(model) model.ProvidedAnswer.YesNo, "2")
                                    No
                                </div>
                            Case 2 'Short answers
                                @<div>
                                    <strong>PLEASE TYPE YOUR ANSWER INTO PROVIDED SPACE BELOW</strong><br />
                                    @Html.TextAreaFor(Function(model) model.ProvidedAnswer.ShortAnswer, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "width:500px;height:100px;", .maxlength = "250"})
                                </div>


                            Case 3 'Multiple Choice @*Radiobuttonfor model value receiver name should be same*@
                                @<div>
                                    <strong>PLEASE CHOOSE THE CORRECT CHOICE FROM THOSE PROVIDED BELOW</strong><br />
                                    <table border="0" cellpadding="2" cellspacing="2">
                                        <colgroup>
                                            <col width="250" />
                                            <col width="400" />
                                        </colgroup>
                                        <tr>
                                            <td colspan="2">
                                                <table border="0" cellspacing="3" cellpadding="3">
                                                    <colgroup>
                                                        <col width="50" />
                                                        <col width="450" />
                                                    </colgroup>
                                                    <tr>
                                                        <td>
                                                            @Html.RadioButtonFor(Function(model) model.ProvidedAnswer.MultipleChoiceSelectedAnswer, 1)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice1Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            @Html.RadioButtonFor(Function(model) model.ProvidedAnswer.MultipleChoiceSelectedAnswer, 2)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice2Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            @Html.RadioButtonFor(Function(model) model.ProvidedAnswer.MultipleChoiceSelectedAnswer, 3)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice3Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            @Html.RadioButtonFor(Function(model) model.ProvidedAnswer.MultipleChoiceSelectedAnswer, 4)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice4Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            Case 4 'Multi Choice @*CheckboxFor model value receiver name should be different*@
                                @<div>
                                    <strong>PLEASE CHOOSE THE CORRECT CHOICE FROM THOSE PROVIDED BELOW</strong><br />
                                    <table border="0" cellpadding="2" cellspacing="2">
                                        <colgroup>
                                            <col width="250" />
                                            <col width="400" />
                                        </colgroup>
                                        <tr>
                                            <td colspan="2">
                                                <table border="0" cellspacing="3" cellpadding="3">
                                                    <colgroup>
                                                        <col width="50" />
                                                        <col width="450" />
                                                    </colgroup>
                                                    <tr>
                                                        <td>
                                                            @Html.CheckBoxFor(Function(model) model.ProvidedAnswer.Choice1Correct, 1)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice1Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice1Correct, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            @Html.CheckBoxFor(Function(model) model.ProvidedAnswer.Choice2Correct, 2)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice2Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice2Correct, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            @Html.CheckBoxFor(Function(model) model.ProvidedAnswer.Choice3Correct, 3)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice3Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice3Correct, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            @Html.CheckBoxFor(Function(model) model.ProvidedAnswer.Choice4Correct, 4)
                                                        </td>
                                                        <td>
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice4Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                            @Html.DisplayFor(Function(model) model.Answer.Choice4Correct, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                        End Select
                    </div>
                </td>
            </tr>
        </table>
        @<br />@<br />
        @*===============================*@
        @If ViewBag.Result Is Nothing AndAlso String.IsNullOrEmpty(ViewBag.Result) Then
            @For i = 1 To Model.lstQAs.Count
                @<input type="submit" value="@i" Class="btn btn-success clsbutton" style="background:cadetblue;" name="button" />
            Next
            @<br />@<br />
            @<p>
                <input type="submit" value="COMPLETED" Class="btn btn-success clsbutton" name="button" style="background:cadetblue;" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="BUTTON" value="CANCEL" Class="btn btn-success clsbutton" name="button" style="background:cadetblue;" onclick="location.href='@Url.Action("CancelTest", "TestSession")'" />
            </p>

            @If ViewBag.Cancelprompt IsNot Nothing Then
                @<div>@ViewBag.CancelPrompt</div>
            End If
        Else
            @<div>
                <div>@ViewBag.Result</div>
            </div>    End If
       End Using
    </div>
</div>



