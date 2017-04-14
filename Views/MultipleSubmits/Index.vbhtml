@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

@ModelType StudentsAssessment.MultipleSubmits

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @For i = 1 To 3
        Select Case i
            Case 1
                @<div>
                    @Html.Display("Name:")
                    @Html.TextAreaFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "width:500px;height:100px;", .maxlength = "250"})
                </div>
            Case 2
                @<div>

                    @Html.Display("age:")
                    @Html.TextAreaFor(Function(model) model.Age, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "width:500px;height:100px;", .maxlength = "250"})
                </div>
            Case 3
            @<div>
                @Html.Display("Gender:")
                @Html.TextAreaFor(Function(model) model.Gender, New With {.htmlAttributes = New With {.class = "form-control"}, .style = "width:500px;height:100px;", .maxlength = "250"})
            </div>
        End Select
        @<input type="submit" value="@i" style="background:cadetblue;" name="button"/>
    Next
    @<input type="submit" value="submittest" name="button" style="background:cadetblue;" />

End Using
