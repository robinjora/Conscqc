<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cqcp590409.aspx.cs" Inherits="ZGZY.WebUI.admin.aspx.cqcp590409" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <link rel="shortcut icon" type="image/ico" href="../images/favicon.ico" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <link href="../jquery-easyui-1.4.1/themes/bootstrap/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../js/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <!--HighCharts-->
    <script type="text/javascript" src="../js/highcharts.js"></script>
    <script type="text/javascript" src="../js/exporting.js"></script>
    <script type="text/javascript" src="../highcharts/themes/sand-signika.js"></script>
    <script type="text/javascript">
        var ui_cqcp590409_chartfact = "<%=cqcp590409_facts %>".split(",");
        var ui_cqcp590409_chartqty_str = "<%=cqcp590409_qtys %>".split(",");
        var ui_cqcp590409_chartqty_dec = new Array();
        var ui_cqcp590409_pandate = new Array();
        for (var i = 0; i < ui_cqcp590409_chartqty_str.length; i++) {
            ui_cqcp590409_chartqty_dec[i] = parseFloat(ui_cqcp590409_chartqty_str[i]);
            ui_cqcp590409_pandate[i] = [ui_cqcp590409_chartfact[i], ui_cqcp590409_chartqty_dec[i]];
        }
        var ui_cqcp590409_charttype = "<%=cqcp590409_charttype %>";

        $(function () {
            if (ui_cqcp590409_charttype == "1") {
                cqcp590409_chartBar();
            }
            else {
                cqcp590409_chartPan();
            }
        });

        function cqcp590409_chartBar() {
            $('#ui_cqcp590409_chartDiv').highcharts({
                chart: {
                    type: 'bar'
                },
                title: {
                    text: '企业发货比较图表',
                    style: { "fontSize": "18px" }
                },
                xAxis: {
                    categories: ui_cqcp590409_chartfact,
                    title: {
                        text: null
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: '方',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    }
                },
                tooltip: {
                    valueSuffix: ' 方'
                },
                plotOptions: {
                    bar: {
                        dataLabels: {
                            enabled: true
                        }
                    }
                },
                credits: {
                    enabled: false
                },
                series: [{
                    name: '出货量',
                    color: '#7D9EC0',
                    data: ui_cqcp590409_chartqty_dec
                }]
            });
        }

        function cqcp590409_chartPan() {
            $('#ui_cqcp590409_chartDiv').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: '企业发货比较图表'
                },
                tooltip: {
                    //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    formatter: function() {
                        return '<b>'+ this.point.name +'</b>: '+ Highcharts.numberFormat(this.percentage, 1) +'% ('+
                                    Highcharts.numberFormat(this.y, 1, '.') +' 方)';
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: '发货量百分比',
                    data: ui_cqcp590409_pandate
                }]
            });
        }
    </script>
</head>
<body>
    <div class="easyui-layout"  data-options="fit:true,border:false"> 
    <div data-options="region:'center',border:false" style="overflow:hidden;">
            <div id="ui_cqcp590409_chartDiv" style="width:100%; height:100%; overflow:hidden;" >
            </div>
    </div>
    </div>
</body>
</html>
