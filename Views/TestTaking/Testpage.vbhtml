@Code
    ViewData("Title") = "Students Testing page"
End Code

@ModelType StudentsAssessment.TestQAData

<div class="row" style="padding:100px;">
    <h3>TEST: @Model.Testname&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ASSESSMENT: @Model.Assessmentname </h3>
    <hr style="background-color:cadetblue;height:2px;" />
   
    @*<div class="col-sm-3" style="margin-left:50px;">
        <div id="divQImage" style="margin-left:-100px;">
            <img src="~/Content/images/0-logo.png" width="300" height="100" />
        </div><br />
        <div id="divSoundLink" style="margin-top:100px;">
            <a href="javascript:void(0);">Click To hear question spoken</a>
        </div>
    </div>
    <div class="col-sm-2" style="width:50px;">
    </div>*@
    <div class="col-sm-9">
        
                @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<table border="1" cellpadding="5" cellspacing="5" style="width:600px;height:300px;">
                <colgroup>
                    <col width="600" />
                </colgroup>
                <tr>
                    <td>
                        @If Model.QuestionStem IsNot Nothing Then
                            @<div id="divQuestion" style="height:100px;overflow-x:hidden;overflow-y:auto;">
                                @Model.QuestionStem
                            </div>
                        Else
                            @<div id="divQuestion">
                                QUESTION STEM WILL SHOW UP HERE
                            </div>
                        End If
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
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                @Html.CheckBoxFor(Function(model) model.ProvidedAnswer.Choice2Correct, 2)
                                                            </td>
                                                            <td>
                                                                @Html.DisplayFor(Function(model) model.Answer.Choice2Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                @Html.CheckBoxFor(Function(model) model.ProvidedAnswer.Choice3Correct, 3)
                                                            </td>
                                                            <td>
                                                                @Html.DisplayFor(Function(model) model.Answer.Choice3Text, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "height:50px;width:500px;", .maxlength = "50"})
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                @Html.CheckBoxFor(Function(model) model.ProvidedAnswer.Choice4Correct, 4)
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
End Select
                      </div>
                    </td>
                </tr>
            </table>
End Using
            
            
            <p>&nbsp;</p>
            <div style="overflow-y:hidden;overflow-x:auto;width:10px;"></div>
            <table>
                <colgroup>
                    @For i = Integer.Parse(Session("qStart")) To Integer.Parse(Session("qEnd"))
                @<col width="50" />
                    Next
                </colgroup>
                <tr>
                    <td>
                        <input type="button" value="<<" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("TestPage", "TestTaking", New With {.button = "prev"})'" />
                    </td>
                    @For i = Integer.Parse(Session("qStart")) To Integer.Parse(Session("qEnd"))
                @<td>
                    <input type="submit" value="@i" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("TestPage", "TestTaking", New With {.page = i})'" />
                </td>
                    Next
                    <td>
                        <input type="button" value=">>" class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("TestPage", "TestTaking", New With {.button = "next"})'" />
                    </td>
                </tr>
            </table>
    </div>
</div>
