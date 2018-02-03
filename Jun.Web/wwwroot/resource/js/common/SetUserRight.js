/*
* =============================================
* Author:		<Author, 姜方君>
* Create date:  <Create Date,2015年4月13日>
* Description:	<Description,,>
* =============================================
*/

//设置用户权限
function SetUserRight() {
    //设置用户权限之前处理
    if (typeof (onBeforeSetUserRight) != "undefined") {
        if (onBeforeSetUserRight() == false) {
            return false;
        }
    }

    //开始设置
    var userRights = $("#userRights").val();
    if (userRights == "" || userRights == null || userRights == undefined) {
        return;
    }
    var base64 = new Base64();
    var strJson = base64.decode(userRights);
    if (strJson != "") {
        var objJson = mini.decode(strJson);
        if (objJson != null && objJson.length > 0) {
            var ControlIDs = "";
            for (var i = 0; i < objJson.length; i++) {
                if (ControlIDs.indexOf(objJson[i].ControlID) >= 0) {
                    continue;
                }
                ControlIDs += objJson[i].ControlID + ",";
            }

            var arrControlID = ControlIDs.split(',');
            for (var i = 0; i < arrControlID.length; i++) {
                if (arrControlID[i] == "") {
                    continue;
                }
                var html = "";
                for (var j = 0; j < objJson.length; j++) {
                    if (objJson[j].ControlID != arrControlID[i]) {
                        continue;
                    }
                    html += "<a class='" + objJson[j].CssClass + "' iconcls='" + objJson[j].IconCls + "' plain='" + objJson[j].Plain + "' enabled='" + objJson[j].BtnEnabled + "' onclick='" + objJson[j].ClickEvent + "(" + objJson[j].ControlID + ")' >" + objJson[j].CName + "</a>&nbsp;";
                }
                html += "<span class='separator'></span>";
                $("div[controlid='" + arrControlID[i] + "']").html(html);
            }
        }
    }
}

//设置字段权限
function SetFieldRight() {
    //设置字段权限之前处理
    if (typeof (onBeforeSetFieldRights) != "undefined") {
        if (onBeforeSetFieldRights() == false) {
            return false;
        }
    }
    //开始设置
    var fieldRights = $("#fieldRights").val();
    if (fieldRights == "" || fieldRights == null || fieldRights == undefined) {
        return;
    }
    var base64 = new Base64();
    var strRights = base64.decode(fieldRights);
    var arrRights = strRights.split(',');
    if (arrRights != null && arrRights.length > 0) {
        for (var i = 0; i < arrRights.length; i++) {
            if (arrRights[i] == "") {
                continue;
            }
            $("#" + arrRights[i]).css("visibility", "visible");
        }
    }
}