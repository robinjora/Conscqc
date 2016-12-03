using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ZGZY.WebUI.admin.ashx
{
    /// <summary>
    /// bg_dddw 的摘要说明
    /// </summary>
    public class bg_dddw : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string action = context.Request.Params["action"];
            string key = context.Request.Params["q"];
            try
            {
                ZGZY.Model.User user = ZGZY.Common.UserHelper.GetUser(context);   //获取cookie里的用户对象
                string userid = user.UserId;
                switch (action)
                {
                    case "getFactory":
                        string where = " and facusing = '1' and factid in (select factid from apuserpriority where id= '" + userid + "')";
                        string strJson = new ZGZY.BLL.Dddw().GetDwFactory(where);
                        context.Response.Write(strJson);
                        break;
                    case "getSpec":
                        string strJsonSpec = new ZGZY.BLL.Dddw().GetDwSpec("spec like '" + key + "%'");
                        context.Response.Write(strJsonSpec);
                        break;
                    case "getStrength":
                        string strJsonStrength = new ZGZY.BLL.Dddw().GetDwStrength("strength like '" + key + "%'");
                        context.Response.Write(strJsonStrength);
                        break;
                    case "getDays":
                        string strJsonDays = new ZGZY.BLL.Dddw().GetDwDays();
                        context.Response.Write(strJsonDays);
                        break;
                    case "getOrdtype":
                        string strJsonOrdtype = new ZGZY.BLL.Dddw().GetDwOrdtype(null);
                        context.Response.Write(strJsonOrdtype);
                        break;
                    case "getOrdid":
                        string strJsonOrdid = new ZGZY.BLL.Dddw().GetDwOrdid("ordh12 like '%" + key + "%'");
                        context.Response.Write(strJsonOrdid);
                        break;
                    case "getBujino":
                        string strJsonBujino = new ZGZY.BLL.Dddw().GetDwBujino();
                        context.Response.Write(strJsonBujino);
                        break;
                    case "getPosid":
                        string strJsonPosid = new ZGZY.BLL.Dddw().GetDwPosid();
                        context.Response.Write(strJsonPosid);
                        break;
                    case "getSubcategory":
                        string strJsonSubcategoryid = new ZGZY.BLL.Dddw().GetDwSubcategory();
                        context.Response.Write(strJsonSubcategoryid);
                        break;
                    case "getAddid":
                        string strJsonAddid = new ZGZY.BLL.Dddw().GetDwAddid("addid like '%" + key + "%'");
                        //context.Response.Write("{\"jsondata\":" + strJsonAddid + ",\"success\":true}");
                        context.Response.Write(strJsonAddid);
                        break;
                    case "getCustid":
                        string strJsonCustid = new ZGZY.BLL.Dddw().GetDwCustid("custid like '%" + key + "%'");
                        context.Response.Write(strJsonCustid);
                        break;
                    case "getEmpid":
                        string strJsonEmpid = new ZGZY.BLL.Dddw().GetDwEmpid("empid like '%" + key + "%'");
                        context.Response.Write(strJsonEmpid);
                        break;
                    default:
                        context.Response.Write("{\"msg\":\"参数错误！\",\"success\":false}");
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