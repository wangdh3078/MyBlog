$(function () {
    $("#nav a").each(function () {
        $this = $(this);
        if ($this[0].href == String(window.location)) {
            $this.addClass("active").parents().siblings().children("a").removeClass("active");
        }
    });
    $("#btn_search").on("click", function () {
        console.log($("#searchKey").val())
    });
})