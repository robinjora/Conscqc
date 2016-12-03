using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 合同（SQL Server数据库实现）
    /// </summary>
    public class Ordh : ZGZY.IDAL.IOrdh
    {
        /// <summary>
        /// 获取新增合同ID:ordid
        /// </summary>
        public string GetNewOrdid(string factid, string date)
        {
            string strSql;
            strSql = String.Format("select dbo.f_getNewOrdid('{0}','{1}')", factid, date);
            return (String)ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 根据ID获取合同
        /// </summary>
        public Model.ordh GetOrdhById(string compid, string factid, string ordid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            //strSql.Append(" isnull(ordh12,'') as ordh12, ");
            //strSql.Append(" isnull(maxqty,0) as maxqty ");
            strSql.Append(" from ordh where compid = @compid and factid = @factid and ordid = @ordid ");
            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",compid),
                                   new SqlParameter("@factid",factid),
                                   new SqlParameter("@ordid",ordid)
                                   };

            ZGZY.Model.ordh ordh = null;
            DataTable dt = ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
            if (dt.Rows.Count > 0)
            {
                ordh = new ZGZY.Model.ordh();
                DataRowToModel(ordh, dt.Rows[0]);
                return ordh;
            }
            else
                return null;
        }
    

        /// <summary>
        /// 添加合同
        /// </summary>
        public int AddOrdh(Model.ordh ordh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ordh(compid,factid,ordid,orddate,ordh12,maxqty,custid,empid,ordh33,updid,updtime)");
            strSql.Append(" values ");
            strSql.Append("(@compid,@factid,@ordid,@orddate,@ordh12,@maxqty,@custid,@empid,@ordh33,@updid,@updtime)");
            strSql.Append(";SELECT 1 from ordh where compid = @compid and factid = @factid and ordid = @ordid");
            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",ordh.compid),
                                   new SqlParameter("@factid",ordh.factid),
                                   new SqlParameter("@ordid",ordh.ordid),
                                   new SqlParameter("@orddate",ordh.orddate),
                                   new SqlParameter("@ordh12",ordh.ordh12),
                                   new SqlParameter("@maxqty",ordh.maxqty),
                                   new SqlParameter("@custid",ordh.custid),
                                   new SqlParameter("@empid",ordh.empid),
                                   new SqlParameter("@ordh33",ordh.ordh33),
                                   new SqlParameter("@updid",ordh.updid),
                                   new SqlParameter("@updtime",ordh.updtime)
                                   };
            return Convert.ToInt32(ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras));
        }

        /// <summary>
        /// 修改合同
        /// </summary>
        public bool EditOrdh(Model.ordh ordh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ordh set ");
            strSql.Append("ordh12 = @ordh12, maxqty = @maxqty, custid = @custid, empid = @empid, ordh33 = @ordh33,");
            strSql.Append(" updid = @updid, updtime = @updtime");
            strSql.Append(" where compid = @compid and factid = @factid and ordid = @ordid");

            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",ordh.compid),
                                   new SqlParameter("@factid",ordh.factid),
                                   new SqlParameter("@ordid",ordh.ordid),
                                   new SqlParameter("@ordh12",ordh.ordh12),
                                   new SqlParameter("@maxqty",ordh.maxqty),
                                   new SqlParameter("@custid",ordh.custid),
                                   new SqlParameter("@empid",ordh.empid),
                                   new SqlParameter("@ordh33",ordh.ordh33),
                                   new SqlParameter("@updid",ordh.updid),
                                   new SqlParameter("@updtime",ordh.updtime)
                                   };
            object obj = ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
            if (Convert.ToInt32(obj) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        public bool DeleteOrdh(string compid, string factid, string ordid)
        {
            List<string> list = new List<string>();
            list.Add(string.Format("delete from ordh where compid = '{0}' and factid = '{1}' and ordid = '{2}'", compid, factid, ordid));
            list.Add(string.Format("delete from ordb where compid = '{0}' and factid = '{1}' and ordid = '{2}'", compid, factid, ordid));
            list.Add(string.Format("delete from ordc where compid = '{0}' and factid = '{1}' and ordid = '{2}'", compid, factid, ordid));

            try
            {
                ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, list );
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 把DataRow行转成实体类对象
        /// </summary>
        private void DataRowToModel(ZGZY.Model.ordh model, DataRow dr)
        {
            if (!DBNull.Value.Equals(dr["compid"]))
                model.compid = dr["compid"].ToString();
            if (!DBNull.Value.Equals(dr["factid"]))
                model.factid = dr["factid"].ToString();
            if (!DBNull.Value.Equals(dr["ordid"]))
                model.ordid = dr["ordid"].ToString();
            if (!DBNull.Value.Equals(dr["orddate"]))
                model.orddate = dr["orddate"].ToString();
            if (!DBNull.Value.Equals(dr["ordh12"]))
                model.ordh12 = dr["ordh12"].ToString();
            if (!DBNull.Value.Equals(dr["maxqty"]))
                model.maxqty = decimal.Parse(dr["maxqty"].ToString());
            if (!DBNull.Value.Equals(dr["custid"]))
                model.custid = dr["custid"].ToString();
            if (!DBNull.Value.Equals(dr["empid"]))
                model.empid = dr["empid"].ToString();
            if (!DBNull.Value.Equals(dr["ordh33"]))
                model.ordh33 = dr["ordh33"].ToString();
        }
    }
}
