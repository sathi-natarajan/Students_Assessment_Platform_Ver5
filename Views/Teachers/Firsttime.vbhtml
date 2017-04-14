@Code
    ViewData("Title") = "Instructions for first time users"
End Code

<script src="~/Scripts/jquery-1.12.4.min.js"></script>

<link href="~/Content/Superfish/css/superfish.css" rel="stylesheet" media="screen" />
<link href="~/Content/Superfish/css/superfish-vertical.css" rel="stylesheet" media="screen" />
<script src="~/Content/Superfish/js/jquery.js"></script>
<script src="~/Content/Superfish/js/superfish.js"></script>
<script src="~/Content/Superfish/js/hoverIntent.js"></script>

<div class="row" style="padding:100px;">
    <div class="col-sm-9" style="width:700px;padding:100px;">
        @If ViewBag.Message IsNot Nothing Then
            @<div>
                 @ViewBag.Message
            </div>
            If Session("Purpose") IsNot Nothing AndAlso String.IsNullOrEmpty(Session("Purpose")) = False Then
                Dim strPurpose = Session("Purpose").ToString
                Select Case strPurpose
                        Case "Addclass"
                        @<table cellspacing="3">
                            <tr>
                                <td>
                                    @Html.ActionLink("Add a class", "AddClass", "Teachers", New With {.class = "btn btn-success clsbutton", .style = "background: cadetblue;"})
                                </td>
                                <td>
                                    @*@Html.ActionLink("Back", "Index", "Welcome", New With {.class = "btn btn-success", .style = "background: cadetblue;"})*@
                                   @* <input type="button" value="Back" class="btn btn-success" style="background: cadetblue;"*@
                                            @*onclick="@Url.Action("Index", "Welcome")" />*@
                                    <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />

                                </td>
                            </tr>
                        </table>
                    Case "SetCurrentIDs"
                        @<table cellspacing="3">
                            <tr>
                                <td>
                                    @Html.ActionLink("Go to your profile", "EditProfile", "Teachers", New With {.class = "btn btn-success", .style = "background: cadetblue;"})
                                </td>
                                <td>
                                    @*@Html.ActionLink("Back", "Index", "Welcome", New With {.class = "btn btn-success", .style = "background: cadetblue;"})*@
                                    <input type="button" id="Back" name="Back" value="Back" Class="btn btn-success clsbutton" style="background:cadetblue;" onclick="location.href='@Url.Action("Index", "Welcome")'" />
                                </td>
                            </tr>
                        </table>
                End Select
            End If
        End If
    </div>
    <div Class="col-sm-3">
        @*@Html.Partial("SideMenu")*@
    </div>
</div>