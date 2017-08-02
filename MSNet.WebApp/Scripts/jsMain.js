$(function () {
    $(".ckAll").click(function () { ($(this).attr("checked")) ? ($(":checkbox").attr("checked", true)) : ($(":checkbox").attr("checked", false)) });
    $(".ckThis").click(function () { ($(this).attr("checked")) ? ($(this).attr("checked", true)) : ($(this).attr("checked", false)) });
    $(".add,[ids='edit'],[ids='subadd']").click(function () { location.href = $(this).attr("urls"); });
    $(".del").click(function () {
        var urls = $(this).attr("urls");
        var ids = "";
        $(".ckThis").each(function () { if ($(this).attr("checked")) { ids += $(this).val() + ","; } });
        if (ids == "") { alert("请选择所要删除的项！"); return; }
        $.get(urls + "?ids=" + ids, function (d) { if (!d.success) { alert(d.message); } location.href = location.href; });
    });
    $("[ids='sdel'],[ids='lock'],[ids='top'],[ids='audit']").click(function () {
        var urls = $(this).attr("urls");
        $.get(urls, function (d) { if (!d.success) { alert(d.message); } location.href = location.href; });
    });
    $("[ids='cdel']").click(function () {
        var existsub = $(this).attr("existsub");  
        var existcontent = $(this).attr("existcontent");
        if (existsub != "0") { alert("当前栏目下存在子栏目！\r\n请先删除其下对应的子栏目！"); return; }
        if (existcontent != "0") { alert("当前栏目下存在相关内容！\r\n请先删除其下内容!"); return; }
        var urls = $(this).attr("urls");
        $.get(urls, function (d) { if (!d.success) { alert(d.message); } location.href = location.href; });
    });
})