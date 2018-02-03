/*
* =============================================
* Author:		<Author, 姜方君>
* Create date:  <Create Date,2015年4月13日>
* Description:	<Description,,>
* =============================================
*/

//通用服务
var CommonServer = {

    //服务参数
    ServerArgs: function () {
        //通讯地址
        this.AjaxUrl = PageName + ".aspx?";
        //调用方法
        this.AjaxMethod = "";
        //操作动作名称
        this.AjaxMethodDec = "未知操作";
        //提交方式,默认是POST
        this.AjaxType = "POST";
        //通讯数据参数
        this.AjaxData = {};
        //服务返回执行回调函数
        this.CallBack = function (data) {
        }
    },

    //封装提交参数
    PackAjaxData: function (data) {
        if (typeof (data) == "object") {
            return mini.encode(data);
        } else {
            return data;
        }
    },

    //Jquery Ajax方式请求
    AjaxSubmit: function (ServerArgs) {
        var AjaxUrl = ServerArgs.AjaxUrl;
        if (ServerArgs.AjaxMethod != "") {
            AjaxUrl += "method=" + ServerArgs.AjaxMethod + "&";
        }
        if (ServerArgs.AjaxMethodDec != "") {
            AjaxUrl += "methodDec=" + ServerArgs.AjaxMethodDec + "&";
        }
        //var AjaxUrl = ServerArgs.AjaxUrl + "method=" + ServerArgs.AjaxMethod + "&methodDec=" + ServerArgs.AjaxMethodDec;
        var AjaxType = ServerArgs.AjaxType;
        var AjaxData = CommonServer.PackAjaxData(ServerArgs.AjaxData);
        //alert(mini.decode(AjaxData));
        $.ajax({
            url: AjaxUrl,
            type: AjaxType,
            data: parseObjJson(AjaxData),
            cache: false,
            success: function (data) {
                if (data == null) {
                    mini.alert("[系统返回数据错误]");
                    return;
                }
                //执行回调函数
                if (ServerArgs.CallBack) {
                    ServerArgs.CallBack(data);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                mini.alert(jqXHR.responseText);
            }
        });
    }
}