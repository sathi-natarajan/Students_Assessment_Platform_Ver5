@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<script src="~/Scripts/jquery-ui-1.12.1.min.js"></script>
<script src="~/Content/jQueriUI/jquery-ui-1.12.1.min.js"></script>
<link href="~/Content/jQueriUI/themes/base/jquery-ui.min.css" rel="stylesheet" />

<script>
    $(function () {
        $("#Dialog1").button().on("click", function () {
            $( "#dialog-confirm" ).html("<p><span class=\"ui-icon ui-icon-alert\" style=\"float:left; margin:12px 12px 20px 0;\"></span>These items will be permanently deleted and cannot be recovered. Are you sure?</p>")
            $( "#dialog-confirm" ).dialog({
                resizable: false,
                title: "My own title here instead",
                height: "auto",
                width: 400,
                height: 500,
                modal: true,
                buttons: {
                    "OK": function () {
                        alert("You clicked OK");
                        $(this).dialog("close");
                    },
                    Cancel: function () {
                        alert("You clicked Cancel");
                        $(this).dialog("close");
                    }
                }
            });
        });

        $("#Dialog2").button().on("click", function () {
            $("#dialog-confirm").html("<p>This is another dialog on the page.  Note differen size etc</p>")
            $("#dialog-confirm").dialog({
                resizable: false,
                title: "My own title here instead",
                height: "auto",
                width: 200,
                height: 200,
                modal: true,
                buttons: {
                    "OK": function () {
                        alert("You clicked OK");
                        $(this).dialog("close");
                    },
                    Cancel: function () {
                        alert("You clicked Cancel");
                        $(this).dialog("close");
                    }
                }
            });
        });
  } );
</script>

    <div id="dialog-confirm" title="Empty the recycle bin?">
    </div>
<button id="Dialog1" class="ui-button ui-corner-all ui-widget">Display Alert 1</button><br/>
<button id="Dialog2">Display Alert 2</button>