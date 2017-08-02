var currid = 0;
function playnext() {
    if (currid == 4) {
        currid = 0;
    }
    else {
        currid++;
    };
    setfocus(currid);
    play();
}
function setfocus(id) {
    var oid = "#tmb" + id;
    $("#focusPic").attr("src", $(oid).attr("iu"));
    $("#focusLink").attr("href", $(oid).attr("ihref"));
    for (i = 0; i < 5; i++) {
        $("#tmb" + i).removeClass().addClass("thumb_off");
    };
    $(oid).removeClass().addClass("thumb_on");
    currid = id;
}
function play() { setTimeout(playnext, 3000); }
window.onload = function () { play(); }