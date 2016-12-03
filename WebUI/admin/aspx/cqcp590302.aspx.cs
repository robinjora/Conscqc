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
    public partial class cqcp590302 : System.Web.UI.Page
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
            //ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590302.rdlc";

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
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590302();</script>");
        }

        private void Print()
        {
            RDLCPrinter.BillPrint.Run(ReportViewer1.LocalReport);
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname = { "", "", "", "", "", "", "", "", "", "", "", "" };
            string[] sparas = { "", "", "", "", "", "", "", "", "", "", "", "" };

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //企业
            str = Request.Form.GetValues("ui_cqcp590302_factidFilter");
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
            str = Request.Form.GetValues("ui_cqcp590302_begdateFilter");
            sparasname[2] = "@inbegdate";
            string[] datestrs = str[0].Split(new char[] { '-' });
            string strYear = "0000" + datestrs[0];
            string strMonth = "00" + datestrs[1];
            string strDay = "00" + datestrs[2];
            sparas[2] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            str = Request.Form.GetValues("ui_cqcp590302_enddateFilter");
            sparasname[3] = "@inenddate";
            datestrs = str[0].Split(new char[] { '-' });
            strYear = "0000" + datestrs[0];
            strMonth = "00" + datestrs[1];
            strDay = "00" + datestrs[2];
            sparas[3] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            //检测类别
            str = Request.Form.GetValues("ui_cqcp590302_typeFilter");
            sparasname[4] = "@intype";
            if (str != null)
            {
                if (str[0] == "砂检测")
                {
                    sparas[4] = "1";
                }
                else {
                    sparas[4] = str[0];
                }
                if (string.IsNullOrEmpty(sparas[4].Trim()))
                {
                    sparas[4] = "1";
                }
            }
            else
            {
                sparas[4] = "1";
            }

            switch (sparas[4])
            {
                case "1":
                    ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590302.rdlc";
                    break;
                case "2":
                    ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590302_s2.rdlc";
                    break;
                case "3":
                    ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590302_s3.rdlc";
                    break;
                case "4":
                    ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590302_s4.rdlc";
                    break;
                case "5":
                    ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590302_s5.rdlc";
                    break;
                case "6":
                    ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590302_s6.rdlc";
                    break;
                default:
                    break;
            }

            //updid
            sparasname[5] = "@inupdid";
            sparas[5] = "";

            //inmd5
            sparasname[6] = "@inmd5";
            sparas[6] = "";

            //供应商
            str = Request.Form.GetValues("ui_cqcp590302_sac157Filter");
            sparasname[7] = "@insac157";
            if (str != null)
            {
                sparas[7] = str[0];
                if (string.IsNullOrEmpty(sparas[7].Trim()))
                {
                    sparas[7] = "ZZ";
                }
            }
            else
            {
                sparas[7] = "ZZ";
            }

            //品种
            str = Request.Form.GetValues("ui_cqcp590302_mattype2Filter");
            sparasname[8] = "@inmattype2";
            if (str != null)
            {
                sparas[8] = str[0];
                if (string.IsNullOrEmpty(sparas[8].Trim()))
                {
                    sparas[8] = "ZZ";
                }
            }
            else
            {
                sparas[8] = "ZZ";
            }

            //规格
            str = Request.Form.GetValues("ui_cqcp590302_mattype3Filter");
            sparasname[9] = "@inmattype3";
            if (str != null)
            {
                sparas[9] = str[0];
                if (string.IsNullOrEmpty(sparas[9].Trim()))
                {
                    sparas[9] = "ZZ";
                }
            }
            else
            {
                sparas[9] = "ZZ";
            }

            //合格否
            str = Request.Form.GetValues("ui_cqcp590302_resultFilter");
            sparasname[10] = "@inresult";
            if (str != null)
            {
                if (str[0] == "on")
                {
                    sparas[10] = "1";
                }
                else
                {
                    sparas[10] = "ZZ";
                }
            }
            else
            {
                sparas[10] = "ZZ";
            }

            //检测类型
            str = Request.Form.GetValues("ui_cqcp590302_cktypeFilter");
            sparasname[11] = "@incktype";
            if (str != null)
            {
                sparas[11] = str[0];
                if (string.IsNullOrEmpty(sparas[11].Trim()))
                {
                    sparas[11] = "ZZ";
                }
            }
            else
            {
                sparas[11] = "ZZ";
            }

            DataTable dt = new ZGZY.BLL.Report().cqcp590302("sp_cqcp590302_web_new", sparasname, sparas);

            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}