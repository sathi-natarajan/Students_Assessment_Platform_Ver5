@ModelType IEnumerable(Of StudentsAssessment.BulkLoadQuestionAnswers)
@Code
    ViewData("Title") = "BulkUploadQAs"
End Code

@*<h2>BulkUploadQAs</h2>

    <p>
        @Html.ActionLink("Create New", "Create")
    </p>*@

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">      
        <h3>UPLOAD QUESTIONS/ANSWERS TO QUESTION BANK</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Using (Html.BeginForm("ImportExcel", "QuestionBank", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
            @Html.AntiForgeryToken()
            @<table>
                 <tr>
                     <td>
                         <ol>
                             <li>
                                 Create an excel spreadsheet with rows of entries one for each question and answer combination.  For simplicity, please call it
                                 <strong>QuestionsAnswers.xls</strong>
                             </li>
                             <li>
                                 Please make sure the format of entries conform to the format shown in the below table.  The actual data given below is only
                                 provided as examples.  You can also make a copy of the above spreadsheet in "Data_for_uploading" folder and modify
                                 only the data to upload in which case the formatting is easily preserved.<br />
                                 <table border="1">
                                     <tr style="background-color:cadetblue;font-weight:bold;">
                                         <td>Question Stem</td>
                                         <td>Description</td>
                                         <td>Question Type</td>
                                         <td>Standard</td>
                                         <td>Answer</td>
                                         <td>Correct?</td>
                                     </tr>
                                     <tr>
                                         <td>How many states are there in US?</td>
                                         <td>Please type in your answer in the field below</td>
                                         <td>Short Answer</td>
                                         <td>Standard I</td>
                                         <td>50</td>
                                         <td>Yes</td>
                                     </tr>
                                     <tr>
                                         <td>Who among the following is the current president of United States?</td>
                                         <td>Please choose ONE of the choices from below list</td>
                                         <td>Multiple Choice</td>
                                         <td>Standard II</td>
                                         <td>Bill Clinton</td>
                                         <td>No</td>
                                     </tr>
                                     <tr>
                                         <td>Who among the following is the current president of United States?</td>
                                         <td>Please choose ONE of the choices from below list</td>
                                         <td>Multiple Choice</td>
                                         <td>Standard II</td>
                                         <td>Barack Obama</td>
                                         <td>No</td>
                                     </tr>
                                     <tr>
                                         <td>Who among the following is the current president of United States?</td>
                                         <td>Please choose ONE of the choices from below list</td>
                                         <td>Multiple Choice</td>
                                         <td>Standard II</td>
                                         <td>Donald Trump</td>
                                         <td>Yes</td>
                                     </tr>
                                     <tr>
                                         <td>Who among the following is the current president of United States?</td>
                                         <td>Please choose ONE of the choices from below list</td>
                                         <td>Multiple Choice</td>
                                         <td>Standard II</td>
                                         <td>George Bush</td>
                                         <td>No</td>
                                     </tr>
                                 </table>
                             </li>
                             <li>
                                 Once ready, click on the "Choose File" button below and, in the dialog box shown, navigate
                                 to the location where you have the spreadsheet saved.  Select that and click OK.  Its file
                                 name then appears near the button below
                             </li>
                             <li>
                                 Click on "PREVIEW DATA" button below.  Upon doing so, you will see the actual data that is contained
                                 in your excel spreadsheet.  They are the ones going to be uploaded when you click on the 
                                 button called "UPLOAD DATA" that is shown below the data.
                             </li>
                             <li>
                                 Finally, click on that button to have the records shown saved into the system and activated
                                 immediately!
                             </li>
                         </ol>
                     </td>
                 </tr>
                <tr>
                    <td><input type="file" id="FileUpload1" name="FileUpload1" accept=".xls" /></td>
                </tr>
                <tr>
                    <td>
                        <input type="submit" id="Submit" name="Submit" value="PREVIEW DATA" class="btn btn-success clsbutton-round" />
                    </td>
                </tr>
            </table>
        End Using

        @If Model IsNot Nothing AndAlso Model.Count > 0 Then
            @Using (Html.BeginForm("BulkUploadQAs", "QuestionBank"))
                @Html.AntiForgeryToken()
                @Html.Label("Total # of items to upload: ")@Model.Count@<br />
                @<table class="table">
                    <colgroup>
                        <col />
                        <col />
                        <col />
                        <col />
                        <col width="200" />
                    </colgroup>
                    <tr>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.QuestionStem)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.Description)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.QuestionType)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.Standard)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.Answer)
                        </th>
                        @*<th>
                            @Html.DisplayNameFor(Function(model) model.Correct)
                        </th>
                        <th></th>*@
                    </tr>

                    @For Each item In Model
                        @<tr>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.QuestionStem)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Description)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.QuestionType)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Standard)
                            </td>
                            <td>
                                @If String.IsNullOrEmpty(item.AnswerData.Choice1Text) = False Then
                                    @Html.DisplayFor(Function(modelItem) item.AnswerData.Choice1Text)
                                    If item.AnswerData.Choice1Correct Then
                                        @<img src="../Content/images/check.gif" />@<br />
                                    End If
                                Else
                                    @<br />
                                End If
                                @If String.IsNullOrEmpty(item.AnswerData.Choice2Text) = False Then
                                    @Html.DisplayFor(Function(modelItem) item.AnswerData.Choice2Text)
                                    If item.AnswerData.Choice2Correct Then
                                        @<img src="../Content/images/check.gif" />@<br />
                                    Else
                                        @<br />
                                    End If
                                End If
                                @If String.IsNullOrEmpty(item.AnswerData.Choice3Text) = False Then
                                    @Html.DisplayFor(Function(modelItem) item.AnswerData.Choice3Text)
                                    If item.AnswerData.Choice3Correct Then
                                        @<img src="../Content/images/check.gif" />@<br />
                                    Else
                                        @<br />
                                    End If
                                End If
                                @If String.IsNullOrEmpty(item.AnswerData.Choice4Text) = False Then
                                    @Html.DisplayFor(Function(modelItem) item.AnswerData.Choice4Text)
                                    If item.AnswerData.Choice4Correct Then
                                        @<img src="../Content/images/check.gif" />@<br />
                                    Else
                                        @<br />
                                    End If
                                End If
                            </td>
                            @*<td>
                                @Html.DisplayFor(Function(modelItem) item.Correct)
                            </td>*@
                            <td>
                                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                                @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                                @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
                            </td>
                        </tr>
                    Next
                    <tr>
                        <td>
                            <input type="submit" id="Submit1" name="Submit1" value="UPLOAD DATA" class="btn btn-success clsbutton-round" />
                        </td>
                    </tr>
                    @*<tr>
                        <td>
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
                    </tr>*@
                </table>
            End USING
        End If
        @If String.IsNullOrEmpty(ViewBag.StatusMessage) = False Then
            @<div class="field-validation-error">
                @ViewBag.StatusMessage
            </div>
        Else
            @<div class="field-validation-error">
                @Html.Raw(ViewBag.StatusMessage)
            </div>
        End If      
    </div>
</div>