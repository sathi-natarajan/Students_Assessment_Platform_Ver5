﻿
@Code
    ViewData("Title") = "AddSubjecttoClass"
End Code

@ModelType StudentsAssessment.SubjectsData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        //$("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Teachers/GetSubjectsData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedClass').val(); //mere $(this).val() does not seem to work
        if (iSel > 0) {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iClassID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
            });

        }
        else
        {
            $("#divStatusMessage").text("Your class list is empty.  Please add some classes to your list first");
            $("#trClasses").css("visibility", "hidden");
            $("#trSubjects").css("visibility", "hidden");
            $("#trDetails").css("visibility", "hidden");
        }
           
    });

    function FillSubjectData() {
        //$("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Teachers/GetSubjectData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedSubject').val(); //mere $(this).val() does not seem to work
        if (iSel > 0) {
            $.ajax({
                //type: "POST",
                url: serviceURL,
                //data: param = "",
                data: { iSubjectID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc1,
                error: errorFunc1
            });
        }
        else
        {
            $("#divStatusMessage").text("Your subject list is empty.  Please contact administrator.  Or,  choose another class.");
            //$("#trClasses").css("visibility", "hidden");
            $("#trSubjects").css("visibility", "hidden");
            $("#trDetails").css("visibility", "hidden");
        }
       
    }
    function FillSubjectsData() {
        //$("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/Teachers/GetSubjectsData'; //This should not be inside AJAX call itself
        var iSel = $('#SelectedClass').val(); //mere $(this).val() does not seem to work
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iClassID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
        FillSubjectData();
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        //$('#SelectedSubject').append($('<option>', {
        //    value: data.Value,
        //    text: data.Text
        //})).append($('<option>', {
        //    value: data.Value,
        //    text: data.Text
        //}))
        //$('#SelectedSubject').empty().append($('<option>', {
        //    value: -1,
        //    text: "Select a subject"
        //}));
        $("#trClasses").css("visibility", "visible");
        $("#trSubjects").css("visibility", "visible");
        $("#trDetails").css("visibility", "visible");

        if (data.length > 0)
        {
            $('#SelectedSubject').empty();
            $.each(data, function (i, item) {
                $('#SelectedSubject').append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });
            FillSubjectData();
        }
        else
        {
            $("#divStatusMessage").text("Your subject list is empty.  Please contact administrator.  Or,  choose another class.");
            //$("#trClasses").css("visibility", "hidden");
            $("#trSubjects").css("visibility", "hidden");
            $("#trDetails").css("visibility", "hidden");
        }
      
    }

    function errorFunc() {
        alert('class fill error');
    }

    function successFunc1(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        $("#trSubjects").css("visibility", "visible");
        $("#trDetails").css("visibility", "visible");
        $('#GradeLevel').val(data.GradeLevel);
    }
    function errorFunc1() {
        alert('subjects fill error');
    }
</script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>


<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @<h3>ADD SUBJECT TO A CLASS</h3>
            @<hr style="background-color:cadetblue;height:2px;" />
            @<table border="0" cellpadding="2" cellspacing="2">
                <colgroup>
                    <col width="300" />
                    <col width="400" />
                </colgroup>
              @if model.TaughtClassesList.Count > 0 Then
                   @<tr id = "trClasses" >
                     <td colspan="2">
                        @Html.Label("Select class to which you want to add a subject", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                     </td>
                    </tr>
                 @<tr id = "trClasses" >
                    <td colspan="2">
                        @Html.DropDownListFor(Function(model) model.SelectedClass, Model.TaughtClassesList, New With {.onchange = "FillSubjectsData();"})
                        @Html.ValidationMessageFor(Function(model) model.SelectedClass, "", New With {.class = "text-danger"})
                    </td>
                 </tr>

                 @If Model.SelectedClass > 0 AndAlso Model.SubjectsList IsNot Nothing AndAlso
                              Model.SubjectsList.Count > 0 Then
                      @<tr id = "trClasses" >
                     <td colspan = "2" >
                        @Html.Label("Select a subject from below list to add to above class", htmlAttributes:=New With {.Class = "control-label col-md-2", .style = "width:100%;"})
                     </td>
                   </tr>

                    @<tr id="trSubjects">
                        <td>
                            @Html.DropDownListFor(Function(model) model.SelectedSubject, Model.SubjectsList, "Select a subject", New With {.onchange = "FillSubjectData();"})
                            @Html.ValidationMessageFor(Function(model) model.SelectedSubject, "", New With {.class = "text-danger"})
                        </td>
                    </tr>

                    @<tr id="trDetails">
                        <td>
                            @Html.Label("What is this subject's appropriate grade level:", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                        </td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.GradeLevel, New With {.htmlAttributes = New With {.class = "form-control", .style = "width:100%;"}, .readonly = "true"})
                            @Html.ValidationMessageFor(Function(model) model.GradeLevel, "", New With {.class = "text-danger"})
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="ADD" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                            <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton-round" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Home")'" />

                        </td>
                    </tr>
                 Else
                    @<tr>
                        <td colspan="2">
                            List of subjects could not be loaded for this class.  Please select another
                            class
                        </td>
                    </tr>
                    @<tr>
                        <td colspan="2" style="text-align:center;">
                            <input type="submit" value="ADD" Class="btn btn-success clsbutton-round" style="background:cadetblue;" />
                        </td>
                    </tr>
                 End If
              Else
                @<tr id="trClasses">
                    <td colspan="2">
                        @Html.Label("You are not teaching any classes currently.  Please add some classes first.", htmlAttributes:=New With {.class = "control-label col-md-2", .style = "width:100%;"})
                    </td>
                </tr>
                @<tr>
                    <td colspan="2" style="text-align:center;">
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
    </div>@* <div class="col-sm-9"*@
    <div class="col-sm-3">
        <h3>TEACHER TASKS</h3>
        <hr style="background-color:cadetblue;height:2px;" />
        @Html.Partial("SideMenu")
    </div>
</div>