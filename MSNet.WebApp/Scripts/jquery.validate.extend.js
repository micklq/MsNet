jQuery.validator.addMethod("mobile", function (value, element, param) {
    var tel = /^1\d{10}$/;
    return tel.test(value) || this.optional(element);
}, "手机号码格式不正确");

jQuery.validator.addMethod("tel", function (value, element, param) {
    var tel = /(^\d{3,4}(\-)?\d{7,8}$)|(^\d{3,4}(\-)?\d{7,8}(\-){1}\d{3,4}$)/;
    return tel.test(value) || this.optional(element);
}, "电话格式不正确");

jQuery.validator.addMethod("mobiletel", function (value, element, param) {
    var tel = /(^1\d{10}$)|(^\d{3,4}-\d{7,8}$)|(^\d{3,4}-\d{7,8}(\-){1}\d{3,4}$)/; 
    return tel.test(value) || this.optional(element);    
}, "手机/电话格式不正确");

jQuery.validator.addMethod("mintextlength", function (value, element, param) {
    var l = value.len();
    return this.optional(element) || l >= param;
}, "");
jQuery.validator.addMethod("maxtextlength", function (value, element, param) {
    var l = value.len();
    return this.optional(element) || l <= param;
}, "");
jQuery.validator.addMethod("rangetextlength", function (value, element, param) {
    var length = value.len();
    return this.optional(element) || (length >= param[0] && length <= param[1]);
}, "");
Array.prototype.exists = function (item) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == item)
            return true;
    }
    return false;
}

String.prototype.splitStr = function (chars) {
    var arr = [];
    if (this == null || this.length == 0)
        return arr;
    if (chars == null || chars.length == 0)
        return arr;
    var txt = "";
    for (var i = 0; i < this.length; i++) {
        var c = this.charAt(i); 
        if (chars.exists(c)) {
            if (txt.length > 0) {
                arr[arr.length] = txt;
                txt = "";
            }
            continue;
        }
        txt += c;
    }
    if (txt.length > 0)
        arr[arr.length] = txt;
    return arr;
}

jQuery.validator.addMethod("mintaglength", function (value, element, param) {
    var tags = value.splitStr([',', '，',' ','.','。','_',';','；']);
    for (var i = 0; i < tags.length; i++) {
        var l = tags[i].len();
        var r = this.optional(element) || l >= param;
        if (!r)
            return false;
    }
    return true;

}, "");

jQuery.validator.addMethod("maxtaglength", function (value, element, param) {
    var tags = value.splitStr([',', '，', ' ', '.', '。', '_', ';', '；']); 
    for (var i = 0; i < tags.length; i++) {
        var l = tags[i].len();
        var r = this.optional(element) || l <= param;
        if (!r)
            return false;
    }
    return true;
}, "");

jQuery.validator.addMethod("rangetaglength", function (value, element, param) {
    var tags = value.splitStr([',', '，', ' ', '.', '。', '_', ';', '；']);
    for (var i = 0; i < tags.length; i++) {
        var length = tags[i].len();
        var r = this.optional(element) || (length >= param[0] && length <= param[1]);
        if (!r)
            return false;
    }
    return true;
}, "");

jQuery.validator.unobtrusive.adapters.addBool("mobile");
jQuery.validator.unobtrusive.adapters.addBool("mobiletel");
jQuery.validator.unobtrusive.adapters.addBool("tel");

jQuery.validator.unobtrusive.adapters.addMinMax("textlength", "mintextlength", "maxtextlength", "rangetextlength");
jQuery.validator.unobtrusive.adapters.addMinMax("taglength", "mintaglength", "maxtaglength", "rangetaglength");

(function ($) {
    $.validator.addMethod("greaterTo", function (value, element, param) {
        // value:当前元素的值
        // element:当前元素
        // param:对比的对象元素
        //data-val-greater="大于xxx"
        //data-val-greater-to="selecter"

        var val = $(param).val();
        if (val == null)
            return false;
        return value > val;
    }, "");
    $.validator.unobtrusive.adapters.add("greater", ["to"], function (options) {
        var ruleName = "greaterTo";
        var element = $(options.form).find(options.params.to)[0];
        options.rules[ruleName] = element;
        if (options.message) {
            options.messages[ruleName] = options.message;
        }
    });

    $.validator.addMethod("lessTo", function (value, element, param) {
        // value:当前元素的值
        // element:当前元素
        // param:对比的对象元素
        //data-val-less="小于xxx"
        //data-val-less-to="selecter"

        var val = $(param).val();
        if (val == null)
            return false;
        return value < val;
    }, "");
    $.validator.unobtrusive.adapters.add("less", ["to"], function (options) {
        var ruleName = "lessTo";
        var element = $(options.form).find(options.params.to)[0];
        options.rules[ruleName] = element;
        if (options.message) {
            options.messages[ruleName] = options.message;
        }
    });
})(jQuery);