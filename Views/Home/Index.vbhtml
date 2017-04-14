@Code
    ViewData("Title") = "Student Assessment Platform - Home"
End Code

<h2>HOME - MAIN SCREEN</h2>

<div class="row">
    <div class="col-sm-3" style="margin-top:50px;">
        <button type="button" value="" onclick="location.href='@Url.Action("Index", "TestTaking")'" class="btn btn-success clsbutton-round">TAKE TEST</button>
    </div>
    <div class="col-sm-3" style="margin-top:100px;">
         <button type="button" value="" onclick="location.href='@Url.Action("TeacherLogin", "Home")'" class="btn btn-success clsbutton-round">TEACHER LOG-IN</button>
    </div>
    <div class="col-sm-3" style="margin-top:100px;">
        <button type="button" value="" onclick="location.href='@Url.Action("StudentLogin", "Home")'" class="btn btn-success clsbutton-round" >STUDENT LOG-IN</button>
    </div>
    <div class="col-sm-3" style="margin-top:50px;">
        <button type="button" value="" onclick="location.href='@Url.Action("CreateTeacherAccount", "Home")'" class="btn btn-success clsbutton-round">CREATE TEACHER ACCT.</button>
    </div>
</div>