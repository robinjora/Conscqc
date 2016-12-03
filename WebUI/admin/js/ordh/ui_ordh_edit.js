//初始化
var ui_ordh_edit_state, ui_ordh_edit_compid, ui_ordh_edit_factid, ui_ordh_edit_ordid;

$(function () {
    /*获取参数*/
    editTab = $("#tabs").tabs("getSelected");
    editContent = editTab.panel('options').content;
    editParameters = editContent.split("|");
    ui_ordh_edit_state = editParameters[0];
    ui_ordh_edit_compid = editParameters[1];
    ui_ordh_edit_factid = editParameters[2];
    ui_ordh_edit_ordid = editParameters[3];

    loading_ordh_edit();     //加载等待页面
    ui_ordhedit_numberbox();

    if (ui_ordh_edit_state == 'A') {
        /*初始化*/
        ui_ordhedit_newDate();      //日期初始化
        ui_ordhedit_ddwLoad();      //下拉初始化
        ui_ordhedit_orddateChange();    //日期栏位添加change事件
        /*关键栏位解锁*/
        $("#ui_ordhedit_factid").combogrid({ disabled: false });
        $("#ui_ordhedit_ordid").textbox({ disabled: false });
        $("#ui_ordhedit_orddate").datebox({ disabled: false });
        $("#ui_ordh_edit_ordblabel").show();
        $("#ui_ordh_edit_ordclabel").show();
        $("#ui_ordh_edit_uploadlabel").show();
    }
    else if (ui_ordh_edit_state == "U") {
        /*获取容器内参数*/
        ui_ordhedit_ddwLoad();
        ui_ordhedit_getOrdh();
        /*关键栏位锁定*/
        $("#ui_ordhedit_factid").combogrid({ disabled: true });
        $("#ui_ordhedit_ordid").textbox({ disabled: true });
        $("#ui_ordhedit_orddate").datebox({ disabled: true });
        /*加载身裆tabpage*/
        ui_ordhedit_ordcLoad();
        ui_ordhedit_ordbLoad();
        ui_ordhedit_uploadLoad();
        $("#ui_ordh_edit_ordblabel").hide();
        $("#ui_ordh_edit_ordclabel").hide();
        $("#ui_ordh_edit_uploadlabel").hide();
    }
});

function searchBtn(){
    var test = $("#searchValue").val();
    $('#ui_ordhedit_custid').combogrid("grid").datagrid("reload", { 'q': test });
}
//----------------------------------------ordh头档数据模块----------------------------------------
//初始化----启用日期
function ui_ordhedit_newDate() {
    var date_ordhedit = new Date();
    var yy_ordhedit = date_ordhedit.getFullYear();
    var mm_ordhedit = date_ordhedit.getMonth() + 1;
    var dd_ordhedit = date_ordhedit.getDate();
    var datestr_ordhedit = yy_ordhedit + "-" + (mm_ordhedit < 10 ? "0" + mm_ordhedit : mm_ordhedit)
                                + "-" + (dd_ordhedit < 10 ? "0" + dd_ordhedit : dd_ordhedit);
    $("#ui_ordhedit_orddate").val(datestr_ordhedit);
}

//初始化----请求新ordid
function ui_ordhedit_newOrdid() {
    if (ui_ordh_edit_state == "A") {
        var factid = $("#ui_ordhedit_factid").combogrid("getValue");
        var date = $("#ui_ordhedit_orddate").datebox("getValue");
        var ui_ordhedit_ordid;

        $.ajax({     //获取ordid
            url: "ashx/bg_ordh.ashx?action=getNewOrdid",
            type: "post",
            data: { "factid": factid, "date": date },
            dataType: "json",
            timeout: 5000,
            async: false,
            success: function (data) {
                if (data.success) {
                    ui_ordhedit_ordid = data.newordid.toString();
                    dclose_ordh_edit();
                } else {
                    $.show_warning("错误", data.result);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                if (textStatus == "timeout") {
                    $.show_warning("提示", "请求超时，请刷新当前页重试！");
                }
                else {
                    $.show_warning("错误", textStatus + "：" + errorThrown);
                }
            }
        });

        $("#ui_ordhedit_ordid").textbox("setValue", ui_ordhedit_ordid);
    }
}

//初始化----下拉数据加载
function ui_ordhedit_ddwLoad() {
    //企业下拉数据
    $("#ui_ordhedit_factid").combogrid({
        url: "ashx/bg_dddw.ashx?action=getFactory",
        panelWidth: 200,
        multiple: false,
        idField: "factid",
        textField: "factname",
        method: "get",
        mode: "remote",
        columns: [[
            { field: "factid", title: "代号", width: 40 },
            { field: "factname", title: "简称", width: 60 }
            ]],
        fitColumns: true,
        onLoadSuccess: function () {
            if (ui_ordh_edit_state == "A") {
                $("#ui_ordhedit_factid").combogrid("grid").datagrid("selectRecord", "22");  //厂别初始化
            }
            else {
                $("#ui_ordhedit_factid").combogrid("grid").datagrid("selectRecord", getCookie("ui_ordhedit_factid_ck"));
            }
        },
        onSelect: function () {
            if (ui_ordh_edit_state == "A") {
                ui_ordhedit_newOrdid();
            }
        }
    });

    //客户下拉数据
    $("#ui_ordhedit_custid").combogrid({
        url: "ashx/bg_dddw.ashx?action=getCustid",
        panelWidth: 200,
        multiple: false,
        idField: "custid",
        textField: "custid",
        method: "get",
        mode: "remote",
        columns: [[
            { field: "custid", title: "代号", width: 40 },
            { field: "shortname", title: "简称", width: 60 }
            ]],
        fitColumns: true,
        onLoadSuccess: function () {
            if (ui_ordh_edit_state == "U") {
                $("#ui_ordhedit_custid").combogrid("grid").datagrid("selectRecord", getCookie("ui_ordhedit_custid_ck"));
            }
        },
        onSelect: function (rec) {
            var rows = $('#ui_ordhedit_custid').combogrid('grid').datagrid('getData').rows;
            $('#ui_ordhedit_custlongname').textbox("setValue", rows[rec].longname);
            $("#ui_ordhedit_empid").combogrid("grid").datagrid("selectRecord", rows[rec].empid);
        },
        toolbar: "#testtb",
    });

    //联系人下拉数据
    $("#ui_ordhedit_empid").combogrid({
        url: "ashx/bg_dddw.ashx?action=getEmpid",
        panelWidth: 200,
        multiple: false,
        idField: "empid",
        textField: "empname",
        method: "get",
        mode: "remote",
        columns: [[
            { field: "empid", title: "代号", width: 40 },
            { field: "empname", title: "名称", width: 60 }
            ]],
        onLoadSuccess: function () {
            if (ui_ordh_edit_state == "U") {
                $("#ui_ordhedit_empid").combogrid("grid").datagrid("selectRecord", getCookie("ui_ordhedit_empid_ck"));
            }
        },
        fitColumns: true
    });
}

//初始化----日期onchange事件
function ui_ordhedit_orddateChange() {
    $("#ui_ordhedit_orddate").datebox({
        onSelect: function (date) {
            ui_ordhedit_newOrdid();
        }
    });
}

//初始化----数字框
function ui_ordhedit_numberbox() {
    $("#ui_ordhedit_maxqty").val(0);
    $("#ui_ordhedit_maxqty").numberbox({
        formatter: function (value) {
            if (value == "") {
                return parseFloat("0").toFixed(2);
            }
            else {
                return parseFloat(value).toFixed(2);
            }
        }
    });
}

//获取合同信息
function ui_ordhedit_getOrdh() {
    var factid = ui_ordh_edit_factid;
    var ordid = ui_ordh_edit_ordid;

    $.ajax({     //获取合同信息
        url: "ashx/bg_ordh.ashx?action=getOrdhById",
        type: "post",
        data: { "factid": factid, "ordid": ordid },
        dataType: "json",
        timeout: 5000,
        //async: false,
        success: function (data) {
            if (data.success) {
                setCookie("ui_ordhedit_factid_ck", data.factid);
                setCookie("ui_ordhedit_custid_ck", data.custid);
                setCookie("ui_ordhedit_empid_ck", data.empid);
                //$("#ui_ordhedit_factid").combogrid("grid").datagrid("selectRecord", data.factid);
                $("#ui_ordhedit_ordid").textbox("setValue", data.ordid);
                $("#ui_ordhedit_orddate").datebox("setValue", data.orddate);
                $("#ui_ordhedit_ordh12").textbox("setValue", data.ordh12);
                $("#ui_ordhedit_maxqty").numberbox("setValue", data.maxqty);
                //$("#ui_ordhedit_custid").combogrid("grid").datagrid("selectRecord", data.custid);
                //$("#ui_ordhedit_empid").combogrid("grid").datagrid("selectRecord", data.empid);
                if (data.ordh33 == "Y") {
                    $("#ui_ordhedit_ordh33").attr("checked", true);
                }
                else {
                    $("#ui_ordhedit_ordh33").attr("checked", false);
                }
                dclose_ordh_edit();
            } else {
                $.show_warning("错误", data.result);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (textStatus == "timeout") {
                $.show_warning("提示", "请求超时，请刷新当前页重试！");
            }
            else {
                $.show_warning("错误", textStatus + "：" + errorThrown);
            }
        }
    });
}

//新增
function ui_ordhedit_add() {
    $("#ui_ordhedit_addform").form("submit", {
        url: "ashx/bg_ordh.ashx",
        onSubmit: function (param) {
            $("#ui_ordhedit_save").linkbutton("disable");    //点击就禁用按钮，防止连击
            param.action = "ordhAdd";
            if ($(this).form("validate"))
                return true;
            else {
                $("#ui_ordhedit_save").linkbutton("enable");   //恢复按钮
                return false;
            }
        },
        success: function (data) {
            var dataJson = eval("(" + data + ")");    //转成json格式
            if (dataJson.success) {
                $.show_warning("提示", dataJson.msg);
                $("#ui_ordh_dg").datagrid("reload").datagrid("clearSelections").datagrid("clearChecked");
                var tab = $("#tabs").tabs("getSelected");
                $("#tabs").tabs("update", {
                    tab: tab,
                    options: {
                        title: "修改合同",
                        content: "U|01|" + $("#ui_ordhedit_factid").textbox("getValue") + "|" + $("#ui_ordhedit_ordid").textbox("getValue")
                    }
                });
            } else {
                $("#ui_ordhedit_save").linkbutton("enable");   //恢复按钮
                $.show_warning("提示", dataJson.msg);
            }
        }
    });
}

//修改
function ui_ordhedit_edit() {
    $("#ui_ordhedit_addform").form("submit", {
        url: "ashx/bg_ordh.ashx",
        onSubmit: function (param) {
            $("#ui_ordhedit_save").linkbutton("disable");    //点击就禁用按钮，防止连击
            param.action = "ordhEdit";
            if ($(this).form("validate"))
                return true;
            else {
                $("#ui_ordhedit_save").linkbutton("enable");   //恢复按钮
                return false;
            }
        },
        success: function (data) {
            var dataJson = eval("(" + data + ")");    //转成json格式
            if (dataJson.success) {
                $.show_warning("提示", dataJson.msg);
                $("#ui_ordh_dg").datagrid("reload").datagrid("clearSelections").datagrid("clearChecked");
                var tab = $("#tabs").tabs("getSelected");
                $("#tabs").tabs("update", {
                    tab: tab,
                    options: {
                        title: "修改合同"
                    }
                }); 
            } else {
                $("#ui_ordhedit_save").linkbutton("enable");   //恢复按钮
                $.show_warning("提示", dataJson.msg);
            }
        }
    });
}

//保存按钮事件
function ui_ordhedit_save() {
    if ( ui_ordhedit_editIndex != null) {
        $.messager.alert("提示", "正在编辑单价加价资料，请先保存！");
        return;
    }
    $("#ui_ordhedit_factid").combogrid("enable");
    $("#ui_ordhedit_ordid").textbox("enable");
    $("#ui_ordhedit_orddate").datebox("enable");

    if (ui_ordh_edit_state == 'A') {
        ui_ordhedit_add();
    }
    else if (ui_ordh_edit_state == 'U') {
        ui_ordhedit_edit();
    }
}

//加载等待页面
function loading_ordh_edit() {
    $("<div>").dialog({
        id: "ui_loading_dialog",
        href: "html/ui_loading2.html",
        title: "提示",
        height: 180,
        width: 400,
        modal: true,
        closable: false,
        onClose: function () {
            $(this).dialog('destroy'); //销毁  
        }
    });
}

//关闭等待页面
function dclose_ordh_edit() {
    $('#ui_loading_dialog').dialog('close');
}

//----------------------------------------ordc身档数据模块----------------------------------------
var ui_ordhedit_editIndex = undefined;
var ui_ordhedit_addstate = undefined;
var ui_ordhedit_addfailed = undefined;
//var ui_ordhedit_addidJson = undefined;

//ordc数据加载
function ui_ordhedit_ordcLoad() {
    //ui_ordhedit_ordcAddidSource();
    var factid = ui_ordh_edit_factid;
    var ordid = ui_ordh_edit_ordid;

    $("#ui_ordh_edit_ordcdg").datagrid({       //初始化datagrid
        url: "ashx/bg_ordh.ashx?action=ordcSearch",
        queryParams: { 'compid': '01', 'factid': factid, 'ordid': ordid },
        striped: true, rownumbers: true, pagination: true, pageSize: 10, singleSelect: true,
        idField: 'addid',  //这个idField必须指定为输出的id，输出的是Id就必须是Id，不能小写
        sortName: 'addid',
        sortOrder: 'asc',
        pageList: [10, 20, 40, 60, 80, 100],
        showFooter: true,
        columns: [[
                    { field: 'rownumber', hidden: true },
                    { field: 'compid', hidden: true },
                    { field: 'factid', hidden: true },
                    { field: 'ordid', hidden: true },
                    { field: 'addid', title: '加价代号', width: 100, sortable: true,
                        editor: { type: 'combogrid',
                            //                                    options: { data: ui_ordhedit_addidJson, valueField: "addid", textField: "addname" ,required: true}
                            //                                    }
                            options: {
                                panelWidth: 162,
                                required: true,
                                idField: 'addid',
                                textField: 'addname',
                                url: 'ashx/bg_dddw.ashx?action=getAddid',
                                columns: [[
                                            { field: 'addid', title: 'addid', width: 60 },
                                            { field: 'addname', title: 'addname', width: 100 }
                                        ]],
                                mode: 'remote'
                            }
                        },
                        formatter: function (value, row, index) {
                            var therow = $('#ui_ordh_edit_ordcdg').datagrid('getData').rows[index];
                            return therow.addname;
                        }
                    },
                    { field: 'addmoney', title: '加价金额', width: 100, align: "right",
                        editor: { type: 'numberbox', options: { precision: 2} },
                        formatter: function (value) {
                            return parseFloat(value).toFixed(2);
                        }
                    },
                    { field: 'memo', title: '备注', width: 100, editor: "textbox" },
                    { field: 'useing', title: '使用否', width: 60, align: "center",
                        editor: { type: 'checkbox', options: { on: 'Y', off: 'N'} },
                        formatter: function (value, row, index) {
                            if (value == "Y") {
                                return '<input type="checkbox" name="DataGridCheckbox" checked="checked">';
                            }
                            else if (value == "S") {
                                return '';
                            }
                            else {
                                return '<input type="checkbox" name="DataGridCheckbox">';
                            }
                        }
                    }
                                    ]],
        toolbar: [
                    { text: "添加", iconCls: "icon-add", handler: function () { ui_ordhedit_ordcAdd(); } },
                    { text: "删除", iconCls: "icon-delete", handler: function () { ui_ordhedit_orecRemoveit(); } },
                    { text: "保存", iconCls: "icon-save", handler: function () { ui_ordhedit_ordcAccept(); } }
                                ],
        onClickRow: ui_ordhedit_orecOnClickRow
    });
}

//结束编辑
function ui_ordhedit_ordcEndEditing() {
    if (ui_ordhedit_editIndex == undefined) { return true }

    if ($('#ui_ordh_edit_ordcdg').datagrid('validateRow', ui_ordhedit_editIndex)) {
        $('#ui_ordh_edit_ordcdg').datagrid('endEdit', ui_ordhedit_editIndex);
        ui_ordhedit_editIndex = undefined;
        return true;
    } else {
        return false;
    }
}

//单击触发编辑
function ui_ordhedit_orecOnClickRow(index) {
    if (ui_ordhedit_addstate == 'Y') {
        $.messager.alert("提示", "存在一笔新增加价资料编辑中,请保存!");
        $('#ui_ordh_edit_ordcdg').datagrid('selectRow', ui_ordhedit_editIndex);
    }
    else {
        if (ui_ordhedit_editIndex != index) {
            if (ui_ordhedit_ordcEndEditing()) {
                $('#ui_ordh_edit_ordcdg').datagrid('selectRow', index)
						.datagrid('beginEdit', index);
                ui_ordhedit_editIndex = index;
                if (ui_ordhedit_addfailed != 'Y'){
                    var cellEdit = $('#ui_ordh_edit_ordcdg').datagrid('getEditor', { index: ui_ordhedit_editIndex, field: 'addid' });
                    var $input = cellEdit.target; // 得到文本框对象
                    $input.combogrid('disable');
                }
            } else {
                $('#ui_ordh_edit_ordcdg').datagrid('selectRow', ui_ordhedit_editIndex);
            }
        }
    }
    ui_ordhedit_addfailed = 'N';
}

//新增
function ui_ordhedit_ordcAdd() {
    if (ui_ordhedit_addstate == 'Y') {
        $.messager.alert("提示", "存在一笔新增加价资料编辑中,请保存!");
    }
    else {
        if (ui_ordhedit_ordcEndEditing()) {
            var chRows = $('#ui_ordh_edit_ordcdg').datagrid('getChanges');
            if (chRows.length > 0){
                $.messager.alert("提示", "当前数据已修改，请先保存!");
            }
            else{
                $('#ui_ordh_edit_ordcdg').datagrid('appendRow', { status: 'P' });
                ui_ordhedit_editIndex = $('#ui_ordh_edit_ordcdg').datagrid('getRows').length - 1;
                $('#ui_ordh_edit_ordcdg').datagrid('selectRow', ui_ordhedit_editIndex)
					    .datagrid('beginEdit', ui_ordhedit_editIndex);
                var factid = $('#ui_ordhedit_factid').combogrid('getValue');
                var ordid = $('#ui_ordhedit_ordid').textbox('getValue');
                $('#ui_ordh_edit_ordcdg').datagrid('getRows')[ui_ordhedit_editIndex]['compid'] = '01';
                $('#ui_ordh_edit_ordcdg').datagrid('getRows')[ui_ordhedit_editIndex]['factid'] = factid;
                $('#ui_ordh_edit_ordcdg').datagrid('getRows')[ui_ordhedit_editIndex]['ordid'] = ordid;
                $('#ui_ordh_edit_ordcdg').datagrid('getRows')[ui_ordhedit_editIndex]['addmoney'] = 0;
                $('#ui_ordh_edit_ordcdg').datagrid('getRows')[ui_ordhedit_editIndex]['rownumber'] = ui_ordhedit_editIndex+1;
                ui_ordhedit_addstate = 'Y';
            }
        }
    }
}

//删除
function ui_ordhedit_orecRemoveit() {
    if (ui_ordhedit_editIndex == undefined) {
        $.messager.alert("提示", "请选中一笔加价资料！");
        return
    }

    if (ui_ordhedit_addstate == 'Y') {
            
        $('#ui_ordh_edit_ordcdg').datagrid('cancelEdit', ui_ordhedit_editIndex)
			.datagrid('deleteRow', ui_ordhedit_editIndex);
        ui_ordhedit_editIndex = undefined;
        ui_ordhedit_addstate = 'N';
        $('#ui_ordh_edit_ordcdg').datagrid('acceptChanges');
        $("#ui_ordh_edit_ordcdg").datagrid("reload").datagrid("clearSelections").datagrid("clearChecked");
    }
    else {
        $.messager.confirm('提示', '确定删除第[' + (ui_ordhedit_editIndex+1).toString() + ']行合同？', function (r) {
            if (r) {
                $('#ui_ordh_edit_ordcdg').datagrid('cancelEdit', ui_ordhedit_editIndex)
			.datagrid('deleteRow', ui_ordhedit_editIndex);

                if ($('#ui_ordh_edit_ordcdg').datagrid('getChanges').length) {
                    var deleted = $('#ui_ordh_edit_ordcdg').datagrid('getChanges', "deleted");
                    var effectRow = new Object();
                    if (deleted.length) {
                        effectRow["deleted"] = JSON.stringify(deleted);
                    }

                    $.post("ashx/bg_ordh.ashx?action=ordcDelete", effectRow, function (data) {
                        if (data.success) {
                            $.messager.alert("提示", "删除成功！");
                            $('#ui_ordh_edit_ordcdg').datagrid('acceptChanges');
                            $('#ui_ordh_edit_ordcdg').datagrid("reload");
                        }
                        else {
                            $.messager.alert("提示", "删除失败！" + data.msg);
                        }
                    }, "JSON").error(function () {
                        $.messager.alert("提示", "提交错误了！");
                    });
                }

                ui_ordhedit_editIndex = undefined;
                ui_ordhedit_addstate = 'N';
                $('#ui_ordh_edit_ordcdg').datagrid('acceptChanges');
            }
        });
    }
}

//保存
function ui_ordhedit_ordcAccept() {
    if (ui_ordhedit_ordcEndEditing()) {
        if ($('#ui_ordh_edit_ordcdg').datagrid('getChanges').length) {
            var inserted = $('#ui_ordh_edit_ordcdg').datagrid('getChanges', "inserted");
            var updated = $('#ui_ordh_edit_ordcdg').datagrid('getChanges', "updated");

            var effectRow = new Object();
            if (inserted.length) {
                effectRow["inserted"] = JSON.stringify(inserted);
            }
            if (updated.length) {
                effectRow["updated"] = JSON.stringify(updated);
            }

            $.post("ashx/bg_ordh.ashx?action=ordcSave", effectRow, function (data) {
                if (data.success) {
                    $.messager.alert("提示", "保存成功！");
                    $('#ui_ordh_edit_ordcdg').datagrid('acceptChanges');
                    $("#ui_ordh_edit_ordcdg").datagrid("reload").datagrid("clearSelections").datagrid("clearChecked");
                    ui_ordhedit_addfailed = 'N';
                }
                else {
                    var msgs = data.msg.split("|");
                    $.messager.alert("提示", "保存失败！" + msgs[0]);
                    //ui_ordhedit_reject();
                    if(msgs[2] == 'Y'){
                        ui_ordhedit_addfailed = 'Y';
                    }
                    ui_ordhedit_orecOnClickRow(msgs[1] - 1);
                    if(msgs[2] == 'Y'){
                        ui_ordhedit_addstate = 'Y';
                    }
                    ui_ordhedit_addfailed = 'N';
                }
            }, "JSON").error(function () {
                $.messager.alert("提示", "提交错误了！");
                ui_ordhedit_reject();
            });
            ui_ordhedit_addstate = 'N';
            ui_ordhedit_addfailed = 'N';
        }
    }
}

//请求addid下拉数据源
function ui_ordhedit_ordcAddidSource(){
    $.ajax({
            url: "ashx/bg_dddw.ashx?action=getAddid",
            type: "post",
            //data: { "factid": factid, "date": date },
            dataType: "json",
            timeout: 5000,
            async: false,
            success: function (data) {
                if (data.success) {
                    ui_ordhedit_addidJson = data.jsondata;
                } else {
                    $.show_warning("错误", data.result);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                if (textStatus == "timeout") {
                    $.show_warning("提示", "请求超时，请刷新当前页重试！");
                }
                else {
                    $.show_warning("错误", textStatus + "：" + errorThrown);
                }
            }
        });
    }

//撤销修改
function ui_ordhedit_reject() {
    $('#ui_ordh_edit_ordcdg').datagrid('rejectChanges');
    ui_ordhedit_editIndex = undefined;
    ui_ordhedit_addstate = undefined;
    ui_ordhedit_addfailed = undefined;
}

//----------------------------------------ordb身档数据模块----------------------------------------
function ui_ordhedit_ordbLoad() {
    //ui_ordhedit_ordcAddidSource();
    var factid = ui_ordh_edit_factid;
    var ordid = ui_ordh_edit_ordid;

    $("#ui_ordh_edit_ordbdg").datagrid({       //初始化datagrid
        url: "ashx/bg_ordh.ashx?action=ordbSearch",
        queryParams: { 'compid': '01', 'factid': factid, 'ordid': ordid },
        striped: true, rownumbers: true, pagination: true, pageSize: 10, singleSelect: true,
        idField: 'stgid',  //这个idField必须指定为输出的id，输出的是Id就必须是Id，不能小写
        sortName: 'stgid',
        sortOrder: 'desc',
        pageList: [10, 20, 40, 60, 80, 100],
        columns: [[
                    { field: 'compid', hidden: true },
                    { field: 'factid', hidden: true },
                    { field: 'ordid', hidden: true },
                    { field: 'stgid', title: '强度', width: 100 },
                    { field: 'uniprice', title: '单价', width: 100, align: "right",
                        formatter: function (value) {
                            return parseFloat(value).toFixed(2);
                        }
                    }
                    ]],
        toolbar: [
                    { text: "添加", iconCls: "icon-add", handler: function () { ui_ordhedit_ordbadd(); } },
                    { text: "修改", iconCls: "icon-edit", handler: function () { ui_ordhedit_ordbedit(); } },
                    { text: "删除", iconCls: "icon-delete", handler: function () { ui_ordhedit_orebDelete(); } }
        ],
        onDblClickRow: function () {
            ui_ordhedit_ordbedit();
        }
    });
}

//添加
function ui_ordhedit_ordbadd() {
    $("<div/>").dialog({
        id: "ui_ordhedit_ordbadd_dialog",
        href: "html/ui_ordh_edit_ordbadd.html",
        title: "添加合同强度",
        height: 350,
        width: 460,
        modal: true,
        buttons: [{
            id: "ui_ordhedit_ordbadd_btn",
            text: '添 加',
            handler: function () {
                $("#ui_ordhedit_ordbadd_form").form("submit", {
                    url: "ashx/bg_ordh.ashx",
                    onSubmit: function (param) {
                        $('#ui_ordhedit_ordbadd_btn').linkbutton('disable');    //点击就禁用按钮，防止连击
                        param.action = 'ordbAdd';
                        if ($(this).form('validate'))
                            return true;
                        else {
                            $('#ui_ordhedit_ordbadd_btn').linkbutton('enable');   //恢复按钮
                            return false;
                        }
                    },
                    success: function (data) {
                        var dataJson = eval('(' + data + ')');    //转成json格式
                        if (dataJson.success) {
                            $("#ui_ordhedit_ordbadd_dialog").dialog('destroy');  //销毁dialog对象
                            $.messager.alert("提示", dataJson.msg);
                            $("#ui_ordh_edit_ordbdg").datagrid("reload").datagrid('clearSelections').datagrid('clearChecked');
                        } else {
                            $('#ui_ordhedit_ordbadd_btn').linkbutton('enable');   //恢复按钮
                            $.messager.alert("提示", dataJson.msg);
                        }
                    }
                });
            }
        }],
        onLoad: function () {
            $("#ui_ordhedit_ordbadd_compid").val('01');
            $("#ui_ordhedit_ordbadd_factid").val(ui_ordh_edit_factid);
            $("#ui_ordhedit_ordbadd_ordid").val(ui_ordh_edit_ordid);
            $("#ui_ordhedit_ordbadd_stgid").focus();
        },
        onClose: function () {
            $("#ui_ordhedit_ordbadd_dialog").dialog('destroy');  //销毁dialog对象
        }
    });
}

//修改
function ui_ordhedit_ordbedit() {
    var row = $("#ui_ordh_edit_ordbdg").datagrid("getSelected");
    if (row == null) {
        $.messager.alert("提示", "请选择强度资料");
        return;
    }

    $("<div/>").dialog({
        id: "ui_ordhedit_ordbedit_dialog",
        href: "html/ui_ordh_edit_ordbedit.html",
        title: "修改合同强度",
        height: 350,
        width: 460,
        modal: true,
        buttons: [{
            id: "ui_ordhedit_ordbedit_btn",
            text: '修 改',
            handler: function () {
                $("#ui_ordhedit_ordbedit_form").form("submit", {
                    url: "ashx/bg_ordh.ashx",
                    onSubmit: function (param) {
                        $('#ui_ordhedit_ordbedit_btn').linkbutton('disable');    //点击就禁用按钮，防止连击
                        param.action = 'ordbEdit';
                        if ($(this).form('validate'))
                            return true;
                        else {
                            $('#ui_ordhedit_ordbedit_btn').linkbutton('enable');   //恢复按钮
                            return false;
                        }
                    },
                    success: function (data) {
                        var dataJson = eval('(' + data + ')');    //转成json格式
                        if (dataJson.success) {
                            $("#ui_ordhedit_ordbedit_dialog").dialog('destroy');  //销毁dialog对象
                            $.messager.alert("提示", dataJson.msg);
                            $("#ui_ordh_edit_ordbdg").datagrid("reload").datagrid('clearSelections').datagrid('clearChecked');
                        } else {
                            $('#ui_ordhedit_ordbedit_btn').linkbutton('enable');   //恢复按钮
                            $.messager.alert("提示", dataJson.msg);
                        }
                    }
                });
            }
        }],
        onLoad: function () {
            $("#ui_ordhedit_ordbedit_compid").val('01');
            $("#ui_ordhedit_ordbedit_factid").val(ui_ordh_edit_factid);
            $("#ui_ordhedit_ordbedit_ordid").val(ui_ordh_edit_ordid);
            $("#ui_ordhedit_ordbedit_stgid2").val(row.stgid);
            $('#ui_ordhedit_ordbedit_stgid').combogrid('setValue', row.stgid);
            $("#ui_ordhedit_ordbedit_uniprice").numberbox('setValue', row.uniprice);
        },
        onClose: function () {
            $("#ui_ordhedit_ordbedit_dialog").dialog('destroy');  //销毁dialog对象
        }
    });
}

//删除
function ui_ordhedit_orebDelete() {
    var row = $("#ui_ordh_edit_ordbdg").datagrid("getSelected");
    if (row == null) {
        $.messager.alert("提示", "请选择强度资料");
        return;
    }
    var rowIndex = $("#ui_ordh_edit_ordbdg").datagrid("getRowIndex", row) + 1;
    $.messager.confirm('提示', '确定删除第[' + rowIndex + ']行合同强度？', function (r) {
        if (r) {
            $.ajax({
                url: "ashx/bg_ordh.ashx?action=ordbDelete",
                data: { "factid": row.factid, "ordid": row.ordid, "stgid": row.stgid },
                type: "POST",
                dataType: "json",
                success: function (data) {
                    if (data.success) {
                        $.messager.alert("提示", data.msg);
                        $("#ui_ordh_edit_ordbdg").datagrid("reload").datagrid('clearSelections').datagrid('clearChecked');
                    } else {
                        $.messager.alert("提示", data.msg);
                    }
                }
            });
        }
    });
}

//----------------------------------------文件上传数据模块----------------------------------------
//文件框初始化
function ui_ordhedit_uploadLoad(){
    $("#ui_ordh_edit_uploaddg").datagrid({       //初始化datagrid
        url: "ashx/bg_ordh.ashx?action=uploadSearch",
        queryParams: { 'compid': '01', 'factid': ui_ordh_edit_factid, 'ordid': ui_ordh_edit_ordid },
        striped: true, rownumbers: true, pagination: true, pageSize: 10, singleSelect: true,
        idField: 'id',  //这个idField必须指定为输出的id，输出的是Id就必须是Id，不能小写
        sortName: 'id',
        sortOrder: 'asc',
        pageList: [10, 20, 40, 60, 80, 100],
        columns: [[
                    { field: 'id', title:'编号', width:100 },
                    { field: 'filename', title:'文件名称', width:100 },
                    { field: 'address', title:'路径', width:300 }
        ]],
        toolbar: [
                    { text: "上传", iconCls: "icon-upload", handler: function () { ui_ordhedit_fileUpload(); } },
                    { text: "下载", iconCls: "icon-download", handler: function () { ui_ordhedit_fileDownload(); } }
        ]
    });
}

//上传文件
function ui_ordhedit_fileUpload() {
    $("<div/>").dialog({
        id: "ui_ordhedit_fileUpload_dialog",
        href: "html/ui_ordh_edit_fileupload.html",
        title: "文件上传",
        height: 350,
        width: 460,
        modal: true,
        buttons: [{
            id: "ui_ordhedit_fileupload_btn",
            text: '上 传',
            handler: function () {
                if( ui_ordhedit_ifOverSize() == "2"){
                    $.messager.alert("提示", "未选择文件");
                    return
                }
                else if(ui_ordhedit_ifOverSize() == "1"){
                    $.messager.alert("提示", "文件大小不可超过10M");
                    return
                }
                
                $("#ui_ordhedit_fileupload_form").form("submit", {
                    url: "ashx/bg_ordh.ashx?loadURL=D:\\RobinXie\\AP_RS_NEW(XIEHUI)\\ZGZY\\WebUI\\",
                    onSubmit: function (param) {
                        $('#ui_ordhedit_fileupload_btn').linkbutton('disable');    //点击就禁用按钮，防止连击
                        param.action = 'fileUpload';
                        if ($(this).form('validate'))
                            return true;
                        else {
                            $('#ui_ordhedit_fileupload_btn').linkbutton('enable');   //恢复按钮
                            return false;
                        }
                    },
                    success: function (data) {
                        var dataJson = eval('(' + data + ')');    //转成json格式
                        if (dataJson.success) {
                            $("#ui_ordhedit_fileUpload_dialog").dialog('destroy');  //销毁dialog对象
                            $.messager.alert("提示", dataJson.msg);
                            $("#ui_ordh_edit_uploaddg").datagrid("reload").datagrid('clearSelections').datagrid('clearChecked');
                        } else {
                            $('#ui_ordhedit_fileupload_btn').linkbutton('enable');   //恢复按钮
                            $.messager.alert("提示", dataJson.msg);
                        }
                    },
                    error: function (error) { alert(error); }
                });
            }
        }],
        onLoad: function () {
            $("#ui_ordhedit_fileupload_compid").val('01');
            $("#ui_ordhedit_fileupload_factid").val(ui_ordh_edit_factid);
            $("#ui_ordhedit_fileupload_ordid").val(ui_ordh_edit_ordid);
        },
        onClose: function () {
            $("#ui_ordhedit_fileUpload_dialog").dialog('destroy');  //销毁dialog对象
        }
    });
}

//下载文件
function ui_ordhedit_fileDownload() {
    var row = $("#ui_ordh_edit_uploaddg").datagrid("getSelected");
    if (row == null) {
        $.messager.alert("提示", "请选中一个文件");
        return;
    }

    var url = window.location.href;
    url = url.substring(0,url.length - 17) + row.address + "/" + row.filename;

    var myrar = window.open(url);
    myrar.document.execCommand("SaveAs");
    //myrar.close();
}

//判断上传文件大小
function ui_ordhedit_ifOverSize() {
    var fileInput = $("input[type='file']");
    if (fileInput[0].files.length > 0){
        if(fileInput[0].files[0].size > 10*1024*1024){
            return "1"
        }
        else{
            return "0"
        }
    }
    else{

        return "2"
    }
}