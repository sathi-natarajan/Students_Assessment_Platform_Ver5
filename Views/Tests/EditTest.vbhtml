@Code
    ViewData("Title") = "Edit a test"
End Code

@ModelType StudentsAssessment.TestData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="~/Scripts/jquery-1.12.4.min.js"></script>
<script src="~/Content/jQueriUI/jquery-ui-1.12.1.min.js"></script>
<link href="~/Content/jQueriUI/themes/base/jquery-ui.min.css" rel="stylesheet" />

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        FetchTestDetails();
    });

    function FetchTestDetails() {
        $("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Tests/GetTestData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedTest').val(); //mere $(this).val() does not seem to work
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iTestID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        var strQuestionInfo = "<strong>test ID:</strong>" + data.testid + "<br/>";
        strQuestionInfo += "<strong>testname:</strong>" + data.testname + "<br/>";
        strQuestionInfo += "<strong>Test Description:</strong>" + data.Description + "<br/>";
        strQuestionInfo += "<strong>Test date:</strong>" + data.testdate + "<br/>";
        strQuestionInfo += "<strong>Start time:</strong>" + data.starttime + "<br/>";
        strQuestionInfo += "<strong>End time:</strong>" + data.endtime + "<br/>";
        strQuestionInfo += "<strong>Right now, just displays test info.  Later, will implement editing these things</strong>";
        //alert(strQuestionInfo);
        $("#dlgQuestionInfo").html("<p>" + strQuestionInfo + "</p>")
        $("#dlgQuestionInfo").dialog({
            resizable: false,
            title: "Info. on selected course",
            height: "auto",
            width: 500,
            height: 300,
            modal: true,
            buttons: {
                "OK": function () {
                    // alert("You clicked OK");
                    $(this).dialog("close");
                },
                //Cancel: function () {
                //    //alert("You clicked Cancel");
                //    $(this).dialog("close");
                //}
            }
        });
    }

    function errorFunc() {
        // alert('An error occured when trying to fetch information on the selected test');
        $("#dlgQuestionInfo").html("<p>An error occured when trying to fetch information on the selected test</p>")
        $("#dlgQuestionInfo").dialog({
            resizable: false,
            title: "ERROR",
            height: "auto",
            width: 500,
            height: 300,
            modal: true,
            buttons: {
                "OK": function () {
                    // alert("You clicked OK");
                    $(this).dialog("close");
                },
                //Cancel: function () {
                //    //alert("You clicked Cancel");
                //    $(this).dialog("close");
                //}
            }
        });
    }
</script>

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
            @<h3>EDIT A TEST</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
                @if Model.TestsList.Count()>0
                    @<tr>
                        <td colspan="2">
                            @Html.Label("You have created these tests, please select the one you whose information want to edit", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2">
                            @Html.DropDownListFor(Function(model) model.SelectedTest, Model.TestsList, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;", .onchange = "FetchTestDetails();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedTest, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="UPDATE INFO" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />

                        </td>
                    </tr>
                Else
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            You have not created any tests yet. Nothing to show for editing
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            @* <input type="submit" value="REMOVE CLASS" Class="btn btn-success clsbutton" style="background:cadetblue;" />*@
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                        </td>
                    </tr>
                End If


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
<div id="dlgQuestionInfo" title="QuestionInfo">
</div>