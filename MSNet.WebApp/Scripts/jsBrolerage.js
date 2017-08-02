function JsScroll(o) {
    var idx = parseInt($(o).attr("idx"));
    while (idx != 3) {
        if (idx > 3) {
            var one = $("#pictureDiv").find("[idx=1]"); var two = $("#pictureDiv").find("[idx=2]");
            var three = $("#pictureDiv").find("[idx=3]"); var four = $("#pictureDiv").find("[idx=4]");
            var five = $("#pictureDiv").find("[idx=5]");
            one.attr("idx", 5).css({ "z-index": -3 }).animate({ left: '730px', top: '60px' }, 500).css({ "z-index": 1 });
            two.attr("idx", 1).css({ "z-index": 1 }).animate({ left: '0px', top: '60px' }, 500).find("img").animate({ width: '-=40px' }, 500);
            three.attr("idx", 2).css({ "z-index": 2 }).animate({ left: '135px', top: '30px' }, 500).find("img").animate({ width: '-=40px' }, 500);
            four.attr("idx", 3).css({ "z-index": 3 }).animate({ left: '325px', top: '0px' }, 500).find("img").animate({ width: '+=40px' }, 500);
            five.attr("idx", 4).css({ "z-index": 2 }).animate({ left: '550px', top: '30px' }, 500).find("img").animate({ width: '+=40px' }, 500);
            idx--
        }
        else {
            var one = $("#pictureDiv").find("[idx=1]"); var two = $("#pictureDiv").find("[idx=2]");
            var three = $("#pictureDiv").find("[idx=3]"); var four = $("#pictureDiv").find("[idx=4]");
            var five = $("#pictureDiv").find("[idx=5]");
            five.attr("idx", 1).css({ "z-index": -3 }).animate({ left: '0px', top: '60px' }, 500).css({ "z-index": 1 });
            four.attr("idx", 5).css({ "z-index": 1 }).animate({ left: '730px', top: '60px' }, 500).find("img").animate({ width: '-=40px' }, 500);
            three.attr("idx", 4).css({ "z-index": 2 }).animate({ left: '550px', top: '30px' }, 500).find("img").animate({ width: '-=40px' }, 500);
            two.attr("idx", 3).css({ "z-index": 3 }).animate({ left: '325px', top: '0px' }, 500).find("img").animate({ width: '+=40px' }, 500);
            one.attr("idx", 2).css({ "z-index": 2 }).animate({ left: '135px', top: '30px' }, 500).find("img").animate({ width: '+=40px' }, 500);
            idx++;
        }

    }
}
$(function () {
    var t = 400;
    $("#pictureDiv li").click(function () { JsScroll(this); });
    $("#pictureDiv li").mouseout(function () {
        if ($(this).attr("idx") == 3) {            
            $("#pictureDiv [idx=3]").find("div").hide();
        }
        

    }).mouseover(function () {
        if ($(this).attr("idx") == 3) {                
            $("#pictureDiv [idx=3]").find("div").show();
        }
    });

});
