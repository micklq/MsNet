$(function () {
    $("#homepic").css({ "width": "60%", "top": "30%", "left": "20%" });
    $("#btn1").css({ "top": "90%" });
    $("#homepic").click(function () {
        $("#home").addClass('pt-page-moveToTop');
        $(".page-1-1").addClass('pt-page-moveFromBottom page-current');
        $("#page1").removeClass('hide');
        $(".page-1-1").removeClass('hide');
        $(".btnnext2").addClass('hide');
        setTimeout(function () {
            $(".page-1-1").removeClass('pt-page-moveFromBottom');
            $("#home").addClass('hide');
            $(".btnnext2").removeClass('hide');
        }, 600);

    });
})