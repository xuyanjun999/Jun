/*
* =============================================
* Author:		<Author, 姜方君>
* Create date:  <Create Date,2015年4月13日>
* Description:	<Description,,>
* =============================================
*/


/****
数据查询 Begin
****/

//GRID数据查询
function search(grid, isResetGrid) {
    if (typeof (onBeforeSearch) != "undefined") {
        if (onBeforeSearch(grid, isResetGrid) == false) {
            return false;
        }
    }
    var gridManager = mini.get(grid);
    var fields = GetGridFields(grid);
    var params = getSearchParams();
    if (isResetGrid) { gridManager.reload(); }
    gridManager.load({ BindFields: fields, SearchParams: params });
}

//TREE数据查询
function searchTree(treeid) {
    var tree = mini.get(treeid);
    var url = tree.url;

    var ServerArgs = new CommonServer.ServerArgs();
    ServerArgs.AjaxUrl = url;
    ServerArgs.AjaxMethod = "";
    ServerArgs.AjaxMethodDec = "";
    ServerArgs.AjaxData["SearchParams"] = getSearchTreeParams();
    ServerArgs.CallBack = function (text) {
        var data = mini.decode(text);
        tree.loadData(data);
    }
    CommonServer.AjaxSubmit(ServerArgs);
}

//获取GRID绑定字段
function GetGridFields(grid) {
    var fields = "";
    //获取GIRD
    var gridManager = mini.get(grid);
    var columns = gridManager.getBottomColumns();
    for (var i = 0; i < columns.length; i++) {
        if (columns[i].field) {
            fields += "," + columns[i].field;
        }
    }
    return fields;
}

//获取GRID绑定字段及字段说明
function GetFieldsHeader(grid) {
    var fieldsheader = "";
    //获取GRID
    var gridManager = mini.get(grid);
    var columns = gridManager.getBottomColumns();
    for (var i = 0; i < columns.length; i++) {
        if (columns[i].field) {
            if (fieldsheader == "") {
                fieldsheader += columns[i].field + " as " + columns[i].header;
            } else {
                fieldsheader += "," + columns[i].field + " as " + columns[i].header;
            }
        }
    }
    return fieldsheader;
}

//文件下载
function FileDownLoad(e) {
    var DownLoadUrl = $(e).attr("DownLoadUrl");
    if (DownLoadUrl == "" || DownLoadUrl == "undefined") {
        mini.alert("下载地址出错");
        return;
    }
    if (typeof (FileDownLoad.iframe) == "undefined") {
        var iframe = document.createElement("iframe");
        FileDownLoad.iframe = iframe;
        document.body.appendChild(FileDownLoad.iframe);
    }
    FileDownLoad.iframe.src = DownLoadUrl;
    FileDownLoad.iframe.style.display = "none";
}


/****
数据查询 End
****/


/****
Form数据加载 Begin
****/

function SetFormData(data, PKID) {
    if (typeof (onBeforeSetFormData) != "undefined") {
        if (onBeforeSetFormData(data, PKID) == false) {
            return false;
        }
    }

    var form = new mini.Form("form1");
    //跨页面传递的数据对象，克隆后才可以安全使用
    data = mini.clone(data);
    if (data != "") data = mini.encode(data);

    var ServerArgs = new CommonServer.ServerArgs();
    ServerArgs.AjaxMethod = "BindFrom";
    ServerArgs.AjaxMethodDec = "绑定表单";
    ServerArgs.AjaxData["data"] = data;
    ServerArgs.AjaxData["PKID"] = PKID;
    ServerArgs.CallBack = function (text) {
        if (text != "") {
            var obj = mini.decode(text);
            $("#PKID").val(obj["PKID"]);
            form.setData(obj);
            if (typeof (onAfterSetFormData) != "undefined") {
                onAfterSetFormData(obj, PKID);
            }
        }
    }
    CommonServer.AjaxSubmit(ServerArgs);
}

//设置KEY值
function SetKeyValue(objKey) {
    if (typeof (onBeforeSetKeyValue) != "undefined") {
        if (onBeforeSetKeyValue(objKey) == false) {
            return false;
        }
    }

    var form = new mini.Form("form1");
    //跨页面传递的数据对象，克隆后才可以安全使用
    objKey = mini.clone(objKey);
    Key = objKey;
    form.setData(Key);

    if (typeof (onAfterSetKeyValue) != "undefined") {
        onAfterSetKeyValue(objKey);
    }
}

/****
Form数据加载 End
****/



/****
通用Renderer设置 Begin
****/

//设置人民币金额
function onRMBRenderer(e) {
    var result = "";
    if (e.value != null) {
        if (e.value < 0) {
            result = "<span style='color: red;'>" + e.value + "</span>";
        } else {
            result = "<span style='color: green;'>" + e.value + "</span>";
        }
    }
    return result;
}

/****
通用Renderer设置 End
****/
