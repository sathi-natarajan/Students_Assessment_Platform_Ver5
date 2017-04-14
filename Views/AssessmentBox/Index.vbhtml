@Code
    ViewData("Title") = "Welcome page"
End Code

@ModelType IEnumerable(Of StudentsAssessment.AssessmentData)

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="~/Scripts/jquery-1.12.4.min.js"></script>

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
            @<h3>ASSESSMENT BANK</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @For each item In Model
                @Html.Partial("AssessmentBox", New StudentsAssessment.AssessmentData With
                                                                                            {
                                                                                                .AssessmentID = item.AssessmentID,
                                                                                                .AssessmentIDStr = item.AssessmentIDStr,
                                                                                                .Assessmentname = item.Assessmentname,
                                                                                                .Description = item.Description,
                                                                                                .CreateDate = item.CreateDate})
                @<br />@<br />
            Next
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
</div>
