@Code
    ViewData("Title") = "Create Teacher Account"
    'Layout = Nothing
End Code

@ModelType StudentsAssessment.TeacherData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<script src="~/Content/MaskedInput/jquery.maskedinput.min.js"></script>

<link href="~/Content/jQuery_datepicker/css/jquery.datepick.css" rel="stylesheet" />
<script src="~/Content/jQuery_datepicker/js/jquery.plugin.min.js"></script>
<script src="~/Content/jQuery_datepicker/js/jquery.datepick.min.js"></script>

<script type="text/javascript">
    jQuery(function ($) {
        //$("#Firstname").watermark({ watermarkText: "Type your first name" });
        //$("#Lastname").watermark({ watermarkText: "Type your last name" });
        //$("#Firstname").focus();
        $('#StartDate').datepick();
        //$('#EndDate').datepick();
    });
</script>

<script>
    $(document).ready(function () {
        LoadCities();
    });

    function LoadCities() {
        var serviceURL = '/Home/GetCitiesForState'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedState').val(); //mere $(this).val() does not seem to work;
        if (iSel > 0)
        {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iStateID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
            });
        }
        else
            alert("No states are available to load");
    }

    function LoadSchoolDistricts() {
        var serviceURL = '/Home/GetSchoolDistrictsForCityState'; //This should not be inside AJAX call itself
        var iSel1 = $('#SelectedState').val(); //mere $(this).val() does not seem to work;
        var iSel2 = $('#SelectedCity').val(); //mere $(this).val() does not seem to work;
        if (iSel1 > 0 && iSel2 > 0) {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: {iStateID: iSel1, iCityID: iSel2}, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc1,
                error: errorFunc1
            });
        }
        else
            alert("No cities are available to load");
    }

    function LoadSchools() {
        var serviceURL = '/Home/GetSchoolsForDistrictCityState'; //This should not be inside AJAX call itself
        var iSel1 = $('#SelectedState').val(); //mere $(this).val() does not seem to work;
        var iSel2 = $('#SelectedCity').val(); //mere $(this).val() does not seem to work;
        var iSel3 = $('#SelectedSchoolDist').val(); //mere $(this).val() does not seem to work;
        if (iSel1 > 0 && iSel2 > 0 && iSel3>0) {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iStateID: iSel1, iCityID: iSel2, iDistrictID: iSel3 }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc2,
                error: errorFunc2
            });
        }
        else
            alert("No schools are available to load");
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
      
        if (data.length > 0) {
            $('#SelectedCity').empty();
            $.each(data, function (i, item) {
                $('#SelectedCity').append($('<option>', {
                    value: item.CityID,
                    text: item.Cityname
                }));
            });
            LoadSchoolDistricts()
        }
    }

    function successFunc1(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up

        if (data.length > 0) {
            $('#SelectedSchoolDist').empty();
            $.each(data, function (i, item) {
                $('#SelectedSchoolDist').append($('<option>', {
                    value: item.SchoolDistrictID,
                    text: item.SchoolDistrictname
                }));
            });
            LoadSchools();
        }
    }

    function successFunc2(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up

        if (data.length > 0) {
            $('#SelectedSchool1').empty();
            $.each(data, function (i, item) {
                $('#SelectedSchool1').append($('<option>', {
                    value: item.SchoolID,
                    text: item.Schoolname
                }));
            });
        }
    }
        ////alert(strQuestionInfo);
        //$("#dlgQuestionInfo").html("<p>" + strQuestionInfo + "</p>")
        //$("#dlgQuestionInfo").dialog({
        //    resizable: false,
        //    title: "Info. on selected course",
        //    height: "auto",
        //    width: 500,
        //    height: 300,
        //    modal: true,
        //    buttons: {
        //        "OK": function () {
        //            // alert("You clicked OK");
        //            $(this).dialog("close");
        //        },
        //        //Cancel: function () {
        //        //    //alert("You clicked Cancel");
        //        //    $(this).dialog("close");
        //        //}
        //    }
        //});

    function errorFunc() {
        alert('An error occured when trying to fetch cities for the selected state');
    }
    function errorFunc1() {
        alert('An error occured when trying to fetch school districts for the selected city/state');
    }
    function errorFunc2() {
        alert('An error occured when trying to fetch schools for the selected city/state/school district');
    }
</script>

<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>CREATE A NEW TEACHER ACCOUNT</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="300" />
                    <col width="300" />
                </colgroup>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Firstname, htmlAttributes:=New With {.class = "control-label col-md-10"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Firstname, New With {.htmlAttributes = New With {.class = "form-control"}, .width = "200px", .height = "100px"})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Firstname, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                 <tr>
                     <td>
                         @Html.LabelFor(Function(model) model.Middlename, htmlAttributes:=New With {.class = "control-label col-md-10"})
                     </td>
                     <td>
                         @Html.TextBoxFor(Function(model) model.Middlename, New With {.htmlAttributes = New With {.class = "form-control"}, .width = "200px", .height = "100px"})
                         <br />
                         @Html.ValidationMessageFor(Function(model) model.Middlename, "", New With {.class = "text-danger"})
                     </td>
                 </tr>
                 <tr>
                     <td valign="top">
                         @Html.LabelFor(Function(model) model.Lastname, htmlAttributes:=New With {.class = "control-label col-md-10"})
                     </td>
                     <td>
                         @Html.TextBoxFor(Function(model) model.Lastname, New With {.htmlAttributes = New With {.class = "form-control"}})
                         <br />
                         @Html.ValidationMessageFor(Function(model) model.Lastname, "", New With {.class = "text-danger"})
                     </td>
                 </tr>
                <tr>
                    <td valign="top">
                        @Html.LabelFor(Function(model) model.Emailaddress, htmlAttributes:=New With {.class = "control-label col-md-10"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Emailaddress, New With {.htmlAttributes = New With {.class = "form-control"}})
                        <br />
                        @Html.ValidationMessageFor(Function(model) model.Emailaddress, "", New With {.class = "text-danger"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(model) model.Joindate, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.Joindate, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:175px;"}, .type = "text", .id = "StartDate"})<br />
                        @Html.ValidationMessageFor(Function(model) model.Joindate, "", New With {.class = "text-danger"})
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        @Html.Label("Username: Auto-assigned by system", htmlAttributes:=New With {.class = "control-label col-md-10", .style = "width:  100%;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.Label("Password:", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    </td>
                    <td>
                        <div style="font-weight:bold;">
                            @Html.Label("teacher", New With {.htmlAttributes = New With {.class = "form-control"}})
                        </div>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        @Html.Label("SELECT YOUR GRADE LEVEL:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:200px;"})
                        @Html.DropDownListFor(Function(model) model.SelectedGradeLevel, Model.GradeLevelsList)
                        @Html.ValidationMessageFor(Function(model) model.SelectedGradeLevel, "", New With {.class = "text-danger"})
                    </td>
                </tr>
              </table>
                    @<table border="0" cellpadding="7" cellspacing="7">
                <colgroup>
                    <col width="400" />
                    <col width="400" />
                    <col width="300" />
                </colgroup>
                @If Model.StatesListDDL.Count > 0 Then
                    @<tr>
                        <td colspan="2">
                            @Html.Label("SELECT SCHOOL'S STATE:")
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedState, Model.StatesListDDL, New With {.onchange = "LoadCities();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedState, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2">
                            @Html.Label("SELECT SCHOOL'S CITY:")
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedCity, Model.CitiesListDDL, New With {.onchange = "LoadSchoolDistricts();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedCity, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2">
                            @Html.Label("SELECT SCHOOL'S DISTRICT:")
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedSchoolDist, Model.SchoolDistrictsListDDL, New With {.onchange = "LoadSchools();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedSchoolDist, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2">
                            @Html.Label("SELECT YOUR SCHOOL:")
                        </td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedSchool1, Model.Schools1ListDDL)
                            @Html.ValidationMessageFor(Function(model) model.SelectedSchool1, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                <td colspan = "3" style="text-align:center;">
                    <input type = "submit" value="CREATE ACCOUNT" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                    <input type = "button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                </td>
            </tr>
                Else
            @<tr>
                <td colspan="2">
                    @Html.Label("State information could not be loaded  for selection")
                </td>
            </tr>
            @<tr>
                    <td colspan="3" style="text-align:center;">
                        <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />
                    </td>
            </tr>
                End If
            </table>
            @If String.IsNullOrEmpty(Model.Errormessage) = False Then
                @<div class="field-validation-error">
                    @Model.Errormessage
                </div>
            Else
                @<div class="field-validation-error">
                    @Html.Raw(Model.Successmessage)
                </div>
            End If
End Using
    </div>
</div>
