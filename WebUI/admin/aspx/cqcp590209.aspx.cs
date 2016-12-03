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
    public partial class cqcp590209 : System.Web.UI.Page
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
            ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590209.rdlc";

            DataTable dt = GetData();

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();

            //关闭加载提示
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590209();</script>");
        }

        private void Print()
        {
            RDLCPrinter.BillPrint.Run(ReportViewer1.LocalReport);
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            string[] sparas = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //企业
            str = Request.Form.GetValues("ui_cqcp590209_factidFilter");
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

            //证明书编号
            str = Request.Form.GetValues("ui_cqcp590209_shipidFilter");
            sparasname[2] = "@inshipid";
            if (str != null)
            {
                sparas[2] = str[0];
                if (string.IsNullOrEmpty(sparas[2].Trim()))
                {
                    sparas[2] = "zzzzzzzzzz";
                }
            }
            else
            {
                sparas[2] = "zzzzzzzzzz";
            }

            //日期
            str = Request.Form.GetValues("ui_cqcp590209_begdateFilter");
            sparasname[3] = "@inbegdate";
            string[] datestrs = str[0].Split(new char[] { '-' });
            string strYear = "0000" + datestrs[0];
            string strMonth = "00" + datestrs[1];
            string strDay = "00" + datestrs[2];
            sparas[3] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            str = Request.Form.GetValues("ui_cqcp590209_enddateFilter");
            sparasname[4] = "@inenddate";
            datestrs = str[0].Split(new char[] { '-' });
            strYear = "0000" + datestrs[0];
            strMonth = "00" + datestrs[1];
            strDay = "00" + datestrs[2];
            sparas[4] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);


            //混凝土标记
            str = Request.Form.GetValues("ui_cqcp590209_specFilter");
            sparasname[5] = "@inspec";
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

            //购货单位
            sparasname[6] = "@incustname";
            sparas[6] = "zzzzzzzzzz";

            //工程名称
            str = Request.Form.GetValues("ui_cqcp590209_engnameFilter");
            sparasname[7] = "@inengname";
            if (str != null)
            {
                sparas[7] = str[0];
                if (string.IsNullOrEmpty(sparas[7].Trim()))
                {
                    sparas[7] = "zzzzzzzzzz";
                }
            }
            else
            {
                sparas[7] = "zzzzzzzzzz";
            }

            //不用
            sparasname[8] = "@inworkpart";
            sparas[8] = "zzzzzzzzzz";

            //差异量关系
            str = Request.Form.GetValues("ui_cqcp590209_typeFilter");
            sparasname[9] = "@intype";
            if (str != null)
            {
                sparas[9] = str[0];
                if (string.IsNullOrEmpty(sparas[9].Trim()))
                {
                    sparas[9] = "0";
                }
            }
            else
            {
                sparas[9] = "0";
            }

            //组合关系
            str = Request.Form.GetValues("ui_cqcp590209_relationFilter");
            sparasname[10] = "@inrelation";
            if (str != null)
            {
                sparas[10] = str[0];
                if (string.IsNullOrEmpty(sparas[10].Trim()))
                {
                    sparas[10] = "1";
                }
            }
            else
            {
                sparas[10] = "1";
            }

            //差异比关系
            str = Request.Form.GetValues("ui_cqcp590209_type2Filter");
            sparasname[11] = "@intype2";
            if (str != null)
            {
                sparas[11] = str[0];
                if (string.IsNullOrEmpty(sparas[11].Trim()))
                {
                    sparas[11] = "0";
                }
            }
            else
            {
                sparas[11] = "0";
            }

            //差异比
            str = Request.Form.GetValues("ui_cqcp590209_ph18percentFilter");
            sparasname[12] = "@inph18percent";
            if (str != null)
            {
                sparas[12] = str[0];
                if (string.IsNullOrEmpty(sparas[12].Trim()))
                {
                    sparas[12] = "0";
                }
            }
            else
            {
                sparas[12] = "0";
            }

            //差异量
            str = Request.Form.GetValues("ui_cqcp590209_ph18Filter");
            sparasname[13] = "@inph18";
            if (str != null)
            {
                sparas[13] = str[0];
                if (string.IsNullOrEmpty(sparas[13].Trim()))
                {
                    sparas[13] = "0";
                }
            }
            else
            {
                sparas[13] = "0";
            }

            //泵送否
            str = Request.Form.GetValues("ui_cqcp590209_pondFilter");
            sparasname[14] = "@inpond";
            if (str != null)
            {
                sparas[14] = str[0];
                if (string.IsNullOrEmpty(sparas[14].Trim()))
                {
                    sparas[14] = "zzzzzzzzzz";
                }
            }
            else
            {
                sparas[14] = "zzzzzzzzzz";
            }

            sparasname[15] = "@inupdid";
            sparas[15] = "";

            sparasname[16] = "@inmd5";
            sparas[16] = "";

            DataTable dt = new ZGZY.BLL.Report().cqcp590209("sp_cqcp590209_web_new", sparasname, sparas);

            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}