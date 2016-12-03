using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ZGZY.WebUI.admin.QRcode
{
    /// <summary>
    /// QRcodeHandle 的摘要说明
    /// </summary>
    public class QRcodeHandle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["action"];
            string qrCode = context.Request.Params["qrCode"];
            string qrCode2 = context.Request.Params["qrCode2"];
            if (action != "check")
            {
                string chtml = @"<html>
<head>
    <title>质检站二维码验证</title>
    <script src='../jquery-easyui-1.4.1/jquery.min.js' type='text/javascript'></script>
    <script src='../jquery-easyui-1.4.1/jquery.easyui.min.js' type='text/javascript'></script>
    <meta name='viewport' content='width=device-width, initial-scale=1' /> 
    <style type='text/css'>
        .code
        {
            background-color: White;
            font-family: Arial;
            font-style: italic;
            color: Red;
            border: 0;
            padding: 2px 3px;
            letter-spacing: 3px;
            font-weight: bolder;
            cursor: pointer;
            width: 60px;
        }
        .unchanged
        {
            border: 0;
        }
    </style>
    <script type='text/javascript'>
        $(function () {
            createCode();  //创建验证码
        })

        function checkClick() {
            if (checkInput()) {
                window.location=  window.location.href + '&action=check';
                //window.location='http://192.168.100.160/NTXH2/admin/QRCode/QRcodeHandle.ashx?qrCode=" + 
                qrCode + "&qrCode2=" + qrCode2 + @"&action=check';
            }
        }

        //创建验证码
        var code;
        function createCode() {
            code = '';
            var codeLength = 4;     //验证码长度   
            var qrCode_checkCode = document.getElementById('qrCode_checkCode');
            var selectChar = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            for (var i = 0; i < codeLength; i++) {
                var charIndex = Math.floor(Math.random() * 10);
                code += selectChar[charIndex];
            }
            if (qrCode_checkCode) {
                qrCode_checkCode.className = 'code';
                qrCode_checkCode.value = code;
                //$('#qrCode_VfCode').val(code);   //自动填写验证码
            }
        }

        //检查验证码
        function checkInput() {
            if ($.trim($('#qrCode_VfCode').val()) == '') {
                $('#qrCode_msg').val('验证码不能为空!');
                $('#qrCode_VfCode').val('').focus();
                return false;
            }
            else if (document.getElementById('qrCode_VfCode').value.toUpperCase() != code) {
                $('#qrCode_msg').val('验证码错误！');
                $('#qrCode_VfCode').val('').focus();
                createCode();       //刷新验证码
                return false;
            } else {
                $('#loginBtn').linkbutton('disable');
                return true;
            }
        }

        //刷新验证码
        function reflash(){
            createCode();
            $('#qrCode_VfCode').val('').focus();
        }
    </script>
</head>
<body>
    <form id='qrCodeFrm' method='post'>
        <table>
                <tr>
                    <th colspan='2' align='left'>
                        请输入验证码：
                    </th>
                </tr>
                <tr>
                    <td>
                        <input type='text' id='qrCode_VfCode' autocomplete='off' style='width:80px;' />
                    </td>
                    <td>
                        <input type='text' id='qrCode_checkCode' readonly='readonly' class='unchanged' />
                    </td>
                </tr>
                <tr>
                    <td colspan='2'>
                        <input type='text' id='qrCode_msg' style='border-style: none; color:Red;' readonly='readonly' />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type='button' value='刷新验证码' onclick='reflash();'/>
                    </td>
                    <td>
                        <input type='button' value='提交' onclick='checkClick();' />
                    </td>
                </tr>
        </table>
    </form>
</body>
</html>";

                context.Response.ContentType = "text/html";
                context.Response.Write(chtml);
            }
            else
            {
                //生成验证结果页面
                StringBuilder html = new StringBuilder();
                html.Append(@"<html>
                                <head>
                                <title>质检站二维码验证</title>
                                <meta name='viewport' content='width=device-width, initial-scale=1' /> 
                                </head>
                                <body  style='height: 100%;wight: 100%'>");

                byte ASC3 = (byte)Convert.ToChar(qrCode.Substring(2, 1));
                byte ASC5 = (byte)Convert.ToChar(qrCode.Substring(4, 1));
                byte ASC6 = (byte)Convert.ToChar(qrCode.Substring(5, 1));
                byte ASC10 = (byte)Convert.ToChar(qrCode.Substring(9, 1));
                string stringASC = ASC3.ToString() + ASC5.ToString() + ASC6.ToString() + ASC10.ToString();

                if (stringASC == qrCode2)
                {
                    string result = new ZGZY.BLL.QRcode().ConfirmQRcode(qrCode);
                    
                    if (result == "none")
                    {
                        html.Append(@"<img width=‘40px' height='40px' alt='' src='../images/qrCodeN.png' />
                        <label style='font-size:25px;font-weight: bold;'>验证失败！</label>");
                    }
                    else
                    {
                        string[] results = result.Split(new char[] { '|' });

                        html.Append(@"<img width=‘40px' height='40px' alt='' src='../images/qrCodeY.png' />
                        <label style='font-size:25px;font-weight: bold;'>验证成功！</label><br>
                        <table>
                        <tr><th style='width:80px'>企业名称：</th>
                            <td><label>" + results[0] + "</label></td></tr>" +
                        @"<tr><th>供应日期：</th>
                            <td><label>" + results[1] + "</label></td></tr>" +
                        @"<tr><th>购货单位：</th>
                            <td><label>" + results[2] + "</label></td></tr>" +
                        @"<tr><th>工程名称：</th>
                            <td><label>" + results[3] + "</label></td></tr>" +
                        @"<tr><th>施工部位：</th>
                            <td><label>" + results[4] + "</label></td></tr>" +
                        @"<tr><th>强度等级：</th>
                            <td><label>" + results[5] + "</label></td></tr>" +
                        @"<tr><th>供应数量：</th>
                            <td><label>" + results[6] + "(m3)</label></td></tr><table>");
                    }
                    
                }
                else
                {
                    html.Append(@"<img width=‘40px' height='40px' src='../images/qrCodeR.png' />
                        <label style='font-size:25px;font-weight: bold;'>验证提交异常！</label>");
                }

                html.Append("</body></html>");

                context.Response.ContentType = "text/html";
                context.Response.Write(html);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}