@ModelType StudentsAssessment.AssessmentData

<style type="text/css">
    #tblAssessmentBox {
        border-color: #fff;
        border-size: 2px;
        width: 750px;
    }

        #tblAssessmentBox tr td {
            background-color: lightgray;
            text-align: center;
            font-weight: bold;
            color: #fff;
        }

    /*dATE cREATED Col
    #tblQuestionBox tr td:nth-child(2){
        background-color:green;
        text-align:center;
    }*/
</style>

<table id="tblAssessmentBox" border="1" cellspacing="0" cellpadding="0" style="width:900px;border:2px solid #000;">
    <!--cols 1-3 -->
    <tr style="height:50px;">
        <td colspan="3">
            @Model.Assessmentname
        </td>
        <td>
            @Model.CreateDate 
        </td>
        <td>
            AVG. MASTERY
        </td>
        <td style="background-color:green;">
            XL
        </td>
        <td style="background-color:mediumpurple;">
            SR
        </td>
        <td colspan="2" rowspan="3">
            @Html.ActionLink("E<br />D<br />I<br />T", "EditAssessment", New With {.id = Model.AssessmentID})
            
        </td>
        <td colspan="3" rowspan="3">
            @Html.ActionLink("DUPLICATE<br />ASSESSMENT", "DuplicateAssessment", New With {.id = Model.AssessmentID})
        </td>
        <td colspan="2" rowspan="3">
            @Html.ActionLink(" T<br />R<br />A<br />S<br />H", "TrashAssessment", New With {.id = Model.AssessmentID})
        </td>
    </tr>
    <!--cols 4-6 -->
    <tr>
        <td colspan="3">
            <div style="background-color:lightblue;margin-top:10px;border:2px solid #fff;">STANDARDS CONTAINED</div><br /><br />
            <div style="background-color:lightblue;margin-top:-35px;border:2px solid #fff;">@Model.Description</div>
        </td>
        <td>
            UNIQUE TEST # <br /><br />
            <div style="background-color:green;border:2px solid #fff;">REFRESH</div>
        </td>
        <td>
            NUMBER OF STUDENTS <br />
            TESTED &/ OR REMAINING
        </td>
        <td colspan="2" style="background-color:orange;">
            VIEW DATA
        </td>
    </tr>
</table>

