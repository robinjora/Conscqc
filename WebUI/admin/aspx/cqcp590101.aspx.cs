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
    public partial class cqcp590101 : System.Web.UI.Page
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
            ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590101.rdlc";

            DataTable dt = GetData();

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            //参数传递
            //string[] str;
            //str = Request.Form.GetValues("ui_rpt585102dx141_factidFilter");
            //string infactid;
            //if (str != null)
            //{
            //    infactid = str[0];
            //}
            //else
            //{
            //    infactid = "ZZ";
            //}

            //str = Request.Form.GetValues("ui_rpt585102dx141_dateFilter");
            //string insdate = str[0];

            //ReportParameter p1 = new ReportParameter("incompid", "01");
            //ReportParameter p2 = new ReportParameter("infactid", infactid);
            //ReportParameter p3 = new ReportParameter("insdate", insdate);
            //ReportParameter p4 = new ReportParameter("inuser", "admin");
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });

            ReportViewer1.LocalReport.Refresh();

            //关闭加载提示
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590101();</script>");
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
            str = Request.Form.GetValues("ui_cqcp590101_factidFilter");
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

            //职位
            str = Request.Form.GetValues("ui_cqcp590101_posidFilter");
            sparasname[2] = "@inposid";
            if (str != null)
            {
                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        sparas[2] = sparas[2] + str[i] + "|";
                    }
                }
            }
            else
            {
                sparas[2] = "ZZ";
            }

            //姓名
            str = Request.Form.GetValues("ui_cqcp590101_empnameFilter");
            sparasname[3] = "@inempname";
            if (str != null)
            {
                sparas[3] = str[0];
                if (string.IsNullOrEmpty(sparas[3].Trim()))
                {
                    sparas[3] = "zzzzzzzzzz";
                }
            }
            else
            {
                sparas[3] = "zzzzzzzzzz";
            }

            //updid
            sparasname[4] = "@inupdid";
            sparas[4] = "";

            //身份证号
            str = Request.Form.GetValues("ui_cqcp590101_identitynoFilter");
            sparasname[5] = "@inidentityno";
            if (str != null)
            {
                sparas[5] = str[0];
                if (string.IsNullOrEmpty(sparas[5].Trim()))
                {
                    sparas[5] = "zzzzzzzzzz";
                }
            }
            else
            {
                sparas[5] = "zzzzzzzzzz";
            }

            //上岗证号
            str = Request.Form.GetValues("ui_cqcp590101_emp60Filter");
            sparasname[6] = "@inemp60";
            if (str != null)
            {
                sparas[6] = str[0];
                if (string.IsNullOrEmpty(sparas[6].Trim()))
                {
                    sparas[6] = "zzzzzzzzzz";
                }
            }
            else
            {
                sparas[6] = "zzzzzzzzzz";
            }

            DataTable dt = new ZGZY.BLL.Report().cqcp590101("sp_cqcp590101_web_new", sparasname, sparas);

            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}