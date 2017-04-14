@Code
    ViewData("Title") = "Index"
    'TODO - jQuery is not working if I use a Layout page
    ' Layout = Nothing
End Code

@ModelType StudentsAssessment.LoginData

<script src="~/Scripts/jquery-1.12.4.min.js"></script>
@*<script src="~/Content/Watermark/jquery.watermark.min.js"></script>*@
<script src="~/Content/Watermark/js/jquery.watermark.min.js"></script>
<link href="~/Content/Watermark/css/style.css" rel="stylesheet" />
<script lang="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#Username").watermark({ watermarkText: "Username" });
        $("#Password").watermark({ watermarkText: "Password" });
        $("#Username").focus();
    });
   
</script>


<div class="row" style="text-align:center;padding-top:150px;">
    <h3 style="text-align:center;">@Session("LoginPageHeader")</h3>
    <p>Please type your @Session("LoginPageFor") credentials below:</p>
    <div class="col-sm-4"></div>
    <div class="col-sm-4">
        @Using (Html.BeginForm(FormMethod.Post))
            @Html.AntiForgeryToken()
            @<table id = "tblLogin" cellpadding="3" celspacing="3">
                    <tr>
                        <td>@Html.LabelFor(Function(model) model.Username, htmlAttributes:=New With {.class = "control-label col-md-2"})</td>
                        <td class="focus">@Html.TextBoxFor(Function(model) model.Username, New With {.autofocus = "autofocus"})</td>
                    </tr>
                    <tr>
                        <td colspan="2">@Html.ValidationMessageFor(Function(model) model.Username)</td>
                    </tr>
                    <tr>
                        <td>@Html.LabelFor(Function(model) model.Password)</td>
                        <td>@Html.PasswordFor(Function(model) model.Password)
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">@Html.ValidationMessageFor(Function(model) model.Password)</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="submit" value="LOGIN" class="btn btn-success clsbutton-round" />
                            <input type="button" value="BACK TO MAIN" class="btn btn-success clsbutton-round" onclick="location.href='@Url.Action("Index", "Home")'" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            @*@Html.Label(@ViewBag.StatusMessage, htmlAttributes:=New With {.class = "control-label col-md-2"})*@
                            @If String.IsNullOrEmpty(ViewBag.StatusMessage) = False Then
                                @<div class="field-validation-error">
                                    @ViewBag.StatusMessage
                                </div>
                            Else
                                @<div class="field-validation-error">
                                    @Html.Raw(ViewBag.StatusMessage)
                                </div>
                            End If
</td>
                    </tr>
                </table>
        End Using
    </div>
    <div class="col-sm-4"></div>
</div>

