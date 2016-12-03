using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Data;
using ZGZY.Common;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace ZGZY.WebUI.admin.ashx
{
    /// <summary>
    /// 合同头档操作
    /// </summary>
    public class bg_ordh : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //System.Web.Configuration.HttpRuntimeSection hrs = new System.Web.Configuration.HttpRuntimeSection();
            //if (context.Request.ContentLength > (hrs.MaxRequestLength * 1024))
            //{
            //    context.Response.Write("{\"msg\":\"文件不存在！\",\"success\":false}");
            //    return;
            //}
            context.Response.ContentType = "application/json";
            string action = context.Request.Params["action"];
            ZGZY.Model.User userFromCookie = ZGZY.Common.UserHelper.GetUser(context);
            string userId = userFromCookie.UserId;
            try
            {
                switch (action)
                {
                    case "ordhSearch":
                        string strWhere = "1=1";
                        /*基本参数*/
                        string sort = context.Request.Params["sort"];  //排序列
                        string order = context.Request.Params["order"];  //排序方式 asc或者desc
                        int pageindex = int.Parse(context.Request.Params["page"]);
                        int pagesize = int.Parse(context.Request.Params["rows"]);
                        /*查询条件*/
                        string ui_ordh_ordh12 = context.Request.Params["ui_ordh_ordh12"] ?? "";
                        if (ui_ordh_ordh12.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(ui_ordh_ordh12))   //防止sql注入
                            strWhere += string.Format(" and ordh12 like '%{0}%'", ui_ordh_ordh12.Trim());

                        int totalCount;   //输出参数
                        string strJson = new ZGZY.BLL.Ordh().GetPager("ordh", "factid,ordid,ordh12,orddate", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                        context.Response.Write("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");
                        break;
                    case "ordcSearch":
                        string ordcSearch_strWhere = "1=1";
                        string ordcSearch_sort = context.Request.Params["sort"];  //排序列
                        string ordcSearch_order = context.Request.Params["order"];  //排序方式 asc或者desc
                        int ordcSearch_pageindex = int.Parse(context.Request.Params["page"]);
                        int ordcSearch_pagesize = int.Parse(context.Request.Params["rows"]);

                        string ordcSearch_compid = context.Request.Params["compid"] ?? "";
                        string ordcSearch_factid = context.Request.Params["factid"] ?? "";
                        string ordcSearch_ordid = context.Request.Params["ordid"] ?? "";

                        if (ordcSearch_compid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(ordcSearch_compid))   //防止sql注入
                            ordcSearch_strWhere += string.Format(" and compid = '{0}'", ordcSearch_compid.Trim());
                        if (ordcSearch_factid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(ordcSearch_factid))
                            ordcSearch_strWhere += string.Format(" and factid = '{0}'", ordcSearch_factid.Trim());
                        if (ordcSearch_ordid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(ordcSearch_ordid))
                            ordcSearch_strWhere += string.Format(" and ordid = '{0}'", ordcSearch_ordid.Trim());

                        int ordcSearch_totalCount;   //输出参数
                        decimal ordcSearch_sumValue;
                        string ordcSearch_strJson = new ZGZY.BLL.Ordc().GetPagerNewFooter("ordc",
                            "compid,factid,ordid,addid,addmoney,memo,useing,addname,rownumber",
                            ordcSearch_sort + " " + ordcSearch_order, ordcSearch_pagesize, ordcSearch_pageindex, ordcSearch_strWhere,
                            @"compid,factid,ordid,addid,addmoney,memo,useing,
                        (select addname from t_add where t_add.addid = ordc.addid) as addname,
                        (row_number() over (order by " + ordcSearch_sort + " " + ordcSearch_order + ")) as rownumber ",
                            out ordcSearch_totalCount, "addmoney", out ordcSearch_sumValue);
                        //string ordcSearch_strJson = new ZGZY.BLL.Ordc().GetPager("ordc", "compid,factid,ordid,addid,addmoney,memo,useing", ordcSearch_sort + " " + ordcSearch_order, ordcSearch_pagesize, ordcSearch_pageindex, ordcSearch_strWhere, out ordcSearch_totalCount);
                        if (string.IsNullOrEmpty(ordcSearch_sumValue.ToString()))
                        {
                            ordcSearch_sumValue = 0;
                        }

                        string ordcSearchFooter_strJson = "[{\"addid\":\"合计\", \"addmoney\":" + ordcSearch_sumValue + ", \"useing\":\"S\"}]";
                        //string ordcSearchFooter_strJson = "[{\"addid\":\"合计\", \"addmoney\":10, \"useing\":\"S\"}]";

                        context.Response.Write("{\"total\": " + ordcSearch_totalCount.ToString() + ",\"rows\":" + ordcSearch_strJson + ",\"footer\":" + ordcSearchFooter_strJson + "}");
                        //context.Response.Write("{\"total\": " + ordcSearch_totalCount.ToString() + ",\"rows\":" + ordcSearch_strJson + "}");

                        break;
                    case "ordbSearch":
                        string ordbSearch_strWhere = "1=1";
                        string ordbSearch_sort = context.Request.Params["sort"];  //排序列
                        string ordbSearch_order = context.Request.Params["order"];  //排序方式 asc或者desc
                        int ordbSearch_pageindex = int.Parse(context.Request.Params["page"]);
                        int ordbSearch_pagesize = int.Parse(context.Request.Params["rows"]);

                        string ordbSearch_compid = context.Request.Params["compid"] ?? "";
                        string ordbSearch_factid = context.Request.Params["factid"] ?? "";
                        string ordbSearch_ordid = context.Request.Params["ordid"] ?? "";

                        if (ordbSearch_compid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(ordbSearch_compid))   //防止sql注入
                            ordbSearch_strWhere += string.Format(" and compid = '{0}'", ordbSearch_compid.Trim());
                        if (ordbSearch_factid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(ordbSearch_factid))
                            ordbSearch_strWhere += string.Format(" and factid = '{0}'", ordbSearch_factid.Trim());
                        if (ordbSearch_ordid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(ordbSearch_ordid))
                            ordbSearch_strWhere += string.Format(" and ordid = '{0}'", ordbSearch_ordid.Trim());

                        int ordbSearch_totalCount;   //输出参数
                        string ordbSearch_strJson = new ZGZY.BLL.Ordb().GetPager("ordb", "compid,factid,ordid,stgid,uniprice",
                            ordbSearch_sort + " " + ordbSearch_order, ordbSearch_pagesize, ordbSearch_pageindex, ordbSearch_strWhere, out ordbSearch_totalCount);

                        context.Response.Write("{\"total\": " + ordbSearch_totalCount.ToString() + ",\"rows\":" + ordbSearch_strJson + "}");

                        break;
                    case "getNewOrdid":
                        string getNewOrdid_factid = context.Request.Params["factid"] ?? "99";
                        string getNewOrdid_date = context.Request.Params["date"] ?? "0000";
                        string[] getNewOrdid_dates = getNewOrdid_date.Split('-');
                        string getNewOrdid_date_yy = "0000" + getNewOrdid_dates[0];
                        string getNewOrdid_date_mm = "00" + getNewOrdid_dates[1];
                        getNewOrdid_date = getNewOrdid_date_yy.Substring(getNewOrdid_date_yy.Length - 2) +
                                            getNewOrdid_date_mm.Substring(getNewOrdid_date_mm.Length - 2);
                        string getNewOrdid_ordid = new ZGZY.BLL.Ordh().GetNewOrdid(getNewOrdid_factid, getNewOrdid_date);
                        context.Response.Write("{\"newordid\": \"" + getNewOrdid_ordid + "\",\"success\":true}");
                        break;
                    case "getOrdhById":
                        string getOrdhById_factid = context.Request.Params["factid"] ?? "";
                        string getOrdhById_ordid = context.Request.Params["ordid"] ?? "";
                        ZGZY.Model.ordh ordhEt = new Model.ordh();
                        ordhEt = new ZGZY.BLL.Ordh().GetOrdhById("01", getOrdhById_factid, getOrdhById_ordid);

                        string getOrdhById_orddate = ordhEt.orddate.Substring(0, 4) + "-" + ordhEt.orddate.Substring(4, 2) + "-" + ordhEt.orddate.Substring(6, 2);
                        string getOrdhById_ordh12 = ordhEt.ordh12 ?? "";
                        decimal getOrdhById_maxqty = ordhEt.maxqty ?? 0;
                        string getOrdhById_custid = ordhEt.custid ?? "";
                        string getOrdhById_empid = ordhEt.empid ?? "";
                        string getOrdhById_ordh33 = ordhEt.ordh33 ?? "";
                        context.Response.Write("{\"factid\": \"" + ordhEt.factid.ToString() + "\"," +
                                                "\"ordid\": \"" + ordhEt.ordid.ToString() + "\"," +
                                                "\"orddate\": \"" + getOrdhById_orddate + "\"," +
                                                "\"ordh12\": \"" + getOrdhById_ordh12 + "\"," +
                                                "\"maxqty\": \"" + getOrdhById_maxqty.ToString() + "\"," +
                                                "\"custid\": \"" + getOrdhById_custid + "\"," +
                                                "\"empid\": \"" + getOrdhById_empid + "\"," +
                                                "\"ordh33\": \"" + getOrdhById_ordh33 + "\"," +
                                                "\"success\":true}");

                        break;
                    case "ordhAdd":
                        string ui_ordhedit_factid_add = context.Request.Params["ui_ordhedit_factid"] ?? "";
                        string ui_ordhedit_ordid_add = context.Request.Params["ui_ordhedit_ordid"] ?? "";
                        string ui_ordhedit_orddate_add = context.Request.Params["ui_ordhedit_orddate"] ?? "";
                        string ui_ordhedit_ordh12_add = context.Request.Params["ui_ordhedit_ordh12"] ?? "";
                        string[] ui_ordhedit_orddate_adds = ui_ordhedit_orddate_add.Split('-');
                        string ui_ordhedit_orddate_add_yy = "0000" + ui_ordhedit_orddate_adds[0];
                        string ui_ordhedit_orddate_add_mm = "00" + ui_ordhedit_orddate_adds[1];
                        string ui_ordhedit_orddate_add_dd = "00" + ui_ordhedit_orddate_adds[2];
                        ui_ordhedit_orddate_add = ui_ordhedit_orddate_add_yy.Substring(ui_ordhedit_orddate_add_yy.Length - 4) +
                                                    ui_ordhedit_orddate_add_mm.Substring(ui_ordhedit_orddate_add_mm.Length - 2) +
                                                    ui_ordhedit_orddate_add_dd.Substring(ui_ordhedit_orddate_add_dd.Length - 2);
                        decimal ui_ordhedit_maxqty_add = decimal.Parse(context.Request.Params["ui_ordhedit_maxqty"] ?? "0");
                        string ui_ordhedit_custid_add = context.Request.Params["ui_ordhedit_custid"] ?? "";
                        string ui_ordhedit_empid_add = context.Request.Params["ui_ordhedit_empid"] ?? "";
                        string ui_ordhedit_ordh33_add = "";
                        if (context.Request.Params["ui_ordhedit_ordh33"] == "on")
                        {
                            ui_ordhedit_ordh33_add = "Y";
                        }
                        else
                        {
                            ui_ordhedit_ordh33_add = "N";
                        }

                        ZGZY.Model.ordh ordhAdd = new Model.ordh();
                        ordhAdd.compid = "01";
                        ordhAdd.factid = ui_ordhedit_factid_add;
                        ordhAdd.ordid = ui_ordhedit_ordid_add.Trim();
                        ordhAdd.orddate = ui_ordhedit_orddate_add.Trim();
                        ordhAdd.ordh12 = ui_ordhedit_ordh12_add.Trim();
                        ordhAdd.maxqty = ui_ordhedit_maxqty_add;
                        ordhAdd.custid = ui_ordhedit_custid_add;
                        ordhAdd.empid = ui_ordhedit_empid_add;
                        ordhAdd.ordh33 = ui_ordhedit_ordh33_add;
                        ordhAdd.updid = userId;
                        ordhAdd.updtime = DateTime.Now;

                        new ZGZY.BLL.Ordh().AddBeforeSave(ordhAdd);  //数据验证
                        new ZGZY.BLL.Ordh().BeforeSave(ordhAdd);

                        int ordidadd = new ZGZY.BLL.Ordh().AddOrdh(ordhAdd);
                        if (ordidadd > 0)
                        {
                            context.Response.Write("{\"msg\":\"新增成功！\",\"success\":true}");
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"新增失败！\",\"success\":false}");
                        }

                        break;
                    case "ordhEdit":
                        string ui_ordhedit_factid_edit = context.Request.Params["ui_ordhedit_factid"] ?? "";
                        string ui_ordhedit_ordid_edit = context.Request.Params["ui_ordhedit_ordid"] ?? "";
                        string ui_ordhedit_orddate_edit = context.Request.Params["ui_ordhedit_orddate"] ?? "";
                        string ui_ordhedit_ordh12_edit = context.Request.Params["ui_ordhedit_ordh12"] ?? "";
                        string[] ui_ordhedit_orddate_edits = ui_ordhedit_orddate_edit.Split('-');
                        string ui_ordhedit_orddate_edit_yy = "0000" + ui_ordhedit_orddate_edits[0];
                        string ui_ordhedit_orddate_edit_mm = "00" + ui_ordhedit_orddate_edits[1];
                        string ui_ordhedit_orddate_edit_dd = "00" + ui_ordhedit_orddate_edits[2];
                        ui_ordhedit_orddate_edit = ui_ordhedit_orddate_edit_yy.Substring(ui_ordhedit_orddate_edit_yy.Length - 4) +
                                                    ui_ordhedit_orddate_edit_mm.Substring(ui_ordhedit_orddate_edit_mm.Length - 2) +
                                                    ui_ordhedit_orddate_edit_dd.Substring(ui_ordhedit_orddate_edit_dd.Length - 2);
                        decimal ui_ordhedit_maxqty_edit = decimal.Parse(context.Request.Params["ui_ordhedit_maxqty"] ?? "0");
                        string ui_ordhedit_custid_edit = context.Request.Params["ui_ordhedit_custid"] ?? "";
                        string ui_ordhedit_empid_edit = context.Request.Params["ui_ordhedit_empid"] ?? "";
                        string ui_ordhedit_ordh33_edit = "";
                        if (context.Request.Params["ui_ordhedit_ordh33"] == "on")
                        {
                            ui_ordhedit_ordh33_edit = "Y";
                        }
                        else
                        {
                            ui_ordhedit_ordh33_edit = "N";
                        }

                        ZGZY.Model.ordh ordhEdit = new Model.ordh();
                        ordhEdit.compid = "01";
                        ordhEdit.factid = ui_ordhedit_factid_edit.Trim();
                        ordhEdit.ordid = ui_ordhedit_ordid_edit.Trim();
                        ordhEdit.orddate = ui_ordhedit_orddate_edit.Trim();
                        ordhEdit.ordh12 = ui_ordhedit_ordh12_edit.Trim();
                        ordhEdit.maxqty = ui_ordhedit_maxqty_edit;
                        ordhEdit.custid = ui_ordhedit_custid_edit;
                        ordhEdit.empid = ui_ordhedit_empid_edit;
                        ordhEdit.ordh33 = ui_ordhedit_ordh33_edit;
                        ordhEdit.updid = userId;
                        ordhEdit.updtime = DateTime.Now;

                        new ZGZY.BLL.Ordh().BeforeSave(ordhEdit);    //数据验证

                        bool ordidupdate = new ZGZY.BLL.Ordh().EditOrdh(ordhEdit);
                        if (ordidupdate)
                        {
                            context.Response.Write("{\"msg\":\"修改成功！\",\"success\":true}");
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"修改失败！\",\"success\":false}");
                        }

                        break;
                    case "ordhDelete":
                        string ui_ordhedit_compid_delete = "01";
                        string ui_ordhedit_factid_delete = context.Request.Params["factid"] ?? "";
                        string ui_ordhedit_ordid_delete = context.Request.Params["ordid"] ?? "";
                        if (new ZGZY.BLL.Ordh().DeleteOrdh(ui_ordhedit_compid_delete, ui_ordhedit_factid_delete, ui_ordhedit_ordid_delete))
                        {
                            context.Response.Write("{\"msg\":\"删除成功！\",\"success\":true}");
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"删除失败！\",\"success\":false}");
                        }
                        break;
                    case "ordcSave":
                        string inserted = context.Request.Form["inserted"];
                        string updated = context.Request.Form["updated"];

                        if (updated != null)
                        {
                            List<Model.ordc> ordcupds = new List<Model.ordc>();
                            //POCO test robinxie 20151010
                            List<Model.ordc> ordcTransUpd2 = JsonDeserialize<List<Model.ordc>>(updated);
                            //List<ordcTrans> ordcTransUpd = JsonDeserialize<List<ordcTrans>>(updated);

                            //foreach (ordcTrans ordctrans in ordcTransUpd)
                            foreach (Model.ordc ordctrans in ordcTransUpd2)
                            {
                                Model.ordc ordcupd = new Model.ordc();
                                ordcupd.compid = ordctrans.compid;
                                ordcupd.factid = ordctrans.factid;
                                ordcupd.ordid = ordctrans.ordid;
                                ordcupd.addid = ordctrans.addid;
                                ordcupd.addmoney = ordctrans.addmoney;
                                ordcupd.useing = ordctrans.useing;
                                ordcupd.memo = ordctrans.memo;
                                ordcupd.updid = userId;
                                ordcupd.updtime = ordctrans.updtime;
                                new ZGZY.BLL.Ordc().BeforeSave(ordcupd, ordctrans.rownumber);
                            }

                            //foreach (ordcTrans ordctrans in ordcTransUpd)
                            foreach (Model.ordc ordctrans in ordcTransUpd2)
                            {
                                Model.ordc ordcupd = new Model.ordc();
                                ordcupd.compid = ordctrans.compid;
                                ordcupd.factid = ordctrans.factid;
                                ordcupd.ordid = ordctrans.ordid;
                                ordcupd.addid = ordctrans.addid;
                                ordcupd.addmoney = ordctrans.addmoney;
                                ordcupd.useing = ordctrans.useing;
                                ordcupd.memo = ordctrans.memo;
                                ordcupd.updid = userId;
                                ordcupd.updtime = ordctrans.updtime;
                                bool ordcedit = new ZGZY.BLL.Ordc().EditOrdc(ordcupd);
                                if (!ordcedit)
                                {
                                    context.Response.Write("{\"msg\":\"修改失败！\",\"success\":false}");
                                    break;
                                }
                            }
                        }

                        if (inserted != null)
                        {
                            List<Model.ordc> ordcinss = new List<Model.ordc>();
                            List<ordcTrans> ordcTransIns = JsonDeserialize<List<ordcTrans>>(inserted);

                            foreach (ordcTrans ordctrans in ordcTransIns)
                            {
                                Model.ordc ordcins = new Model.ordc();
                                ordcins.compid = ordctrans.compid;
                                ordcins.factid = ordctrans.factid;
                                ordcins.ordid = ordctrans.ordid;
                                ordcins.addid = ordctrans.addid;
                                ordcins.addmoney = ordctrans.addmoney;
                                ordcins.useing = ordctrans.useing;
                                ordcins.memo = ordctrans.memo;
                                ordcins.updid = userId;
                                ordcins.updtime = ordctrans.updtime;
                                new ZGZY.BLL.Ordc().AddBeforeSave(ordcins, ordctrans.rownumber);
                                int ordcadd = new ZGZY.BLL.Ordc().AddOrdc(ordcins);
                                if (ordcadd <= 0)
                                {
                                    context.Response.Write("{\"msg\":\"新增失败！\",\"success\":false}");
                                    break;
                                }
                            }
                        }

                        context.Response.Write("{\"msg\":\"保存成功！\",\"success\":true}");
                        break;
                    case "ordcDelete":
                        string deleted = context.Request.Form["deleted"];

                        if (deleted != null)
                        {
                            List<Model.ordc> ordcdels = new List<Model.ordc>();
                            List<ordcTrans> ordcTransDel = JsonDeserialize<List<ordcTrans>>(deleted);

                            foreach (ordcTrans ordctrans in ordcTransDel)
                            {
                                bool ordceIsdel = new ZGZY.BLL.Ordc().DeleteOrdc(ordctrans.compid, ordctrans.factid, ordctrans.ordid, ordctrans.addid);
                                if (!ordceIsdel)
                                {
                                    context.Response.Write("{\"msg\":\"删除失败！\",\"success\":false}");
                                    break;
                                }
                            }
                        }

                        context.Response.Write("{\"msg\":\"删除成功！\",\"success\":true}");
                        break;
                    case "ordbAdd":
                        string ui_ordhedit_ordbadd_compid = context.Request.Params["ui_ordhedit_ordbadd_compid"] ?? "";
                        string ui_ordhedit_ordbadd_factid = context.Request.Params["ui_ordhedit_ordbadd_factid"] ?? "";
                        string ui_ordhedit_ordbadd_ordid = context.Request.Params["ui_ordhedit_ordbadd_ordid"] ?? "";
                        string ui_ordhedit_ordbadd_stgid = context.Request.Params["ui_ordhedit_ordbadd_stgid"] ?? "";
                        decimal ui_ordhedit_ordbadd_uniprice = decimal.Parse(context.Request.Params["ui_ordhedit_ordbadd_uniprice"] ?? "0");

                        ZGZY.Model.ordb ordbAdd = new Model.ordb();
                        ordbAdd.compid = ui_ordhedit_ordbadd_compid.Trim();
                        ordbAdd.factid = ui_ordhedit_ordbadd_factid.Trim();
                        ordbAdd.ordid = ui_ordhedit_ordbadd_ordid.Trim();
                        ordbAdd.stgid = ui_ordhedit_ordbadd_stgid.Trim();
                        ordbAdd.uniprice = ui_ordhedit_ordbadd_uniprice;
                        ordbAdd.updid = userId;
                        ordbAdd.updtime = DateTime.Now;

                        int ifordbAdd = new ZGZY.BLL.Ordb().AddOrdb(ordbAdd);
                        if (ifordbAdd > 0)
                        {
                            context.Response.Write("{\"msg\":\"新增成功！\",\"success\":true}");
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"新增失败！\",\"success\":false}");
                        }
                        break;
                    case "ordbDelete":
                        //string ui_ordhedit_ordbdelete_compid = context.Request.Params["ui_ordhedit_ordbadd_compid"] ?? "";
                        string ui_ordhedit_ordbdelete_compid = "01";
                        string ui_ordhedit_ordbdelete_factid = context.Request.Params["factid"] ?? "";
                        string ui_ordhedit_ordbdelete_ordid = context.Request.Params["ordid"] ?? "";
                        string ui_ordhedit_ordbdelete_stgid = context.Request.Params["stgid"] ?? "";
                        if (new ZGZY.BLL.Ordb().DeleteOrdb(ui_ordhedit_ordbdelete_compid, ui_ordhedit_ordbdelete_factid, ui_ordhedit_ordbdelete_ordid, ui_ordhedit_ordbdelete_stgid))
                        {
                            context.Response.Write("{\"msg\":\"删除成功！\",\"success\":true}");
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"删除失败！\",\"success\":false}");
                        }
                        break;
                    case "ordbEdit":
                        string ui_ordhedit_ordbedit_compid = "01";
                        string ui_ordhedit_ordbedit_factid = context.Request.Params["ui_ordhedit_ordbedit_factid"] ?? "";
                        string ui_ordhedit_ordbedit_ordid = context.Request.Params["ui_ordhedit_ordbedit_ordid"] ?? "";
                        string ui_ordhedit_ordbedit_stgid = context.Request.Params["ui_ordhedit_ordbedit_stgid2"] ?? "";
                        decimal ui_ordhedit_ordbedit_uniprice = decimal.Parse(context.Request.Params["ui_ordhedit_ordbedit_uniprice"] ?? "0");

                        ZGZY.Model.ordb ordbEdit = new Model.ordb();
                        ordbEdit.compid = ui_ordhedit_ordbedit_compid.Trim();
                        ordbEdit.factid = ui_ordhedit_ordbedit_factid.Trim();
                        ordbEdit.ordid = ui_ordhedit_ordbedit_ordid.Trim();
                        ordbEdit.stgid = ui_ordhedit_ordbedit_stgid.Trim();
                        ordbEdit.uniprice = ui_ordhedit_ordbedit_uniprice;

                        bool ifordbedit = new ZGZY.BLL.Ordb().EditOrdb(ordbEdit);
                        if (ifordbedit)
                        {
                            context.Response.Write("{\"msg\":\"修改成功！\",\"success\":true}");
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"修改失败！\",\"success\":false}");
                        }
                        break;
                    case "uploadSearch":
                        string uploadSearch_strWhere = "1=1";
                        string uploadSearch_sort = context.Request.Params["sort"];  //排序列
                        string uploadSearch_order = context.Request.Params["order"];  //排序方式 asc或者desc
                        int uploadSearch_pageindex = int.Parse(context.Request.Params["page"]);
                        int uploadSearch_pagesize = int.Parse(context.Request.Params["rows"]);

                        string uploadSearch_compid = context.Request.Params["compid"] ?? "";
                        string uploadSearch_factid = context.Request.Params["factid"] ?? "";
                        string uploadSearch_ordid = context.Request.Params["ordid"] ?? "";

                        if (uploadSearch_compid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(uploadSearch_compid))   //防止sql注入
                            uploadSearch_strWhere += string.Format(" and compid = '{0}'", uploadSearch_compid.Trim());
                        if (uploadSearch_factid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(uploadSearch_factid))
                            uploadSearch_strWhere += string.Format(" and factid = '{0}'", uploadSearch_factid.Trim());
                        if (uploadSearch_ordid.Trim() != "" && !ZGZY.Common.SqlInjection.GetString(uploadSearch_ordid))
                            uploadSearch_strWhere += string.Format(" and ordid = '{0}'", uploadSearch_ordid.Trim());

                        int uploadSearch_totalCount;   //输出参数
                        string uploadSearch_strJson = new ZGZY.BLL.Ordb().GetPager("fileupload", "id,filename,address",
                            uploadSearch_sort + " " + uploadSearch_order, uploadSearch_pagesize, uploadSearch_pageindex, uploadSearch_strWhere, out uploadSearch_totalCount);

                        context.Response.Write("{\"total\": " + uploadSearch_totalCount.ToString() + ",\"rows\":" + uploadSearch_strJson + "}");

                        break;
                    case "fileUpload":
                        HttpFileCollection httpFileCollection = context.Request.Files;
                        HttpPostedFile file = null;
                        string ui_ordhedit_fileUpload_compid = context.Request.Params["ui_ordhedit_fileupload_compid"] ?? "";
                        string ui_ordhedit_fileUpload_factid = context.Request.Params["ui_ordhedit_fileupload_factid"] ?? "";
                        string ui_ordhedit_fileUpload_ordid = context.Request.Params["ui_ordhedit_fileupload_ordid"] ?? "";
                        string ui_ordhedit_fileUpload_filename = context.Request.Params["ui_ordh_edit_fileupload_filename"] ?? "";
                        string ui_ordhedit_fileUpload_address = "/LoadFiles/" + ui_ordhedit_fileUpload_factid + "/" + ui_ordhedit_fileUpload_ordid;
                        string ui_ordhedit_fileUpload_url = context.Request.Params["loadURL"] ?? "";
                        if (httpFileCollection.Count > 0)
                            file = httpFileCollection[0];
                        if (file != null)
                        {
                            //if (file.ContentLength > 10485760)
                            //{
                            //    context.Response.Write("{\"msg\":\"文件大小不可超过10MB！\",\"success\":false}");
                            //}
                            //else
                            //{
                            try
                            {
                                ordhSaveFile(ui_ordhedit_fileUpload_url + ui_ordhedit_fileUpload_address, file.FileName, file);
                                //数据库存档
                                ZGZY.Model.fileupload fileUpload = new Model.fileupload();
                                fileUpload.compid = ui_ordhedit_fileUpload_compid;
                                fileUpload.factid = ui_ordhedit_fileUpload_factid;
                                fileUpload.ordid = ui_ordhedit_fileUpload_ordid;
                                fileUpload.filename = ui_ordhedit_fileUpload_filename;
                                fileUpload.address = ui_ordhedit_fileUpload_address;
                                int iffileUpload = new ZGZY.BLL.FileUpload().AddFileUpload(fileUpload);
                                if (iffileUpload > 0)
                                {
                                    context.Response.Write("{\"msg\":\"上传成功！\",\"success\":true}");
                                }
                                else
                                {
                                    context.Response.Write("{\"msg\":\"上传失败！\",\"success\":false}");
                                }
                            }
                            catch (Exception e)
                            {
                                context.Response.Write("{\"msg\":\"" + e.Message + "\",\"success\":false}");
                            }
                        }
                        else
                        {
                            context.Response.Write("{\"msg\":\"文件不存在！\",\"success\":false}");
                        }
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

        public class ordcTrans
        {
            public int rownumber = 0;
            public string compid = "";
            public string factid = "";
            public string ordid = "";
            public string addid = "";
            public decimal addmoney = 0;
            public string memo = "";
            public string useing = "";
            public string updid = "";
            public DateTime updtime = DateTime.Now;
        }

        private T JsonDeserialize<T>(string jsonString)
        {
           DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
           MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
           T obj = (T)ser.ReadObject(ms);
           return obj;
        }

        private void ordhSaveFile(string path, string filename, HttpPostedFile file)
        {
            //if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            //{
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            //}
            //file.SaveAs(HttpContext.Current.Server.MapPath(path + "/" + filename));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            file.SaveAs(path + "/" + filename);
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