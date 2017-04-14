@Code
    ViewData("Title") = "EditSubject"
End Code

@ModelType StudentsAssessment.SubjectsData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<script language="javascript" type="text/javascript">

    function SelectAssocClass() {
        $("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Admins/GetAssocClass'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedSubject').val(); //mere $(this).val() does not seem to work
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iSubjectID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        //alert(data.classID);
        if (data != null) {
            if (data.classID > 0) {

                //$('select').prop('selectedIndex', data.classID); // select 4th option
                $('#SelectedClass').val(data.classID);
            }
        }

    }

    function errorFunc() {
        alert('class fill error');
    }
</script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

@*@Scripts.Render("~/bundles/jqueryui")
    @Styles.Render("~/Content/cssjqueryui")*@

<div class="row" style="padding-top:100px;">
    <div class="col-lg-3">
        <h3>ADMIN TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        <div>
            @Html.Partial("SideMenu")
        </div>
    </div>
    <div class="col-lg-9">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>EDIT SUBJECT INFORMATION</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table id="tblCreateClass" border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="600" />
                    <col width="200" />
                </colgroup>
                <tr>
                    <td>
                        @Html.Label("SELECT A SUBJECT TO EDIT:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})

                        @*@Html.LabelFor(Function(model) model.ClassesList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})*@
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.SelectedSubject, Model.SubjectsList, New With {.onchange = "SelectAssocClass();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedSubject, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        @Html.Label("TO WHICH OTHER CLASS DO YOU WANT TO ASIGN THIS SUBJECT TO BE TAUGHT?", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        @Html.DropDownListFor(Function(model) model.SelectedClass, Model.ClassesTobeTaughtInList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                    </td>
                </tr>



                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input type="submit" value="UPDATE SUBJECT" class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        @If String.IsNullOrEmpty(ViewBag.StatusMessage) = True Then
                            @<div id="divStatusMessage" class="field-validation-error">
                                @ViewBag.StatusMessage
                            </div>
                        Else
                            @<div id="divStatusMessage" class="field-validation-error">
                                @Html.Raw(ViewBag.StatusMessage)
                            </div>
                        End If
                    </td>
                </tr>
            </table>
        End Using
    </div>
</div>


