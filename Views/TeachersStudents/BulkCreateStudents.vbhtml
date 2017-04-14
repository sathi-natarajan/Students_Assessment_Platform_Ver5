@ModelType IEnumerable(Of StudentsAssessment.StudentData)
@Code
    ViewData("Title") = "Bulk-create Students"
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
        <h3>CREATE A SET OF STUDENT ACCOUNTS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Using (Html.BeginForm("ImportExcel", "Teachers", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
        @Html.AntiForgeryToken()
        @<table>
            <tr>
                <td>
                    <ol>
                        <li>
                            Create an excel spreadsheet with rows of entries one for each student.  For simplicity, please call it
                            <strong>Students.xls</strong>
                        </li>
                        <li>
                            Please make sure the format of entries conform to the format shown in the below table.  The actual data given below is only
                            provided as examples.  You can also make a copy of the above spreadsheet in "Data_for_uploading" folder and modify
                            only the data to upload in which case the formatting is easily preserved.<br />
                            <table border="1">
                                <tr style="background-color:cadetblue;font-weight:bold;">
                                    <td>Firstname</td>
                                    <td>Lastname</td>
                                    <td>Joindate</td>
                                    <td>Grade</td>
                                    <td>School</td>
                                </tr>
                                <tr>
                                    <td>Sathi</td>
                                    <td>Natarajan</td>
                                    <td>04/12/2017</td>
                                    <td>Grade IV</td>
                                    <td>Williamsville East High School</td>
                                </tr>
                                <tr>
                                    <td>Varun</td>
                                    <td>Chakravarthy</td>
                                    <td>04/12/2017</td>
                                    <td>Grade III</td>
                                    <td>Kenmore East High School</td>
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
        @Using (Html.BeginForm("BulkCreateStudents", "Teachers"))
        @Html.AntiForgeryToken()
        @Html.Label("Total # of student records to upload: ")@Model.Count@<br />
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
                    @Html.DisplayNameFor(Function(model) model.Firstname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Lastname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Joindate)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.GradeLevelID)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.SchoolID)
                </th>
                @*<th>
                        @Html.DisplayNameFor(Function(model) model.Correct)
                    </th>
                    <th></th>*@
            </tr>

            @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Firstname)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Lastname)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Joindate)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SchoolID)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.GradeLevelID)
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
        @If ViewBag.output IsNot Nothing AndAlso CType(ViewBag.output, String()).Count > 0 Then
        @<div class="field-validation-error">
            @For Each strOutput In CType(ViewBag.output, String())
        @strOutput
            Next
        </div>
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