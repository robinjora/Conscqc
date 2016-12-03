﻿using System;
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
    public partial class cqcp590205 : System.Web.UI.Page 
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
            ReportViewer1.LocalReport.ReportPath = "admin\\report\\cqcp590205.rdlc";

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
            Response.Write("<script type='text/javascript'>top.dclose_cqcp590205();</script>");
        }

        private void Print()
        {
            RDLCPrinter.BillPrint.Run(ReportViewer1.LocalReport);
        }

        private DataTable GetData()
        {
            //-----获取查询条件------
            string[] str;
            string[] sparasname = { "", "", "", "", "", "", "", "", "" };
            string[] sparas = { "", "", "", "", "", "", "", "", "" };

            sparasname[0] = "@incompid";
            sparas[0] = "01";

            //企业
            str = Request.Form.GetValues("ui_cqcp590205_factidFilter");
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

            //工程名称
            str = Request.Form.GetValues("ui_cqcp590205_ordh12Filter");
            sparasname[2] = "@inordh12";
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
            str = Request.Form.GetValues("ui_cqcp590205_begdateFilter");
            sparasname[3] = "@inbegdate";
            string[] datestrs = str[0].Split(new char[] { '-' });
            string strYear = "0000" + datestrs[0];
            string strMonth = "00" + datestrs[1];
            string strDay = "00" + datestrs[2];
            sparas[3] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            str = Request.Form.GetValues("ui_cqcp590205_enddateFilter");
            sparasname[4] = "@inenddate";
            datestrs = str[0].Split(new char[] { '-' });
            strYear = "0000" + datestrs[0];
            strMonth = "00" + datestrs[1];
            strDay = "00" + datestrs[2];
            sparas[4] = strYear.Substring(strYear.Length - 4, 4) + strMonth.Substring(strMonth.Length - 2, 2) + strDay.Substring(strDay.Length - 2, 2);

            //合同备案号
            str = Request.Form.GetValues("ui_cqcp590205_ordidFilter");
            sparasname[5] = "@inordid";
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

            //updid
            sparasname[6] = "@inupdid";
            sparas[6] = "";

            //是否到期
            str = Request.Form.GetValues("ui_cqcp590205_daoqiFilter");
            sparasname[7] = "@indaoqi";
            if (str != null)
            {
                if (str[0] == "on")
                {
                    sparas[7] = "Y";
                }
                else
                {
                    sparas[7] = "N";
                }
            }
            else
            {
                sparas[7] = "N";
            }

            //百分比
            str = Request.Form.GetValues("ui_cqcp590205_percentFilter");
            sparasname[8] = "@inpercent";
            if (str != null)
            {
                sparas[8] = str[0];
                if (string.IsNullOrEmpty(sparas[8].Trim()))
                {
                    sparas[8] = "0";
                }
            }
            else
            {
                sparas[8] = "0";
            }

            DataTable dt = new ZGZY.BLL.Report().cqcp590205("sp_cqcp590205_web_new", sparasname, sparas);

            return dt;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}