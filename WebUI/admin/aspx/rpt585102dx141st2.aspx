﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rpt585102dx141st2.aspx.cs" Inherits="ZGZY.WebUI.admin.aspx.rpt585102dx141st2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <link rel="shortcut icon" type="image/ico" href="../images/favicon.ico" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <link href="../themes/bootstrap/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../js/easyui-lang-zh_CN.js" type="text/javascript"></script>
   <%-- <script type="text/javascript">
        function bodyResize() {
            document.getElementById("ReportViewer1").style.height = (document.getElementById("robintest").clientHeight - 35).toString() + "px";
        }
    </script>--%>
</head>
<%--<body id="robintest" scroll="no" style="overflow:hidden" onload="bodyResize()" onresize="bodyResize();">   --%> 
<body>
    <div class="easyui-layout"  data-options="fit:true,border:false"> 
    <div data-options="region:'center',border:false">
        <form id="Form1" runat="server">
            <%--查询结果--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" Height="100%"
                SizeToReportContent="true" 
                WaitMessageFont-Size="14pt">
            </rsweb:ReportViewer>
            <%--打印按钮--%>
            <div style="visibility:hidden;">
                <asp:Button ID="btn_print" runat="server" Text="Button" onclick="btn_print_Click" />
            </div>
        </form>
    </div>
    </div>
</body>
</html>

