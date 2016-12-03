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
    public partial class cqcp590301 : System.Web.UI.Page
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
            ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590301.rdlc";

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
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590301();</script>");
        }

        private void Print()
        {
            RDLCPrinter.BillPrint.Run(ReportViewer1.LocalReport);
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname = { "", "", "", "", "", "", "", "", "", "" };
            string[] sparas = { "", "", "", "", "", "", "", "", "", "" };

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //企业
            str = Request.Form.GetValues("ui_cqcp590301_factidFilter");
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
            str = Request.Form.GetValues("ui_cqcp590301_begdateFilter");
            sparasname[2] = "@inbegdate";
            string[] datestrs = str[0].Split(new char[] { '-' });
            string strYear = "0000" + datestrs[0];
            string strMonth = "00" + datestrs[1];
            string strDay = "00" + datestrs[2];
            sparas[2] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            str = Request.Form.GetValues("ui_cqcp590301_enddateFilter");
            sparasname[3] = "@inenddate";
            datestrs = str[0].Split(new char[] { '-' });
            strYear = "0000" + datestrs[0];
            strMonth = "00" + datestrs[1];
            strDay = "00" + datestrs[2];
            sparas[3] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            //工程名称
            str = Request.Form.GetValues("ui_cqcp590301_engnameFilter");
            sparasname[4] = "@inst0112";
            if (str != null)
            {
                sparas[4] = str[0];
                if (string.IsNullOrEmpty(sparas[4].Trim()))
                {
                    sparas[4] = "zzzzzzzzzz";
                }
            }
            else
            {
                sparas[4] = "zzzzzzzzzz";
            }

            //强度
            str = Request.Form.GetValues("ui_cqcp590301_strengthFilter");
            sparasname[5] = "@instrength";
            if (str != null)
            {
                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        sparas[5] = sparas[5] + str[i] + "|";
                    }
                }
            }
            else
            {
                sparas[5] = "ZZ";
            }

            //配比
            str = Request.Form.GetValues("ui_cqcp590301_formulaidFilter");
            sparasname[6] = "@informulaid";
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

            //龄期
            str = Request.Form.GetValues("ui_cqcp590301_daysFilter");
            sparasname[7] = "@indays";
            if (str != null)
            {
                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        sparas[7] = sparas[7] + str[i] + "|";
                    }
                }
            }
            else
            {
                sparas[7] = "ZZ";
            }

            //日期类型
            str = Request.Form.GetValues("ui_cqcp590301_typeFilter");
            sparasname[8] = "@intype";
            if (str != null)
            {
                sparas[8] = str[0];
                if (string.IsNullOrEmpty(sparas[8].Trim()))
                {
                    sparas[8] = "1";
                }
            }
            else
            {
                sparas[8] = "1";
            }

            //updid
            sparasname[9] = "@inupdid";
            sparas[9] = "";

            DataTable dt = new ZGZY.BLL.Report().cqcp590301("sp_cqcp590301_web_new", sparasname, sparas);

            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}