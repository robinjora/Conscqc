using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 合同强度（SQL Server数据库实现）
    /// </summary>
    public class Ordb : ZGZY.IDAL.IOrdb
    {
        /// <summary>
        /// 添加合同强度
        /// </summary>
        public int AddOrdb(Model.ordb ordb)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ordb(compid,factid,ordid,stgid,uniprice,updid,updtime)");
            strSql.Append(" values ");
            strSql.Append("(@compid,@factid,@ordid,@stgid,@uniprice,@updid,@updtime)");
            strSql.Append(";SELECT 1 from ordb where compid = @compid and factid = @factid and ordid = @ordid and stgid=@stgid");
            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",ordb.compid),
                                   new SqlParameter("@factid",ordb.factid),
                                   new SqlParameter("@ordid",ordb.ordid),
                                   new SqlParameter("@stgid",ordb.stgid),
                                   new SqlParameter("@uniprice",ordb.uniprice),
                                   new SqlParameter("@updid",ordb.updid),
                                   new SqlParameter("@updtime",ordb.updtime),
                                   };
            return Convert.ToInt32(ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras));
        }

        /// <summary>
        /// 修改合同强度
        /// </summary>
        public bool EditOrdb(Model.ordb ordb)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update ordb set ");
            strSql.Append(" uniprice = @uniprice, updid = @updid, updtime = @updtime ");
            strSql.Append(" where compid = @compid and factid = @factid and ordid = @ordid and stgid = @stgid ");

            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",ordb.compid),
                                   new SqlParameter("@factid",ordb.factid),
                                   new SqlParameter("@ordid",ordb.ordid),
                                   new SqlParameter("@stgid",ordb.stgid),
                                   new SqlParameter("@uniprice",ordb.uniprice),
                                   new SqlParameter("@updid",ordb.updid),
                                   new SqlParameter("@updtime",ordb.updtime)
                                   };
            object obj = ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
            if (Convert.ToInt32(obj) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除合同强度
        /// </summary>
        public bool DeleteOrdb(string compid, string factid, string ordid, string stgid)
        {
            string sqlstr = string.Format("delete from ordb where compid = '{0}' and factid = '{1}' and ordid = '{2}' and stgid = '{3}'", compid, factid, ordid, stgid);

            try
            {
                ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sqlstr.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
