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
    public partial class rpt585202dx141 : System.Web.UI.Page
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
            ReportViewer1.LocalReport.ReportPath = "admin\\report\\rpt585202dx141.rdlc";

            DataTable dt = GetData();

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            //参数传递
            string[] str;
            str = Request.Form.GetValues("ui_rpt585202dx141_yymmFilter");
            string ls_yymm = str[0];
            ReportParameter p1 = new ReportParameter("inyymm", ls_yymm);
            ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

            ReportViewer1.LocalReport.Refresh();

            //关闭加载提示
            Response.Write("<script type='text/javascript'>top.dclose_rpt585202dx141();</script>"); 
        }

        private void Print()
        {
            RDLCPrinter.BillPrint.Run(ReportViewer1.LocalReport);
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname;
            string[] sparas;
            sparasname = new string[25];
            sparas = new string[25];

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //查询年月
            sparasname[1] = "@inyymm";
            str = Request.Form.GetValues("ui_rpt585202dx141_yymmFilter");
            string[] datestrs = str[0].Split(new char[] { '-' });
            string strYear = "0000" + datestrs[0];
            string strMonth = "00" + datestrs[1];
            sparas[1] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2);

            //客户类别
            sparasname[2] = "@incusttype";
            sparas[2] = "ZZ";

            //客户代号
            sparasname[3] = "@incustid";
            sparas[3] = "ZZ";

            //合同代号
            sparasname[4] = "@inordh12";
            sparas[4] = "ZZ";

            //结案否
            sparasname[5] = "@inclosed";
            str = Request.Form.GetValues("ui_rpt585202dx141_rdltypeFilter");
            sparas[5] = str[0];

            //合同类别
            sparasname[6] = "@inordtype";
            str = Request.Form.GetValues("ui_rpt585202dx141_ordtypeFilter");
            sparas[6] = str[0];

            //报表别
            sparasname[7] = "@intype";
            sparas[7] = "1";

            //企业
            sparasname[8] = "@infactid";
            str = Request.Form.GetValues("ui_rpt585202dx141_factidFilter");
            if (str != null)
            {
                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        sparas[8] = sparas[8] + str[i] + "|";
                    }
                }
            }
            else
            {
                sparas[8] = "ZZ";
            }

            //业务员代号
            sparasname[9] = "@inempid";
            sparas[9] = "ZZ";

            //当月方量
            sparasname[10] = "@inyymmqty";
            sparas[10] = "0";

            //当月金额
            sparasname[11] = "@inyymmamt";
            sparas[11] = "0";

            //收款进度
            sparasname[12] = "@inljqty";
            sparas[12] = "0";

            //累计方量
            sparasname[13] = "@inljamt";
            sparas[13] = "0";

            //累计金额
            sparasname[14] = "@inljowamt";
            sparas[14] = "0";

            //累计欠款
            sparasname[15] = "@inproper";
            sparas[15] = "0";

            //工程名称模糊
            sparasname[16] = "@inordh12a";
            str = Request.Form.GetValues("ui_rpt585202dx141_ordh12Filter");
            if (str != null)
            {
                sparas[16] = str[0];
                if (string.IsNullOrEmpty(sparas[16].Trim()))
                {
                    sparas[16] = "ZZ";
                }
            }
            else
            {
                sparas[16] = "ZZ";
            }


            //客户模糊
            sparasname[17] = "@incustname";
            str = Request.Form.GetValues("ui_rpt585202dx141_custidFilter");
            if (str != null)
            {
                sparas[17] = str[0];
                if (string.IsNullOrEmpty(sparas[17].Trim()))
                {
                    sparas[17] = "ZZ";
                }
            }
            else
            {
                sparas[17] = "ZZ";
            }

            //业务员模糊
            sparasname[18] = "@inbegname";
            str = Request.Form.GetValues("ui_rpt585202dx141_empidFilter");
            if (str != null)
            {
                sparas[18] = str[0];
                if (string.IsNullOrEmpty(sparas[18].Trim()))
                {
                    sparas[18] = "ZZ";
                }
            }
            else
            {
                sparas[18] = "ZZ";
            }
            
            sparasname[19] = "@inuser";
            sparas[19] = "admin";

            //合同代号new
            sparasname[20] = "@inordid";
            str = Request.Form.GetValues("ui_rpt585202dx141_ordidFilter");
            if (str != null)
            {
                sparas[20] = str[0];
                if (string.IsNullOrEmpty(sparas[20].Trim()))
                {
                    sparas[20] = "ZZ";
                }
            }
            else
            {
                sparas[20] = "ZZ";
            }    

            //收款进度new
            sparasname[21] = "@inskjdMark";
            str = Request.Form.GetValues("ui_rpt585202dx141_skjdMarkFilter");
            sparas[21] = str[0];

            sparasname[22] = "@inskjdAmt";
            str = Request.Form.GetValues("ui_rpt585202dx141_skjdAmtFilter");
            if (str != null)
            {
                sparas[22] = str[0];
                if (string.IsNullOrEmpty(sparas[22].Trim()))
                {
                    sparas[22] = "999999";
                }
            }
            else
            {
                sparas[22] = "999999";
            }

            //累计欠款new
            sparasname[23] = "@inljqkMark";
            str = Request.Form.GetValues("ui_rpt585202dx141_ljqkMarkFilter");
            sparas[23] = str[0];

            sparasname[24] = "@inljqkAmt";
            str = Request.Form.GetValues("ui_rpt585202dx141_ljqkAmtFilter");
            if (str != null)
            {
                sparas[24] = str[0];
                if (string.IsNullOrEmpty(sparas[24].Trim()))
                {
                    sparas[24] = "999999";
                }
            }
            else
            {
                sparas[24] = "999999";
            }    

            DataTable dt = new ZGZY.BLL.Report().rpt585202dx141("sp_webp585202_dx141_new", sparasname, sparas);
            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }

    }
}