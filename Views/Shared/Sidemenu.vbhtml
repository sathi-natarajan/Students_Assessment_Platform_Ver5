 <!--In the desired li, put  style="background-color:white;" or something for it to highlight as per the page!-->
@If Session("LoginPageFor") = "STUDENTS" Then
    @if Session("menuarea") Is Nothing Then
        Session("menuarea") = String.Empty
    End If
    @Select Case Session("menuarea").ToString
        Case "studentscourses"
            @<ul id="TeacherTasks" Class="sf-menu sf-vertical clsmenu" style="width:200px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "Welcome")">BACK</a>
                </li>
                 <li><a href="@Url.Action("EnrollinClasses", "StudentsCourses")">REGISTER FOR COURSES</a></li>
                 <li Class="current"><a href="@Url.Action("DisEnrollFromClasses", "StudentsCourses")">DROP COURSES</a></li>
                 <li Class="current"><a href="@Url.Action("ViewEnrollments", "StudentsCourses")">VIEW COURSES</a></li>
            </ul>
        Case Else
            @<ul id="StudentTasks" Class="sf-menu sf-vertical clsmenu" style="width:200px;">
                <!--width here changes that of superfish menu-->
                <li Class="current">
                    <a href="@Url.Action("Index", "Welcome")">HOME</a>
                </li>
                <li>
                    <a href="@Url.Action("Index", "StudentsCourses")">COURSES</a>
                </li>
                <li>
                    <a href="@Url.Action("EditProfile", "Students")">EDIT PROFILE</a>
                </li>
                <li>
                    <a href="@Url.Action("Index", "TestTaking")">TAKE TEST</a>
                </li>
                <li>
                    <a href="@Url.Action("Logout", "Login")">LOG OUT</a>
                </li>
            </ul>
End Select

ElseIf Session("LoginPageFor") = "TEACHERS" Then
    @if Session("menuarea") Is Nothing Then
        Session("menuarea") = String.Empty
    End If
    @Select Case Session("menuarea").ToString
        Case "courses"
            @<ul id="TeacherTasks" Class="sf-menu sf-vertical clsmenu">
                 <li Class="current">
                     <a href="@Url.Action("Index", "Welcome")">BACK</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("AddCourses", "Courses")">ADD COURSES</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("RemoveCourses", "Courses")">REMOVE COURSES</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("ViewCourses", "Courses")">VIEW COURSES</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("EditCourse", "Courses")">EDIT COURSE</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("AddSubjectstoCourses", "Courses")">ADD SUBJECTS</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("RemoveSubjects", "Courses")">REMOVE SUBJECTS</a>
                 </li>
           </ul>       
        Case "teachersstudents"
            @<ul id="TeacherTasks" Class="sf-menu sf-vertical clsmenu">
                <li Class="current">
                    <a href="@Url.Action("Index", "Welcome")">BACK</a>
                </li>
                 <li Class="current">
                     <a href="@Url.Action("CreateStudentAccount", "TeachersStudents")">CREATE STUDENT <br/>ACCOUNT</a>
                 </li>
                 <li>
                     <a href="@Url.Action("BulkCreateStudents", "TeachersStudents")">BULK-CREATE <br/>STUDENT ACCOUNTS</a>
                 </li>
                <li Class="current">
                    <a href="@Url.Action("AddStudentToClass", "TeachersStudents")">ADD STUDENTS</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("RemoveStudentFromClass", "TeachersStudents")">REMOVE STUDENTS</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("ViewStudents", "TeachersStudents")">VIEW STUDENTS</a>
                </li>
            </ul>   
        Case "tests"
            @<ul id="TeacherTasks" Class="sf-menu sf-vertical clsmenu">
                <li Class="current">
                    <a href="@Url.Action("Index", "Welcome")">BACK</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("CreateTest", "Tests")">CREATE TEST</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("RemoveTest", "Tests")">REMOVE TEST</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("EditTest", "Tests")">EDIT TEST</a>
                </li>
                 <li Class="current">
                     <a href="@Url.Action("GenerateTestNo", "Tests")">TEST CODE <br/>GENERATION</a>
                 </li>
                <li Class="current">
                    <a href="@Url.Action("AssignTest", "Tests")">TEST ASSIGNMENT</a>
                </li>
                 <li Class="current">
                     <a href="@Url.Action("ViewTests", "Tests")">VIEW TESTS</a>
                 </li>
            </ul>
        Case "teststypes"
            @<ul id="TeacherTasks" Class="sf-menu sf-vertical clsmenu">
                <li Class="current">
                    <a href="@Url.Action("Index", "Tests")">BACK</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("ViewTests", "Tests")">ALL TESTS</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("ViewCompletedUnScoredTests", "Tests")">UNSCORED TESTS</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("ViewIncompleteTests", "Tests")">INCOMPLETE TESTS</a>
                </li>
                 <li Class="current">
                     <a href="@Url.Action("ViewUnassignedTests", "Tests")">UNASSIGNED TESTS</a>
                 </li>
            </ul>
        Case Else
            @<ul id="TeacherTasks" Class="sf-menu sf-vertical clsmenu">
                <li Class="current">
                    <a href="@Url.Action("Index", "Welcome")">HOME</a>
                </li>
                <li Class="current">
                    <a href="@Url.Action("Index", "Courses")">COURSES</a>
                </li>
               <li>
                    <a href="@Url.Action("Index", "TeachersStudents")">STUDENTS</a>  
    </li>
                <li>
                    <a href="@Url.Action("Index", "QuestionBank")">QUESTION BANK</a>
                </li>
                <li>
                    <a href="@Url.Action("Index", "AssessmentBank")">ASSESSMENT BANK</a>
                </li>
                <li>
                    <a href="@Url.Action("EditProfile", "Teachers")">EDIT PROFILE</a>
                </li>
                <li>
                    <a href="@Url.Action("Index", "Tests")">TESTS</a>
                </li>
                <li>
                    <a href="@Url.Action("Logout", "Login")">LOG OUT</a>
                </li>
            </ul>
    End Select

ElseIf Session("LoginPageFor") = "ADMINISTRATORS" Then
    @if Session("menuarea") Is Nothing Then
        Session("menuarea") = String.Empty
    End If
    @Select Case Session("menuarea").ToString
        Case "adminclasses"
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                 <li Class="current">
                     <a href="@Url.Action("Index", "WelcomeAdmin")">BACK</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("AddClass", "AdminClasses")">CREATE NEW CLASS</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("RemoveClass", "AdminClasses")">ELIMINATE CLASS</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("EditClass", "AdminClasses")">EDIT CLASS INFO</a>
                 </li>
                 <li Class="current">
                     <a href="@Url.Action("ViewClasses", "AdminClasses")">VIEW ALL CLASSES</a>
                 </li>
            </ul>

        Case "adminsubjects"
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "WelcomeAdmin")">BACK</a>
                </li>
                 <li><a href="@Url.Action("AddSubject", "AdminSubjects")">CREATE A  SUBJECT</a></li>
                 <li>
                     <a href="@Url.Action("UploadSubjects", "AdminSubjects")">UPLOAD SUBJECTS</a>
                 </li>
                 <li Class="current"><a href="@Url.Action("RemoveSubject", "AdminSubjects")">ELIMINATE A SUBJECT</a></li>
                 <li Class="current"><a href="@Url.Action("EditSubject", "AdminSubjects")">EDIT SUBJECT INFO</a></li>
                 <li Class="current"><a href="@Url.Action("ViewSubjects", "AdminSubjects")">VIEW ALL SUBJECTS</a></li>
            </ul>

        Case "adminstudents"
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "WelcomeAdmin")">BACK</a>
                </li>
                 <li><a href="@Url.Action("ActivateSA", "Accounts")">ACTIVATE STUDENT ACCOUNT</a></li>
                 <li Class="current"><a href="@Url.Action("EditStudent", "AdminStudents")">EDIT STUDENT INFO</a></li>
                 <li Class="current"><a href="@Url.Action("RemoveStudent", "AdminStudents")">REMOVE STUDENT</a></li>
                 <li Class="current"><a href="@Url.Action("ViewStudents", "AdminStudents")">VIEW ALL STUDENTS</a></li>
            </ul>

        Case "adminteachers"
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "WelcomeAdmin")">BACK</a>
                </li>
                 <li>
                     <a href="@Url.Action("BulkCreateTeachers", "AdminTeachers")">UPLOAD TEACHER ACCOUNTS</a>
                 </li>
                 <li><a href="@Url.Action("ActivateTA", "Accounts")">ACTIVATE TEACHER ACCOUNT</a></li>
                 <li Class="current"><a href="@Url.Action("EditTeacher", "AdminTeachers")">EDIT TEACHER INFO</a></li>
                 <li Class="current"><a href="@Url.Action("RemoveTeacher", "AdminTeachers")">REMOVE TEACHER</a></li>
                 <li Class="current"><a href="@Url.Action("ViewTeachers", "AdminTeachers")">VIEW TEACHERS</a></li>
                 @*<li Class="current"><a href="@Url.Action("AssignToTeachers", "AdminClasses")">ASSIGN CLASSES</a></li>*@
            </ul>
        Case "adminschools"
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "WelcomeAdmin")">BACK</a>
                </li>
                <li>
                    <a href="@Url.Action("UploadSchools", "AdminSchools")">UPLOAD SCHOOL INFO</a>
                </li>
                <li><a href="@Url.Action("EditSchools_notimp", "AdminSchools")">EDIT SCHOOL INFO</a></li>
            </ul>
        Case "admincourses"
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "WelcomeAdmin")">BACK</a>
                </li>
                <li><a href="@Url.Action("EditCourse", "AdminCourses")">EDIT COURSE INFO</a></li>
                <li><a href="@Url.Action("EditSubject", "AdminCourses")">EDIT SUBJECT INFO</a></li>
                 <li><a href="@Url.Action("AssignCourse", "AdminCourses")">ASSIGN COURSES</a></li>
            </ul>
            @*Case "communitybank"
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "WelcomeAdmin")">BACK</a>
                </li>
                <li>
                    <a href="@Url.Action("UploadSchools", "AdminSchools")">UPLOAD SCHOOL INFO</a>
                </li>
                <li>
                    <a href="@Url.Action("UploadGradeLevels", "AdminSchools")">UPLOAD GRADE LEVELS</a>
                </li>
                <li><a href="@Url.Action("EditSchools", "AdminSchools")">EDIT SCHOOL INFO</a></li>
            </ul>*@
    Case Else
            @<ul id="AdminTasks" Class="sf-menu sf-vertical clsmenu" style="width:250px;">
                <li Class="current">
                    <a href="@Url.Action("Index", "WelcomeAdmin")">HOME</a>
                </li>
                 <li>
                     <a href="@Url.Action("Index", "AdminCourses")">COURSES</a></li>
                @*<li>
                    <a href="@Url.Action("Index", "AdminClasses")">CLASSES</a>
                </li>
                <li>
                    <a href="@Url.Action("Index", "AdminSubjects")">SUBJECTS</a>
                </li>*@
                <li>
                    <a href="@Url.Action("Index", "AdminStudents")">STUDENTS</a>
                </li>
                <li>
                    <a href="@Url.Action("Index", "AdminTeachers")">TEACHERS</a>
                </li>
                 <li>
                     <a href="@Url.Action("Index", "AdminSchools")">SCHOOLS</a>
                 </li>
                <li>
                    <a href="@Url.Action("Index_notimp", "CommunityBank")">COMMUNITY BANK</a>
                </li>
                <li>
                    <a href="@Url.Action("Logout", "Login")">LOG OUT</a>
                </li>
            </ul>
End Select

End If
