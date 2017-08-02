$(function () {
    
    $("div.banner1").css({ "height": parseInt((parseInt($("div.banner1").width()) * 11) / 32) + "px" });
    $("div.banner1 img").css({ "height": parseInt((parseInt($("div.banner1 img").width()) * 11) / 32) + "px" });
    $("#Slide div.SlideThumb img").css({ "height": parseInt((parseInt($("#Slide div.SlideThumb img").width()) * 11) / 32) + "px" });
    $("#Slide div.focPicture").css({ "height": parseInt((parseInt($("#Slide div.focPicture").width()) * 11) / 32) + "px" });
    $("#Slide div.focPicture img").css({ "height": parseInt((parseInt($("#Slide div.focPicture img").width()) * 11) / 32) + "px" });
    $("div.banner2").css({ "height": parseInt((parseInt($("div.banner2").width()) * 25) / 96) + "px" });
    $("div.banner2 img").css({ "height": parseInt((parseInt($("div.banner2 img").width()) * 25) / 96) + "px" });
    $("div.banner3").css({ "height": parseInt((parseInt($("div.banner3").width()) * 11) / 32) + "px" });
    $("div.banner4").css({ "height": parseInt((parseInt($("div.banner4").width()) * 101) / 160) + "px" });
    $("div.banner4 img").css({ "height": parseInt((parseInt($("div.banner4 img").width()) * 101) / 160) + "px" });

    $("div.Item2 img").css({ "height": parseInt((parseInt($("div.Item2 img").width()) * 6) / 13) + "px" });
    $("div.pMain div.page-left4,div.pMain div.page-right4").css({ "height": parseInt((parseInt($("div.page-left4 div.newIC0 div.newsI1 div.newIC1 img").width()) * 290) / 319) + "px" });
    $("div.page-left4 div.newIC0 div.newsI1 div.newIC1 img").css({ "height": parseInt((parseInt($("div.page-left4 div.newIC0 div.newsI1 div.newIC1 img").width()) * 290) / 319) + "px" });
    var nwHeight = parseInt((parseInt($("div.page-right4 div.newsI2 div.newIC2 img").width()) * 275) / 250);
    if (nwHeight <10) {
        nwHeight = 230;
    }
    $("div.page-right4 div.newsI2 div.newIC2 img").css({ "height": nwHeight + "px" });
    $("#iPanel div.mvImg,#iPanel div.mvImg a").css({ "height": parseInt((parseInt($("#iPanel div.mvImg").width()) * 106) / 159) + "px" });
    $("div.iDiv").css({ "height": parseInt((parseInt($("#iPanel div.mvImg").height()) * 3) + 8) + "px" });
    $("div.page div.mvImg img").css({ "height": parseInt((parseInt($("div.page div.mvImg img").width()) * 106) / 159) + "px" });
        
    $("div.apMain div.aIH272").filter(".aIW410").css({ "height": parseInt((parseInt($("div.apMain div.aIH272").filter(".aIW410").find("img").first().width()) * 272) / 410) + "px" });
    $("div.apMain div.aIH272").filter(".aIW365").css({ "height": parseInt((parseInt($("div.apMain div.aIH272").filter(".aIW365").find("img").first().width()) * 272) / 365) + "px" });

    $("div.apMain div.aIH320").filter(".aIW485").css({ "height": parseInt((parseInt($("div.apMain div.aIH320").filter(".aIW485").find("img").first().width()) * 320) / 485) + "px" });
    $("div.apMain div.aIH320").filter(".aIW215").css({ "height": parseInt((parseInt($("div.apMain div.aIH320").filter(".aIW215").find("img").first().width()) * 320) / 215) + "px" });

    $("div.apMain div.aIH340").filter(".aIW510").css({ "height": parseInt((parseInt($("div.apMain div.aIH340").filter(".aIW510").find("img").first().width()) * 340) / 510) + "px" });
    $("div.apMain div.aIH340").filter(".aIW230").css({ "height": parseInt((parseInt($("div.apMain div.aIH340").filter(".aIW230").find("img").first().width()) * 340) / 230) + "px" });
    $("div.apMain div.aIH340").filter(".aIW445").css({ "height": parseInt((parseInt($("div.apMain div.aIH340").filter(".aIW445").find("img").first().width()) * 340) / 445) + "px" });
   
   
})