using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 合同加价（SQL Server数据库实现）
    /// </summary>
    public class Ordc : ZGZY.IDAL.IOrdc
    {
        /// <summary>
        /// 添加合同加价
        /// </summary>
        public int AddOrdc(Model.ordc ordc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ordc(compid,ordid,addid,addmoney,updid,updtime,memo,useing,factid)");
            strSql.Append(" values ");
            strSql.Append("(@compid,@ordid,@addid,@addmoney,@updid,@updtime,@memo,@useing,@factid)");
            strSql.Append(";SELECT 1 from ordc where compid = @compid and factid = @factid and ordid = @ordid and addid = @addid");
            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",ordc.compid),
                                   new SqlParameter("@factid",ordc.factid),
                                   new SqlParameter("@ordid",ordc.ordid),
                                   new SqlParameter("@addid",ordc.addid),
                                   new SqlParameter("@addmoney",ordc.addmoney),
                                   new SqlParameter("@memo",ordc.memo),
                                   new SqlParameter("@useing",ordc.useing),
                                   new SqlParameter("@updid",ordc.updid),
                                   new SqlParameter("@updtime",ordc.updtime)
                                   };
            return Convert.ToInt32(ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras));
        }

        /// <summary>
        /// 修改合同加价
        /// </summary>
        public bool EditOrdc(Model.ordc ordc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ordc set ");
            strSql.Append("addmoney = @addmoney,");
            strSql.Append("memo = @memo,");
            strSql.Append("useing = @useing,");
            strSql.Append("updid = @updid,");
            strSql.Append("updtime = @updtime");
            strSql.Append(" where compid = @compid and factid = @factid and ordid = @ordid and addid = @addid");

            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",ordc.compid),
                                   new SqlParameter("@factid",ordc.factid),
                                   new SqlParameter("@ordid",ordc.ordid),
                                   new SqlParameter("@addid",ordc.addid),
                                   new SqlParameter("@addmoney",ordc.addmoney),
                                   new SqlParameter("@memo",ordc.memo),
                                   new SqlParameter("@useing",ordc.useing),
                                   new SqlParameter("@updid",ordc.updid),
                                   new SqlParameter("@updtime",ordc.updtime)
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
        public bool DeleteOrdc(string compid, string factid, string ordid, string addid)
        {
            List<string> list = new List<string>();
            list.Add(string.Format("delete from ordc where compid = '{0}' and factid = '{1}' and ordid = '{2}' and addid = '{3}'", compid, factid, ordid, addid));

            try
            {
                ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, list);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
