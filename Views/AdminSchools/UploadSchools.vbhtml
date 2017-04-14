@ModelType IEnumerable(Of StudentsAssessment.SchoolData)
@Code
    ViewData("Title") = "Upload School data"
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
        <h3>ADMIN TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
     <h3>UPLOAD SCHOOL RECORDS</h3>
     <hr style="background-color:cadetblue;height:2px;" />
        @Using (Html.BeginForm("ImportExcel", "AdminSchools", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
        @Html.AntiForgeryToken()
        @<table>
            <tr>
                <td>
                    <ol>
                        <li>
                            Create an excel spreadsheet with rows of entries one for each school.  For simplicity, please call it
                            <strong>SchoolInfo.xls</strong>
                        </li>
                        <li>
                            Please make sure the format of entries conform to the format shown in the below table.  The actual data given below is only
                            provided as examples.  You can also make a copy of the above spreadsheet in "Data_for_uploading" folder and modify
                            only the data to upload in which case the formatting is easily preserved.<br />
                            <table border="1">
                                <tr style="background-color:cadetblue;font-weight:bold;">
                                    <td>City</td>
                                    <td>State</td>
                                    <td>School district</td>
                                    <td>School</td>
                                </tr>
                                <tr>
                                    <td>Williamsville</td>
                                    <td>NY</td>
                                    <td>Williamaville Central School District</td>
                                    <td>Williamsville East High School</td>
                                </tr>
                                <tr>
                                    <td>Tonawanda</td>
                                    <td>NY</td>
                                    <td>Ken-Ton School District</td>
                                    <td>Hamilton Elementary School</td>
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
        @Using (Html.BeginForm("UploadSchools", "AdminSchools"))
        @Html.AntiForgeryToken()
        @Html.Label("Total # of school records to upload: ")@Model.Count@<br />
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
                    @Html.DisplayNameFor(Function(model) model.SchoolCity.Cityname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.SchoolState.Statename)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.SchoolDistrict.SchoolDistrictname)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.Schoolname)
                </th>
            </tr>

            @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SchoolCity.Cityname)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SchoolState.Statename)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SchoolDistrict.SchoolDistrictname)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Schoolname)
            </td>
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
            </td>
        </tr>
            Next
            <tr>
                <td>
                    <input type="submit" id="Submit1" name="Submit1" value="UPLOAD SCHOOLS" class="btn btn-success clsbutton-round" />
                </td>
            </tr>
        </table>
        End USING
        End If
        @If ViewBag.output IsNot Nothing AndAlso CType(ViewBag.output, String()).Count > 0 Then
        @<div class="field-validation-error">
            @For Each strOutput In CType(ViewBag.output, String())
        @strOutput@<br />
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
