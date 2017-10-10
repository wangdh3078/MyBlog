$(function () {
    $("#nav a").each(function () {
        $this = $(this);
        if ($this[0].href == String(window.location)) {
            $this.addClass("active").parents().siblings().children("a").removeClass("active");
        }
    });
    $("#search_Key").keydown(function (event) {
        debugger;
        if (event.keyCode == 13) {
            window.location.href = "/Search/Index?key=" + $.trim($("#search_Key").val());
        }
    })  
    $("#btn_search").on("click", function () {
        window.location.href = "/Search/Index?key=" + $.trim($("#search_Key").val());
    });
})