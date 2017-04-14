<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>@ViewData("Title")</title>
    @*@Styles.Render("~/Content/css")*@
    <link href="~/Content/Site.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery-1.12.4.min.js"></script>
   
    <style type="text/css">
        body { 
            height: 1500px; 
        }
        #divFooter { 
            position: fixed; 
            bottom: 0; 
            height: 75px; 
            /*background: #000;*/ 
            width: 100%; 
            text-align: center; 
         }
        /*table tr td {border-right:2px solid cadetblue;}*/
         /*Non-sticky
        footer {
            position: relative;
            background-color: #bbd775;
            height: 2em;
            text-align: center;
            font-weight: bold;
            font-style: italic;
            margin-top: 100%;
            bottom: 0px;
            left: 0px;
            width: 100%;
        }*/
         /*Sticky
        footer {
            position: fixed;
            left: 0px;
            bottom: 0px;
            height: 5em;
            width: 100%;
            text-align: center;
            font-weight: bold;
            font-style: italic;*/
            /*Makes it transparent*/
            /*opacity: 0.5;*/
            /*filter: alpha(opacity=50);*/ /* For IE8 and earlier */
       /*}          */
            /*Color can be changed for the following in the site now:
            header, footer and buttons
        */
            #divHeaderJumbotron, #divFooterJumbotron, .btn {
                background-color: cadetblue !important;
            }

            /*For validation messages*/
            .field-validation-error {
                color: maroon;
                font-weight: bold;
            }

            /*Remove spinners from input boxes*/
            input[type=number]::-webkit-inner-spin-button,
            input[type=number]::-webkit-outer-spin-button {
                -webkit-appearance: none;
                margin: 0;
            }
    </style>
    <script>
        jQuery(document).ready(function () {
            $(function () {
                $('.focus :input').focus();
            })
        });
    </script>
</head>
<body style="margin:0;">
    <header>
        <div id="divHeaderJumbotron" class="jumbotron navbar navbar-default navbar-inverse navbar-fixed-top" style="background-color:cadetblue;height:100px;">
            <div style="margin-top:-2%;">
                <table id="" cellpadding="0" cellspacing="0">
                    <colgroup>
                        <col />
                        <col width="500" />
                        <col width="200" />
                    </colgroup>
                    <tr>
                        <td valign="top">
                            <img src="~/Content/images/logoEmpireEducation.png" />
                            @*<img src="~/Content/images/nav-handle.png" />*@
                        </td>
                        <td valign="top">&nbsp;</td>
                        <td valign="bottom">
                            @If Session("Welcome") IsNot Nothing Then
                            @<div style="font-size:12pt;">@Session("Welcome").ToString</div>
                            End If
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </header>

    <link href="~/Content/Student_Assessment_Themes/RGB_128_126_122.css" rel="stylesheet" />

    <div class="container body-content">
        @RenderBody()
    </div>
    <footer>
        <div id="divFooter" style="background-color:cadetblue;color:#ffffff;">
            @*<div style="margin-top:-2.75%;font-size:0.75em;line-height:1em;font-weight:bold;">*@
                &copy; @DateTime.Now.Year - Students Assessment Platform<br />
                All rights  reserved.  Application suitable for use in the field of education only<br />
                Web application version 5
            @*</div>*@
        </div>
    </footer>

    @*ToDo - The below causes jQuery to not work.  Will separatey figure out why*@
    @*@Scripts.Render("~/bundles/jquery")*@
    @*@Scripts.Render("~/bundles/bootstrap")*@
    @*@RenderSection("scripts", required:=False)*@
</body>
</html>
