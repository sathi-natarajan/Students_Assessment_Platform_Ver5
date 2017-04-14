 <!--In the desired li, put  style="background-color:white;" or something for it to highlight as per the page!-->
@If Session("LoginPageFor") = "STUDENTS" Then
    @<ul id="StudentTasks" Class="sf-menu sf-vertical clsmenu" style="width:200px;">
        <!--width here changes that of superfish menu-->
            <li Class="current">
                <a href="@Url.Action("Index", "Welcome")">HOME</a>
            </li>
        <li>
            <a href="#a">CLASSES</a>
            <ul>
                <li><a href="@Url.Action("EnrollinClasses", "Students")">TAKE CLASSES</a></li>
                <li Class="current"><a href="@Url.Action("DisEnrollFromClasses", "Students")">DROP CLASSES</a></li>
                <li Class="current"><a href="@Url.Action("ViewEnrollments", "Students")">VIEW CLASSES</a></li>
            </ul>
        </li>
            <li>
                <a href="@Url.Action("EditProfile", "Students")">EDIT PROFILE</a>
            </li>
            <li>
                <a href="@Url.Action("TakeTest", "Students")">TAKE TEST</a>
            </li>
        <li>
            <a href="@Url.Action("Logout", "Login")">LOG OUT</a>
        </li>
    </ul>
ElseIf Session("LoginPageFor") = "TEACHERS" Then
    @<ul id="TeacherTasks" Class="sf-menu sf-vertical clsmenu">
        @select Case Session("Section")
                Case "main"
                    @<li>
                        <a href = "@Url.Action("Index", "Welcome")">HOME</a>
                    </li>
                    @<li>
                        <a href="@Url.Action("Index", "Classes")">CLASSES</a>
                    </li>
                    @<li>
                        <a href="@Url.Action("Index", "Subjects")">SUBJECTS</a>
                    </li>
                    @<li>
                        <a href="@Url.Action("Index", "Students")">STUDENTS</a>
                    </li>
                    @<li>
                        <a href="@Url.Action("EditProfile", "Teachers")">EDIT PROFILE</a>
                    </li>
                    @<li>
                        <a href="@Url.Action("Logout", "Login")">LOG OUT</a>
                    </li>
            Case "classes"
                @<li>
                    <a href="@Url.Action("Index", "Welcome")">HOME</a>
                </li>
                @<li>
                    <a href="@Url.Action("Index", "Classes")">SELECT CLASSES</a>
                </li>
                @<li>
                    <a href="@Url.Action("Index", "Subjects")">REMOVE CLASSES</a>
                </li>
                @<li>
                    <a href="@Url.Action("Index", "Students")">VIEW CLASSES</a>
                </li>
            Case "subject"
                @<li>
                    <a href="@Url.Action("Index", "Welcome")">HOME</a>
                </li>
                @<li>
                    <a href="@Url.Action("Index", "Classes")">SELECT CLASSES</a>
                </li>
                @<li>
                    <a href="@Url.Action("Index", "Subjects")">REMOVE CLASSES</a>
                </li>
                @<li>
                    <a href="@Url.Action("Index", "Students")">VIEW CLASSES</a>
                </li>
End Select
        
        <li>
            <a href = "@Url.Action("Index", "Classes")" >Class</a>
            <ul>
            <li> <a href = "@Url.Action("AddClass", "Classes")">Select CLASSES</a></li>
                <li Class="current"><a href="@Url.Action("RemoveClass", "Classes")">REMOVE CLASSES</a></li>
                <li Class="current"><a href="@Url.Action("ViewClasses", "Classes")">VIEW YOUR CLASSES</a></li>
            </ul>
        </li>
        <li>
                    <a href = "@Url.Action("Index", "Subjects")">SUBJECT</a>
            <ul>
                    <li>
                    <a href = "@Url.Action("AddSubjectToClass", "Subjects")">ADD To Class</a>
                </li>
                <li>
                    <a href = "@Url.Action("RemoveSubjectFromClass", "Subjects")">REMOVE FROM Class</a>
                </li>
                <li Class="current"><a href="@Url.Action("ViewSubjects", "Subjects")">VIEW YOUR SUBJECTS</a></li>
            </ul>
        </li>
        <li> <a href = "@Url.Action("Index", "TeachersStudents")">STUDENT</a>
            <ul>
                        <li>
                        <a href ="@Url.Action("CreateStudentAccount", "TeachersStudents")">CREATE A STUDENT ACCOUNT</a>
                </li>
                <li>
                        <a href = "@Url.Action("BulkCreateStudents", "TeachersStudents")">BULK-CREATE STUDENT ACCOUNTS</a>
                </li>
                <li>
                        <a href = "@Url.Action("AddStudentToClass", "TeachersStudents")">ADD To Class</a>
                </li>
                <li>
                        <a href = "@Url.Action("RemoveStudentFromClass", "TeachersStudents")">REMOVE FROM Class</a>
                </li>
                <li Class="current"><a href="@Url.Action("ViewStudents", "TeachersStudents")">VIEW YOUR STUDENTS</a></li>
            </ul>
        </li>
        <li>
                            <a href = "@Url.Action("NewList", "QuestionBank")">QUESTION BANK</a>
        </li>                                               
        <li>
                            <a href = "@Url.Action("Index", "AssessmentBank")">ASSESSMENT BANK</a>
        </li>
            <li>
                            <a href = "@Url.Action("EditProfile", "Teachers")">EDIT PROFILE</a>
            </li>
         <li>
                            <a href = "@Url.Action("Index", "Tests")">TESTS MGMT.</a>
             <ul>
                            <li>
                            <a href ="@Url.Action("CreateTest", "Tests")">CREATE TEST</a>
                 </li>
                 <li>
                            <a href = "@Url.Action("RemoveTest", "Tests")">REMOVE TEST</a>
                 </li>
                 <li>
                            <a href = "@Url.Action("EditTest", "Tests")">EDIT TEST INFO.</a>
                 </li>
                 <li>
                            <a href = "@Url.Action("GenerateTestNo", "Tests")">GENERATE TEST NO.</a>
                 </li>
                 <li>
                            <a href = "@Url.Action("AssignTest", "Tests")">ASSIGN TEST To STUDENT</a>
                 </li>

                 <li Class="current"><a href="@Url.Action("ViewTests", "Tests")">VIEW TESTS</a></li>
             </ul>
         </li>
        <li>
                                <a href = "@Url.Action("Logout", "Login")">LOG OUT</a>
        </li>
    </ul>
ElseIf Session("LoginPageFor") = "ADMINISTRATORS" Then
    @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;margin-left:-100px;">
            <li Class="current">
                <a href="@Url.Action("Index", "WelcomeAdmin")">HOME</a>
            </li>
        <li>
            <a href="#a">CLASSES</a>
            <ul>
                <li><a href="@Url.Action("AddClass", "Admins")">CREATE A CLASS</a></li>
                <li Class="current"><a href="@Url.Action("RemoveClass", "Admins")">ELIMINATE A CLASS</a></li>
                <li Class="current"><a href="@Url.Action("EditClass", "Admins")">EDIT CLASS INFO</a></li>
                <li Class="current"><a href="@Url.Action("ViewClasses", "Admins")">VIEW ALL CLASSES</a></li>
            </ul>
        </li>
        <li>
            <a href="#">SUBJECTS</a>
            <ul>
                <li><a href="@Url.Action("AddSubject", "Admins")">CREATE A  SUBJECT</a></li>
                <li Class="current"><a href="@Url.Action("RemoveSubject", "Admins")">ELIMINATE A SUBJECT</a></li>
                <li Class="current"><a href="@Url.Action("EditSubject", "Admins")">EDIT SUBJECT INFO</a></li>
                <li Class="current"><a href="@Url.Action("ViewSubjects", "Admins")">VIEW ALL SUBJECTS</a></li>
            </ul>
        </li>
        <li>
            <a href="#">STUDENTS</a>
            <ul>
                <li><a href="@Url.Action("CreateStudentAccount", "Teachers")">ENROLL STUDENT</a></li>
                <li Class="current"><a href="@Url.Action("RemoveStudent", "Admins")">REMOVE STUDENT</a></li>
                <li Class="current"><a href="@Url.Action("EditStudent", "Admins")">EDIT STUDENT INFO</a></li>
                <li Class="current"><a href="@Url.Action("ViewStudents", "Admins")">VIEW ALL STUDENTS</a></li>
            </ul>
        </li>
            <li>
                <a href="#">TEACHERS</a>
                <ul>
                    <li><a href="@Url.Action("AddTeacher", "Admins")">CREATE A TEACHER ACCT.</a></li>
                    <li>
                        <a href="@Url.Action("BulkCreateTeachers", "Admins")">BULK-CREATE TEACHER ACCOUNTS</a>
                    </li>
                    <li Class="current"><a href="@Url.Action("RemoveTeacher", "Admins")">REMOVE TEACHER</a></li>
                    <li Class="current"><a href="@Url.Action("EditTeacher", "Admins")">EDIT TEACHER INFO</a></li>
                    <li Class="current"><a href="@Url.Action("ViewTeachers", "Admins")">VIEW TEACHERS</a></li>
                    <li Class="current"><a href="@Url.Action("AssignToTeachers", "Admins")">ASSIGN CLASSES</a></li>
                </ul>
            </li>
        <li>
            <a href="#">PROFILES</a>
            <ul>
                <li><a href="@Url.Action("TeacherProfiles", "Admins")">TEACHER PROFILES</a></li>
                <li><a href="@Url.Action("StudentProfiles", "Admins")">STUDENT PROFILES</a></li>
            </ul>
        </li>
            <li>
                <a href="#">ACCOUNTS</a>
                <ul>
                    <li><a href="@Url.Action("ActivateSA", "Accounts")">STUDENT ACCOUNTS</a></li>
                    <li><a href="@Url.Action("ActivateTA", "Accounts")">TEACHER ACCOUNTS</a></li>
                </ul>
            </li>
            <li>
                <a href="#">COMMUNITY BANK</a>
                <ul>
                    <li><a href="@Url.Action("CreateQuestions", "Admins")">CREATE QUESTION</a></li>
                    <li Class="current"><a href="@Url.Action("RemoveQuestions", "Admins")">REMOVE QUESTION</a></li>
                    <li Class="current"><a href="@Url.Action("ViewQuestions", "Admins")">VIEW QUESTIONS</a></li>
                </ul>
            </li>
            @*<li>
                <a href="@Url.Action("Logout", "Login")">ANNOUNCEMENTS AND NEWS</a>
                <ul>
                    <li><a href="@Url.Action("CreateAssessment", "Admins")">SEND ANNOUNCEMENTS</a></li>
                    <li><a href="@Url.Action("CreateAssessment", "Admins")">VIEW ANNOUNCEMENTS</a></li>
                </ul>
            </li>*@
        <li>
            <a href="@Url.Action("Logout", "Login")">LOG OUT</a>
        </li>
    </ul>
End If
