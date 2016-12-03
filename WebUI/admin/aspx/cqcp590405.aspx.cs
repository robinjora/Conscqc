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

namespace ZGZY.WebUI.admin.aspx
{
    public partial class cqcp590405 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }

        private void ShowReport()
        {
            ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590405.rdlc";

            DataTable dt = GetData();

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();

            //关闭加载提示
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590405();</script>");
        }

        private void Print()
        {
            RDLCPrinter.BillPrint.Run(ReportViewer1.LocalReport);
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname = { "", "", "", "", "", "", "" };
            string[] sparas = { "", "", "", "", "", "", "" };

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //企业
            str = Request.Form.GetValues("ui_cqcp590405_factidFilter");
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
            str = Request.Form.GetValues("ui_cqcp590405_begdateFilter");
            sparasname[2] = "@inbegdate";
            string[] datestrs = str[0].Split(new char[] { '-' });
            string strYear = "0000" + datestrs[0];
            string strMonth = "00" + datestrs[1];
            string strDay = "00" + datestrs[2];
            sparas[2] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);


            str = Request.Form.GetValues("ui_cqcp590405_enddateFilter");
            sparasname[3] = "@inenddate";
            datestrs = str[0].Split(new char[] { '-' });
            strYear = "0000" + datestrs[0];
            strMonth = "00" + datestrs[1];
            strDay = "00" + datestrs[2];
            sparas[3] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);


            //排序
            str = Request.Form.GetValues("ui_cqcp590405_sortFilter");
            sparasname[4] = "@insort";
            if (str != null)
            {
                sparas[4] = str[0];
                if (string.IsNullOrEmpty(sparas[4].Trim()))
                {
                    sparas[4] = "1";
                }
            }
            else
            {
                sparas[4] = "1";
            }

            //用户
            sparasname[5] = "@inuserid";
            HttpContext _context = HttpContext.Current;
            ZGZY.Model.User user = ZGZY.Common.UserHelper.GetUser(_context);   //获取cookie里的用户对象
            sparas[5] = user.UserId; ;

            //机别
            str = Request.Form.GetValues("ui_cqcp590405_bujinoFilter");
            sparasname[6] = "@inbujino";
            if (str != null)
            {
                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        sparas[6] = sparas[6] + str[i] + "|";
                    }
                }
            }
            else
            {
                sparas[6] = "ZZ";
            }


            DataTable dt = new ZGZY.BLL.Report().cqcp590405("sp_cqcp590405_web_new", sparasname, sparas);

            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}