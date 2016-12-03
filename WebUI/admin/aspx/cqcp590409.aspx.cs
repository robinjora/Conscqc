using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using RDLCPrinter;
using System.Web.Services;
using System.Collections;

namespace ZGZY.WebUI.admin.aspx
{
    public partial class cqcp590409 : System.Web.UI.Page
    {
        public string cqcp590409_facts = "";
        public string cqcp590409_qtys = "";
        public string cqcp590409_charttype = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }

        private void ShowReport()
        {
            DataTable dt = GetData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    cqcp590409_facts = dt.Rows[i]["factname"].ToString();
                    cqcp590409_qtys = dt.Rows[i]["qty"].ToString();
                }
                else
                {
                    cqcp590409_facts = cqcp590409_facts + "," + dt.Rows[i]["factname"].ToString();
                    cqcp590409_qtys = cqcp590409_qtys + "," + dt.Rows[i]["qty"].ToString();
                }
            }

            //关闭加载提示
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590409();</script>");
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname = { "", "", "", "", "" };
            string[] sparas = { "", "", "", "", "" };

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //企业
            str = Request.Form.GetValues("ui_cqcp590409_factidFilter");
            sparasname[1] = "@infactid";
            if (str != null)
            {
                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        sparas[1] = sparas[1] + str[i] + "|";
                    }
                }
            }
            else
            {
                sparas[1] = "ZZ";
            }

            //日期
            str = Request.Form.GetValues("ui_cqcp590409_begdateFilter");
            sparasname[2] = "@inbegdate";
            string[] datestrs = str[0].Split(new char[] { '-' });
            string strYear = "0000" + datestrs[0];
            string strMonth = "00" + datestrs[1];
            string strDay = "00" + datestrs[2];
            sparas[2] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);


            str = Request.Form.GetValues("ui_cqcp590409_enddateFilter");
            sparasname[3] = "@inenddate";
            datestrs = str[0].Split(new char[] { '-' });
            strYear = "0000" + datestrs[0];
            strMonth = "00" + datestrs[1];
            strDay = "00" + datestrs[2];
            sparas[3] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            //用户
            sparasname[4] = "@inuserid";
            HttpContext _context = HttpContext.Current;
            ZGZY.Model.User user = ZGZY.Common.UserHelper.GetUser(_context);   //获取cookie里的用户对象
            sparas[4] = user.UserId; ;

            str = Request.Form.GetValues("ui_cqcp590409_typeFilter");
            cqcp590409_charttype = str[0];

            DataTable dt = new ZGZY.BLL.Report().cqcp590409("sp_cqcp590409_web_new", sparasname, sparas);

            return dt;
        }
    }
}