@Code
    ViewData("Title") = "Not Found"
End Code

<div class="row" style="padding-top:100px;">
    <div class="col-lg-12">
        <div id="divError" style="background-color: cadetblue; color: #000; height: 170px;">
            <div style="padding:20px;">
                <h3>
                    Application Error:
                </h3>
                <h4>
                    Sorry.  The section of Students Assessment Platform you are looking for is under construction
                </h4>
            </div>
        </div>
        <br />
        <br />
        <input type="button" value="BACK TO MAIN" class="btn btn-success clsbutton-round" onclick="location.href='@Url.Action("Index", "Home")'" />
    </div>
</div>