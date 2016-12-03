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
    public partial class cqcp590407 : System.Web.UI.Page
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
            ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590407.rdlc";

            DataTable dt = GetData();

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();

            //关闭加载提示
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590407();</script>");
        }

        private void Print()
        {
            RDLCPrinter.BillPrint.Run(ReportViewer1.LocalReport);
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname = { "", "", "", "", "", "" };
            string[] sparas = { "", "", "", "", "", "" };

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //企业
            str = Request.Form.GetValues("ui_cqcp590407_factidFilter");
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
            str = Request.Form.GetValues("ui_cqcp590407_begdateFilter");
            sparasname[2] = "@inbegdatetime";
            sparas[2] = str[0];

            str = Request.Form.GetValues("ui_cqcp590407_enddateFilter");
            sparasname[3] = "@inenddatetime";
            sparas[3] = str[0];

            //强度
            str = Request.Form.GetValues("ui_cqcp590407_minFilter");
            sparasname[4] = "@inmin";
            if (str != null)
            {
                sparas[4] = str[0];
                if (string.IsNullOrEmpty(sparas[4].Trim()))
                {
                    sparas[4] = "0";
                }
            }
            else
            {
                sparas[4] = "0";
            }

            sparasname[5] = "@inuserid";
            HttpContext _context = HttpContext.Current;
            ZGZY.Model.User user = ZGZY.Common.UserHelper.GetUser(_context);   //获取cookie里的用户对象
            sparas[5] = user.UserId; ;

            DataTable dt = new ZGZY.BLL.Report().cqcp590407("sp_cqcp590407_web_new", sparasname, sparas);

            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}