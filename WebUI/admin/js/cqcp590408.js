
    // JScript 文件
    var factid1 = "30|";
    var factid2 = "31|";
    var factid3 = "32|";
    var factid4 = "33|";
    var factid5 = "34|";
    var factid6 = "35|";
    var factid7 = "36|";
    var factid8 = "37|";
    var factid9 = "38|";
    var factid10 = "39|";
    var factid11 = "3A|";
    var factid12 = "3B|";
    var factid13 = "3C|";
    var factid14 = "3D|";
    $(function () {
        show();
    });

    function show() {
        showPanel(factid1, "p1");
    }

    function showSum() {
        var tdate = new Date();
        var yy_tdate = tdate.getFullYear();
        var mm_tdate = tdate.getMonth() + 1;
        var dd_tdate = tdate.getDate();
        var datestr = yy_tdate + '-' + (mm_tdate < 10 ? '0' + mm_tdate : mm_tdate) + '-' + (dd_tdate < 10 ? '0' + dd_tdate : dd_tdate);
        var monthstr = yy_tdate + '-' + (mm_tdate < 10 ? '0' + mm_tdate : mm_tdate);

        $("#sumddate").text(datestr);
        $("#sumdmonth").text(monthstr);

        $.ajax({
            url: "ashx/bg_chart.ashx?action=getSum",
            type: "post",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (data) {
                $("#sumddqty").text(Math.round(data.dayqty));
                $("#sumdmqty").text(Math.round(data.monqty));
            }
        });
    }

    function showPanel(factid, pname) {
        $.ajax({
            url: "ashx/bg_chart.ashx?action=getfact",
            type: "post",
            data: { "factid": factid },
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (data) {
                $('#' + pname).panel({ title: data.factname.toString() });
                //厂状态标识（factstate）
                if (data.factstate.toString() == '√') {
                    //$('#p1').panel({iconCls:'icon-accept'});
                    $('#' + pname).css("background", "#458B74");
                    $('#' + pname + 's').css("background", "#ccffcc");
                }
                else {
                    //$('#p1').panel({iconCls:'icon-exclamation'});
                    $('#' + pname).css("background", "#B22222");
                    $('#' + pname + 's').css("background", "#ffa07a");
                    $('#' + pname + 'b1').css("background", "#ffa07a");
                    $('#' + pname + 'b2').css("background", "#ffa07a");
                    $('#' + pname + 'b3').css("background", "#ffa07a");
                }
                $("#" + pname + "sdqty").text(Math.round(data.factdayqty));
                $("#" + pname + "smqty").text(Math.round(data.factmonqty));


                //1号机
                if (data.bujino1.toString() == '1') {
                    $('#' + pname + 'b1table').css("visibility", "visible");
                    $('#' + pname + 'b1').panel({ title: '1号机' });
                    if (data.bujistate1.toString() == '√') {
                        $('#' + pname + 'b1').panel({ iconCls: 'icon-stop_green' });
                        $('#' + pname + 'b1').css("background", "#ccffcc");
                    }
                    else {
                        $('#' + pname + 'b1').panel({ iconCls: 'icon-stop_red' });
                        $('#' + pname + 'b1').css("background", "#ffa07a");
                    }
                    $("#" + pname + "b1dqty").text(Math.round(data.bujidayqty1));
                    $("#" + pname + "b1mqty").text(Math.round(data.bujimonqty1));
                }
                else {
                    $('#' + pname + 'b1table').css("visibility", "hidden")
                }

                //2号机
                if (data.bujino2.toString() == '2') {
                    $('#' + pname + 'b2table').css("visibility", "visible")
                    $('#' + pname + 'b2').panel({ title: '2号机' });
                    if (data.bujistate2.toString() == '√') {
                        $('#' + pname + 'b2').panel({ iconCls: 'icon-stop_green' });
                        $('#' + pname + 'b2').css("background", "#ccffcc");
                    }
                    else {
                        $('#' + pname + 'b2').panel({ iconCls: 'icon-stop_red' });
                        $('#' + pname + 'b2').css("background", "#ffa07a");
                    }
                    $("#" + pname + "b2dqty").text(Math.round(data.bujidayqty2));
                    $("#" + pname + "b2mqty").text(Math.round(data.bujimonqty2));
                }
                else {
                    $('#' + pname + 'b2table').css("visibility", "hidden")
                }

                //3号机
                if (data.bujino3.toString() == '3') {
                    $('#' + pname + 'b3table').css("visibility", "visible")
                    $('#' + pname + 'b3').panel({ title: '3号机' });
                    if (data.bujistate3.toString() == '√') {
                        $('#' + pname + 'b3').panel({ iconCls: 'icon-stop_green' });
                        $('#' + pname + 'b3').css("background", "#ccffcc");
                    }
                    else {
                        $('#' + pname + 'b3').panel({ iconCls: 'icon-stop_red' });
                        $('#' + pname + 'b3').css("background", "#ffa07a");
                    }
                    $("#" + pname + "b3dqty").text(Math.round(data.bujidayqty3));
                    $("#" + pname + "b3mqty").text(Math.round(data.bujimonqty3));
                }
                else {
                    $('#' + pname + 'b3table').css("visibility", "hidden")
                }
            }
        });
    }