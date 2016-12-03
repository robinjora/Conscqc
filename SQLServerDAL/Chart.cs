using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    public class Chart : ZGZY.IDAL.IChart
    {
        /// <summary>
        /// 获取半年内月份
        /// </summary>
        public DataTable GetChartMonth()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec [sp_webrsGetMonth]");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 获取企业
        /// </summary>
        public DataTable GetChartFact()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec [sp_webrsGetFact]");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// Chart1数据
        /// </summary>
        public DataTable GetChart1Data()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec [sp_webrsChart1]");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// Chart2数据
        /// </summary>
        public DataTable GetChart2Data()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec [sp_webrsChart2]");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// cqcp590408 企业数据
        /// </summary>
        public DataTable cqcp590408GetData(string factid, string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec sp_cqcp590408_web_new  '01','" + factid + "','1','" + userid + "'");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// cqcp590408 总数据
        /// </summary>
        public DataTable cqcp590408GetSum(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec sp_cqcp590408_web_sumqty_new  '01','ZZ','1','" + userid + "'");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }
    }
}
