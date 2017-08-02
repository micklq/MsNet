$(function () {
    var t = 400;
    $("div.aIWMF").mouseout(function () {
        clearTimeout(t);
        t = setTimeout(function () { $("#aText").hide(); }, 400);

    }).mouseover(function () {
        if (t != null) clearTimeout(t);
        t = null;
        var w = $(this).width();
        var h = $(this).height();
        var o = $(this).offset();
        $("#artname").html($(this).find("img").attr("name"));
        $("#artauthor").html($(this).find("img").attr("author"));
        $("#artsize").html($(this).find("img").attr("size"));
        $("#artmaterial").html($(this).find("img").attr("material"));
        $("#artenname").html($(this).find("img").attr("enname"));
        $("#artenauthor").html($(this).find("img").attr("enauthor"));
        $("#artensize").html($(this).find("img").attr("size"));
        $("#artenmaterial").html($(this).find("img").attr("enmaterial"));
        $("#pictureUrl").html($(this).find("img").attr("src"));
        var aid = $(this).find("img").attr("artid");
        var alink = $(this).find("img").attr("artlink");
        $("#arthref").attr("href", "").attr("href",alink);
       

        $("#aTextC").css({ "margin-top": (h / 6) + "px" });
        $("#aText").css({ "width": w + "px", "height": h + "px", "top": o.top, "left": o.left }).show();
    });
    //$("#aText").click(function () {
    //    var w = parseInt($(this).width()) + 60;
    //    var h = parseInt($(this).height()) + 60;
    //    var top = ($(this).offset().top - 30);
    //    var left = ($(this).offset().left - 30);
    //    $("#dialogPicture").find("img").attr("src", $("#pictureUrl").html()).css({ "width": w + "px", "height": h + "px" });
    //    $("#dialogPicture").css({ "width": w + "px", "height": h + "px", "top": top, "left": left }).show();       
    //});
    $("#dialogPicture").mouseout(function () {
        $("#dialogPicture").hide();

    }).mouseover(function () {
        $("#dialogPicture").show();
    });
})
function BannerScrool()
{
    $("#Slide1").append($("#Slide1 img:first"));    
}
