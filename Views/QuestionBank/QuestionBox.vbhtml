
@ModelType StudentsAssessment.QuestionData
<script src="~/Scripts/jquery-1.12.4.min.js"></script>
<script src="~/Content/jQueriUI/jquery-ui-1.12.1.min.js"></script>
<link href="~/Content/jQueriUI/themes/base/jquery-ui.min.css" rel="stylesheet" />
<script>
    function ShowInfo(ID)
    {
        alert("You clicked on label " +ID);
    }

    function FetchQuestionInfo(ID) {
        $("#divStatusMessage").text(""); //Put it consistently everyhwhere
        var serviceURL = '/QuestionBank/GetQuestionInfo'; //This should not be inside AJAX call itself
        var iSel = ID;
        $.ajax({
            //type: "POST",
            url: serviceURL,
            //data: param = "",
            data: { iQuestionID: iSel }, /*The parameter name in the FirstAJAX Action should be "param" only*/
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    }

    function successFunc(data, status) {
        //JSON members should be same case as how it is sent.  Otherwise, it will not show up
        //$('#Endtime').val(data.Endtime);
        var strQuestionInfo="<strong>Question ID:</strong>" + data.QuestionID+"<br/>";
        strQuestionInfo += "<strong>Question:</strong>" + data.QuestionStem + "<br/>";
        strQuestionInfo += "<strong>QuestionType:</strong>" + data.QuestionType;
        //alert(strQuestionInfo);
        $("#dlgQuestionInfo").html("<p>" + strQuestionInfo + "</p>")
        $("#dlgQuestionInfo").dialog({
            resizable: false,
            title: "Info. on selected question",
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
        $("#dlgQuestionInfo").html("<p>An error occured when trying to fetch information on the selected question</p>")
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
<style type="text/css">
    #tblQuestionBox tr td a
    {
        text-decoration:none;
    }
    #tblQuestionBox {
        border-color: #fff;
        border-size: 2px;
        width: 750px;
    }

        #tblQuestionBox tr td {
            background-color: lightgray;
            text-align: center;
            font-weight: bold;
        }

            /*Only the second col*/
            #tblQuestionBox tr td:nth-child(2) {
                background-color: green;
                text-align: center;
            }

            /*Only the first row*/
            #tblQuestionBox tr td:nth-child(1) {
                background-color: orange;
                text-align: center;
            }
        /*Only the first col of 1st row*/
        #tblQuestionBox tr:nth-child(1) td:nth-child(1) {
            background-color: lightgray;
            text-align: center;
        }

        /*Only the first col of 3rd row*/
        #tblQuestionBox tr:nth-child(3) td:nth-child(1) {
            background-color: lightgray;
            text-align: center;
        }
</style>
<table id="tblQuestionBox" border="1" cellspacing="0" cellpadding="0">
<colgroup>
    <col width="400" />
    <col width="100" />
    <col width="100" />
    <col width="30" />
    <col width="30" />
    <col width="10" />
    <col width="50" />
</colgroup>
<tr>
    <td colspan="3">
        @Model.QuestionIDStr 
    </td>
    <td rowspan="3">
        @*@Html.ActionLink(" E<br />D<br />I<br />T", "EditQuestion", New With {.id = Model.QuestionID})*@
        <a href="@Url.Action("EditQuestion", "QuestionBox", New With {.id = Model.QuestionID})">E<br />D<br />I<br />T</a>
    </td>
    <td rowspan="3">
        @*@Html.ActionLink("T<br />R<br />A<br />S</br/>H", "TrashQuestionAnswers", New With {.id = Model.QuestionID})*@
        <a href="@Url.Action("TrashQuestionAnswers", "QuestionBox", New With {.id = Model.QuestionID})">T<br />R<br />A<br />S</br/>H</a>
    </td>
    <td colspan="2" rowspan="3">
        @*@Html.ActionLink("DUPL. <br />QUESTION.<br /> NEW ID", "DuplicateQuestion", New With {.id = Model.QuestionID})*@ 
        <a href="@Url.Action("DuplicateQuestion", "QuestionBox", New With {.id = Model.QuestionID})">DUPL. <br />QUESTION.<br /> NEW ID</a>
    </td>
    <td colspan="3" rowspan="3">
        @*@Html.ActionLink("ADD TO ASSESSMENT", "AddtoAssessment", New With {.id = Model.QuestionID})*@
        <a href="@Url.Action("AddtoAssessment", "QuestionBox", New With {.id = Model.QuestionID})">ADD TO <br/>ASSESSMENT</a>      
    </td>
</tr>
<tr style="height:100px;">
    <td>
        @Html.Label(Model.QuestionStem, New With {.onclick = "FetchQuestionInfo(" + Model.QuestionID.ToString + ");"})
    </td>
</tr>
<tr>
    <td colspan="3">
        @Model.Standard.Standardname 
    </td>
</tr>
</table>
<div id="dlgQuestionInfo" title="QuestionInfo">
</div>