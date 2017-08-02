/*huang.qc 2009-09-15 extend methods、jquery and jquery.fn*/

//extend String
jQuery.extend(String.prototype, {
    trim: function() { return $.trim(this); },
    ltrim: function() { return this.replace(/(^\s*)/g, ""); },
    rtrim: function() { return this.replace(/(\s*$)/g, ""); },
    clearHTML: function() { return this.replace(/<[^>]*>/g, ""); },
    lower: function() { return this.toLowerCase(); },
    upper: function() { return this.toUpperCase(); },
    isChn: function() { return (/^([\u4e00-\u9fa5\uf900-\ufa2d])*$/.test(this)); },
    hasChn: function() { return (/[\u4e00-\u9fa5\uf900-\ufa2d]/.test(this)); },
    len: function () { return this.replace(/([^\x00-\xff])/g, "**").length; },
    Sub: function (len, dot) { var txt = this.sub(len, 0); if (typeof dot != 'undefined' && dot && this.len() > len) txt += '...'; return txt; },
    sub: function(len, start, end) {
        if (len == null) return this;
        if (start == null) start = 0;
        if (end == null || (end + 1) > this.length) end = this.length;
        var a = 0, i = 0, temp = "";
        for (i = start; i < end; i++) { a += this.charCodeAt(i) > 255 ? 2 : 1; if (a > len) return temp; temp += this.charAt(i); }
        return temp;
    },
    dbc2sbc: function() {
        var result = '', code = '';
        for (var i = 0; i < this.length; i++) {
            code = this.charCodeAt(i);
            if (code >= 65281 && code <= 65373)
                result += String.fromCharCode(this.charCodeAt(i) - 65248);
            else if (code == 12288)
                result += String.fromCharCode(this.charCodeAt(i) - 12288 + 32);
            else
                result += this.charAt(i);
        }
        return result;
    },
    format: function() { var args = arguments; return this.replace(/\{(\d+)\}/g, function(m, i) { return args[i]; }); },
    startWith: function(str) { if (str == null || str == "" || this.length == 0 || str.length > this.length) return false; return (this.substr(0, str.length) == str); },
    endWith: function(str) { if (str == null || str == "" || this.length == 0 || str.length > this.length) return false; return (this.substring(this.length - str.length) == str); },
    isN: function() { if (this == null || this == "") return false; return (/^(\-|\+)?(\d+)*$/.test(this)); },
    isNN: function() { if (this == null || this == "") return false; return (/^(((\+)?[1-9]+(\d*))|(([1-9])+(\d*)))$/.test(this)); },
    is_NN: function() { if (this == null || this == "") return false; return (/^(\-){1}(\d+)*$/.test(this)); },
    isUserName: function() { if (this == null) return false; return (/^[A-Za-z_]{1}[A-Za-z0-9_]{5,17}$/.test(this)); },
    isEmail: function () {
        if (this == null || this.length == 0)
            return false;
        return /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i.test(this)
    },
    isMobile: function() { if (this == null) return false; return (/^1[0-9]{10}$/.test(this)); },
    isTel: function() { if (this == null) return false; return (/^(\d{3,4})-(\d{7,8})/.test(this)); },
    isIDCard: function() { return (/^(\d{18}|\d{15}|\d{14}[A-Za-z]{1})$/.test(this)); },
    toInt: function(def) { if (def == null) def = 0; if (this == null || this.length == 0) return def; var reg = /^[-+]?\d+(\.\d+)?$/g; var result = reg.test(this); if (result) return parseInt(this); else return def; },
    toDate: function() {
        var DateStr = this; if (!DateStr.isDateTime() && !DateStr.isDate()) return null;
        var converted = Date.parse(DateStr); var myDate = new Date(converted);
        if (isNaN(myDate)) {
            if (DateStr.isDate()) { /*2008-01-01*/var arys = DateStr.split('-'); myDate = new Date(arys[0], --arys[1], arys[2]); }
            else { /*2008-01-01 00:00:00*/var partArray = DateStr.split(" "); var darray = partArray[0].split("-"); var tarray = partArray[1].split(":"); myDate = new Date(darray[0], --darray[1], darray[2], tarray[0], tarray[1], tarray[2]); }
        }
        return myDate;
    },
    getArray: function(spliter) { var a = []; if (spliter == null || spliter == "") for (var i = 0; i < this.length; i++) a.insert(this.charAt(i), i); else a = this.split(spliter); return a; },
    isDateTime: function() { return (/^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[0-9])|([1][0-9])|([2][0-4]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$/.test(this)); },
    isDate: function() { return (/^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))$/.test(this)); },
    isTime: function() { return (/^(\s(((0?[0-9])|([1][0-9])|([2][0-4]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$/.test(this)); },
    times: function(n) { var result = ''; for (var i = 0; i < n; i++) result += this; return result; },
    padl: function(c, len) { if (this.length >= len) return this; var n = len - this.length; return c.toString().times(n) + this; },
    padr: function(c, len) { if (this.length >= len) return this; var n = len - this.length; return this + c.toString().times(n); },
    camelize: function() { var parts = this.getArray('-'), len = parts.length; if (len == 1) return parts[0]; var camelized = this.charAt(0) == '-' ? parts[0].charAt(0).upper() + parts[0].substring(1) : parts[0]; for (var i = 1; i < len; i++) camelized += parts[i].charAt(0).upper() + parts[i].substring(1); return camelized; },
    capitalize: function() { return this.charAt(0).upper() + this.substring(1).lower(); }
})
//extend Date
jQuery.extend(Date.prototype, {
    date: function(f) { if (f == null) f = "yyyy-MM-dd"; return this.format(f); },
    time: function(f) { if (f == null) f = "yyyy-MM-dd"; return this.format(f); },
    isLeapYear: function() { return (0 == this.getYear() % 4 && ((this.getYear() % 100 != 0) || (this.getYear() % 400 == 0))); },
    format: function(formatStr) {//date format,eg：(new Date()).format("yyyy-MM-dd HH:mm:ss")
        var str = formatStr;
        var Week = ['日', '一', '二', '三', '四', '五', '六'];
        str = str.replace(/yyyy|YYYY/, this.getFullYear());
        str = str.replace(/yy|YY/, (this.getYear() % 100) > 9 ? (this.getYear() % 100).toString() : '0' + (this.getYear() % 100));

        str = str.replace(/MM/, (this.getMonth() + 1) > 9 ? (this.getMonth() + 1).toString() : '0' + (this.getMonth() + 1));
        str = str.replace(/M/g, (this.getMonth() + 1));

        str = str.replace(/w|W/g, Week[this.getDay()]);

        str = str.replace(/dd|DD/, this.getDate() > 9 ? this.getDate().toString() : '0' + this.getDate());
        str = str.replace(/d|D/g, this.getDate());

        str = str.replace(/hh|HH/, this.getHours() > 9 ? this.getHours().toString() : '0' + this.getHours());
        str = str.replace(/h|H/g, this.getHours());
        str = str.replace(/mm/, this.getMinutes() > 9 ? this.getMinutes().toString() : '0' + this.getMinutes());
        str = str.replace(/m/g, this.getMinutes());

        str = str.replace(/ss|SS/, this.getSeconds() > 9 ? this.getSeconds().toString() : '0' + this.getSeconds());
        str = str.replace(/s|S/g, this.getSeconds());

        return str;
    },
    daysDiff: function(targetDate) {
        var thisDate = this.format("yyyy-MM-dd");
        var thisMonth = thisDate.substring(5, thisDate.lastIndexOf('-'));
        var thisDay = thisDate.substring(thisDate.length, thisDate.lastIndexOf('-') + 1);
        var thisYear = thisDate.substring(0, thisDate.indexOf('-'));

        if (typeof targetDate != 'string')
            targetDate = targetDate.format("yyyy-MM-dd");

        var targetMonth = targetDate.substring(5, targetDate.lastIndexOf('-'));
        var targetDay = targetDate.substring(targetDate.length, targetDate.lastIndexOf('-') + 1);
        var targetYear = targetDate.substring(0, targetDate.indexOf('-'));

        var cha = ((Date.parse(thisMonth + '/' + thisDay + '/' + thisYear) - Date.parse(targetMonth + '/' + targetDay + '/' + targetYear)) / 86400000);
        return Math.abs(cha);
    },
    dateDiff: function(datePart, dtEnd) {
        var dtStart = this;
        if (typeof dtEnd == 'string') dtEnd = dtEnd.toDate();

        switch (datePart.lower()) {
            case 's':
            case 'second': return parseInt((dtEnd - dtStart) / 1000);
            case 'n':
            case 'minute': return parseInt((dtEnd - dtStart) / 60000);
            case 'h':
            case "hour": return parseInt((dtEnd - dtStart) / 3600000);
            case 'd':
            case 'day': return parseInt((dtEnd - dtStart) / 86400000);
            case 'w':
            case 'week': return parseInt((dtEnd - dtStart) / (86400000 * 7));
            case 'm':
            case 'month': return (dtEnd.getMonth() + 1) + ((dtEnd.getFullYear() - dtStart.getFullYear()) * 12) - (dtStart.getMonth() + 1);
            case 'y':
            case 'year': return dtEnd.getFullYear() - dtStart.getFullYear();
        }
    },
    dateAdd: function(datePart, Number) {
        var dtTmp = this;
        var date;
        switch (datePart) {
            case 's':
            case 'second': date = new Date(Date.parse(dtTmp) + (1000 * Number)); break;
            case 'm':
            case 'mi':
            case 'minute': date = new Date(Date.parse(dtTmp) + (60000 * Number)); break;
            case 'h':
            case 'H': date = new Date(Date.parse(dtTmp) + (3600000 * Number)); break;
            case 'd':
            case 'day': date = new Date(Date.parse(dtTmp) + (86400000 * Number)); break;
            case 'w':
            case 'week': date = new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number)); break;
            case 'M':
            case 'mon':
            case 'month': date = new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds()); break;
            case 'y':
            case 'year': date = new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds()); break;
        }
        return date.format("yyyy-MM-dd HH:mm:ss");
    },
    dayOfWeek: function() { return this.getDay() + 1; },
    dayOfWeekCn: function() { return ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"][this.getDay() + 1]; },
    dayOfWeekEn: function() { return ["SUNDAY", "MONDAY", "TURESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY"][this.getDay() + 1]; }
});

jQuery.kong = function(index, value) { return value; }
var enumFn = {
    each: function (func, args) { jQuery.each(this, func, args); },
    where: function (func) {
        var arr = [];
        for (var i = 0; i < this.length; i++) {
            if (func(i, this[i]))
                arr.push(this[i]);
        }
        return arr;
    },
    first: function (func) {
        if (func == null)
            return (this.length == 0) ? null : this[0];
        var items = this.where(func); return (items.length == 0) ? null : items[0];
    },
    last: function (func) {
        if (func == null)
            return (this.length == 0) ? null : this[items.length - 1];
        var items = this.where(func); return items.length == 0 ? null : items[items.length - 1];
    },
    max: function (func) {
        var result; this.each(function (index, value) { if (typeof value == 'object' && func == null) throw {}; value = (func || jQuery.kong)(index, value); if (result == undefined || value >= result) result = value; }); return result;
    },
    min: function (func) {
        var result; this.each(function (index, value) { value = (func || jQuery.kong)(index, value); if (result == undefined || value < result) result = value; }); return result;
    },
    exist: function (item, att) {
        if (typeof item == 'string') item = item.lower(); for (var i = 0; i < this.length; i++) { if (typeof item == 'string' && this[i].lower() == item) return true; else if (att != null) { var a1 = eval("this[i]." + att), a2 = eval("item." + att); if (a1.lower() == a2.lower()) return true; } else if (this[i] == item) return true; } return false;
    },
    add: function () {
        if (arguments == null || arguments.length == 0) return; for (var i = 0; i < arguments.length; i++) { this[this.length] = arguments[i]; }
    },
    remove: function () {
        if (arguments == null || arguments.length == 0) return; var items = []; for (var i = 0; i < arguments.length; i++) { items[items.length] = arguments[i]; } var arr = []; for (var i = 0; i < this.length; i++) { var exist = items.exist(this[i]); if (!exist) arr.add(this[i]); } return arr;
    },
    select: function (att) {
        var _list = []; this.each(function (index, item) { var v = item.getAttribute(att); _list.add(v); }); return _list;
    },
    distinct: function () {
        var _list = []; this.each(function (index, item) { if (!_list.exist(item)) _list.add(item); }); return _list;
    }
}

jQuery.extend(Array.prototype, enumFn);

var jqueryExt = {
    ie: navigator.userAgent.lower().indexOf('msie') > -1,
    ie6: navigator.userAgent.lower().indexOf('msie 7') > -1 ? false : navigator.userAgent.lower().indexOf('msie 6') > -1,
    ie7: navigator.userAgent.lower().indexOf('msie 7') > -1,
    ie8: navigator.userAgent.lower().indexOf('msie 8') > -1,
    maxthon: navigator.userAgent.lower().indexOf('maxthon') > -1,
    firefox: navigator.userAgent.lower().indexOf('firefox') > -1,
    google: navigator.userAgent.lower().indexOf('chrome') > -1,
    opera: !!window.opera,
    webKit: navigator.userAgent.indexOf('AppleWebKit/') > -1,
    gecko: navigator.userAgent.indexOf('Gecko') > -1 && navigator.userAgent.indexOf('KHTML') == -1,
    avail: function () {
        var winWidth = 0, winHeight = 0;
        if (window.innerWidth) { winWidth = window.innerWidth; winHeight = window.innerHeight; }
        else ((document.body) && (document.body.clientWidth))
        { winWidth = document.body.clientWidth; winHeight = document.body.clientHeight; }

        if (document.documentElement && document.documentElement.clientWidth) { winWidth = document.documentElement.clientWidth; winHeight = document.documentElement.clientHeight; }

        return { width: winWidth, height: winHeight };
    },
    docAvail: function () { return { width: document.body.scrollWidth, height: document.body.scrollHeight }; },
    center: function (obj) { var avail = jqueryExt.avail(); var loc = {}; if (typeof obj == 'undefined' || obj == null) { loc.left = avail.width / 2; loc.top = avail.height / 2; } else if (typeof obj == 'object') { loc.left = (avail.width - el.offsetWidth) / 2; loc.top = (avail.height - el.offsetHeight) / 2; } else if (typeof obj == 'string') { obj = fn.idObj(obj); if (obj == null) { loc.left = avail.width / 2; loc.top = avail.height / 2; } else { loc.left = (avail.width - el.offsetWidth) / 2; loc.top = (avail.height - el.offsetHeight) / 2; } } return loc; },

    url: document.location,
    host: document.location.hostname,
    port: document.location.port,
    path: document.location.pathname,
    root: document.location.protocol + "//" + document.location.hostname + (document.location.port == "80" ? "" : ":" + document.location.port) + "/",
    qstr: document.location.search,
    page: function () {
        var index = this.path.lastIndexOf("/");
        if (index < 0)
            return this.path;
        return this.path.substr(index + 1);
    },
    ext: function () {
        var p = this.page();
        if (p == "")
            return "";
        var index = p.lastIndexOf(".");
        if (index < 0)
            return "";
        return p.substr(index + 1);
    },
    q: function (key, v) { if (v == null) { key = key.lower(); var queryStr = this.qstr; if (queryStr.length > 0) queryStr = queryStr.substr(1); var kvs = queryStr.split("&"); var itemArray; for (var i = 0; i < kvs.length; i++) { itemArray = kvs[i].split("="); if (itemArray[0].lower() == key && itemArray.length == 2) return itemArray[1]; return ""; } return ""; } else { key = key.lower(); var queryStr = this.qstr; if (queryStr.length > 0) queryStr = queryStr.substr(1); var kvs = queryStr.split("&"), itemArray, newQ = "?", find = false; kvs.each(function (idx, kv) { newQ += idx == 0 ? "" : "&"; itemArray = kv.split("="); if (itemArray[0].lower() == key) { find = true; newQ += "{0}={1}".format(key, v); } else newQ += kv; }); if (!find) newQ += "{0}{1}={2}".format(newQ == "?" ? "" : "&", key, v); return this.pageNoQ() + newQ; } },
    req: function (url, success, err) {
        jQuery.ajax({
            url: url,
            success:success,
            error:err
        });
    }
}


jQuery.extend(jqueryExt);


var jqueryFnExt = {
    wh: function () {
        var w = this.width();
        var h = this.height();
        return { width: w, height: h };
    },
    offsetPos: function () { var iPos_x = 0, iPos_y = 0, el = this[0]; while (el != null) { iPos_x += el["offsetLeft"]; iPos_y += el["offsetTop"]; el = el.offsetParent; } return { left: iPos_x, top: iPos_y }; },
    bottom: function () { return this[0].offsetPos().top + this[0].offsetHeight; },
    right: function () { return this[0].offsetPos().left + this[0].offsetWidth; },
    isHide: function () { return this.css("display").lower() == "none" || this.css("visibility").lower() == "hidden"; }
}
jQuery.fn.extend(jqueryFnExt);

if (jQuery.firefox)
{
    HTMLElement.prototype.__defineGetter__("outerHTML", function() {
        var a = this.attributes, str = "<" + this.tagName, i = 0; for (; i < a.length; i++)
            if (a[i].specified)
            str += " " + a[i].name + '="' + a[i].value + '"';
        if (!this.canHaveChildren)
            return str + " />";
        return str + ">" + this.innerHTML + "</" + this.tagName + ">";
    });
    HTMLElement.prototype.__defineSetter__("outerHTML", function(s) {
        var r = this.ownerDocument.createRange();
        r.setStartBefore(this);
        var df = r.createContextualFragment(s);
        this.parentNode.replaceChild(df, this);
        return s;
    });
    HTMLElement.prototype.__defineGetter__("canHaveChildren", function() {
        return !/^(area|base|basefont|col|frame|hr|img|br|input|isindex|link|meta|param)$/.test(this.tagName.toLowerCase());
    });

    XMLDocument.prototype.selectSingleNode = Element.prototype.selectSingleNode = function(xpath) {
        var x = this.selectNodes(xpath)
        if (!x || x.length < 1)
            return null;
        return x[0];
    }
    XMLDocument.prototype.selectNodes = Element.prototype.selectNodes = function(xpath) {
        var xpe = new XPathEvaluator();
        var nsResolver = xpe.createNSResolver(this.ownerDocument == null ? this.documentElement : this.ownerDocument.documentElement);
        var result = xpe.evaluate(xpath, this, nsResolver, 0, null);
        var found = [];
        var res;
        while (res = result.iterateNext())
            found.push(res);
        return found;
    }
}

jQuery.close = function () {
    var ua = navigator.userAgent
    var ie = navigator.appName == "Microsoft Internet Explorer" ? true : false;

    if (ie) {
        var IEversion = parseFloat(ua.substring(ua.indexOf("MSIE ") + 5, ua.indexOf(";", ua.indexOf("MSIE "))))
        if (IEversion < 5.5) {
            var str = '<object id=noTipClose classid="clsid:ADB880A6-D8FF-11CF-9377-00AA003B7A11">'
            str += '<param name="Command" value="Close"></object>';
            document.body.insertAdjacentHTML("beforeEnd", str);
            document.all.noTipClose.Click();
        }
        else {
            window.opener = null;
            window.open('', '_self', ''); //for IE7
            window.close();
        }
    }
    else {
        window.close()
    }
}
jQuery.nodes = function (xdoc, xpath) {
    var a = [];
    if (xdoc == null)
        return a;
    if (xdoc.documentElement == null)
        return a;
    a = xdoc.documentElement.selectNodes(xpath);

    return jQuery.array(a);
}
jQuery.stopEvent = function (e) {
    if (e == null)
        e = event;
    if (e.stopPropagation)
        e.stopPropagation();
    else
        e.cancelBubble = true;
}
jQuery.mouseXY = function (ev) {
    if (ev.pageX || ev.pageY)
        return { x: ev.pageX, y: ev.pageY };
    return {
        x: ev.clientX + document.body.scrollLeft - document.body.clientLeft,
        y: ev.clientY + document.body.scrollTop - document.body.clientTop
    };
}
var List = function () {
    this.Items = [];

    this.Add = function (item) {
        this.Items.push(item);
    }
    this.Remove = function (item) {
        for (var i = this.Items.length - 1; i >= 0; i--) {
            if (this.Items[i] == item) {
                this.Items.splice(i, 1);
            }
        }
    }
    this.Contains = function (item) {
        var find = false;
        for (var i = 0; i < this.Items.length; i++) {
            if (this.Items[i] == k) {
                find = true;
                break;
            }
        }
        return find;
    }
    this.Contact = function (items) {
        for (var i = 0; i < items.length; i++) {
            this.Add(items[i]);
        }
    }
}
var Dictionary = function () {
    this.Keys = [];
    this.Values = [];
    this.Add = function (k, v) {
        var find = false;
        for (var i = 0; i < this.Keys.length; i++) {
            if (this.Keys[i] == k) {
                this.Values[i] = v;
                find = true;
                break;
            }
        }
        if (!find) {
            this.Keys.push(k);
            this.Values.push(v);
        }
    }
    this.Remove = function (k) {
        for (var i = 0; i < this.Keys.length; i++) {
            if (this.Keys[i] == k) {
                this.Keys.splice(i, 1);
                this.Values.splice(i, 1);
                break;
            }
        }
    }
    this.ContainsKey = function (key) {
        var find = false;
        for (var i = 0; i < this.Keys.length; i++) {
            if (this.Keys[i] == key) {
                find = true;
                break;
            }
        }
        return find;
    }
}
$.htmlEncode = function(input) {
//    var converter = document.createElement("DIV");
//    converter.innerText = input;
//    var output = converter.innerHTML;
    //    converter = null;
    var output = input.replace(/&/g, '&amp').replace(/\"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;')
    return output;
}
$.htmlDecode = function(input){
//    var converter = document.createElement("DIV");
//    converter.innerHTML = input;
//    var output = converter.innerText;
    //    converter = null;
    var output = input.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>'); 
    return output;
}

jQuery.extend(String.prototype, {
    clearHtml: function () {
        var str = this;
        str = str.replace(/<[^>]*>/g, "");
        str = str.replace(/\/r\/n/g, "<br />");
        return str;
    },
    toJsonObj: function () {
        var str = this;    
        var d = { success: false, message: '未知错误' };
        if (str == null || str.length == 0) {
            d.message = "返回内容为空";
            return d;
        }
        str = str.replace("<pre>{", "{").replace("}</pre>", "}");
        if (!str.trim().startWith('{')) {
            d.message = "无法识别返回的内容，服务器出现异常";
            return d;
        }
        try {
            d = eval('(' + str + ')');
        } catch (ex) {
            d = { success: false, message: '无法解析返回的数据，' + ex.message }
        }
        if (typeof d.success != 'undefined' && d.success == false && typeof d.login_timeout != 'undefined' && d.login_timeout == true) {
            setTimeout(function () {
                top.location.href = top.location.href.toString();
            }, 5000);
        }
        return d;
    },
    htmlEncode: function () {
        if (this == null || this.length == 0)
            return this;
        var html = $.htmlEncode(this);
        return html;
    },
    htmlDecode: function () {
        if (this == null || this.length == 0)
            return this;
        var html = $.htmlDecode(this);
        //html = $.htmlDecode(html);
        return html;
    }
});

