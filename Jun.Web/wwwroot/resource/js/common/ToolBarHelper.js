/*
* =============================================
* Author:		<Author, 姜方君>
* Create date:  <Create Date,2015年4月13日>
* Description:	<Description,,>
* =============================================
*/


/****
页面ToolBarClick事件 Begin
****/

//Form添加
function FormAdd(control) {
    if (typeof (onBeforeFormAdd) != "undefined") {
        if (onBeforeFormAdd(control) == false) {
            return false;
        }
    }

    var form = new mini.Form(control.id);
    form.clear();
    $("#PKID").val("-1");
    //form.validate();

    if (typeof (onAfterFormAdd) != "undefined") {
        onAfterFormAdd(control);
    }
}

//GRID添加
function GridAdd(control) {
    if (typeof (onBeforeGridAdd) != "undefined") {
        if (onBeforeGridAdd(control) == false) {
            return false;
        }
    }

    var url = $("div[controlid='" + control.id + "']").attr("eidturl");
    var title = $("div[controlid='" + control.id + "']").attr("eidttitle");
    var width = $("div[controlid='" + control.id + "']").attr("eidtwidth");
    var height = $("div[controlid='" + control.id + "']").attr("eidtheight");
    var keys = $("div[controlid='" + control.id + "']").attr("keys");
    //获取GIRD
    var grid = mini.get(control.id);
    //打开窗口
    mini.open({
        url: url,
        title: "添加" + title,
        width: width,
        height: height,
        allowResize: false,
        onload: function () {
            if (typeof (keys) != "undefined") {
                var objKey = {};
                var arrKey = keys.split("|");
                for (var i = 0; i < arrKey.length; i++) {
                    if (arrKey[i] != "") {
                        var key = arrKey[i].split("-")[0];
                        var prop = arrKey[i].split("-")[1];
                        if (key == "PKID") {
                            objKey[prop] = $("#" + key).val();
                        } else {
                            objKey[prop] = mini.get(key).getValue();
                        }
                    }
                }
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetKeyValue(objKey);
            }
        },
        ondestroy: function (action) {
            search(control.id, true);
        }
    });

    if (typeof (onAfterGridAdd) != "undefined") {
        onAfterGridAdd(control);
    }
}

//Form修改
function FormEdit(control) {
    if (typeof (onBeforeFormEdit) != "undefined") {
        if (onBeforeFormEdit(control) == false) {
            return false;
        }
    }

    if (typeof (onAfterFormEdit) != "undefined") {
        onAfterFormEdit(control);
    }
}

//GRID修改
function GridEdit(control) {
    if (typeof (onBeforeGridEdit) != "undefined") {
        if (onBeforeGridEdit(control) == false) {
            return false;
        }
    }

    var url = $("div[controlid='" + control.id + "']").attr("eidturl");
    var title = $("div[controlid='" + control.id + "']").attr("eidttitle");
    var width = $("div[controlid='" + control.id + "']").attr("eidtwidth");
    var height = $("div[controlid='" + control.id + "']").attr("eidtheight");
    var keys = $("div[controlid='" + control.id + "']").attr("keys"); 
    //获取GIRD
    var grid = mini.get(control.id);

    var row = grid.getSelecteds();
    if (row == null || row == undefined || row.length == 0) {
        mini.alert("请选择数据");
        return;
    }
    if (row.length > 1) {
        mini.alert("只能选择一条数据");
        return;
    }
    mini.open({
        url: url,
        title: "修改" + title,
        width: width,
        height: height,
        allowResize: false,
        onload: function () {
            var iframe = this.getIFrameEl();
            iframe.contentWindow.SetFormData(row, "");
            if (typeof (keys) != "undefined") {
                var objKey = {};
                var arrKey = keys.split("|");
                for (var i = 0; i < arrKey.length; i++) {
                    if (arrKey[i] != "") {
                        var key = arrKey[i].split("-")[0];
                        var prop = arrKey[i].split("-")[1];
                        if (key == "PKID") {
                            objKey[prop] = $("#" + key).val();
                        } else {
                            objKey[prop] = mini.get(key).getValue();
                        }
                    }
                }
                iframe.contentWindow.SetKeyValue(objKey);
            }
        },
        ondestroy: function (action) {
            grid.reload();
        }
    });

    if (typeof (onAfterGridEdit) != "undefined") {
        onAfterGridEdit(control);
    }
}

//Form保存
function FormSave(control) {
    if (typeof (onBeforeFormSave) != "undefined") {
        if (onBeforeFormSave(control) == false) {
            return false;
        }
    }

    var form = new mini.Form(control.id);
    var data = form.getData();

    form.validate();
    if (form.isValid() == false) {
        mini.alert("[保存失败]填写信息有误,请验证！");
        return;
    }
    var objJson = mini.decode(mini.encode([data]));

    var PKID = $("#PKID").val();
    objJson[0]["PKID"] = PKID;
    objJson[0]["BOOKERID"] = $("#__CURRENT_USERID__").val();
    objJson[0]["BOOKERNAME"] = $("#__CURRENT_USERNAME__").val();

    var strJson = mini.encode(objJson);


    var ServerArgs = new CommonServer.ServerArgs();
    ServerArgs.AjaxMethod = "FormSave";
    ServerArgs.AjaxMethodDec = "保存表单数据";
    ServerArgs.AjaxData["PKID"] = PKID;
    ServerArgs.AjaxData["data"] = strJson;
    ServerArgs.CallBack = function (text) {
        mini.alert(text.split(',')[0]);
        if (text.split(',')[1] != "") {
            SetFormData("", text.split(',')[1]);

            if (typeof (onAfterFormSave) != "undefined") {
                onAfterFormSave(control);
            }
        }
    }
    CommonServer.AjaxSubmit(ServerArgs);
}

//FROM保存后关闭
function FormSaveClose(e) {
    if (typeof (onBeforeSaveClose) != "undefined") {
        if (onBeforeSaveClose(e) == false) {
            return false;
        }
    }

    var form = new mini.Form(e.id);
    var data = form.getData();

    form.validate();
    if (form.isValid() == false) {
        mini.alert("[保存失败]填写信息有误,请验证！");
        return;
    }
    var objJson = mini.decode(mini.encode([data]));

    var PKID = $("#PKID").val();
    objJson[0]["PKID"] = PKID;
    objJson[0]["BOOKERID"] = $("#__CURRENT_USERID__").val();
    objJson[0]["BOOKERNAME"] = $("#__CURRENT_USERNAME__").val();

    var strJson = mini.encode(objJson);

    var ServerArgs = new CommonServer.ServerArgs();
    ServerArgs.AjaxMethod = "FormSave";
    ServerArgs.AjaxMethodDec = "保存表单数据";
    ServerArgs.AjaxData["PKID"] = PKID;
    ServerArgs.AjaxData["data"] = strJson;
    ServerArgs.CallBack = function (text) {
        mini.showMessageBox({
            width: 250,
            title: "提醒",
            buttons: ["ok"],
            message: text.split(',')[0],
            iconCls: "mini-messagebox-info",
            callback: function (action) {
                if (text.indexOf("成功") >= 0) {
                    window.CloseOwnerWindow();
                }
            }
        });
    }
    CommonServer.AjaxSubmit(ServerArgs);

    if (typeof (onAfterSaveClose) != "undefined") {
        onAfterSaveClose(e);
    }
}

//GRID保存
function GridSave(control) {
    if (typeof (onBeforeGridSave) != "undefined") {
        if (onBeforeGridSave(control) == false) {
            return false;
        }
    }

    var form = new mini.Form("form1");
    form.validate();
    if (form.isValid() == false) {
        mini.alert("保存失败,填写信息有误,请验证！");
        return;
    }

    var grid = mini.get(control.id);
    //执行修改
    grid.commitEdit();
    var rowsData = grid.getChanges();
    if (rowsData == null || rowsData == undefined || rowsData.length == 0) {
        mini.alert("暂无需要保存的数据");
        return;
    }
    grid.loading("保存中，请稍后......");
    var strJson = mini.encode(rowsData);

    var ServerArgs = new CommonServer.ServerArgs();
    ServerArgs.AjaxMethod = "GridSave";
    ServerArgs.AjaxMethodDec = "保存列表数据";
    ServerArgs.AjaxData["data"] = strJson;
    ServerArgs.CallBack = function (text) {
        mini.alert(text);
        search(control.id, true);
    }
    CommonServer.AjaxSubmit(ServerArgs);

    if (typeof (onAfterGridSave) != "undefined") {
        onAfterGridSave(control);
    }
}

//Form删除
function FormDelete(control) {
    if (typeof (onBeforeFormDelete) != "undefined") {
        if (onBeforeFormDelete(control) == false) {
            return false;
        }
    }
    var PKID = $("#PKID").val();
    if (PKID == "" || PKID == "-1") {
        mini.alert("无可删除的数据");
        return;
    }

    mini.confirm("确定删除记录？", "确定？",
        function (action) {
            if (action == "ok") {
                var form = new mini.Form(control.id);
                var data = form.getData();
                var objJson = mini.decode(mini.encode([data]));

                objJson[0]["PKID"] = PKID;
                objJson[0]["BOOKERID"] = $("#__CURRENT_USERID__").val();
                objJson[0]["BOOKERNAME"] = $("#__CURRENT_USERNAME__").val();

                var strJson = mini.encode(objJson);

                var ServerArgs = new CommonServer.ServerArgs();
                ServerArgs.AjaxMethod = "FormDelete";
                ServerArgs.AjaxMethodDec = "删除表单数据";
                ServerArgs.AjaxData["PKID"] = PKID;
                ServerArgs.AjaxData["data"] = strJson;
                ServerArgs.CallBack = function (text) {
                    mini.alert(text.split(',')[0]);
                    if (text.indexOf("成功") >= 0) {
                        FormAdd(control);
                    }
                }
                CommonServer.AjaxSubmit(ServerArgs);
            }
        }
    );

    if (typeof (onAfterFormDelete) != "undefined") {
        onAfterFormDelete(control);
    }
}

//GRID删除
function GridDelete(control) {
    if (typeof (onBeforeGridDelete) != "undefined") {
        if (onBeforeGridDelete(control) == false) {
            return false;
        }
    }

    //获取GIRD
    var grid = mini.get(control.id);

    var rows = grid.getSelecteds();
    if (rows == null || rows == undefined || rows.length == 0) {
        mini.alert("请选择数据");
        return;
    }

    var removeRowNum = 0;

    mini.confirm("确定删除记录？", "确定？",
        function (action) {
            if (action == "ok") {
                for (var i = 0; i < rows.length; i++) {
                    grid.removeRow(rows[i], true);
                    if (rows[i].hasOwnProperty("_state")) {
                        if (rows[i]._state = "added" && rows[i].PKID == "-1") {
                            removeRowNum++;
                        }
                    }
                }

                if (removeRowNum == rows.length) {
                    mini.alert("删除成功！");
                    return;
                }

                var ServerArgs = new CommonServer.ServerArgs();
                ServerArgs.AjaxMethod = "GridDelete";
                ServerArgs.AjaxMethodDec = "删除列表数据";
                ServerArgs.AjaxData["data"] = mini.encode(rows);
                ServerArgs.CallBack = function (text) {
                    mini.alert(text.split(',')[0]);
                    if (text.split(',')[1] == "") {
                        search(control.id, false);
                    }
                }
                CommonServer.AjaxSubmit(ServerArgs);
            }
        }
    );
}


//GRID导出
function GridExport(control) {
    //获取GIRD
    var grid = mini.get(control.id);
    //获取排序方式
    var sortField = grid.sortField;
    //获取排序规则
    var sortOrder = grid.sortOrder;
    //获取参数
    var fields = GetFieldsHeader(control.id);
    //获取查询条件
    var params = getSearchParams();

    var loadingMes = mini.loading("正在处理, 请稍后 ...", "Loading");
    setTimeout(function () {
        var ServerArgs = new CommonServer.ServerArgs();
        ServerArgs.AjaxMethod = "GridExport";
        ServerArgs.AjaxMethodDec = "导出数据";
        ServerArgs.AjaxData["BindFields"] = fields;
        ServerArgs.AjaxData["SearchParams"] = params;
        ServerArgs.AjaxData["sortField"] = sortField;
        ServerArgs.AjaxData["sortOrder"] = sortOrder;
        ServerArgs.CallBack = function (text) {
            mini.hideMessageBox(loadingMes);
            var result = text.split(',');
            if (result[0] == "导出成功") {
                mini.open({
                    url: "DownLoad.aspx",
                    title: "文件下载",
                    width: 350,
                    height: 150,
                    onload: function () {
                        var iframe = this.getIFrameEl();
                        iframe.contentWindow.SetUrl(result[1]);
                    }
                });
            } else {
                mini.alert(result[0]);
            }
        }
        CommonServer.AjaxSubmit(ServerArgs);
    }, 1000);
}


//Grid批量添加
function GridBatchAdd(control) {
    //获取GIRD
    var grid = mini.get(control.id);
    var newRow = {};
    newRow.PKID = "-1";
    grid.addRow(newRow, 0);
    grid.beginEditRow(newRow);
}


//Grid批量修改
function GridBatchEdit(control) {
    //获取GIRD
    var grid = mini.get(control.id);
    //获取选择行
    var rows = grid.getSelecteds();

    if (rows == null || rows == undefined || rows.length == 0) {
        mini.alert("请选择数据");
        return;
    }

    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        row._state = "modified";
        grid.beginEditRow(row);
    }
}


//连接点击查看
function DateView(row_uid, control_id) {

    if (typeof (onBeforeDateView) != "undefined") {
        if (onBeforeDateView(row_uid, control_id) == false) {
            return false;
        }
    }

    var url = $("div[controlid='" + control_id + "']").attr("eidturl");
    var title = $("div[controlid='" + control_id + "']").attr("eidttitle");
    var width = $("div[controlid='" + control_id + "']").attr("eidtwidth");
    var height = $("div[controlid='" + control_id + "']").attr("eidtheight");
    var keys = $("div[controlid='" + control_id + "']").attr("keys");
    //获取GIRD
    var row = [];
    var grid = mini.get(control_id);
    row[0] = grid.getRowByUID(row_uid);
    if (row == null || row == undefined || row.length == 0) {
        mini.alert("请选择数据");
        return;
    }
    if (row.length > 1) {
        mini.alert("只能选择一条数据");
        return;
    }
    mini.open({
        url: url,
        title: "修改" + title,
        width: width,
        height: height,
        allowResize: false,
        onload: function () {
            var iframe = this.getIFrameEl();
            iframe.contentWindow.SetFormData(row, "");
            if (typeof (keys) != "undefined") {
                var objKey = {};
                var arrKey = keys.split("|");
                for (var i = 0; i < arrKey.length; i++) {
                    if (arrKey[i] != "") {
                        var key = arrKey[i].split("-")[0];
                        var prop = arrKey[i].split("-")[1];
                        if (key == "PKID") {
                            objKey[prop] = $("#" + key).val();
                        } else {
                            objKey[prop] = mini.get(key).getValue();
                        }
                    }
                }
                iframe.contentWindow.SetKeyValue(objKey);
            }
        },
        ondestroy: function (action) {
            grid.reload();
        }
    });

    if (typeof (onAfterDateView) != "undefined") {
        onAfterDateView(row_uid, control_id);
    }
}

/****
页面ToolBarClick事件 End
****/