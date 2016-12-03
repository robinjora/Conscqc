using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ZGZY.WebUI.admin.ashx
{
    /// <summary>
    /// bg_chart 的摘要说明
    /// </summary>
    public class bg_chart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string action = context.Request.Params["action"];
            string factid = context.Request.Params["factid"];

            try
            {
                ZGZY.Model.User user = ZGZY.Common.UserHelper.GetUser(context);   //获取cookie里的用户对象
                string userid = user.UserId;

                switch (action)
                {
                    case "getChartMonth":
                        string monArr = new ZGZY.BLL.Chart().GetChartMonth();
                        context.Response.Write(monArr);
                        break;
                    case "getChartFact":
                        string monFact = new ZGZY.BLL.Chart().GetChartFact();
                        context.Response.Write(monFact);
                        break;
                    case "getChart1Data":
                        string strData1 = new ZGZY.BLL.Chart().GetChart1Data();
                        context.Response.Write(strData1);
                        break;
                    case "getChart2Data":
                        string strData2 = new ZGZY.BLL.Chart().GetChart2Data();
                        context.Response.Write(strData2);
                        break;
                    case "getfact":
                        string data = new ZGZY.BLL.Chart().cqcp590408GetData(factid, userid);
                        context.Response.Write(data);
                        break;
                    case "getSum":
                        string sdate = new ZGZY.BLL.Chart().cqcp590408GetSum(userid);
                        context.Response.Write(sdate);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"msg\":\"" + ZGZY.Common.JsonHelper.StringFilter(ex.Message) + "\",\"success\":false}");
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