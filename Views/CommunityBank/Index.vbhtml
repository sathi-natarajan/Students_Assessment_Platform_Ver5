@ModelType IEnumerable(Of StudentsAssessment.QuestionData)
@Code
    ViewData("Title") = "Community Bank"
    'Layout = Nothing
End Code

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

            @<div>
                <h3>COMMUNITY BANK</h3>
                <hr style="background-color:cadetblue;height:2px;" />

                <table cellpadding="5" cellspacing="5">
                    <colgroup>
                        <col />
                        <col width="450" />
                    </colgroup>
                    <tr>
                        <td>
                            <div style="float:right;">
                                @*<a class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("New_CreateQuestion", "QuestionBank")'">CREATE A QUESTION</a>
                                <a class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("New_FetchQuestionsList", "QuestionBank")'">REFRESH LIST</a>
                                <a class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("New_FilterQuestion", "QuestionBank")'">FILTER LIST</a>*@
                                <a class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("BulkUploadQAs", "CommunityBank")'">BULK-LOAD MASTER QUESTIONS/ANSWERS</a>
                                <a class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("UploadStandards", "CommunityBank")'">UPLOAD STANDARDS INFORMATION</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>


            @*@<table cellpadding="15">
                <colgroup>
                    <col width="100" valign="top" />
                    <col width="200" valign="top" />
                </colgroup>
                <tr>
                    <td colspan="2">
                        @Html.Label("Total # of questions returned: ")@Model.Count<br />
                        <div id="divQuestionsList" style="height:400px;width:800px;
                        overflow-x:hidden;overflow-y:auto;border:2px solid cadetblue;
                        padding-top:20px;padding-left:20px;">
                            @if Model.Count > 0 Then
                                @For Each item In Model
                                    @<table border="1" class="table" style="width:600px;">
                                        <colgroup>
                                            <col width="100" />
                                            <col width="500" />
                                            <col width="100" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                @Html.DisplayFor(Function(modelItem) item.QuestionIDStr)
                                            </td>
                                            <td>
                                                @Html.DisplayFor(Function(modelItem) item.QuestionStem)
                                            </td>
                                            <td>
                                                @Html.DisplayFor(Function(modelItem) item.QuestionTypename)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_RemoveQuestionAnswers", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Trash Ques.
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_DuplicateQuestion", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Duplicate Ques.
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_AddToAssessment", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Add to Assessmt.
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_Addexplanation", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Add explanation.
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_AddImage", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Add image.
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_AddSound", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Add sound.
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_QuestionInfo", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Question Info
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("New_UpdateQuestion", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Update Question
                                                </a>
                                                <a href="javascript:void(0);" class="btn btn-success clsbutton" style="background:cadetblue;height:25px;"
                                                   onclick="location.href='@Url.Action("RaiseDialog1", "QuestionBank", New With {.iQuestionID = item.QuestionID})'">
                                                    Summa raise a dialog
                                                </a>
                                            </td>
                                          
                                        </tr>

                                    </table>
                                Next
                            Else
                                @<div>There is Nothing to show here</div>
                            End If

                        </div>

                    </td>
                </tr>
            </table>*@
        End Using
    </div>
</div>
@*<td>
    @Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
        @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
        @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})
        </td>*@
<div id="dialog" title="Basic dialog">

</div>

@Html.Raw(TempData("Script"))

