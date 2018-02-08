/*
* =============================================
* Author:		<Author, 姜方君>
* Create date:  <Create Date,2015年4月13日>
* Description:	<Description,,>
* =============================================
*/

//页面加载执行
$(document).ready(function () {

    //页面第一次加载执行方法
    if (typeof (onPageLoad) != "undefined") {
        if (onPageLoad() == false) {
            return false;
        }
    }

    //设置权限
    //SetUserRight();
    //设置字段权限
   // SetFieldRight();

    //监听List页面查询回车事件
    //    $("#search").keyup(function (event) {
    //        if (event.keyCode == 13) {
    //            $("#btnsearch").click();
    //        }
    //    });
});


//获取Url传递参数值
function Request(strName) {
    var strHref = window.document.location.href;
    var intPos = strHref.indexOf("?");
    var strRight = strHref.substr(intPos + 1);
    var arrTmp = strRight.split("&");
    for (var i = 0; i < arrTmp.length; i++) {
        var arrTemp = arrTmp[i].split("=");
        if (arrTemp[0].toUpperCase() == strName.toUpperCase()) return arrTemp[1];
    }
    return "";
}

//异步调用后台方法
function getAjax() {
    var src = location.href;
    var reg = /\/(\w{1,}).aspx/;
    if (reg.test(src)) {
        return eval(RegExp.$1);
    }
    return null;
}

//文本替换
function MyReplace(source, oldC, newC) {
    try {
        var reg = new RegExp(oldC, "g"); //创建正则RegExp对象   
        var newstr = source.replace(reg, newC);
        return newstr;
    } catch (e) { return source; }
}


//时间格式转换
function StringToDate(str) {
    var sDate = MyReplace(MyReplace(str, "T", " "), "-", "/");
    var i = sDate.indexOf(".");
    if (i >= 0) {
        sDate = sDate.substring(0, i);
    }
    var objDate = new Date(Date.parse(sDate));
    return objDate;
}

//创建GUID
function createGUID() {
    var str = new Date().format(3);
    return str;
}

//删除左右两端的空格  
function trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

//删除左边的空格 
function ltrim(str) {
    return str.replace(/(^\s*)/g, "");
}

//删除右边的空格  
function rtrim(str) {
    return str.replace(/(\s*$)/g, "");
}

//****************JSON操作 Begin *********************

//JSON字符串转JSON对象
function parseObjJson(strData) {
    return (new Function("return " + strData))();
}

//JSON对象转JSON字符串
function parseStrJson(obj) {
    return JSON.stringify(obj);
}

//****************JSON操作 Begin *********************


//获得Cookie的原始值
function GetCookie(name) {
    var arg = name + "=";
    var alen = arg.length;
    var clen = document.cookie.length;
    var i = 0;
    while (i < clen) {
        var j = i + alen;
        if (document.cookie.substring(i, j) == arg) {
            var endstr = document.cookie.indexOf(";", j);
            if (endstr == -1)
                endstr = document.cookie.length;
            return unescape(document.cookie.substring(j, endstr));
        }
        i = document.cookie.indexOf(" ", i) + 1;
        if (i == 0) break;
    }
    return null;
}


//设定Cookie值
function SetCookie(name, value) {
    var expdate = new Date();
    var argv = SetCookie.arguments;
    var argc = SetCookie.arguments.length;
    var expires = (argc > 2) ? argv[2] : null;
    var path = (argc > 3) ? argv[3] : null;
    var domain = (argc > 4) ? argv[4] : null;
    var secure = (argc > 5) ? argv[5] : false;
    if (expires != null) expdate.setTime(expdate.getTime() + (expires * 1000));
    document.cookie = name + "=" + escape(value) + ((expires == null) ? "" : ("; expires=" + expdate.toGMTString()))
+ ((path == null) ? "" : ("; path=" + path)) + ((domain == null) ? "" : ("; domain=" + domain))
+ ((secure == true) ? "; secure" : "");
}


//判断是否全部为空   
function isEmpty(expression) {
    var arry;
    if (typeof (expression) == "undefined") {
        arry = $(".isEmpty");
    } else {
        arry = $(expression);
    }
    for (i = 0; i < arry.length; i++) {
        var cur = $(arry[i]);
        if (cur.val() == "") {
            return false;
        }
    }
    return true;
}

//判断是否全是整数   
function isNum(expression) {
    var arry;
    if (typeof (expression) == "undefined") {
        arry = $(".isNumber");
    } else {
        arry = $(expression);
    }
    for (i = 0; i < arry.length; i++) {
        var cur = $(arry[i]);
        if (!/^\d+$/.test(cur.val())) {
            return false;
        }
    }
    return true;
}

//验证数字
function RequiredNum(type, value) {
    var result = false;
    if (value == null || value == "" || value == undefined) {
        return result;
    }
    switch (type) {
        case "isInteger": //匹配integer
            result = (/^[-\+]?\d+$/.test(value) && parseInt(value) >= 0) ? true : false;
            break;
        case "isFloat": //判断浮点型 
            result = /^[-\+]?\d+(\.\d+)?$/.test(value) ? true : false;
            break;
        case "isNumber": // 判断数值类型，包括整数和浮点数
            result = /^[-\+]?\d+$/.test(value) || /^[-\+]?\d+(\.\d+)?$/.test(value) ? true : false;
            break;
        case "isDigits": // 只能输入[0-9]数字
            result = /^\d+$/.test(value) ? true : false;
            break;
        case "isChinese": // 判断中文字符 
            result = /^[A-Za-z]+$/.test(value) ? true : false;
            break;
        case "isEnglish": // 判断英文字符 
            result = /^[A-Za-z]+$/.test(value) ? true : false;
            break;
        case "isPhone": // 手机号码验证 
            var tel = /^(\d{3,4}-?)?\d{7,9}$/g;
            result = tel.test(value) ? true : false;
            break;
        case "isTel": // 联系电话(手机/电话皆可)验证  
            var length = value.length;
            var mobile = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
            var tel = /^(\d{3,4}-?)?\d{7,9}$/g;
            result = tel.test(value) || (length == 11 && mobile.test(value)) ? true : false;
            break;
        case "isTel": // 邮政编码验证
            var zip = /^[0-9]{6}$/;
            result = zip.test(value) ? true : false;
            break;
        case "ip": // 邮政编码验证
            result = /^(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.)(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.){2}([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))$/.test(value) ? true : false;
            break;
        case "stringCheck": // 字符验证，只能包含中文、英文、数字、下划线等字符。
            result = /^[a-zA-Z0-9\u4e00-\u9fa5-_]+$/.test(value) ? true : false;
            break;
        case "isChinese": // 匹配汉字
            result = /^[\u4e00-\u9fa5]+$/.test(value) ? true : false;
            break;
        case "isRightfulString": // 判断是否为合法字符(a-zA-Z0-9-_)
            result = /^[A-Za-z0-9_-]+$/.test(value) ? true : false;
            break;
        case "isContainsSpecialChar": // 判断是否包含中英文特殊字符，除英文"-_"字符外
            var reg = RegExp(/[(\ )(\`)(\~)(\!)(\@)(\#)(\$)(\%)(\^)(\&)(\*)(\()(\))(\+)(\=)(\|)(\{)(\})(\')(\:)(\;)(\')(',)(\[)(\])(\.)(\<)(\>)(\/)(\?)(\~)(\！)(\@)(\#)(\￥)(\%)(\…)(\&)(\*)(\（)(\）)(\—)(\+)(\|)(\{)(\})(\【)(\】)(\‘)(\；)(\：)(\”)(\“)(\’)(\。)(\，)(\、)(\？)]+/);
            result = !reg.test(value) ? true : false;
            break;
        default:
            result = false;
            break;

    }
    return result;
}

//获取Url传递参数值
function Request(strName) {
    var strHref = window.document.location.href;
    var intPos = strHref.indexOf("?");
    var strRight = strHref.substr(intPos + 1);
    var arrTmp = strRight.split("&");
    for (var i = 0; i < arrTmp.length; i++) {
        var arrTemp = arrTmp[i].split("=");
        if (arrTemp[0].toUpperCase() == strName.toUpperCase()) {
            return arrTemp[1];
        }
    }
    return "";
}

//****************打开窗口设置 Begin *********************

//通用窗口设置
var CommonWin = {

    //窗口参数设置
    WinParams: function () {
        WinUrl: ""; //打开窗口路径
        WinTitle: "新窗口"; //打开窗口标题,默认新窗口
        WinWidth: 600; //打开窗口宽度,默认600px
        WinHeight: 400; //打开窗口高度,默认400px
    },

    //开打窗口
    OpenWin: function (WinParams) {
        var Url = WinParams.WinUrl;
        if (Url == "") {
            mini.alert();
        }
        mini.open({
            url: WinParams.WinUrl,
            title: "修改" + title,
            width: width,
            height: height,
            onload: function () {
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetFormData(row, "");
            },
            ondestroy: function (action) {
                grid.reload();
            }
        });
    }
}

//****************打开窗口设置 end *********************


//****************键盘事件监测 Begin *********************


//处理键盘事件 禁止后退键（Backspace）密码或单行、多行文本框除外
function onKeyEvent(e) {
    //获取event对象
    var ev = e || window.event;
    //获取事件源
    var obj = ev.target || ev.srcElement;
    //获取事件源类型
    var t = obj.type || obj.getAttribute('type');

    //获取作为判断条件的事件类型
    var vReadOnly = obj.getAttribute('readonly');
    var vEnabled = obj.getAttribute('enabled');
    //处理null值情况
    vReadOnly = (vReadOnly == null) ? false : vReadOnly;
    vEnabled = (vEnabled == null) ? true : vEnabled;

    //当敲Backspace键时，事件源类型为密码或单行、多行文本的，
    //并且readonly属性为true或enabled属性为false的，则退格键失效
    var flag1 = (ev.keyCode == 8 && (t == "password" || t == "text" || t == "textarea") && (vReadOnly == true || vEnabled != true)) ? true : false;

    //当敲Backspace键时，事件源类型非密码或单行、多行文本的，则退格键失效
    var flag2 = (ev.keyCode == 8 && t != "password" && t != "text" && t != "textarea") ? true : false;

    //判断
    if (flag2) {
        return false;
    }
    if (flag1) {
        return false;
    }
}

//禁止后退键 作用于Firefox、Opera
document.onkeypress = onKeyEvent;
//禁止后退键  作用于IE、Chrome
document.onkeydown = onKeyEvent;

//****************键盘事件监测 end *********************


// 对Date的扩展，将 Date 转化为指定格式的String 
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
/*
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1,                 //月份 
        "d+": this.getDate(),                    //日 
        "h+": this.getHours(),                   //小时 
        "m+": this.getMinutes(),                 //分 
        "s+": this.getSeconds(),                 //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds()             //毫秒 
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
*/

//计算天数差的函数，通用  
function DateDiff(sDate1, sDate2) { 
    var aDate, oDate1, oDate2, iDays
    aDate = sDate1.split("-")
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]) //转换为12-18-2006格式  
    aDate = sDate2.split("-")
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
    iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24) //把相差的毫秒数转换为天数  
    return iDays
}

//获取当前周次
function getYearWeek(date) {
    var date2 = new Date(date.getFullYear(), 0, 1);
    var day1 = date.getDay();
    if (day1 == 0) day1 = 7;
    var day2 = date2.getDay();
    if (day2 == 0) day2 = 7;
    d = Math.round((date.getTime() - date2.getTime() + (day2 - day1) * (24 * 60 * 60 * 1000)) / 86400000);
    return Math.ceil(d / 7) + 1;
}
